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
        public int semesterId { get; set; }
        public int studentId { get; set; }
        public string canvasLink { get; set; }
        public List<Assessment> assessmentList { get; set; } // List of assessments for the course

        // Constructor to initialize a Course object and fetch assessments from the database
        public Course(int id, int code, string title, int creditPoint, string description, string canvasLink, int semesterId, int studentId)
        {
            this.id = id;
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.canvasLink = canvasLink;
            this.semesterId = semesterId;
            this.studentId = studentId;
            assessmentList = new List<Assessment>(); // Initialize the assessment list
            GetAssessmentFromDatabase(); // Fetch assessments from the database
        }

        // Constructor to initialize a Course object and add it to the database
        public Course(int code, string title, int creditPoint, string description, string canvasLink, int semesterId, int studentId)
        {
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.canvasLink = canvasLink;
            this.semesterId = semesterId;
            this.studentId = studentId;
            assessmentList = new List<Assessment>();
            AddCourseToDatabase(); // Add the course to the database
        }

        // Constructor to initialize a Course object without interacting with the database
        public Course(int code, string title, int creditPoint, string description, string canvasLink)
        {
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.canvasLink = canvasLink;
            assessmentList = new List<Assessment>();
        }

        // Add the course to the database and get the generated ID
        public void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO course (code, title, creditPoint, description, canvasLink, semesterId, studentId) VALUES (@code, @title, @creditPoint, @description, @canvasLink, @semesterId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@code", code); // Set the code parameter
                    cmd.Parameters.AddWithValue("@title", title); // Set the title parameter
                    cmd.Parameters.AddWithValue("@creditPoint", creditPoint); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@description", description); // Set the description parameter
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
                SqlCommand cmd = new SqlCommand("SELECT id, name, description, type, date, status, weight, mark, individual, [group], canvasLink FROM assessment WHERE courseId = @courseId AND studentId = @studentId", conn); // SQL query to fetch assessments
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
                        string status = reader.GetString(5); // Get the assessment status
                        int weight = reader.GetInt32(6); // Get the assessment weight
                        int mark = reader.GetInt32(7); // Get the assessment mark
                        bool individual = reader.GetBoolean(8); // Get the individual status
                        bool group = reader.GetBoolean(9); // Get the group status
                        string canvasLink = reader.GetString(10); // Get the assessment canvas link

                        // Add the assessment to the assessment list
                        assessmentList.Add(new Assessment(assessmentId, name, description, type, date, status, weight, mark, individual, group, canvasLink, this.id, studentId));
                    }
                }
            }
        }
    }
}
