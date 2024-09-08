using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class StudentCriteria
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for criteria details
        public int Id { get; private set; } // Criteria ID
        public string Description { get; set; } // Criteria description
        public int AssessmentId { get; set; } // ID of the assessment associated with the criteria
        public List<StudentRating> RatingList { get; private set; } // List of ratings for the criteria
        public int StudentId { get; set; } // ID of the student associated with the criteria

        // Constructor to initialize a Criteria object and fetch ratings from the database
        public StudentCriteria(int id, string description, int assessmentId, int studentId)
        {
            Id = id;
            Description = description;
            AssessmentId = assessmentId;
            StudentId = studentId;
            RatingList = new List<StudentRating>(); // Initialize the rating list
            LoadRatingsFromDatabase(); // Fetch ratings from the database
        }

        // Constructor to initialize a Criteria object and add it to the database
        public StudentCriteria(string description, int assessmentId, int studentId)
        {
            Description = description;
            AssessmentId = assessmentId;
            StudentId = studentId;
            RatingList = new List<StudentRating>(); // Initialize the rating list
            AddCriteriaToDatabase(); // Add the criteria to the database
        }

        // Add the criteria to the database and get the generated ID
        private void AddCriteriaToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO criteria (description, assessmentId, studentId) VALUES (@description, @assessmentId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert criteria and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@assessmentId", AssessmentId); // Set the assessmentId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch ratings from the database and initialize the rating list
        private void LoadRatingsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, description, grade FROM rating WHERE criteriaId = @criteriaId AND studentId = @studentId"; // SQL query to fetch ratings

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@criteriaId", Id); // Set the criteriaId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int ratingId = reader.GetInt32(0); // Get the rating ID
                            string ratingDescription = reader.GetString(1); // Get the rating description
                            string grade = reader.GetString(2); // Get the rating grade
                            RatingList.Add(new StudentRating(ratingId, ratingDescription, grade, Id, StudentId)); // Add the rating to the rating list
                        }
                    }
                }
            }
        }

        // Delete the criteria and related ratings from the database
        public void DeleteCriteriaFromDatabase()
        {
            // Delete all ratings associated with the criteria
            foreach (StudentRating rating in RatingList)
            {
                rating.DeleteRatingFromDatabase();
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM criteria
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for criteria ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
