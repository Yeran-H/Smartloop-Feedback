using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects
{
    public class CheckList
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for checklist details
        public int Id { get; private set; } // Checklist ID
        public string Name { get; set; } // Checklist name
        public bool IsChecked { get; set; } // Checklist status
        public int StudentId { get; set; } // ID of the student associated with the checklist
        public int AssessmentId { get; set; } // ID of the assessment associated with the checklist

        // Constructor to initialize a CheckList object
        public CheckList(int id, string name, bool isChecked, int studentId, int assessmentId)
        {
            Id = id;
            Name = name;
            IsChecked = isChecked;
            StudentId = studentId;
            AssessmentId = assessmentId;
        }

        // Constructor to initialize a CheckList object and add it to the database
        public CheckList(string name, int studentId, bool isChecked, int assessmentId)
        {
            Name = name;
            IsChecked = isChecked;
            StudentId = studentId;
            AssessmentId = assessmentId;
            AddToDatabase(); // Add the checklist to the database
        }

        // Add the checklist to the database and get the generated ID
        private void AddToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO checkList (name, isChecked, assessmentId, studentId) VALUES (@name, @isChecked, @assessmentId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert checklist and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@isChecked", IsChecked); // Set the isChecked parameter
                    cmd.Parameters.AddWithValue("@assessmentId", AssessmentId); // Set the assessmentId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Update the checklist status in the database
        public void UpdateChecked(bool isChecked)
        {
            IsChecked = isChecked;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE checkList
                    SET 
                        isChecked = @isChecked
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@isChecked", IsChecked);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete the checklist from the database
        public void DeleteCheckListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM checkList
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for checklist ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
