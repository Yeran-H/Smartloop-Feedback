using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace Smartloop_Feedback.Objects.Updated
{
    public class User
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfileImage { get; set; }
        public bool IsStudent { get; set; }

        public User(int id, string name, string email, string password, byte[] profileImage, bool isStudent)
        {
            Email = email;
            Password = password;
            Id = id;
            Name = name;
            ProfileImage = profileImage;
            IsStudent = isStudent;
            //YearList = new SortedDictionary<int, Year>();
        }

        public bool ValidateUserInput()
        {
            return ValidateEmail() && ValidatePassword() && !ValidateId();
        }

        public bool ValidatePassword()
        {
            if (Password.Length >= 8)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ValidateId()
        {
            string IdStr = Id.ToString();

            // Check if the length of the Id is 8 charaters long
            if (IdStr.Length != 8)
            {
                MessageBox.Show("Student ID must be 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool exists = false;

            if (IsStudent)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM student WHERE studentId = @Id"; // SQL query to check if studentId exists
                    using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                    {
                        cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                        exists = (int)cmd.ExecuteScalar() > 0; // Execute the query and check if any row exists
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM tutor WHERE tutorId = @Id"; // SQL query to check if studentId exists
                    using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                    {
                        cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                        exists = (int)cmd.ExecuteScalar() > 0; // Execute the query and check if any row exists
                    }
                }
            }

            if (exists)
            {
                MessageBox.Show("Id must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return exists;
        }

        public bool ValidateEmail()
        {
            if (!Email.EndsWith("@student.uts.edu.au", StringComparison.OrdinalIgnoreCase) && !Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) && !Email.EndsWith("@uts.edu.au", StringComparison.OrdinalIgnoreCase))
            {
                string domainError = IsStudent ? "@student.uts.edu.au or @gmail.com" : "@uts.edu.au or @gmail.com";
                MessageBox.Show($"Email must end with {domainError}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
