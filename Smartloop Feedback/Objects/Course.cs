using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class Course
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        public int Id { get; private set; } // Course ID
        public int Code { get; set; } // Course code
        public string Name { get; set; } // Course name
        public int CreditPoint { get; set; } // Course credit points
        public string Description { get; set; } // Course description
        public string Year { get; set; }
        public string Semester { get; set; }
        public string CanvasLink { get; set; }

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
    }
}
