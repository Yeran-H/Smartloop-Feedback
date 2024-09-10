using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Asn1.X509;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;

namespace Smartloop_Feedback.Objects.Updated.User_Object.Student
{
    public class StudentCourse : CourseAssociation
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
        public bool IsCompleted { get; set; }
        public double CourseMark { get; set; }
        public double CourseGPA { get; set; }
        public Tutorial Tutorial { get; set; }

        public StudentCourse(int id, Course course, int userId, int semesterId, bool isStudent)
            : base(id, course, userId, semesterId, isStudent)
        {
            LoadStudentCourseFromDatabase();
        }

        public StudentCourse(Course course, int userId, int semesterId, bool isStudent, int tutorialId)
            : base(course, userId, semesterId, isStudent)
        {
            IsCompleted = false;
            CourseMark = 0.0;
            CourseGPA = 0.0;
            Tutorial = new Tutorial(tutorialId);
            AddStudentCourseToDatabase();
        }

        // Add the student course to the database
        private void AddStudentCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO studentCourse (courseAssociationId, isCompleted, courseMark, courseGPA, tutorialId) VALUES (@courseAssociationId, @isCompleted, @courseMark, @courseGPA, @tutorialId);"; // SQL query to insert student course

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@courseAssociationId", Id); // Use the generated ID from CourseAssociation
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted); // Set the isCompleted parameter
                    cmd.Parameters.AddWithValue("@courseMark", CourseMark); // Set the courseMarks parameter
                    cmd.Parameters.AddWithValue("@courseGPA", CourseGPA); // Set the courseGPA parameter
                    cmd.Parameters.AddWithValue("@tutorialId", Tutorial.Id);

                    cmd.ExecuteNonQuery(); // Execute the query
                }
            }
        }

        // Fetch courses from the database and initialize the course list
        private void LoadStudentCourseFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT isCompleted, courseMark, courseGPA, tutorialId FROM studentCourse WHERE courseAssociationId = @Id"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        if (reader.Read()) // Read each row
                        {
                            IsCompleted = reader.GetBoolean(0);
                            CourseMark = reader.GetDouble(1);
                            CourseGPA = reader.GetDouble(2);
                            Tutorial = new Tutorial(reader.GetInt32(3));
                        }
                    }
                }
            }
        }
    }
}
