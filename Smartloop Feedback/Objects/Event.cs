using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace Smartloop_Feedback.Objects
{
    public class Event
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public int id {  get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int studentId { get; set; }
        public int courseId { get; set; }
        public string category { get; set; }
        public int color { get; set; }

        public Event(int id, string name, DateTime date, int studentId, int courseId, string category, int color)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.studentId = studentId;
            this.courseId = courseId;
            this.category = category;
            this.color = color;
        }

        public Event(string name, DateTime date, string category, int color, int studentId, int courseId)
        {
            this.name = name;
            this.date = date;
            this.studentId = studentId;
            this.courseId = courseId;
            this.category = category;
            this.color = color;
            AddEventToDatabase();
        }

        public Event(string name, DateTime date, string category, int color)
        { 
            this.name = name;
            this.date = date;
            this.category = category;
            this.color = color;
        }

        public void AddEventToDatabase()
        {
            if(category == "None")
            {
                courseId = 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO event (name, date, category, color, courseId, studentId) VALUES (@name, @date, @category, @color, @courseId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@courseId", courseId); // Set the courseId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }
    }
}
