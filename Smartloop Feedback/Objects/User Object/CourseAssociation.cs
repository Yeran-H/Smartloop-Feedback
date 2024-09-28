using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Asn1.X509;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class CourseAssociation : Course
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SemesterId { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsStudent { get; set; }
        public SortedDictionary<int, Event> EventList { get; private set; }

        public CourseAssociation (int id, int courseId, int userId, int semesterId, bool isCompleted, bool isStudent)
            :base(courseId)
        {
            this.Id = id;
            this.UserId = userId;
            this.SemesterId = semesterId;
            this.IsStudent = isStudent;
            this.IsCompleted = isCompleted;
            EventList = new SortedDictionary<int, Event>();
        }

        public CourseAssociation(int courseId, int userId, int semesterId, bool isCompleted, bool isStudent)
            :base(courseId)
        {
            this.UserId = userId;
            this.SemesterId = semesterId;
            this.IsStudent = isStudent;
            this.IsCompleted= isCompleted;
            EventList = new SortedDictionary<int, Event>();
            AddCourseToDatabase();
        }

        // Add the course to the database and get the generated ID
        private void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql;

                if (IsStudent)
                {
                    sql = "INSERT INTO courseAssociation (courseId, studentId, semesterId, isCompleted, isStudent) VALUES (@courseId, @userId, @semesterId, @isCompleted, @isStudent); SELECT SCOPE_IDENTITY();";
                }
                else
                {
                    sql = "INSERT INTO courseAssociation (courseId, tutorId, semesterId, isCompleted, isStudent) VALUES (@courseId, @userId, @semesterId, @isCompleted, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the code parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the title parameter
                    cmd.Parameters.AddWithValue("@semesterId", SemesterId); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@isStudent", IsStudent); // Set the description parameter
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch events from the database and initialize the event list
        public void LoadEventsFromDatabase()
        {
            EventList.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, name, date, startTime, endTime, category, color FROM event WHERE courseId = @courseId ORDER BY date", conn);
                cmd.Parameters.AddWithValue("@courseId", Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime date = reader.GetDateTime(2);
                        TimeSpan startTime = reader.GetTimeSpan(3);
                        TimeSpan endTime = reader.GetTimeSpan(4);
                        string category = reader.GetString(5);
                        int color = reader.GetInt32(6);
                        EventList.Add(id, new Event(id, name, date, startTime, endTime, UserId, Id, category, color));
                    }
                }
            }
        }

        // Update an event in the database
        public void UpdateEvent(Event selectedEvent)
        {
            if (EventList.ContainsKey(selectedEvent.Id))
            {
                EventList[selectedEvent.Id].UpdateEventInDatabase(selectedEvent);
            }
        }
    }
}
