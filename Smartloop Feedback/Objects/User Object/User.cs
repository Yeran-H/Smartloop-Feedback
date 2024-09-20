using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class User
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfileImage { get; set; }
        public bool IsStudent { get; set; }
        public SortedDictionary<int, YearAssociation> YearList { get; set; }
        public Dictionary<int, Event> EventList { get; set; }

        public User(int id, string name, string email, string password, byte[] profileImage, bool isStudent)
        {
            Email = email;
            Password = password;
            Id = id;
            Name = name;
            ProfileImage = profileImage;
            IsStudent = isStudent;
            YearList = new SortedDictionary<int, YearAssociation>();
            EventList = new Dictionary<int, Event>();
            LoadYearsFromDatabase();
            LoadEventsFromDatabase();
        }

        public bool ValidateUserInput()
        {
            return ValidateEmail() && ValidatePassword() && !ValidateId();
        }

        public bool ValidatePassword()
        {
            if (Password.Length >= 8)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ValidateId()
        {
            string IdStr = Id.ToString();

            // Check if the length of the Id is 8 charaters long
            if (IdStr.Length != 8)
            {
                MessageBox.Show("Student ID must be 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool exists = false;

            if (IsStudent)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM student WHERE studentId = @Id"; // SQL query to check if studentId exists
                    using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                    {
                        cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                        exists = (int)cmd.ExecuteScalar() > 0; // Execute the query and check if any row exists
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM tutor WHERE tutorId = @Id"; // SQL query to check if studentId exists
                    using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                    {
                        cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                        exists = (int)cmd.ExecuteScalar() > 0; // Execute the query and check if any row exists
                    }
                }
            }

            if (exists)
            {
                MessageBox.Show("Id must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return exists;
        }

        public bool ValidateEmail()
        {
            if (!Email.EndsWith("@student.uts.edu.au", StringComparison.OrdinalIgnoreCase) && !Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) && !Email.EndsWith("@uts.edu.au", StringComparison.OrdinalIgnoreCase))
            {
                string domainError = IsStudent ? "@student.uts.edu.au or @gmail.com" : "@uts.edu.au or @gmail.com";
                MessageBox.Show($"Email must end with {domainError}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Private method to fetch years from the database for the student
        private void LoadYearsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, name FROM yearAssociation WHERE studentId = @userId OR tutorId = @userId ORDER BY name"; // SQL query to fetch years
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@userId", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int id = reader.GetInt32(0); // Get the year name
                            int yearName = reader.GetInt32(1); // Get the year ID
                            YearList.Add(yearName, new YearAssociation(id, yearName, Id, IsStudent)); // Add the year to the year list
                        }
                    }
                }
            }
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
                string sql = "SELECT courseId FROM courseAssociation WHERE userId = @userId"; // SQL query to fetch courses
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@userId", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            Course course = new Course(reader.GetInt32(0));
                            courseList.Add(course.Name); // Add the course title to the list
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

                // SQL query to find the courseAssociation ID
                string sql = @"
                    SELECT ca.id
                    FROM courseAssociation ca
                    INNER JOIN course c ON ca.courseId = c.id
                    WHERE c.name = @courseName AND ca.userId = @userId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Set the parameters
                    cmd.Parameters.AddWithValue("@courseName", courseName);
                    cmd.Parameters.AddWithValue("@userId", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If a matching record is found
                        {
                            return reader.GetInt32(0); // Return the courseAssociation ID
                        }
                    }
                }
            }

            return -1; // Return -1 if no matching courseAssociation is found
        }


        // Fetch events from the database for the student
        public void LoadEventsFromDatabase()
        {
            EventList.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT id, name, date, startTime, endTime, courseId, category, color FROM event WHERE userId = @userId ORDER BY date"; // SQL query to fetch events
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@userId", Id); // Set the studentId parameter

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

        public void DeleteUserFromDatabase()
        {
            // Delete all years associated with the student
            foreach (YearAssociation year in YearList.Values)
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

                if(IsStudent)
                {
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
                else
                {
                    string deleteQuery = @"
                    DELETE FROM tutor
                    WHERE tutorId = @tutorId";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        // Add the parameter for studentId
                        cmd.Parameters.AddWithValue("@tutorId", Id);

                        // Execute the delete command
                        cmd.ExecuteNonQuery();
                    }
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
    }
}
