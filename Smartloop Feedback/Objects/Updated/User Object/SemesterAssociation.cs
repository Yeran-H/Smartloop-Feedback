using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class SemesterAssociation
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
    
        public int Id { get; set; }
        public Semester Semester { get; set; }
        public int YearId { get; set; }
        public int UserId { get; set; }
        public bool IsStudent { get; set; }
        public Dictionary<int, CourseAssociation> CourseList { get; set; }

        public SemesterAssociation(int id, string semesterName, int yearAssociationId, int yearName, int userId, bool isStudent)
        {
            Id = id;
            YearId = yearAssociationId;
            UserId = userId;
            IsStudent = isStudent;
            Semester = new Semester(semesterName, yearName);
            CourseList = new Dictionary<int, CourseAssociation>();
            LoadCoursesFromDatabase();
        }

        public SemesterAssociation(string semesterName, int yearAssociationId, int yearName, int userId, bool isStudent)
        {
            YearId = yearAssociationId;
            UserId = userId;
            IsStudent = isStudent;
            Semester = new Semester(semesterName, yearName);
            CourseList = new Dictionary<int, CourseAssociation>();
            AddSemesterToDatabase();
        }

        // Add the semester to the database and get the generated ID
        private void AddSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO semesterAssociation (name, yearId, userId, semesterId, isStudent) VALUES (@name, @yearId, @userId, @semesterId, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert semester and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Semester.Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@yearId", YearId); // Set the yearId parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter
                    cmd.Parameters.AddWithValue("@semesterId", Semester.Id);
                    cmd.Parameters.AddWithValue("@isStudent", IsStudent);
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
                string sql = "SELECT id, courseId FROM courseAssociation WHERE semesterId = @semesterId AND userId = @userId"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@semesterId", Id); // Set the semesterId parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int courseAssociationId = reader.GetInt32(0);
                            Course course = new Course(reader.GetInt32(1));

                            if(IsStudent)
                            {
                                StudentCourse studentCourse = new StudentCourse(courseAssociationId, course, UserId, Id, IsStudent);
                                CourseList.Add(studentCourse.Course.Code, studentCourse);
                            }
                        }
                    }
                }
            }
        }
    }
}
