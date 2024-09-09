using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Crypto.Paddings;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class YearAssociation
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public int Id { get; set; }
        public Year Year { get; set; }
        public int UserId { get; set; }
        public bool IsStudent { get; set; }

        public YearAssociation(int id, int yearName, int userId, bool isStudent)
        {
            this.Id = id;
            this.UserId = userId;
            this.IsStudent = isStudent;
            Year = new Year(yearName);
        }

        public YearAssociation(int yearName, int userId, bool isStudent)
        {
            this.UserId = userId;
            this.IsStudent = isStudent;
            Year = new Year(yearName);
            AddYearToDatabase();
        }

        // Add the year to the database and get the generated ID
        private void AddYearToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO yearAssociation (name, userId, isStudent) VALUES (@name, @userId, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Year.Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter
                    cmd.Parameters.AddWithValue("@isStudent", IsStudent);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }
    }
}
