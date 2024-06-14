using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartloop_Feedback.Objects;
using System.Security.Policy;

namespace Smartloop_Feedback.Objects
{
    public class Course
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public int id {  get; set; }
        public int code { get; set; }
        public string title { get; set; }
        public int creditPoint { get; set; }
        public string description { get; set; }
        public int semesterId { get; set; }
        public int studentId { get; set; }
        public string canvasLink { get; set; }
        public List<Assessment> assessmentList { get; set; }
        public Course(int id, int code, string title, int creditPoint, string description, string canvasLink, int semesterId, int studentId) 
        { 
            this.id = id;
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.canvasLink = canvasLink;
            this.semesterId = semesterId;
            this.studentId = studentId;
            assessmentList = new List<Assessment>();
            getAssessmentFromDatabase();
        }
        public Course(int code, string title, int creditPoint, string description, string canvasLink, int semesterId, int studentId)
        {
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.canvasLink = canvasLink;
            this.semesterId = semesterId;
            this.studentId = studentId;
            addCourseToDatabase();
        }

        public Course(int code, string title, int creditPoint, string description, string canvasLink)
        {
            this.code = code;
            this.title = title;
            this.creditPoint = creditPoint;
            this.description = description;
            this.canvasLink = canvasLink;
        }

        public void addCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO course (code, title, creditPoint, description, canvasLink, semesterId, studentId) VALUES (@code, @title, @creditPoint, @description, @canvasLink, @semesterId, @studentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@creditPoint", creditPoint);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink);
                    cmd.Parameters.AddWithValue("@semesterId", semesterId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void getAssessmentFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, name, description, type, date, status, weight, mark FROM assessment WHERE courseId = @courseId AND studentId = @studentId", conn);
                cmd.Parameters.AddWithValue("@courseId", id);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        string type = reader.GetString(3);
                        DateTime date = reader.GetDateTime(4);
                        string status = reader.GetString(5);
                        int weight = reader.GetInt32(6);
                        int mark = reader.GetInt32(7);
                        assessmentList.Add(new Assessment(id, name, description, type, date, status, weight, mark, this.id, studentId));
                    }
                }
            }
        }
    }
}
