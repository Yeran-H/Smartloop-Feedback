using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;

namespace Smartloop_Feedback.Objects.Updated.User_Object.Student
{
    public class StudentAssessment : Assessment
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;

        public int Id { get; set; }
        public int Status { get; set; }
        public double StudentMark {  get; set; }
        public bool IsFinalised { get; set; }
        public string Feedback {  get; set; }
        public int StudentCourseId { get; set; }
        public int UserId { get; set; }
        public List<CheckList> CheckList { get; set; }
        public SortedDictionary<int, FeedbackResult> FeedbackList { get; set; }
        public List<Tuple<string, string>> PastAssessment { get; set; }

        public StudentAssessment(int id, int assessmentId, int status, double mark, bool isFinalised, string feedback, int courseId, int userId)
            : base(assessmentId)
        {
            this.Id = id;
            this.Status = status;
            this.StudentMark = mark;
            this.IsFinalised = isFinalised;
            this.Feedback = feedback;
            this.StudentCourseId = courseId;
            this.UserId = userId;
            CheckList = new List<CheckList>();
            FeedbackList = new SortedDictionary<int, FeedbackResult>();
            LoadCheckListFromDatabase();
            LoadFeedbackListFromDatabase();
        }

        public StudentAssessment(int assessmentId, int courseId, int userId)
            : base(assessmentId)
        {
            this.Status = 0;
            this.StudentMark = 0.0;
            this.IsFinalised = false;
            this.Feedback = "";
            this.StudentCourseId = courseId;
            this.UserId = userId;
            CheckList = new List<CheckList>();
            FeedbackList = new SortedDictionary<int, FeedbackResult>();
            AddAssessmentToDatabase();
        }

