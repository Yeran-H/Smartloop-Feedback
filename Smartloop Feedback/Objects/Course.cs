using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartloop_Feedback.Objects;

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
    }
}
