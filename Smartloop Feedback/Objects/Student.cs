using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public class Student
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public string name { get; set; }
        public string email { get; set; }
        public int studentId { get; set; }
        public string password { get; set; }
        public string degree { get; set; }
        public byte[] profileImage { get; set; }
        public List<Year> yearList {  get; set; }

        public Student(int studentId, string name, string email, string degree, string password, byte[] profileImage)
        {
            this.name = name;
            this.email = email;
            this.studentId = studentId;
            this.password = password;
            this.degree = degree;
            this.profileImage = profileImage;
            yearList = new List<Year>();
            getYearFromDatabase();
        }

        public Student() { }

        private void getYearFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT name, id FROM year WHERE studentId = @studentId", conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        yearList.Add(new Year(name, studentId, id));
                    }
                }
            }
        }

        public bool ValidatePassword()
        {
            return password.Length >= 8;
        }

        public bool ValidateStudentId()
        {
            string studentIdStr = studentId.ToString();
            return studentIdStr.Length == 8;
        }

        public bool ValidateEmail()
        {
            return email.EndsWith("@student.uts.edu.au", StringComparison.OrdinalIgnoreCase) || email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        public int numYears()
        {
            return yearList == null ? 0 : yearList.Count;
        }

        public bool uniqueYear(string name)
        {
            foreach (Year year in yearList)
            {
                if(year.name ==  name)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
