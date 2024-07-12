using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class Course
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for course details
        public int id { get; set; }
        public int code { get; set; }
        public string title { get; set; }
        public int creditPoint { get; set; }
        public string description { get; set; }
        public bool isCompleted { get; set; }
        public int semesterId { get; set; }
        public int studentId { get; set; }
        public string canvasLink { get; set; }
        public Dictionary<int, Assessment> assessmentList { get; set; } // List of assessments for the course
        public Dictionary<int, Event> eventList { get; set; }

        // Constructor to initialize a Course object and fetch assessments from the database
        public Course(int id, int code, string title, int creditPoint, string description, bool isCompleted, string canvasLink, int semesterId, int studentId)
        {
            this.id = id;
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.isCompleted = isCompleted;
            this.canvasLink = canvasLink;
            this.semesterId = semesterId;
            this.studentId = studentId;
            assessmentList = new Dictionary<int, Assessment>(); // Initialize the assessment list
            eventList = new Dictionary<int, Event>();
            GetAssessmentFromDatabase(); // Fetch assessments from the database
        }

        // Constructor to initialize a Course object and add it to the database
        public Course(int code, string title, int creditPoint, string description, bool isCompleted, string canvasLink, int semesterId, int studentId)
        {
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.isCompleted = isCompleted;
            this.canvasLink = canvasLink;
            this.semesterId = semesterId;
            this.studentId = studentId;
            assessmentList = new Dictionary<int, Assessment>();
            eventList = new Dictionary<int, Event>();
            AddCourseToDatabase(); // Add the course to the database
        }

        // Constructor to initialize a Course object without interacting with the database
        public Course(int code, string title, int creditPoint, string description, bool isCompleted, string canvasLink)
        {
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.isCompleted = isCompleted;
            this.canvasLink = canvasLink;
            assessmentList = new Dictionary<int, Assessment>();
        }

        // Add the course to the database and get the generated ID
        public void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO course (code, title, creditPoint, description, isCompleted, canvasLink, semesterId, studentId) VALUES (@code, @title, @creditPoint, @description, @isCompleted, @canvasLink, @semesterId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@code", code); // Set the code parameter
                    cmd.Parameters.AddWithValue("@title", title); // Set the title parameter
                    cmd.Parameters.AddWithValue("@creditPoint", creditPoint); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@description", description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@isCompleted", isCompleted);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink); // Set the canvasLink parameter
                    cmd.Parameters.AddWithValue("@semesterId", semesterId); // Set the semesterId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch assessments from the database and initialize the assessment list
        private void GetAssessmentFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name, description, type, date, status, weight, mark, finalMark, individual, [group], isFinalised, canvasLink FROM assessment WHERE courseId = @courseId AND studentId = @studentId", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@courseId", id); // Set the courseId parameter
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int assessmentId = reader.GetInt32(0); // Get the assessment ID
                        string name = reader.GetString(1); // Get the assessment name
                        string description = reader.GetString(2); // Get the assessment description
                        string type = reader.GetString(3); // Get the assessment type
                        DateTime date = reader.GetDateTime(4); // Get the assessment date
                        int status = reader.GetInt32(5); // Get the assessment status
                        double weight = (double)reader.GetDecimal(6); // Get the assessment weight
                        double mark = (double)reader.GetDecimal(7); // Get the assessment mark
                        double finalMark = (double)reader.GetDecimal(8);
                        bool individual = reader.GetBoolean(9); // Get the individual status
                        bool group = reader.GetBoolean(10); // Get the group status
                        bool isFinalised = reader.GetBoolean(11);
                        string canvasLink = reader.GetString(12); // Get the assessment canvas link

                        // Add the assessment to the assessment list
                        assessmentList.Add(assessmentId, new Assessment(assessmentId, name, description, type, date, status, weight, mark, finalMark, individual, group, isFinalised, canvasLink, this.id, studentId));
                    }
                }
            }
        }

        public void GetEventsFromDatabase()
        {
            eventList.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, name, date, category, color FROM event WHERE courseId = @courseId ORDER BY date", conn);
                cmd.Parameters.AddWithValue("@courseId", this.id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime date = reader.GetDateTime(2);
                        string category = reader.GetString(3);
                        int color = reader.GetInt32(4);
                        eventList.Add(id, new Event(id, name, date, studentId, this.id, category, color));
                    }
                }
            }
        }

        public void UpdateEvent(Event selectedEvent)
        {
            eventList[selectedEvent.id].UpdateEventInDatabase(selectedEvent);
        }

        public double CalculateCurrentMark()
        {
            double totalWeightedMarks = 0.0;
            double TotalWeight = 0.0;

            foreach(var assessment in assessmentList.Values)
            {
                if(assessment.isFinalised)
                {
                    totalWeightedMarks += (assessment.finalMark / assessment.mark) * assessment.weight;
                    TotalWeight += assessment.weight;
                }
            }

            return TotalWeight > 0 ? (totalWeightedMarks / TotalWeight) * 100 : 0.0;
        }

        public double CalculateTargetMark(double targetMark)
        {
            double totalWeightedMarks = 0.0;
            double totalWeight = 0.0;
            double remainingWeight = 0.0;

            foreach (var assessment in assessmentList.Values)
            {
                if (assessment.isFinalised)
                {
                    totalWeightedMarks += (assessment.finalMark / assessment.mark) * assessment.weight;
                    totalWeight += assessment.weight;
                }
                else
                {
                    remainingWeight += assessment.weight;
                }
            }

            remainingWeight += 100 - totalWeight - remainingWeight;

            if (remainingWeight == 0)
            {
                // All assessments are finalized
                double currentMark = totalWeight > 0 ? totalWeightedMarks / totalWeight : 0.0;
                isCompleted = true;
                return currentMark >= targetMark ? 0.0 : double.NaN; // Return NaN if it's not possible to achieve the target
            }
            else
            {
                isCompleted = false;
            }

            double requiredTotalMarks = targetMark * (totalWeight + remainingWeight);
            double requiredAdditionalMarks = requiredTotalMarks - totalWeightedMarks;

            return (requiredAdditionalMarks / remainingWeight) * 100;
        }
    }
}
