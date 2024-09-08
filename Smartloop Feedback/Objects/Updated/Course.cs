﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Crypto.Paddings;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class Course
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        public int Id { get; set; } // Course ID
        public int Code { get; set; } // Course code
        public string Name { get; set; } // Course name
        public int CreditPoint { get; set; } // Course credit points
        public string Description { get; set; } // Course description
        public string Year { get; set; }
        public string Semester { get; set; }
        public string CanvasLink { get; set; }
        public Dictionary<int, Assessment> AssessmentList { get; set; }

        public Course(int id, int code, string name, int creditPoint, string description, string Year, string Semester, string CanvasLink)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.CreditPoint = creditPoint;
            this.Description = description;
            this.Year = Year;
            this.Semester = Semester;
            this.CanvasLink = CanvasLink;
            AssessmentList = new Dictionary<int, Assessment>();
            LoadAssessmentsFromDatabase();
        }

        public Course(int code, string name, int creditPoint, string description, string Year, string Semester, string CanvasLink)
        {
            this.Code = code;
            this.Name = name;
            this.CreditPoint = creditPoint;
            this.Description = description;
            this.Year = Year;
            this.Semester = Semester;
            this.CanvasLink = CanvasLink;
            AssessmentList = new Dictionary<int, Assessment>();
            AddCourseToDatabase();
        }

        // Add the course to the database and get the generated ID
        private void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO course (code, name, creditPoint, description, year, semester, canvasLink) VALUES (@code, @name, @creditPoint, @description, @year, @semester, @canvasLink); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@code", Code); // Set the code parameter
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@creditPoint", CreditPoint); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@year", Year);
                    cmd.Parameters.AddWithValue("@semester", Semester);
                    cmd.Parameters.AddWithValue("@canvasLink", CanvasLink); // Set the canvasLink parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        public void UpdateCourseToDatabase(int code, string name, int creditPoint, string description, string year, string semester, string canvasLink)
        {
            Code = code;
            Name = name;
            CreditPoint = creditPoint;
            Description = description;
            Year = year;
            Semester = semester;
            CanvasLink = canvasLink;

            foreach (Assessment assessment in AssessmentList.Values)
            {
                assessment.UpdateAssessmentToDatabase(Description);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE course
                    SET 
                        code = @code,
                        name = @name,
                        creditPoint = @creditPoint,
                        description = @description,
                        year = @year,
                        semester = @semester,
                        canvasLink = @canvasLink
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@creditPoint", creditPoint);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@semester", semester);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Fetch assessments from the database and initialize the assessment list
        private void LoadAssessmentsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name, description, courseDescription, type, date, weight, mark, canvasLink, fileName, fileData FROM assessment WHERE courseId = @courseId", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@courseId", Id); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int assessmentId = reader.GetInt32(0); // Get the assessment ID
                        string name = reader.GetString(1); // Get the assessment name
                        string description = reader.GetString(2); // Get the assessment description
                        string courseDescription = reader.GetString(3);
                        string type = reader.GetString(4); // Get the assessment type
                        DateTime date = reader.GetDateTime(5); // Get the assessment date
                        double weight = (double)reader.GetDecimal(6); // Get the assessment weight
                        double mark = (double)reader.GetDecimal(7); // Get the assessment mark
                        string canvasLink = reader.GetString(8); // Get the assessment canvas link
                        string fileName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        byte[] fileData = reader["fileData"] == DBNull.Value ? null : (byte[])reader["fileData"];


                        // Add the assessment to the assessment list
                        AssessmentList.Add(assessmentId, new Assessment(assessmentId, name, description, courseDescription, type, date, weight, mark, canvasLink, fileName, fileData, Id));
                    }
                }
            }
        }

        public bool WeightTotal(double weight)
        {
            double total = weight;

            foreach (Assessment assessment in AssessmentList.Values)
            {
                total += assessment.Weight;
            }

            return total > 100;
        }
    }
}
