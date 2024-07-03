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
        public List<Semester> semesterList { get; set; } // List of semesters in the year

        // Constructor to initialize a Year object and fetch semesters from the database
        public Year(string name, int studentId, int id)
        {
            this.name = name;
            this.studentId = studentId;
            this.id = id;
            semesterList = new List<Semester>(); // Initialize the semester list
            getSemesterFromDatabase(); // Fetch semesters from the database
        }

        // Constructor to initialize a Year object and add it to the database
        public Year(string name, int studentId, List<string> semesterNames)
        {
            this.name = name;
            this.studentId = studentId;
            semesterList = new List<Semester>(); // Initialize the semester list
            addYearToDatabase(); // Add the year to the database
            addSemesterToDatabase(semesterNames); // Add the semesters to the database
        }

        // Add the year to the database and get the generated ID
        public void addYearToDatabase()
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
        public void addSemesterToDatabase(List<string> semesterNames)
        {
            foreach (string semesterName in semesterNames) // Loop through each semester name
            {
                semesterList.Add(new Semester(semesterName, id, studentId)); // Add a new semester to the semester list
            }
        }

        // Fetch semesters from the database and initialize the semester list
        private void getSemesterFromDatabase()
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
                        semesterList.Add(new Semester(name, id, this.id, studentId)); // Add the semester to the semester list
                    }
                }
            }
        }

        // Get the number of semesters in the year
        public int numSemester()
        {
            return semesterList?.Count ?? 0; // Return the count of the semester list, or 0 if it is null
        }

        // Get the index of a semester by its name
        public int semesterIndex(string semesterName)
        {
            for (int i = 0; i < numSemester(); i++) // Loop through each semester
            {
                if (semesterList[i].name.Equals(semesterName, StringComparison.OrdinalIgnoreCase)) // Compare the semester name
                {
                    return i; // Return the index if the names match
                }
            }
            return -1; // Return -1 if the semester is not found
        }
    }
}
