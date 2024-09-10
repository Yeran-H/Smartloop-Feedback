using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;

namespace Smartloop_Feedback.Objects
{
    public class Coordinator
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public Dictionary<int, Course> CourseList { get; set; }

        public Coordinator()
        {
            CourseList = new Dictionary<int, Course>();
            LoadCourseList();
        }

        public Coordinator(Semester semester)
        {
            CourseList = new Dictionary<int, Course>();
            LoadCourseList(semester);
        }

        private void LoadCourseList()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, code, name, creditPoint, description, yearName, semesterId, canvasLink, tutorNum FROM course"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int courseId = reader.GetInt32(0); // Get the course ID
                            int code = reader.GetInt32(1); // Get the course code
                            string title = reader.GetString(2); // Get the course title
                            int creditPoint = reader.GetInt32(3); // Get the course credit points
                            string description = reader.GetString(4); // Get the course description
                            int yearName = reader.GetInt32(5); // Get the course year
                            int semesterId = reader.GetInt32(6);
                            string canvasLink = reader.GetString(7); // Get the course canvas link
                            int tutorNum = reader.GetInt32(8);
                            CourseList.Add(courseId, new Course(courseId, code, title, creditPoint, description, yearName, semesterId, canvasLink, tutorNum)); // Add the course to the course list
                        }
                    }
                }
            }
        }

        private void LoadCourseList(Semester semester)
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, code, name, creditPoint, description, yearName, semesterId, canvasLink, tutorNum FROM course WHERE yearName = @yearName AND semesterId = @semesterId"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@yearName", semester.Year.Name);
                    cmd.Parameters.AddWithValue("@semesterId", semester.Id);

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int courseId = reader.GetInt32(0); // Get the course ID
                            int code = reader.GetInt32(1); // Get the course code
                            string title = reader.GetString(2); // Get the course title
                            int creditPoint = reader.GetInt32(3); // Get the course credit points
                            string description = reader.GetString(4); // Get the course description
                            int yearName = reader.GetInt32(5); // Get the course year
                            int semesterId = reader.GetInt32(6);
                            string canvasLink = reader.GetString(7); // Get the course canvas link
                            int tutorNum = reader.GetInt32(8);
                            CourseList.Add(courseId, new Course(courseId, code, title, creditPoint, description, yearName, semesterId, canvasLink, tutorNum)); // Add the course to the course list
                        }
                    }
                }
            }
        }

        // Delete a course from the database
        public void DeleteCourseFromDatabase(int courseId)
        {
            if (CourseList.ContainsKey(courseId))
            {
                CourseList[courseId].DeleteCourseFromDatabase(); // Delete the course from the database
                CourseList.Remove(courseId); // Remove the course from the list
            }
        }
    }
}
