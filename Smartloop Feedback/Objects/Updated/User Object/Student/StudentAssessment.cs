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
            LoadCheckListFromDatabase();
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
    }
}
