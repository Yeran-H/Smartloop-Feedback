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
    }
}
