using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;


namespace Smartloop_Feedback.Objects.Updated
{
    public class Semester
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearId { get; set; }

        public Semester(int id, string name, int yearId)
        {
            Id = id;
            Name = name;
            YearId = yearId;
        }

        public Semester(string name, int yearId)
        {
            Name = name;
            YearId = yearId;
            AddSemesterToDatabase();
        }

        private void AddSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO semester (name, yearId) VALUES (@name, @yearId); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@yearId", YearId);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }
    }
}
