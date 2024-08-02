using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using ZstdSharp.Unsafe;

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
        public int status { get; set; }
        public double weight { get; set; }
        public double mark { get; set; }
        public double finalMark { get; set; }
        public bool individual { get; set; }
        public bool group { get; set; }
        public bool isFinalised { get; set; }
        public string canvasLink { get; set; }
        public List<Criteria> criteriaList { get; set; } // List of criteria for the assessment
        public List<CheckList> checkList { get; set; }
        public int courseId { get; set; }
        public int studentId { get; set; }

        // Constructor to initialize an Assessment object and fetch criteria from the database
        public Assessment(int id, string name, string description, string type, DateTime date, int status, double weight, double mark, double finalMark, bool individual, bool group, bool isFinalised, string canvasLink, int courseId, int studentId)
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
            this.isFinalised = isFinalised;
            this.canvasLink = canvasLink;
            this.courseId = courseId;
            this.studentId = studentId;
            criteriaList = new List<Criteria>(); // Initialize the criteria list
            checkList = new List<CheckList>();
            GetCriteriaFromDatabase(); // Fetch criteria from the database
            GetCheckListFromDatabase();
        }

        // Constructor to initialize an Assessment object and add it to the database
        public Assessment(string name, string description, string type, DateTime date, int status, int weight, int mark, double finalMark, bool individual, bool group, bool isFinalised, string canvasLink, int courseId, int studentId)
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
            this.isFinalised = isFinalised;
            this.canvasLink = canvasLink;
            this.courseId = courseId;
            this.studentId = studentId;
            criteriaList = new List<Criteria>(); // Initialize the criteria list
            checkList = new List<CheckList>();
            AddAssessmentToDatabase(); // Add the assessment to the database
        }

        // Add the assessment to the database and get the generated ID
        public void AddAssessmentToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO assessment (name, description, type, date, status, weight, mark, finalMark, individual, [group], isFinalised, canvasLink, courseId, studentId) VALUES (@name, @description, @type, @date, @status, @weight, @mark, @finalMark, @individual, @group, @isFinalised, @canvasLink, @courseId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

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
                    cmd.Parameters.AddWithValue("@isFinalised", isFinalised);
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
                        criteriaList.Add(new Criteria(criteriaId, criteriaDescription, this.id, studentId)); // Add the criteria to the criteria list
                    }
                }
            }
        }

        private void GetCheckListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name, isChecked FROM checkList WHERE assessmentId = @assessmentId AND studentId = @studentId", conn); // SQL query to fetch criteria
                cmd.Parameters.AddWithValue("@assessmentId", id); // Set the assessmentId parameter
                cmd.Parameters.AddWithValue("@studentId", studentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int checkListId = reader.GetInt32(0);
                        string checkListName = reader.GetString(1);
                        bool isChecked = reader.GetBoolean(2);
                        checkList.Add(new CheckList(checkListId, checkListName, isChecked, id, studentId));
                    }
                }
            }

            CalculateStatus();
        }

        public void DeleteAssessmentFromDatabase()
        {
            foreach (CheckList checkList in checkList)
            {
                checkList.DeleteCheckListFromDatabase();
            }

            foreach (Criteria criteria in criteriaList)
            {
                criteria.DeleteCriteriaFromDatabase();
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM assessment
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for studentId
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CalculateStatus()
        {
            if (checkList.Count != 0)
            {
                int count = checkList.Count(item => item.isChecked);
                status = (int)((count / (double)checkList.Count) * 100);
            }
            else
            {
                status = 0;
            }
        }

        public void UpdateToDatabase(string description, DateTime date, bool isFinalised)
        {
            this.description = description;
            this.date = date;
            this.isFinalised = isFinalised;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE assessment
                    SET 
                        mark = @mark,
                        finalMark = @finalMark,
                        description = @description,
                        date = @date,
                        isFinalised = @isFinalised
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@mark", mark);
                    cmd.Parameters.AddWithValue("@finalMark", finalMark);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@isFinalised", isFinalised);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAssessmentToDatabase(string title, string description, DateTime date, string type, double mark, double weight, bool individual, bool group, string canvasLink)
        {
            foreach (Criteria criteria in criteriaList)
            {
                criteria.DeleteCriteriaFromDatabase();
            }


            this.name = title;
            this.description = description;
            this.date = date;
            this.type = type;
            this.mark = mark;
            this.weight = weight;
            this.individual = individual;
            this.group = group;
            this.canvasLink = canvasLink;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE assessment
                    SET 
                        name = @name,
                        description = @description,
                        date = @date,
                        type = @type,
                        mark = @mark,
                        weight = @weight,
                        individual = @individual,
                        group = @group,
                        canvasLink = @canvasLink
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@mark", mark);
                    cmd.Parameters.AddWithValue("@weight", weight);
                    cmd.Parameters.AddWithValue("@individual", individual);
                    cmd.Parameters.AddWithValue("@group", group);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
