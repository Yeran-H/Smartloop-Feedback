using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects.Updated.User_Object.Student
{
    internal class Student : User
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        // Public properties for student details
        public string Degree { get; set; } // Student's degree

        // Constructor to initialize a Student object with details and fetch years and events from the database
        public Student(int studentId, string name, string email, string password, string degree, byte[] profileImage)
            : base(studentId, name, email, password, profileImage, true)
        {
            Degree = degree;
        }

        public Student(int studentId, string name, string email, string password, string degree, byte[] profileImage, bool x)
        : base(studentId, name, email, password, profileImage, true)
        {
            Degree = degree;
            AddStudentToDatabase();
        }

        private void AddStudentToDatabase()
        {
            // Insert the new student record into the database
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO student (name, email, studentId, password, degree, profileImage) VALUES (@name, @mail, @studentId, @password, @degree, @profileImage)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@mail", Email);
                    cmd.Parameters.AddWithValue("@studentId", Id);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@degree", Degree);
                    SqlParameter profileImageParam = new SqlParameter("@profileImage", SqlDbType.VarBinary);
                    profileImageParam.Value = ProfileImage != null ? ProfileImage : (object)DBNull.Value;
                    cmd.Parameters.Add(profileImageParam);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
