using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Smartloop_Feedback.Objects.Updated.User_Object
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
        public SortedDictionary<int, YearAssociation> YearList { get; set; }

        public User(int id, string name, string email, string password, byte[] profileImage, bool isStudent)
        {
            Email = email;
            Password = password;
            Id = id;
            Name = name;
            ProfileImage = profileImage;
            IsStudent = isStudent;
            YearList = new SortedDictionary<int, YearAssociation>();
            LoadYearsFromDatabase();
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

        // Private method to fetch years from the database for the student
        private void LoadYearsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT id, name FROM yearAssociation WHERE id = @id ORDER BY name"; // SQL query to fetch years
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@id", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        while (reader.Read()) // Read each row
                        {
                            int id = reader.GetInt32(0); // Get the year name
                            int yearName = reader.GetInt32(1); // Get the year ID
                            YearList.Add(yearName, new YearAssociation(id, yearName, Id, IsStudent)); // Add the year to the year list
                        }
                    }
                }
            }
        }

        // Check if a year name is unique within the student's year list
        public bool UniqueYear(int name)
        {
            return !YearList.ContainsKey(name);
        }
    }
}
