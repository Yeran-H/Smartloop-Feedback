﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Crypto.Paddings;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Smartloop_Feedback.Objects
{
    public class Assessment
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourseDescription { get; set; }
        public string Type { get; set; }
        public DateTime Date {  get; set; }
        public double Weight { get; set; }
        public double Mark {  get; set; }
        public string CanvasLink { get; set; }
        public List<Criteria> CriteriaList { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int CourseId { get; set; }

        public Assessment(int id, string name, string description, string courseDescription, string type, DateTime date, double weight, double mark, string canvasLink, string fileName, byte[] fileData, int courseId)
        {
            Id = id;
            Name = name;
            Description = description;
            CourseDescription = courseDescription;
            Type = type;
            Date = date;
            Weight = weight;
            Mark = mark;
            CanvasLink = canvasLink;
            FileName = fileName;
            FileData = fileData;
            CourseId = courseId;
            CriteriaList = new List<Criteria>();
            LoadCriteriaFromDatabase(); // Fetch criteria from the database
        }

        public Assessment(string name, string description, string courseDescription, string type, DateTime date, double weight, double mark, string canvasLink, string fileName, byte[] fileData, int courseId)
        {
            Name = name;
            Description = description;
            CourseDescription = courseDescription;
            Type = type;
            Date = date;
            Weight = weight;
            Mark = mark;
            CanvasLink = canvasLink;
            FileName = fileName;
            FileData = fileData;
            CourseId = courseId;
            CriteriaList = new List<Criteria>();
            AddAssessmentToDatabase();
        }

        // Add the assessment to the database and get the generated ID
        private void AddAssessmentToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO assessment (name, description, courseDescription, type, date, weight, mark, canvasLink, fileName, fileData, courseId) VALUES (@name, @description, @courseDescription, @type, @date, @weight, @mark, @canvasLink, @fileName, @fileData, @courseId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@courseDescription", CourseDescription);
                    cmd.Parameters.AddWithValue("@type", Type); // Set the type parameter
                    cmd.Parameters.AddWithValue("@date", Date); // Set the date parameter
                    cmd.Parameters.AddWithValue("@weight", Weight); // Set the weight parameter
                    cmd.Parameters.AddWithValue("@mark", Mark); // Set the mark parameter
                    cmd.Parameters.AddWithValue("@canvasLink", CanvasLink); // Set the canvasLink parameter
                    cmd.Parameters.AddWithValue("@fileName", (object)FileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fileData", (object)FileData ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch criteria from the database and initialize the criteria list
        private void LoadCriteriaFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, description FROM criteria WHERE assessmentId = @assessmentId", conn); // SQL query to fetch criteria
                cmd.Parameters.AddWithValue("@assessmentId", Id); // Set the assessmentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int criteriaId = reader.GetInt32(0); // Get the criteria ID
                        string criteriaDescription = reader.GetString(1); // Get the criteria description
                        CriteriaList.Add(new Criteria(criteriaId, criteriaDescription, Id)); // Add the criteria to the criteria list
                    }
                }
            }
        }

        public void UpdateAssessmentToDatabase(string courseDescription)
        {
            CourseDescription = courseDescription;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE assessment
                    SET 
                        courseDescription = @courseDescription,
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@courseDescription", CourseDescription);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
