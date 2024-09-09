using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects.Updated
{
    public class Year
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for year details
        public int Id { get; set; }
        public int Name { get; set; } // Name of the year

        public Year(int id, int name)
        {
            Id = id;
            Name = name;
        }

        public Year(int name)
        {
            Name = name;
            AddYearToDatabase();
        }

        private void AddYearToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection

                // Check if the year with the given name exists
                SqlCommand checkCmd = new SqlCommand("SELECT TOP 1 id FROM year WHERE name = @name", conn);
                checkCmd.Parameters.AddWithValue("@name", Name); // Set the year parameter

                using (SqlDataReader reader = checkCmd.ExecuteReader()) // Execute the query and get a reader
                {
                    if (reader.Read()) // Check if a row is returned
                    {
                        // Year exists, retrieve its details
                        Id = reader.GetInt32(0);
                    }
                    else
                    {
                        string sql = "INSERT INTO year (name) VALUES (@name); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                        using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                        {
                            cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                            Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                        }
                    }
                }
            }
        }
    }
}
