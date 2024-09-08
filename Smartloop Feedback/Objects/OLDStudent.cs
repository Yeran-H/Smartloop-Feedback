using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Smartloop_Feedback
{
    public class OLDStudent : OLDUser
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        // Public properties for student details
        public string Degree { get; set; } // Student's degree
        public Dictionary<int, Event> EventList { get; set; } // List of events for the student

        // Constructor to initialize a Student object with details and fetch years and events from the database
        public OLDStudent(int studentId, string name, string email, string password, string degree, byte[] profileImage)
            : base(studentId, name, email, password, profileImage, true)
        {
            Degree = degree;
            ProfileImage = profileImage;
            EventList = new Dictionary<int, Event>();
            LoadYearsFromDatabase();
            LoadEventsFromDatabase();
        }

        public OLDStudent(int studentId, string name, string email, string password, string degree, byte[] profileImage, bool x)
        : base(studentId, name, email, password, profileImage, true)
        {
            Degree = degree;
            ProfileImage = profileImage;
            EventList = new Dictionary<int, Event>();
            AddStudentToDatabase();
        }

        private void AddStudentToDatabase()
        {
            // Insert the new student record into the database
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO student (name, email, studentId, password, degree, profileImage) VALUES (@name, @mail, @studentId, @password, @degree, @profileImage)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@mail", Email);
                    cmd.Parameters.AddWithValue("@studentId", Id);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@degree", Degree);
                    SqlParameter profileImageParam = new SqlParameter("@profileImage", SqlDbType.VarBinary);
                    profileImageParam.Value = ProfileImage != null ? ProfileImage : (object)DBNull.Value;
                    cmd.Parameters.Add(profileImageParam);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update student details in the database
        public void UpdateToDatabase(OLDStudent selectedStudent)
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
                    cmd.Parameters.AddWithValue("@studentId", Id);
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
            //foreach (StudentYear year in YearList.Values)
            //{
            //    year.DeleteYearFromDatabase();
            //}

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
                    cmd.Parameters.AddWithValue("@studentId", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a year and related data from the database
        public void DeleteYearFromDatabase(int yearName)
        {
            //if (YearList.ContainsKey(yearName))
            //{
            //    YearList[yearName].DeleteYearFromDatabase(); // Delete the year from the database
            //    YearList.Remove(yearName); // Remove the year from the list
            //}
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
                    cmd.Parameters.AddWithValue("@studentId", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int name = reader.GetInt32(0); // Get the year name
                            int id = reader.GetInt32(1); // Get the year ID
                            //YearList.Add(name, new StudentYear(name, Id, id)); // Add the year to the year list
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
                    cmd.Parameters.AddWithValue("@studentId", Id); // Set the studentId parameter

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
                            EventList.Add(id, new Event(id, name, date, startTime, endTime, Id, courseId, category, color)); // Add the event to the event list
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
                    cmd.Parameters.AddWithValue("@studentId", Id); // Set the studentId parameter

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
                    cmd.Parameters.AddWithValue("@studentId", Id); // Set the studentId parameter
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
