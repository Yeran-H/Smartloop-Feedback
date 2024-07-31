using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace Smartloop_Feedback.Objects
{
    public  class CheckList
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public int id {  get; set; }
        public string name { get; set; }
        public bool isChecked { get; set; }
        public int studentId { get; set; }
        public int assessmentId { get; set; }
        public CheckList(int id, string name, bool isChecked, int studentId, int assessmentId)
        {
            this.id = id;
            this.name= name;
            this.isChecked = isChecked;
            this.studentId= studentId;
            this.assessmentId= assessmentId;
        }

        public CheckList(string name, int studentId, bool isChecked,int assessmentId)
        {
            this.name = name;
            this.isChecked = isChecked;
            this.studentId = studentId;
            this.assessmentId = assessmentId;
            AddToDatabase();
        }

        public void AddToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO checkList (name, isChecked, assessmentId, studentId) VALUES (@name, @isChecked, @assessmentId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert rating and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@isChecked", isChecked);
                    cmd.Parameters.AddWithValue("@assessmentId", assessmentId); // Set the assessmentId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        public void UpdateChecked(bool isChecked)
        {
            this.isChecked = isChecked;
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
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@isChecked", this.isChecked);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

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
                    // Add the parameter for studentId
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
