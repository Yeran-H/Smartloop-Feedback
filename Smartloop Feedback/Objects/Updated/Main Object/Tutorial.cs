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
        public Tutorial(int id)
        {
            this.Id = id;
            LoadTutorialFromDatabase();
        }

        // Fetch assessments from the database and initialize the assessment list
        private void LoadTutorialFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT name, courseId FROM tutorial WHERE Id = @Id", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@Id", Id); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    if (reader.Read()) // Read each row
                    {
                        Name = reader.GetString(0); 
                        CourseId = reader.GetInt32(1); 
                    }
                }
            }
        }

        private void AddTutorialFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO tutorial (name, courseId) VALUES (@name, @courseId); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@courseId", CourseId);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Delete the assessment and related data from the database
        public void DeleteTutorialFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM tutorial
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
