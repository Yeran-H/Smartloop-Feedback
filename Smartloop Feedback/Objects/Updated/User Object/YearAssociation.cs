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
    public class YearAssociation : Year
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsStudent { get; set; }
        public SortedDictionary<string, SemesterAssociation> SemesterList { get; set; }

        public YearAssociation(int id, int yearName, int userId, bool isStudent)
            : base(yearName)
        {
            this.Id = id;
            this.UserId = userId;
            this.IsStudent = isStudent;

            SemesterList = new SortedDictionary<string, SemesterAssociation>();
            LoadSemestersFromDatabase();
        }

        public YearAssociation(int yearName, int userId, bool isStudent, List<string> semesterNames)
            : base(yearName)
        {
            this.UserId = userId;
            this.IsStudent = isStudent;
            AddYearAssociationToDatabase();

            SemesterList = new SortedDictionary<string, SemesterAssociation>();
            AddSemestersAssociationToDatabase(semesterNames);
        }

        // Add the year to the database and get the generated ID
        private void AddYearAssociationToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO yearAssociation (name, userId, isStudent) VALUES (@name, @userId, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter
                    cmd.Parameters.AddWithValue("@isStudent", IsStudent);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Update the year name in the database
        public void UpdateYearInDatabase(int yearName)
        {
            Name = yearName; // Update the year name

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "UPDATE yearAssociation SET name = @name WHERE id = @id"; // SQL query to update year name

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@id", Id); // Set the id parameter
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.ExecuteNonQuery(); // Execute the update command
                }
            }
        }

        // Add the semesters to the database and initialize the semester list
        private void AddSemestersAssociationToDatabase(List<string> semesterNames)
        {
            foreach (string semesterName in semesterNames) // Loop through each semester name
            {
                SemesterList.Add(semesterName, new SemesterAssociation(semesterName, Id, Name, UserId, IsStudent)); // Add the semester to the semester list
            }
        }

        // Fetch semesters from the database and initialize the semester list
        private void LoadSemestersFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, name FROM semesterAssociation WHERE yearId = @yearId AND userId = @userId"; // SQL query to fetch semesters
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@yearId", Id); // Set the yearId parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int semesterId = reader.GetInt32(0); // Get the semester ID
                            string name = reader.GetString(1); // Get the semester name
                            SemesterList.Add(name, new SemesterAssociation(semesterId, name, Id, Name, UserId, IsStudent)); // Add the semester to the semester list
                        }
                    }
                }
            }
        }

        // Delete a semester from the database
        public void DeleteSemesterFromDatabase(string semesterName)
        {
            if (SemesterList.ContainsKey(semesterName)) // Check if the semester exists
            {
                SemesterList[semesterName].DeleteSemesterFromDatabase(); // Delete the semester from the database
                SemesterList.Remove(semesterName); // Remove the semester from the list
            }
        }

        // Delete the year and all its semesters from the database
        public void DeleteYearFromDatabase()
        {
            foreach (SemesterAssociation semester in SemesterList.Values) // Loop through each semester
            {
                semester.DeleteSemesterFromDatabase(); // Delete the semester from the database
            }

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "DELETE FROM yearAssociation WHERE id = @id"; // SQL query to delete the year

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@id", Id); // Set the id parameter
                    cmd.ExecuteNonQuery(); // Execute the delete command
                }
            }
        }
    }
}
