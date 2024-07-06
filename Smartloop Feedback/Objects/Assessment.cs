using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Smartloop_Feedback.Objects
{
    public class Assessment
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for assessment details
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public int weight { get; set; }
        public int mark { get; set; }
        public int finalMark { get; set; }
        public bool individual { get; set; }
        public bool group { get; set; }
        public string canvasLink { get; set; }
        public Dictionary<int, Criteria> criteriaList { get; set; } // List of criteria for the assessment
        public int courseId { get; set; }
        public int studentId { get; set; }

        // Constructor to initialize an Assessment object and fetch criteria from the database
        public Assessment(int id, string name, string description, string type, DateTime date, string status, int weight, int mark, int finalMark, bool individual, bool group, string canvasLink, int courseId, int studentId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.type = type;
            this.date = date;
            this.status = status;
            this.weight = weight;
            this.mark = mark;
            this.finalMark = finalMark;
            this.individual = individual;
            this.group = group;
            this.canvasLink = canvasLink;
            this.courseId = courseId;
            this.studentId = studentId;
            criteriaList = new Dictionary<int, Criteria>(); // Initialize the criteria list
            GetCriteriaFromDatabase(); // Fetch criteria from the database
        }

        // Constructor to initialize an Assessment object and add it to the database
        public Assessment(string name, string description, string type, DateTime date, string status, int weight, int mark, int finalMark, bool individual, bool group, string canvasLink, int courseId, int studentId)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.date = date;
            this.status = status;
            this.weight = weight;
            this.mark = mark;
            this.finalMark = finalMark;
            this.individual = individual;
            this.group = group;
            this.canvasLink = canvasLink;
            this.courseId = courseId;
            this.studentId = studentId;
            criteriaList = new Dictionary<int, Criteria>(); // Initialize the criteria list
            AddAssessmentToDatabase(); // Add the assessment to the database
        }

        // Add the assessment to the database and get the generated ID
        public void AddAssessmentToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO assessment (name, description, type, date, status, weight, mark, finalMark, individual, [group], canvasLink, courseId, studentId) VALUES (@name, @description, @type, @date, @status, @weight, @mark, @totalMark, @individual, @group, @canvasLink, @courseId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@description", description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@type", type); // Set the type parameter
                    cmd.Parameters.AddWithValue("@date", date); // Set the date parameter
                    cmd.Parameters.AddWithValue("@status", status); // Set the status parameter
                    cmd.Parameters.AddWithValue("@weight", weight); // Set the weight parameter
                    cmd.Parameters.AddWithValue("@mark", mark); // Set the mark parameter
                    cmd.Parameters.AddWithValue("@finalMark", finalMark);
                    cmd.Parameters.AddWithValue("@individual", individual); // Set the individual parameter
                    cmd.Parameters.AddWithValue("@group", group); // Set the group parameter
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink); // Set the canvasLink parameter
                    cmd.Parameters.AddWithValue("@courseId", courseId); // Set the courseId parameter
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter
                    id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch criteria from the database and initialize the criteria list
        private void GetCriteriaFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, description FROM criteria WHERE assessmentId = @assessmentId AND studentId = @studentId", conn); // SQL query to fetch criteria
                cmd.Parameters.AddWithValue("@assessmentId", id); // Set the assessmentId parameter
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int criteriaId = reader.GetInt32(0); // Get the criteria ID
                        string criteriaDescription = reader.GetString(1); // Get the criteria description
                        criteriaList.Add(criteriaId, new Criteria(criteriaId, criteriaDescription, this.id, studentId)); // Add the criteria to the criteria list
                    }
                }
            }
        }
    }
}
