using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartloop_Feedback
{
    public class Semester
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public string name {  get; set; }
        public int id { get; set; }
        public int yearId { get; set; }
        public int studentId { get; set; }

        public Semester(string name, int id, int yearId, int studentId) 
        {
            this.name = name;
            this.id = id;
            this.yearId = yearId;
            this.studentId = studentId;
        }

        public Semester(string name, int yearId, int studentId)
        {
            this.name = name;
            this.yearId = yearId;
            this.studentId = studentId;
            addSemesterToDatabase();
        }

        public void addSemesterToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO semester (name, yearId, studentId) VALUES (@name, @yearId, @studentId)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@yearId", yearId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
