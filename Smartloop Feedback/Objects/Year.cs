using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback
{
    public class Year
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for year details
        public string name { get; set; }
        public int studentId { get; } // Student ID associated with the year
        public int id { get; set; } // Year ID
        public Dictionary<string, Semester> semesterList { get; set; } // List of semesters in the year

        // Constructor to initialize a Year object and fetch semesters from the database
        public Year(string name, int studentId, int id)
        {
            this.name = name;
            this.studentId = studentId;
            this.id = id;
            semesterList = new Dictionary<string, Semester>(); // Initialize the semester list
            GetSemesterFromDatabase(); // Fetch semesters from the database
        }

        // Constructor to initialize a Year object and add it to the database
        public Year(string name, int studentId, List<string> semesterNames)
        {
            this.name = name;
            this.studentId = studentId;
            semesterList = new Dictionary<string, Semester>(); // Initialize the semester list
            AddYearToDatabase(); // Add the year to the database
            AddSemesterToDatabase(semesterNames); // Add the semesters to the database
        }

        // Add the year to the database and get the generated ID
        public void AddYearToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO year (name, studentId) VALUES (@name, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert year and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Add the semesters to the database and initialize the semester list
        public void AddSemesterToDatabase(List<string> semesterNames)
        {
            foreach (string semesterName in semesterNames) // Loop through each semester name
            {
                Semester semester = new Semester(semesterName, id, studentId);
                semesterList.Add(semester.name, semester); // Add a new semester to the semester list
            }
        }

        // Fetch semesters from the database and initialize the semester list
        private void GetSemesterFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT name, id FROM semester WHERE yearId = @yearId AND studentId = @studentId", conn); // SQL query to fetch semesters
                cmd.Parameters.AddWithValue("@yearId", id); // Set the yearId parameter
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        string name = reader.GetString(0); // Get the semester name
                        int id = reader.GetInt32(1); // Get the semester ID
                        semesterList.Add(name, new Semester(name, id, this.id, studentId)); // Add the semester to the semester list
                    }
                }
            }
        }
    }
}
