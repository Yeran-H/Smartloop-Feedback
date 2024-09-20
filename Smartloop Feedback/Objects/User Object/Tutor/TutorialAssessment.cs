using OpenAI_API;
using OpenAI_API.Chat;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Smartloop_Feedback.Objects.User_Object.Tutor
{
    public class TutorialAssessment : Assessment
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;

        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public string General {  get; set; }
        public int TutorialId { get; set; }
        public TutorialAssessment(int id, int assessmentID, bool isCompleted, string general, int tutorialId)
            :base(assessmentID)
        {
            this.Id = id;
            this.General = general; 
            this.IsCompleted = isCompleted;
            this.TutorialId = tutorialId;
        }

        public TutorialAssessment(int assessmentID, int tutorialId)
            : base(assessmentID)
        {
            this.General = "";
            this.IsCompleted = false;
            AddTutorialAssessmentIntoDatabase();
        }

        private void AddTutorialAssessmentIntoDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO tutorialAssessment (isCompleted, general, tutorialId, assessmentId) VALUES (@isCompleted, @general, @tutorialId, @assessmentId);"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted);
                    cmd.Parameters.AddWithValue("@general", General);
                    cmd.Parameters.AddWithValue("@tutorialId", TutorialId);
                    cmd.Parameters.AddWithValue("@assessmentId", AssessmentId);
                }
            }
        }

        public void UpdateAssessmentToDatabase(bool isFinalised)
        {
            if (isFinalised && General == "")
            {
                GenerateFinalFeedback();
            }

            IsCompleted = isFinalised;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE tutorialAssessment
                    SET 
                        isCompleted = @isCompleted,
                        general = @general
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted);
                    cmd.Parameters.AddWithValue("@general", General ?? (object)DBNull.Value);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private async void GenerateFinalFeedback()
        {
            api = new OpenAIAPI(apiKey);
            var conversation = api.Chat.CreateConversation();

            // Append system message
            conversation.AppendMessage(ChatMessageRole.System, "You are an intelligent and empathetic educational assistant. Your goal is to analyze students general feedback from the assessment task. Then take all those feedback summarise and then provide feedback to the tutor to help them know what they did well and what to improve on.");

            // Append user messages
            conversation.AppendMessage(ChatMessageRole.User, $"Please provide a general summary for the tutor based on the student's final feedback on the assessment task, highlighting areas of improvement and areas that still need attention.");

            // Loop through previous feedback and append to conversation
            conversation.AppendMessage(ChatMessageRole.User, "Here are the students final feedback:");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand(" SELECT sa.feedback FROM studentAssessment sa INNER JOIN studentCourse sc ON sa.userId = sc.userId WHERE sa.assessmentId = @assessmentId AND sc.tutorialId = @tutorialId", conn);

                cmd.Parameters.AddWithValue("@assessmentId", AssessmentId);
                cmd.Parameters.AddWithValue("@tutorialId", TutorialId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        conversation.AppendMessage(ChatMessageRole.User, reader.GetString(0));
                    }
                }
            }

            // Request a general progress summary from the AI
            conversation.AppendMessage(ChatMessageRole.User, "Based on the provided previous feedbacks, please provide a general summary of the student's progress within assessment task, including specific improvements made and areas that still require attention. Include actionable suggestions for further improvement.");

            // Get the response from the AI
            General = await conversation.GetResponseFromChatbotAsync();
        }
    }
}