        // Add the assessment to the database and get the generated ID
        private void AddAssessmentToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO studentAssessment (assessmentId, status, studentMark, isFinalised, feedback, courseId, userId) VALUES (@assessmentId, @status, @studentMark, @isFinalised, @feedback, @courseId, @userId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@assessmentId", AssessmentId);
                    cmd.Parameters.AddWithValue("@status", Status);
                    cmd.Parameters.AddWithValue("@studentMark", StudentMark);
                    cmd.Parameters.AddWithValue("@isFinalised", IsFinalised);
                    cmd.Parameters.AddWithValue("@feedback", Feedback);
                    cmd.Parameters.AddWithValue("@courseId", StudentCourseId);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch checklist items from the database and initialize the checklist
        private void LoadCheckListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name, isChecked FROM checkList WHERE assessmentId = @assessmentId AND userId = @userId", conn); // SQL query to fetch checklist items
                cmd.Parameters.AddWithValue("@assessmentId", Id); // Set the assessmentId parameter
                cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int checkListId = reader.GetInt32(0); // Get the checklist item ID
                        string checkListName = reader.GetString(1); // Get the checklist item name
                        bool isChecked = reader.GetBoolean(2); // Get the checklist item status
                        CheckList.Add(new CheckList(checkListId, checkListName, isChecked, UserId, Id)); // Add the checklist item to the checklist
                    }
                }
            }

            CalculateStatus(); // Calculate the status of the assessment based on checklist items
        }

        // Calculate the status of the assessment based on checklist items
        public void CalculateStatus()
        {
            if (CheckList.Count != 0)
            {
                int count = CheckList.Count(item => item.IsChecked);
                Status = (int)((count / (double)CheckList.Count) * 100);
            }
            else
            {
                Status = 0;
            }
        }

        private void LoadFeedbackListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, attempt, teacherFeedback, fileName, fileData, notes, feedback, previousAttemptId, previousAssessmentId FROM feedbackResult WHERE assessmentId = @assessmentId AND userId = @userId", conn);

                cmd.Parameters.AddWithValue("@assessmentId", Id);
                cmd.Parameters.AddWithValue("@userId", UserId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int feedbackId = reader.GetInt32(0);
                        int attempt = reader.GetInt32(1);
                        string teacherFeedback = reader.IsDBNull(2) ? null : reader.GetString(2);
                        string fileName = reader.GetString(3);
                        byte[] fileData = (byte[])reader["fileData"];
                        string notes = reader.IsDBNull(5) ? null : reader.GetString(5);
                        string feedbackText = reader.GetString(6);
                        string previousAttemptId = reader.IsDBNull(7) ? null : reader.GetString(7);
                        string previousAssessmentId = reader.IsDBNull(8) ? null : reader.GetString(8);

                        int[] intArray;

                        if (!string.IsNullOrEmpty(previousAttemptId))
                        {
                            intArray = previousAttemptId
                                .Split(',')
                                .Where(s => !string.IsNullOrWhiteSpace(s))
                                .Select(int.Parse)
                                .ToArray();
                        }
                        else
                        {
                            intArray = new int[0];
                        }

                        string[] stringArray;

                        if (!string.IsNullOrEmpty(previousAssessmentId))
                        {
                            stringArray = previousAssessmentId
                                .Split(',')
                                .Where(s => !string.IsNullOrWhiteSpace(s))
                                .ToArray();
                        }
                        else
                        {
                            stringArray = new string[0];
                        }



                        FeedbackList.Add(attempt, new FeedbackResult(feedbackId, attempt, teacherFeedback, fileName, fileData, notes, feedbackText, intArray, stringArray, UserId, Id));
                    }
                }
            }
        }

        public void GeneratePastAssessment()
        {
            PastAssessment = new List<Tuple<string, string>>();

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection

                // Updated SQL query with a JOIN to get the 'name' from the 'assessment' table
                SqlCommand cmd = new SqlCommand(
                    "SELECT a.name, sa.feedback, sa.isFinalised " +
                    "FROM studentAssessment sa " +
                    "INNER JOIN assessment a ON sa.assessmentId = a.id " +
                    "WHERE sa.userId = @userId AND sa.courseId = @courseId AND sa.isFinalised = 1",
                    conn);

                cmd.Parameters.AddWithValue("@courseId", CourseId);
                cmd.Parameters.AddWithValue("@userId", UserId);

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        string name = reader.GetString(0); // 'name' from 'assessment' table
                        string finalFeedback = reader.IsDBNull(1) ? null : reader.GetString(1); // 'feedback' from 'studentAssessment' table
                        PastAssessment.Add(Tuple.Create(name, finalFeedback)); // Add the pair to the list
                    }
                }
            }
        }


        public void UpdateAssessmentToDatabase(bool isFinalised)
        {
            if (isFinalised && Feedback == "")
            {
                GenerateFinalFeedback();
            }

            IsFinalised = isFinalised;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE studentAssessment
                    SET 
                        StudentMark = @studentMark,
                        isFinalised = @isFinalised,
                        feedback = @feedback
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@studentMark", StudentMark);
                    cmd.Parameters.AddWithValue("@isFinalised", isFinalised);
                    cmd.Parameters.AddWithValue("@feedback", Feedback ?? (object)DBNull.Value);

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
            conversation.AppendMessage(ChatMessageRole.System, "You are an intelligent and empathetic educational assistant. Your goal is to analyze the improvements the student has made across multiple attempts and provide a summary of their progress, along with suggestions for further improvement.");

            // Append user messages
            conversation.AppendMessage(ChatMessageRole.User, $"Please provide a general summary of the student's progress based on their previous feedback, highlighting areas of improvement and areas that still need attention.");

            // Loop through previous feedback and append to conversation
            if (FeedbackList.Count > 0)
            {
                conversation.AppendMessage(ChatMessageRole.User, "Here are the previous attemps:");
                foreach (FeedbackResult feedbackResult in FeedbackList.Values)
                {
                    conversation.AppendMessage(ChatMessageRole.User, feedbackResult.Feedback);
                }
            }

            // Request a general progress summary from the AI
            conversation.AppendMessage(ChatMessageRole.User, "Based on the provided previous feedbacks, please provide a general summary of the student's progress, including specific improvements made and areas that still require attention. Include actionable suggestions for further improvement.");

            // Get the response from the AI
            Feedback = await conversation.GetResponseFromChatbotAsync();
        }

        // Delete the assessment and related data from the database
        public void DeleteStudentAssessmentFromDatabase()
        {
            foreach (CheckList checkList in CheckList)
            {
                checkList.DeleteCheckListFromDatabase();
            }

            foreach (FeedbackResult feedbackResult in FeedbackList.Values)
            {
                feedbackResult.DeleteFeedbackFromDatabase();
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM studentAssessment
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for assessment ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
