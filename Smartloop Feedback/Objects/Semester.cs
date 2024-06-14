using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback
{
    public class Semester
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public string name {  get; set; }
        public int id { get; set; }
        public int yearId { get; set; }
        public int studentId { get; set; }
        public List<Course> courseList { get; set; }

        public Semester(string name, int id, int yearId, int studentId) 
        {
            this.name = name;
            this.id = id;
            this.yearId = yearId;
            this.studentId = studentId;
            courseList = new List<Course>();
            getCourseFromDatabase();
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
                string sql = "INSERT INTO semester (name, yearId, studentId) VALUES (@name, @yearId, @studentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@yearId", yearId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void getCourseFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, code, title, creditPoint, description FROM course WHERE semesterId = @semesterId AND studentId = @studentId", conn);
                cmd.Parameters.AddWithValue("@semesterId", id);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int code = reader.GetInt32(1);
                        string title = reader.GetString(2);
                        int creditPoint = reader.GetInt32(3);
                        string description = reader.GetString(4);
                        courseList.Add(new Course(id, code, title, creditPoint, description, this.id, studentId));
                    }
                }
            }
        }

        public int numCourse()
        {
            return courseList == null ? 0 : courseList.Count;
        }
    }
}
