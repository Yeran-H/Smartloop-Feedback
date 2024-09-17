using Google.Protobuf.WellKnownTypes;
using OpenAI_API.Chat;
using OpenAI_API;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects.User_Object.Tutor
{
    public class TutorialAssociation : Tutorial
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;
        public Dictionary<int, StudentCourse> StudentList { get; set; }
        public string GeneralFeedback {  get; set; }
        public bool IsCompleted { get; set; }
        public Dictionary<int, TutorialAssessment> AssessmentList { get; set; }

        public TutorialAssociation(int id)
            :base(id) 
        {
            StudentList = new Dictionary<int, StudentCourse>();
            AssessmentList = new Dictionary<int, TutorialAssessment>();
            LoadTutorialAssociationFromDatabase();
            LoadStudentCourse();
            LoadTutorialAssessmentFromDatabase();
        }

        public TutorialAssociation(int id, bool x)
            : base(id)
        {
            GeneralFeedback = "";
            IsCompleted = false;
            StudentList = new Dictionary<int, StudentCourse>();
            AssessmentList = new Dictionary<int, TutorialAssessment>();
            AddTutorialAssociationToDatabase();
            LoadStudentCourse();
            AddTutorialAssessment();
        }

        private void AddTutorialAssociationToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO tutorialAssociation (tutorialId, generalFeedback, isCompleted) VALUES (@tutorialId, @generalFeedback, @isCompleted);"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@tutorialId", Id); 
                    cmd.Parameters.AddWithValue("@generalFeedback", GeneralFeedback);
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted);
                }
            }
        }

        private void LoadTutorialAssociationFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT generalFeedback, isCompleted FROM tutorialAssociation WHERE tutorialId = @Id", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@Id", Id); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    if (reader.Read()) // Read each row
                    {
                        GeneralFeedback = reader.GetString(0);
                        IsCompleted = reader.GetBoolean(1);
                    }
                }
            }
        }

        private void LoadStudentCourse()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT ca.id, ca.courseId, ca.studentId, ca.semesterId, ca.isStudent FROM courseAssociation ca JOIN studentCourse sc ON ca.id = sc.courseAssociationId WHERE ca.courseId = @courseId AND sc.tutorialId = @tutorialId", conn); // Updated SQL query to fetch assessments

                cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter
                cmd.Parameters.AddWithValue("@tutorialId", Id); // Set the tutorialId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        StudentList.Add(reader.GetInt32(0), new StudentCourse(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetBoolean(4)));
                    }
                }
            }
        }

        private void AddTutorialAssessment()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id FROM assessment WHERE courseId = @courseId", conn); // Updated SQL query to fetch assessments

                cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        AssessmentList.Add(reader.GetInt32(0), new TutorialAssessment(reader.GetInt32(0), Id));
                    }
                }
            }
        }

        private void LoadTutorialAssessmentFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, assessmentID, isCompleted, general, FROM tutorialAssessment WHERE tutorialId = @tutorialId", conn); // Updated SQL query to fetch assessments

                cmd.Parameters.AddWithValue("@tutorialId", Id); // Set the tutorialId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        var temp = new TutorialAssessment(reader.GetInt32(0), reader.GetInt32(1), reader.GetBoolean(2), reader.GetString(3), Id);
                        AssessmentList.Add(temp.Id, temp);
                    }
                }
            }
        }

        public void GetGeneralFeedback()
        {
            int count = 0;

            foreach(TutorialAssessment tutorialAssessment in AssessmentList.Values)
            {
                if(tutorialAssessment.IsCompleted)
                {
                    count++;
                }
            }

            if(count == AssessmentList.Count && GeneralFeedback == "")
            {
                GenerateFinalFeedback();
                IsCompleted = true;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string updateQuery = @"
                    UPDATE tutorialAssociation
                    SET 
                        isCompleted = @isCompleted
                        generalFeedback = @generalFeedback
                    WHERE
                        id = @id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        // Add parameters with values
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@isCompleted", IsCompleted);
                        cmd.Parameters.AddWithValue("@generalFeedback", GeneralFeedback ?? (object)DBNull.Value);

                        // Execute the update command
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private async void GenerateFinalFeedback()
        {
            api = new OpenAIAPI(apiKey);
            var conversation = api.Chat.CreateConversation();

            // Append system message
            conversation.AppendMessage(ChatMessageRole.System, "You are an intelligent and empathetic educational assistant. Your goal is to analyze all of the general feedback from the assessment task and provide general feedback and improvement for that tutorial class.");

            // Append user messages
            conversation.AppendMessage(ChatMessageRole.User, $"Please provide a general summary for the tutor based on the general feedback from assessment task for the tutorial class, highlighting areas of improvement and areas that still need attention.");

            // Loop through previous feedback and append to conversation
            conversation.AppendMessage(ChatMessageRole.User, "Here are the general assessment feedback:");

            foreach (TutorialAssessment tutorialAssessment in AssessmentList.Values)
            {
                conversation.AppendMessage(ChatMessageRole.User, tutorialAssessment.General);
            }

            // Request a general progress summary from the AI
            conversation.AppendMessage(ChatMessageRole.User, "Based on the provided general assessment feedbacks, please provide a general summary of the tutorial progress, including specific improvements made and areas that still require attention. Include actionable suggestions for further improvement.");

            // Get the response from the AI
            GeneralFeedback = await conversation.GetResponseFromChatbotAsync();
        }
    }
}
