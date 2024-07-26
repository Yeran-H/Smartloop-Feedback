using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback
{
    public class Semester
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        // Public properties for semester details
        public string name { get; set; }
        public int id { get; set; }
        public int yearId { get; set; }
        public int studentId { get; set; }
        public Dictionary<int, Course> courseList { get; set; }

        // Constructor to initialize a Semester object and fetch courses from the database
        public Semester(string name, int id, int yearId, int studentId)
        {
            this.name = name;
            this.id = id;
            this.yearId = yearId;
            this.studentId = studentId;
            courseList = new Dictionary<int, Course>(); // Initialize the course list
            GetCourseFromDatabase(); // Fetch courses from the database
        }

        // Constructor to initialize a Semester object and add it to the database
        public Semester(string name, int yearId, int studentId)
        {
            this.name = name;
            this.yearId = yearId;
            this.studentId = studentId;
            courseList = new Dictionary<int, Course>(); // Initialize the course list
            AddSemesterToDatabase(); // Add the semester to the database
        }

        // Add the semester to the database and get the generated ID
        public void AddSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO semester (name, yearId, studentId) VALUES (@name, @yearId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert semester and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@yearId", yearId); // Set the yearId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch courses from the database and initialize the course list
        private void GetCourseFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, code, title, creditPoint, description, isCompleted, canvasLink FROM course WHERE semesterId = @semesterId AND studentId = @studentId", conn); // SQL query to fetch courses
                cmd.Parameters.AddWithValue("@semesterId", id); // Set the semesterId parameter
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int courseId = reader.GetInt32(0); // Get the course ID
                        int code = reader.GetInt32(1); // Get the course code
                        string title = reader.GetString(2); // Get the course title
                        int creditPoint = reader.GetInt32(3); // Get the course credit points
                        string description = reader.GetString(4); // Get the course description
                        bool isCompleted = reader.GetBoolean(5);
                        string canvasLink = reader.GetString(6); // Get the course canvas link
                        courseList.Add(courseId, new Course(courseId, code, title, creditPoint, description, isCompleted, canvasLink, this.id, studentId)); // Add the course to the course list
                    }
                }
            }
        }

        public void DeleteSemesterFromDatabase()
        {
            foreach (Course course in courseList.Values)
            {
                course.DeleteCourseFromDatabase();
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM semester
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for studentId
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCourseFromDatabase(int courseId)
        {
            courseList[courseId].DeleteCourseFromDatabase();
            courseList.Remove(courseId);
        }
    }
}
