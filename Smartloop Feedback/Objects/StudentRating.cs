using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects
{
    public class StudentRating
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for rating details
        public int Id { get; private set; } // Rating ID
        public string Description { get; set; } // Description of the rating
        public string Grade { get; set; } // Grade of the rating
        public int CriteriaId { get; set; } // ID of the criteria associated with the rating
        public int StudentId { get; set; } // ID of the student associated with the rating

        // Constructor to initialize a Rating object
        public StudentRating(int id, string description, string grade, int criteriaId, int studentId)
        {
            Id = id;
            Description = description;
            Grade = grade;
            CriteriaId = criteriaId;
            StudentId = studentId;
        }

        // Constructor to initialize a Rating object and add it to the database
        public StudentRating(string description, string grade, int criteriaId, int studentId)
        {
            Description = description;
            Grade = grade;
            CriteriaId = criteriaId;
            StudentId = studentId;
            AddRatingToDatabase(); // Add the rating to the database
        }

        // Add the rating to the database and get the generated ID
        private void AddRatingToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO rating (description, grade, criteriaId, studentId) VALUES (@description, @grade, @criteriaId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert rating and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@grade", Grade); // Set the grade parameter
                    cmd.Parameters.AddWithValue("@criteriaId", CriteriaId); // Set the criteriaId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Delete the rating from the database
        public void DeleteRatingFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection

                string deleteQuery = @"
                    DELETE FROM rating
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn)) // Create a command
                {
                    // Add the parameter for rating ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
