using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public class Student
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        // Public properties for student details
        public string Name { get; set; } // Student's name
        public string Email { get; set; } // Student's email
        public int StudentId { get; set; } // Student's ID
        public string Password { get; set; } // Student's password
        public string Degree { get; set; } // Student's degree
        public byte[] ProfileImage { get; set; } // Student's profile image
        public SortedDictionary<int, Year> YearList { get; set; } // List of years for the student
        public Dictionary<int, Event> EventList { get; set; } // List of events for the student

        // Constructor to initialize a Student object with details and fetch years and events from the database
        public Student(int studentId, string name, string email, string password, string degree, byte[] profileImage)
        {
            Name = name;
            Email = email;
            StudentId = studentId;
            Password = password;
            Degree = degree;
            ProfileImage = profileImage;
            YearList = new SortedDictionary<int, Year>(); // Initialize the year list
            EventList = new Dictionary<int, Event>(); // Initialize the event list
            LoadYearsFromDatabase(); // Fetch years from the database
            LoadEventsFromDatabase(); // Fetch events from the database
        }

        // Update student details in the database
        public void UpdateToDatabase(Student selectedStudent)
        {
            Name = selectedStudent.Name;
            Email = selectedStudent.Email;
            Password = selectedStudent.Password;
            Degree = selectedStudent.Degree;
            ProfileImage = selectedStudent.ProfileImage;

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
                    cmd.Parameters.AddWithValue("@studentId", StudentId);
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@degree", Degree);
                    cmd.Parameters.AddWithValue("@profileImage", ProfileImage);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete student and related data from the database
        public void DeleteStudentFromDatabase()
        {
            // Delete all years associated with the student
            foreach (Year year in YearList.Values)
            {
                year.DeleteYearFromDatabase();
            }

            // Delete all events associated with the student
            foreach (Event ev in EventList.Values)
            {
                ev.DeleteEventFromDatabase();
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
                    cmd.Parameters.AddWithValue("@studentId", StudentId);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a year and related data from the database
        public void DeleteYearFromDatabase(int yearName)
        {
            if (YearList.ContainsKey(yearName))
            {
                YearList[yearName].DeleteYearFromDatabase(); // Delete the year from the database
                YearList.Remove(yearName); // Remove the year from the list
            }
        }

        // Private method to fetch years from the database for the student
        private void LoadYearsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT name, id FROM year WHERE studentId = @studentId ORDER BY name"; // SQL query to fetch years
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int name = reader.GetInt32(0); // Get the year name
                            int id = reader.GetInt32(1); // Get the year ID
                            YearList.Add(name, new Year(name, StudentId, id)); // Add the year to the year list
                        }
                    }
                }
            }
        }

        // Fetch events from the database for the student
        public void LoadEventsFromDatabase()
        {
            EventList.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT id, name, date, startTime, endTime, courseId, category, color FROM event WHERE studentId = @studentId ORDER BY date"; // SQL query to fetch events
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            DateTime date = reader.GetDateTime(2);
                            TimeSpan startTime = reader.GetTimeSpan(3);
                            TimeSpan endTime = reader.GetTimeSpan(4);
                            int courseId = reader.GetInt32(5);
                            string category = reader.GetString(6);
                            int color = reader.GetInt32(7);
                            EventList.Add(id, new Event(id, name, date, startTime, endTime, StudentId, courseId, category, color)); // Add the event to the event list
                        }
                    }
                }
            }
        }

        // Update event details in the database
        public void UpdateEvent(Event selectedEvent)
        {
            if (EventList.ContainsKey(selectedEvent.Id))
            {
                EventList[selectedEvent.Id].UpdateEventInDatabase(selectedEvent);
            }
        }

        // Delete event from the database
        public void DeleteEvent(Event selectedEvent)
        {
            if (EventList.ContainsKey(selectedEvent.Id))
            {
                EventList[selectedEvent.Id].DeleteEventFromDatabase();
                EventList.Remove(selectedEvent.Id);
            }
        }

        // Validate if the password meets the minimum length requirement
        public bool ValidatePassword()
        {
            return Password.Length >= 8;
        }

        // Validate if the student ID is exactly 8 digits long
        public bool ValidateStudentId()
        {
            string studentIdStr = StudentId.ToString();

            // Check if the length of the studentId is 8 charaters long
            if (studentIdStr.Length != 8)
            {
                return false;
            }

            bool exists = false;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM student WHERE studentId = @studentId"; // SQL query to check if studentId exists
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    exists = (int)cmd.ExecuteScalar() > 0; // Execute the query and check if any row exists
                }
            }

            return exists;
        }


        // Validate if the email has a valid domain
        public bool ValidateEmail()
        {
            return Email.EndsWith("@student.uts.edu.au", StringComparison.OrdinalIgnoreCase) || Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        // Check if a year name is unique within the student's year list
        public bool UniqueYear(int name)
        {
            return !YearList.ContainsKey(name);
        }

        // Get the list of courses for the student
        public List<string> GetCourseList()
        {
            List<string> courseList = new List<string>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT title FROM course WHERE studentId = @studentId"; // SQL query to fetch courses
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            string title = reader.GetString(0); // Get the course title
                            courseList.Add(title); // Add the course title to the list
                        }
                    }
                }
            }

            return courseList;
        }

        // Find the course ID for a given course name
        public int FindCourseId(string courseName)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT id FROM course WHERE studentId = @studentId AND title = @courseName"; // SQL query to find course ID
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    cmd.Parameters.AddWithValue("@courseName", courseName); // Set the courseName parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        if (reader.Read()) // If a matching record is found
                        {
                            return reader.GetInt32(0); // Return the course ID
                        }
                    }
                }
            }
            return -1; // Return -1 if no matching course is found
        }
    }
}
