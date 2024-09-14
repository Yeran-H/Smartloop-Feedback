using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Smartloop_Feedback.Objects.User_Object.Tutor
{
    public class Tutor : User
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database

        public Tutor(int tutorId, string name, string email, string password, byte[] profileImage)
            : base(tutorId, name, email, password, profileImage, false)
        {
        }

        public Tutor(int tutorId, string name, string email, string password, byte[] profileImage, bool x)
            : base(tutorId, name, email, password, profileImage, false)
        {
            AddTutorToDatabase();
        }

        private void AddTutorToDatabase()
        {
            // Insert the new tutor record into the database
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO tutor (name, email, tutorId, password, profileImage) VALUES (@name, @mail, @tutorId, @password, @profileImage)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@mail", Email);
                    cmd.Parameters.AddWithValue("@tutorId", Id);
                    cmd.Parameters.AddWithValue("@password", Password);
                    SqlParameter profileImageParam = new SqlParameter("@profileImage", SqlDbType.VarBinary);
                    profileImageParam.Value = ProfileImage != null ? ProfileImage : (object)DBNull.Value;
                    cmd.Parameters.Add(profileImageParam);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
