using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public class Student
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        // Public properties for student details
        public string name { get; set; }
        public string email { get; set; }
        public int studentId { get; set; }
        public string password { get; set; }
        public string degree { get; set; }
        public byte[] profileImage { get; set; }
        public List<Year> yearList { get; set; }

        // Constructor to initialize a Student object with details and fetch years from the database
        public Student(int studentId, string name, string email, string degree, string password, byte[] profileImage)
        {
            this.name = name;
            this.email = email;
            this.studentId = studentId;
            this.password = password;
            this.degree = degree;
            this.profileImage = profileImage;
            yearList = new List<Year>(); // Initialize the year list
            getYearFromDatabase(); // Fetch years from the database
        }

        // Private method to fetch years from the database for the student
        private void getYearFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT name, id FROM year WHERE studentId = @studentId", conn); // SQL query to fetch years
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        string name = reader.GetString(0); // Get the year name
                        int id = reader.GetInt32(1); // Get the year ID
                        yearList.Add(new Year(name, studentId, id)); // Add the year to the year list
                    }
                }
            }
        }

        // Validate if the password meets the minimum length requirement
        public bool ValidatePassword()
        {
            return password.Length >= 8;
        }

        // Validate if the student ID is exactly 8 digits long
        public bool ValidateStudentId()
        {
            string studentIdStr = studentId.ToString();
            return studentIdStr.Length == 8;
        }

        // Validate if the email has a valid domain
        public bool ValidateEmail()
        {
            return email.EndsWith("@student.uts.edu.au", StringComparison.OrdinalIgnoreCase) || email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        // Get the number of years associated with the student
        public int numYears()
        {
            return yearList == null ? 0 : yearList.Count;
        }

        // Check if a year name is unique within the student's year list
        public bool uniqueYear(string name)
        {
            return yearList.All(year => year.name != name);
        }
    }
}
