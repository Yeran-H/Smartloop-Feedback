using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Dictionary<string, Year> yearList { get; set; }
        public Dictionary<int, Event> eventList { get; set; }

        // Constructor to initialize a Student object with details and fetch years from the database
        public Student(int studentId, string name, string email, string degree, string password, byte[] profileImage)
        {
            this.name = name;
            this.email = email;
            this.studentId = studentId;
            this.password = password;
            this.degree = degree;
            this.profileImage = profileImage;
            yearList = new Dictionary<string, Year>(); // Initialize the year list
            eventList = new Dictionary<int, Event>();
            GetYearFromDatabase(); // Fetch years from the database
            GetEventFromDatabase();
        }

        // Private method to fetch years from the database for the student
        private void GetYearFromDatabase()
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
                        yearList.Add(name, new Year(name, studentId, id)); // Add the year to the year list
                    }
                }
            }
        }

        public void GetEventFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open(); 
                SqlCommand cmd = new SqlCommand("SELECT id, name, date, courseId, category, color FROM event WHERE studentId = @studentId ORDER BY date", conn); 
                cmd.Parameters.AddWithValue("@studentId", studentId); 

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime date = reader.GetDateTime(2);
                        int courseId = reader.GetInt32(3);
                        string category = reader.GetString(4);
                        int color = reader.GetInt32(5);
                        eventList.Add(id, new Event(id, name, date, studentId, courseId, category, color)); 
                    }
                }
            }
        }

        public void UpdateEvent(Event selectedEvent)
        {
            eventList[selectedEvent.id].UpdateEventInDatabase(selectedEvent);
        }

        public void DeleteEvent(Event selectedEvent)
        {
            eventList[selectedEvent.id].DeleteEventFromDatabase();
            eventList.Remove(selectedEvent.id);
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

        // Check if a year name is unique within the student's year list
        public bool UniqueYear(string name)
        {
            return yearList.Values.Any(year => year.name != name);
        }

        public List<string> GetCourseList()
        {
            List<string> courseList = new List<string>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT title FROM course WHERE studentId = @studentId", conn); 
                cmd.Parameters.AddWithValue("@studentId", studentId); 

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        string title = reader.GetString(0);
                        courseList.Add(title);
                    }
                    return courseList;
                }
            }
        }

        public int FindCourseId(string courseName)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id FROM course WHERE studentId = @studentId AND title = @courseName", conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@courseName", courseName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // If a matching record is found
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            return -1;
        }
    }
}
