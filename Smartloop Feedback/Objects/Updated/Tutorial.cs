using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects.Updated
{
    public class Tutorial
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public Tutorial(int id, string name, int courseId) 
        { 
            this.Id = id;
            this.Name = name;
            this.CourseId = courseId;
        }
        public Tutorial(string name, int courseId)
        {
            this.Name = name;
            this.CourseId = courseId;
            AddTutorialFromDatabase();
        }

        private void AddTutorialFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO course (name, courseId) VALUES (@name, @courseId); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@courseId", CourseId);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }
    }
}
