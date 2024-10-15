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
        public int SemesterId { get; set; }
        public string Name { get; set; }
        public Year Year { get; set; }

        public Semester(int id, string name, int yearName)
        {
            SemesterId = id;
            Name = name;
            Year = new Year(yearName);
        }

        public Semester(string name, int yearName)
        {
            Name = name;
            Year = new Year(yearName);
            AddSemesterToDatabase();
        }

        public Semester(int semesterId)
        {
            AddSemesterToDatabase(semesterId);
        }

        private void AddSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection

                // Check if the semester with the given name and yearId exists
                SqlCommand checkCmd = new SqlCommand("SELECT TOP 1 id FROM semester WHERE name = @name AND yearName = @yearName", conn);
                checkCmd.Parameters.AddWithValue("@name", Name); // Set the semester name parameter
                checkCmd.Parameters.AddWithValue("@yearName", Year.Name); // Set the yearId parameter

                using (SqlDataReader reader = checkCmd.ExecuteReader()) // Execute the query and get a reader
                {
                    if (reader.Read()) // Check if a row is returned
                    {
                        // Semester exists, retrieve its details
                        SemesterId = reader.GetInt32(0);
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        string sql = "INSERT INTO semester (name, yearName) VALUES (@name, @yearName); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                        using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                        {
                            cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                            cmd.Parameters.AddWithValue("@yearName", Year.Name);
                            SemesterId = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                        }
                    }
                }
            }
        }

        private void AddSemesterToDatabase(int semesterId)
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection

                // Check if the semester with the given name and yearId exists
                SqlCommand checkCmd = new SqlCommand("SELECT TOP 1 name, yearName FROM semester WHERE id = @id", conn);
                checkCmd.Parameters.AddWithValue("@id", semesterId); 

                using (SqlDataReader reader = checkCmd.ExecuteReader()) // Execute the query and get a reader
                {
                    if (reader.Read()) // Check if a row is returned
                    {
                        // Semester exists, retrieve its details
                        SemesterId = semesterId;
                        Name = reader.GetString(0);
                        Year = new Year(reader.GetInt32(1));

                    }
                }
            }
        }
    }
}
