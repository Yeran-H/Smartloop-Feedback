using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Crypto.Paddings;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;

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
        public Year Year { get; set; }
        public Semester Semester { get; set; }
        public string CanvasLink { get; set; }
        public int TutorNum { get; set; }
        public Dictionary<int, Assessment> AssessmentList { get; set; }
        public Dictionary<int, Tutorial> TutorialList { get; set; }

        public Course(int id, int code, string name, int creditPoint, string description, int yearName, string semesterName, string CanvasLink, int tutorNum)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.CreditPoint = creditPoint;
            this.Description = description;
            this.CanvasLink = CanvasLink;
            this.TutorNum = tutorNum;
            AssessmentList = new Dictionary<int, Assessment>();
            TutorialList = new Dictionary<int, Tutorial>();
            Year = new Year(yearName);
            Semester = new Semester(semesterName, Year.Name);
            LoadAssessmentsFromDatabase();
            LoadTutorialFromDatabase();
        }

        public Course(int code, string name, int creditPoint, string description, int yearName, string semesterName, string CanvasLink, int tutorNum)
        {
            this.Code = code;
            this.Name = name;
            this.CreditPoint = creditPoint;
            this.Description = description;
            this.CanvasLink = CanvasLink;
            AssessmentList = new Dictionary<int, Assessment>();
            this.TutorNum = tutorNum;
            TutorialList = new Dictionary<int, Tutorial>();
            Year = new Year(yearName);
            Semester = new Semester(semesterName, Year.Name);
            AddCourseToDatabase();
            AddTutorialFromDatabase(false);
        }

        // Add the course to the database and get the generated ID
        private void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO course (code, name, creditPoint, description, yearName, semesterId, canvasLink) VALUES (@code, @name, @creditPoint, @description, @yearName, @semesterId, @canvasLink); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@code", Code); // Set the code parameter
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@creditPoint", CreditPoint); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@yearName", Year.Name);
                    cmd.Parameters.AddWithValue("@semesterId", Semester.Id);
                    cmd.Parameters.AddWithValue("@canvasLink", CanvasLink); // Set the canvasLink parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        public void AddTutorialFromDatabase(bool flag)
        {
            if(TutorNum == 0 || flag)
            {
                Tutorial tutorial = new Tutorial("0", Id);
                TutorialList.Add(tutorial.Id, tutorial);
                return;
            }

            for (int i = 1; i <= TutorNum; i++)
            {
                Tutorial tutorial = new Tutorial(i.ToString(), Id);
                TutorialList.Add(tutorial.Id, tutorial);
            }
        }

        public void UpdateCourseToDatabase(int code, string name, int creditPoint, string description, int year, string semester, string canvasLink)
        {
            Code = code;
            Name = name;
            CreditPoint = creditPoint;
            Description = description;
            Year = new Year(year);
            Semester = new Semester(semester, Year.Name);
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
                        yearName = @yearName,
                        semesterId = @semesterId,
                        canvasLink = @canvasLink,
                        tutorNum = @tutorNum,
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
                    cmd.Parameters.AddWithValue("@yearName", Year.Name);
                    cmd.Parameters.AddWithValue("@semesterId", Semester.Id);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink);
                    cmd.Parameters.AddWithValue("@tutorNum", TutorNum);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete the course and related data from the database
        public void DeleteCourseFromDatabase()
        {
            // Delete all assessments associated with the course
            foreach (Assessment assessment in AssessmentList.Values)
            {
                assessment.DeleteAssessmentFromDatabase();
            }

            // Delete all assessments associated with the course
            foreach (Tutorial tutorial in TutorialList.Values)
            {
                tutorial.DeleteTutorialFromDatabase();
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM course
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add the parameter for course ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
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

        // Fetch assessments from the database and initialize the assessment list
        private void LoadTutorialFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name FROM tutorial WHERE courseId = @courseId", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@courseId", Id); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int tutorialId = reader.GetInt32(0); // Get the tutorial id
                        string name = reader.GetString(1); // Get the assessment name

                        // Add the assessment to the assessment list
                        TutorialList.Add(tutorialId, new Tutorial(tutorialId, name, Id));
                    }
                }
            }
        }

        // Delete an assessment from the database
        public void DeleteAssessmentFromDatabase(int assessmentId)
        {
            if (AssessmentList.ContainsKey(assessmentId))
            {
                AssessmentList[assessmentId].DeleteAssessmentFromDatabase(); // Delete the assessment from the database
                AssessmentList.Remove(assessmentId); // Remove the assessment from the list
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
