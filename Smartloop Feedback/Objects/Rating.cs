using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects
{
    public class Rating
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for rating details
        public int id { get; set; }
        public string description { get; set; }
        public string grade { get; set; }
        public int criteriaId { get; set; }
        public int studentId { get; set; }

        // Constructor to initialize a Rating object
        public Rating(int id, string description, string grade, int criteriaId, int studentId)
        {
            this.id = id;
            this.description = description;
            this.grade = grade;
            this.criteriaId = criteriaId;
            this.studentId = studentId;
        }

        // Constructor to initialize a Rating object and add it to the database
        public Rating(string description, string grade, int criteriaId, int studentId)
        {
            this.description = description;
            this.grade = grade;
            this.criteriaId = criteriaId;
            this.studentId = studentId;
            AddRatingToDatabase(); // Add the rating to the database
        }

        // Constructor to initialize a Rating object without interacting with the database
        public Rating(string description, string grade)
        {
            this.description = description;
            this.grade = grade;
        }

        // Add the rating to the database and get the generated ID
        public void AddRatingToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO rating (description, grade, criteriaId, studentId) VALUES (@description, @grade, @criteriaId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert rating and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@description", description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@grade", grade); // Set the grade parameter
                    cmd.Parameters.AddWithValue("@criteriaId", criteriaId); // Set the criteriaId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        public void DeleteRatingFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM rating
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for studentId
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
