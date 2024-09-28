using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using Smartloop_Feedback.Objects.User_Object.Tutor;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class SemesterAssociation : Semester
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
    
        public int Id { get; set; }
        public int YearId { get; set; }
        public int UserId { get; set; }
        public bool IsStudent { get; set; }
        public Dictionary<int, CourseAssociation> CourseList { get; set; }

        public SemesterAssociation(int id, string semesterName, int yearAssociationId, int yearName, int userId, bool isStudent)
            :base(semesterName, yearName)
        {
            Id = id;
            YearId = yearAssociationId;
            UserId = userId;
            IsStudent = isStudent;
            CourseList = new Dictionary<int, CourseAssociation>();
            LoadCoursesFromDatabase();
        }

        public SemesterAssociation(string semesterName, int yearAssociationId, int yearName, int userId, bool isStudent)
            : base(semesterName, yearName)
        {
            YearId = yearAssociationId;
            UserId = userId;
            IsStudent = isStudent;
            CourseList = new Dictionary<int, CourseAssociation>();
            AddSemesterToDatabase();
        }

        // Add the semester to the database and get the generated ID
        private void AddSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql;
                
                if(IsStudent)
                {
                    sql = "INSERT INTO semesterAssociation (name, yearId, studentId, semesterId, isStudent) VALUES (@name, @yearId, @userId, @semesterId, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert semester and get the generated ID
                }
                else
                {
                    sql = "INSERT INTO semesterAssociation (name, yearId, tutorId, semesterId, isStudent) VALUES (@name, @yearId, @userId, @semesterId, @isStudent); SELECT SCOPE_IDENTITY();"; // SQL query to insert semester and get the generated ID
                }


                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@yearId", YearId); // Set the yearId parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter
                    cmd.Parameters.AddWithValue("@semesterId", SemesterId);
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
                string sql;

                if (IsStudent)
                {
                    sql = "SELECT id, isCompleted, courseId FROM courseAssociation WHERE semesterId = @semesterId AND studentId = @userId"; // SQL query to fetch courses
                }
                else
                {
                    sql = "SELECT id, isCompleted, courseId FROM courseAssociation WHERE semesterId = @semesterId AND tutorId = @userId"; // SQL query to fetch courses
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@semesterId", Id); // Set the semesterId parameter
                    cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int courseAssociationId = reader.GetInt32(0);
                            bool isCompleted = reader.IsDBNull(1);
                            int courseId = reader.GetInt32(2);

                            if(IsStudent)
                            {
                                StudentCourse studentCourse = new StudentCourse(courseAssociationId, courseId, UserId, Id, isCompleted, IsStudent);
                                CourseList.Add(studentCourse.Code, studentCourse);
                            }
                            else
                            {
                                TutorCourse tutorCourse = new TutorCourse(courseAssociationId, courseId, UserId, Id, isCompleted, IsStudent);
                                CourseList.Add(tutorCourse.Code, tutorCourse);
                            }
                        }
                    }
                }
            }
        }

        // Delete the semester and related courses from the database
        public void DeleteSemesterFromDatabase()
        {
            // Delete all courses associated with the semester
            foreach (CourseAssociation course in CourseList.Values)
            {
                if(IsStudent && course is StudentCourse studentCourse)
                {
                    studentCourse.DeleteStudentCourseFromDatabase();
                }
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM semesterAssociation
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
        public void DeleteCourseFromDatabase(int courseCode)
        {
            if (CourseList.ContainsKey(courseCode) && IsStudent && CourseList[courseCode] is StudentCourse studentCourse) 
            {
                studentCourse.DeleteStudentCourseFromDatabase(); // Delete the course from the database
                CourseList.Remove(courseCode); // Remove the course from the list
            }
            else if (CourseList.ContainsKey(courseCode) && IsStudent && CourseList[courseCode] is TutorCourse tutorCourse)
            {
                tutorCourse.DeleteTutorCourseFromDatabase(); // Delete the course from the database
                CourseList.Remove(courseCode); // Remove the course from the list
            }
        }
    }
}
