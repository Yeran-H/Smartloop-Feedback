using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Drawing;

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
        public Student(int studentId, string name, string email, string password, string degree, byte[] profileImage)
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

        public void UpdateToDatabase(Student selectedStudent)
        {
            name = selectedStudent.name;
            email = selectedStudent.email;
            password = selectedStudent.password;
            degree = selectedStudent.degree;
            profileImage = selectedStudent.profileImage;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE student
                    SET 
                        name = @name,
                        email = @email,
                        password = @password,
                        degree = @degree,
                        profileImage = @profileImage
                    WHERE
                        studentId = @studentId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@degree", degree);
                    cmd.Parameters.AddWithValue("@profileImage", profileImage);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudentFromDatabase()
        {
            foreach(Year year in yearList.Values)
            {
                year.DeleteYearFromDatabase();
            }

            foreach (Event events in eventList.Values)
            {
                events.DeleteEventFromDatabase();
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM student
                    WHERE studentId = @studentId";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for studentId
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteYearFromDatabase(string yearName)
        {
            yearList[yearName].DeleteYearFromDatabase();

            yearList.Remove(yearName);
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
