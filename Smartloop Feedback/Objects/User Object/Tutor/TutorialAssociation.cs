using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects.User_Object.Tutor
{
    public class TutorialAssociation : Tutorial
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public Dictionary<int, StudentCourse> StudentList { get; set; }
        public string GeneralFeedback {  get; set; }
        public bool IsCompleted { get; set; }

        public TutorialAssociation(int id)
            :base(id) 
        {
            StudentList = new Dictionary<int, StudentCourse>();
            LoadTutorialAssociationFromDatabase();
            LoadStudentAssessment();
        }

        public TutorialAssociation(int id, bool x)
            : base(id)
        {
            GeneralFeedback = "";
            IsCompleted = false;
            StudentList = new Dictionary<int, StudentCourse>();
            AddTutorialAssociationToDatabase();
            LoadStudentAssessment();
        }

        private void AddTutorialAssociationToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO tutorialAssociation (tutorialId, generalFeedback, isCompleted) VALUES (@tutorialId, @generalFeedback, @isCompleted);"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@tutorialId", Id); 
                    cmd.Parameters.AddWithValue("@generalFeedback", GeneralFeedback);
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted);
                }
            }
        }

        private void LoadTutorialAssociationFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT generalFeedback, isCompleted FROM tutorialAssociation WHERE tutorialId = @Id", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@Id", Id); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    if (reader.Read()) // Read each row
                    {
                        GeneralFeedback = reader.GetString(0);
                        IsCompleted = reader.GetBoolean(1);
                    }
                }
            }
        }

        private void LoadStudentAssessment()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT ca.id, ca.courseId, ca.studentId, ca.semesterId, ca.isStudent FROM courseAssociation ca JOIN studentCourse sc ON ca.id = sc.courseAssociationId WHERE ca.courseId = @courseId AND sc.tutorialId = @tutorialId", conn); // Updated SQL query to fetch assessments

                cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter
                cmd.Parameters.AddWithValue("@tutorialId", Id); // Set the tutorialId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        StudentList.Add(reader.GetInt32(0), new StudentCourse(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetBoolean(4)));
                    }
                }
            }
        }

    }
}
