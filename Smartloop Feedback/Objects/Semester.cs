using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback
{
    public class Semester
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        // Public properties for semester details
        public string Name { get; set; } // Name of the semester
        public int Id { get; set; } // ID of the semester
        public int YearId { get; set; } // ID of the year this semester belongs to
        public int StudentId { get; set; } // ID of the student
        public SortedDictionary<int, StudentCourse> CourseList { get; set; } // List of courses in the semester

        // Constructor to initialize a Semester object and fetch courses from the database
        public Semester(string name, int id, int yearId, int studentId)
        {
            Name = name;
            Id = id;
            YearId = yearId;
            StudentId = studentId;
            CourseList = new SortedDictionary<int, StudentCourse>(); // Initialize the course list
            LoadCoursesFromDatabase(); // Fetch courses from the database
        }

        // Constructor to initialize a Semester object and add it to the database
        public Semester(string name, int yearId, int studentId)
        {
            Name = name;
            YearId = yearId;
            StudentId = studentId;
            CourseList = new SortedDictionary<int, StudentCourse>(); // Initialize the course list
            AddSemesterToDatabase(); // Add the semester to the database
        }

        // Add the semester to the database and get the generated ID
        private void AddSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO semester (name, yearId, studentId) VALUES (@name, @yearId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert semester and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@yearId", YearId); // Set the yearId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch courses from the database and initialize the course list
        private void LoadCoursesFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, code, title, creditPoint, description, isCompleted, canvasLink FROM course WHERE semesterId = @semesterId AND studentId = @studentId"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@semesterId", Id); // Set the semesterId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int courseId = reader.GetInt32(0); // Get the course ID
                            int code = reader.GetInt32(1); // Get the course code
                            string title = reader.GetString(2); // Get the course title
                            int creditPoint = reader.GetInt32(3); // Get the course credit points
                            string description = reader.GetString(4); // Get the course description
                            bool isCompleted = reader.GetBoolean(5); // Get the course completion status
                            string canvasLink = reader.GetString(6); // Get the course canvas link
                            CourseList.Add(courseId, new StudentCourse(courseId, code, title, creditPoint, description, isCompleted, canvasLink, Id, StudentId)); // Add the course to the course list
                        }
                    }
                }
            }
        }

        // Delete the semester and related courses from the database
        public void DeleteSemesterFromDatabase()
        {
            // Delete all courses associated with the semester
            foreach (StudentCourse course in CourseList.Values)
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
                    // Add the parameter for semester ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
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
