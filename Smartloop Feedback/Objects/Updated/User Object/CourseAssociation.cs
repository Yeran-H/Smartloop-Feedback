using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Asn1.X509;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class CourseAssociation : Course
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SemesterId { get; set; }
        public bool IsStudent { get; set; }

        public CourseAssociation (int id, int courseId, int userId, int semesterId, bool isStudent)
            :base(courseId)
        {
            this.Id = id;
            this.UserId = userId;
            this.SemesterId = semesterId;
            this.IsStudent = isStudent;
        }

        public CourseAssociation(int courseId, int userId, int semesterId, bool isStudent)
            :base(courseId)
        {
            this.UserId = userId;
            this.SemesterId = semesterId;
            this.IsStudent = isStudent;
            AddCourseToDatabase();
        }

        // Add the course to the database and get the generated ID
        private void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO courseAssociation (courseId, userId, semesterId, isStudent) VALUES (@courseId, @userId, @semesterId, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the code parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the title parameter
                    cmd.Parameters.AddWithValue("@semesterId", SemesterId); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@isStudent", IsStudent); // Set the description parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }
    }
}
