using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback
{
    public class StudentYear
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for year details
        public int Name { get; set; } // Name of the year
        public int StudentId { get; } // Student ID associated with the year
        public int Id { get; set; } // Year ID
        public SortedDictionary<string, StudentSemester> SemesterList { get; set; } // List of semesters in the year

        // Constructor to initialize a Year object and fetch semesters from the database
        public StudentYear(int name, int studentId, int id)
        {
            Name = name;
            StudentId = studentId;
            Id = id;
            SemesterList = new SortedDictionary<string, StudentSemester>(); // Initialize the semester list
            LoadSemestersFromDatabase(); // Fetch semesters from the database
        }

        // Constructor to initialize a Year object and add it to the database
        public StudentYear(int name, int studentId, List<string> semesterNames)
        {
            Name = name;
            StudentId = studentId;
            SemesterList = new SortedDictionary<string, StudentSemester>(); // Initialize the semester list
            AddYearToDatabase(); // Add the year to the database
            AddSemestersToDatabase(semesterNames); // Add the semesters to the database
        }

        // Add the year to the database and get the generated ID
        private void AddYearToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO year (name, studentId) VALUES (@name, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Add the semesters to the database and initialize the semester list
        private void AddSemestersToDatabase(List<string> semesterNames)
        {
            foreach (string semesterName in semesterNames) // Loop through each semester name
            {
                StudentSemester semester = new StudentSemester(semesterName, Id, StudentId); // Create a new semester
                SemesterList.Add(semester.Name, semester); // Add the semester to the semester list
            }
        }

        // Fetch semesters from the database and initialize the semester list
        private void LoadSemestersFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT name, id FROM semester WHERE yearId = @yearId AND studentId = @studentId"; // SQL query to fetch semesters
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@yearId", Id); // Set the yearId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            string name = reader.GetString(0); // Get the semester name
                            int id = reader.GetInt32(1); // Get the semester ID
                            SemesterList.Add(name, new StudentSemester(name, id, Id, StudentId)); // Add the semester to the semester list
                        }
                    }
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
                string sql = "UPDATE year SET name = @name WHERE id = @id"; // SQL query to update year name

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@id", Id); // Set the id parameter
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.ExecuteNonQuery(); // Execute the update command
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
            foreach (StudentSemester semester in SemesterList.Values) // Loop through each semester
            {
                semester.DeleteSemesterFromDatabase(); // Delete the semester from the database
            }

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "DELETE FROM year WHERE id = @id"; // SQL query to delete the year

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@id", Id); // Set the id parameter
                    cmd.ExecuteNonQuery(); // Execute the delete command
                }
            }
        }
    }
}
