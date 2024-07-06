using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class Criteria
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for criteria details
        public int id { get; set; }
        public string description { get; set; }
        public int assessmentId { get; set; }
        public Dictionary<int, Rating> ratingList { get; set; } // List of ratings for the criteria
        public int studentId { get; set; }

        // Constructor to initialize a Criteria object and fetch ratings from the database
        public Criteria(int id, string description, int assessmentId, int studentId)
        {
            this.id = id;
            this.description = description;
            this.assessmentId = assessmentId;
            this.studentId = studentId;
            ratingList = new Dictionary<int, Rating>(); // Initialize the rating list
            GetRatingFromDatabase(); // Fetch ratings from the database
        }

        // Constructor to initialize a Criteria object and add it to the database
        public Criteria(string description, int assessmentId, int studentId)
        {
            this.description = description;
            this.assessmentId = assessmentId;
            this.studentId = studentId;
            ratingList = new Dictionary<int, Rating>(); // Initialize the rating list
            AddCriteriaToDatabase(); // Add the criteria to the database
        }

        // Constructor to initialize a Criteria object without interacting with the database
        public Criteria(string description)
        {
            this.description = description;
            ratingList = new Dictionary<int, Rating>(); // Initialize the rating list
        }

        // Add the criteria to the database and get the generated ID
        public void AddCriteriaToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO criteria (description, assessmentId, studentId) VALUES (@description, @assessmentId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert criteria and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@description", description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@assessmentId", assessmentId); // Set the assessmentId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch ratings from the database and initialize the rating list
        private void GetRatingFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, description, grade FROM rating WHERE criteriaId = @criteriaId AND studentId = @studentId", conn); // SQL query to fetch ratings
                cmd.Parameters.AddWithValue("@criteriaId", id); // Set the criteriaId parameter
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int ratingId = reader.GetInt32(0); // Get the rating ID
                        string ratingDescription = reader.GetString(1); // Get the rating description
                        string grade = reader.GetString(2); // Get the rating grade
                        ratingList.Add(ratingId, new Rating(ratingId, ratingDescription, grade, this.id, studentId)); // Add the rating to the rating list
                    }
                }
            }
        }
    }
}
