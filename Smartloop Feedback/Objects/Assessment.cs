using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Smartloop_Feedback.Objects
{
    public class Assessment
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for assessment details
        public int Id { get; private set; } // Assessment ID
        public string Name { get; set; } // Assessment name
        public string Description { get; set; } // Assessment description
        public string CourseDescription { get; set; }
        public string Type { get; set; } // Assessment type
        public DateTime Date { get; set; } // Assessment date
        public int Status { get; set; } // Assessment status
        public double Weight { get; set; } // Assessment weight
        public double Mark { get; set; } // Assessment mark
        public double FinalMark { get; set; } // Final mark for the assessment
        public bool Individual { get; set; } // Is the assessment individual?
        public bool Group { get; set; } // Is the assessment group-based?
        public bool IsFinalised { get; set; } // Is the assessment finalised?
        public string CanvasLink { get; set; } // Link to the assessment's Canvas page
        public List<Criteria> CriteriaList { get; set; } // List of criteria for the assessment
        public List<CheckList> CheckList { get; set; } // List of checklist items for the assessment
        public SortedDictionary<int, FeedbackResult> FeedbackList { get; set; }
        public int CourseId { get; set; } // ID of the course associated with the assessment
        public int StudentId { get; set; } // ID of the student associated with the assessment

        // Constructor to initialize an Assessment object and fetch criteria and checklist from the database
        public Assessment(int id, string name, string description, string courseDescription, string type, DateTime date, int status, double weight, double mark, double finalMark, bool individual, bool group, bool isFinalised, string canvasLink, int courseId, int studentId)
        {
            Id = id;
            Name = name;
            Description = description;
            CourseDescription = courseDescription;
            Type = type;
            Date = date;
            Status = status;
            Weight = weight;
            Mark = mark;
            FinalMark = finalMark;
            Individual = individual;
            Group = group;
            IsFinalised = isFinalised;
            CanvasLink = canvasLink;
            CourseId = courseId;
            StudentId = studentId;
            CriteriaList = new List<Criteria>(); // Initialize the criteria list
            CheckList = new List<CheckList>(); // Initialize the checklist
            FeedbackList = new SortedDictionary<int, FeedbackResult>();
            LoadCriteriaFromDatabase(); // Fetch criteria from the database
            LoadCheckListFromDatabase(); // Fetch checklist from the database
            LoadFeedbackListFromDatabase();
        }

        // Constructor to initialize an Assessment object and add it to the database
        public Assessment(string name, string description, string courseDescription, string type, DateTime date, int status, double weight, double mark, double finalMark, bool individual, bool group, bool isFinalised, string canvasLink, int courseId, int studentId)
        {
            Name = name;
            Description = description;
            CourseDescription = courseDescription;
            Type = type;
            Date = date;
            Status = status;
            Weight = weight;
            Mark = mark;
            FinalMark = finalMark;
            Individual = individual;
            Group = group;
            IsFinalised = isFinalised;
            CanvasLink = canvasLink;
            CourseId = courseId;
            StudentId = studentId;
            CriteriaList = new List<Criteria>(); // Initialize the criteria list
            CheckList = new List<CheckList>(); // Initialize the checklist
            FeedbackList = new SortedDictionary<int, FeedbackResult>();
            AddAssessmentToDatabase(); // Add the assessment to the database
        }

        // Add the assessment to the database and get the generated ID
        private void AddAssessmentToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO assessment (name, description, courseDescription, type, date, status, weight, mark, finalMark, individual, [group], isFinalised, canvasLink, courseId, studentId) VALUES (@name, @description, @courseDescription, @type, @date, @status, @weight, @mark, @finalMark, @individual, @group, @isFinalised, @canvasLink, @courseId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@courseDescription", CourseDescription);
                    cmd.Parameters.AddWithValue("@type", Type); // Set the type parameter
                    cmd.Parameters.AddWithValue("@date", Date); // Set the date parameter
                    cmd.Parameters.AddWithValue("@status", Status); // Set the status parameter
                    cmd.Parameters.AddWithValue("@weight", Weight); // Set the weight parameter
                    cmd.Parameters.AddWithValue("@mark", Mark); // Set the mark parameter
                    cmd.Parameters.AddWithValue("@finalMark", FinalMark); // Set the final mark parameter
                    cmd.Parameters.AddWithValue("@individual", Individual); // Set the individual parameter
                    cmd.Parameters.AddWithValue("@group", Group); // Set the group parameter
                    cmd.Parameters.AddWithValue("@isFinalised", IsFinalised); // Set the isFinalised parameter
                    cmd.Parameters.AddWithValue("@canvasLink", CanvasLink); // Set the canvasLink parameter
                    cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
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
                SqlCommand cmd = new SqlCommand("SELECT id, description FROM criteria WHERE assessmentId = @assessmentId AND studentId = @studentId", conn); // SQL query to fetch criteria
                cmd.Parameters.AddWithValue("@assessmentId", Id); // Set the assessmentId parameter
                cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int criteriaId = reader.GetInt32(0); // Get the criteria ID
                        string criteriaDescription = reader.GetString(1); // Get the criteria description
                        CriteriaList.Add(new Criteria(criteriaId, criteriaDescription, Id, StudentId)); // Add the criteria to the criteria list
                    }
                }
            }
        }

        // Fetch checklist items from the database and initialize the checklist
        private void LoadCheckListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name, isChecked FROM checkList WHERE assessmentId = @assessmentId AND studentId = @studentId", conn); // SQL query to fetch checklist items
                cmd.Parameters.AddWithValue("@assessmentId", Id); // Set the assessmentId parameter
                cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int checkListId = reader.GetInt32(0); // Get the checklist item ID
                        string checkListName = reader.GetString(1); // Get the checklist item name
                        bool isChecked = reader.GetBoolean(2); // Get the checklist item status
                        CheckList.Add(new CheckList(checkListId, checkListName, isChecked, StudentId, Id)); // Add the checklist item to the checklist
                    }
                }
            }

            CalculateStatus(); // Calculate the status of the assessment based on checklist items
        }

        private void LoadFeedbackListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, attempt, teacherFeedback, fileName, fileData, notes, grade, feedback, nextStep, CriteriaRatings FROM feedbackResult WHERE assessmentId = @assessmentId AND studentId = @studentId",conn); 

                cmd.Parameters.AddWithValue("@assessmentId", Id); 
                cmd.Parameters.AddWithValue("@studentId", StudentId); 

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        int feedbackId = reader.GetInt32(0);
                        int attempt = reader.GetInt32(1);
                        string teacherFeedback = reader.GetString(2); 
                        string fileName = reader.GetString(3); 
                        byte[] fileData = (byte[])reader["fileData"]; 
                        string notes = reader.GetString(5); 
                        string grade = reader.GetString(6); 
                        string feedbackText = reader.GetString(7); 
                        string nextStep = reader.GetString(8); 
                        string criteriaRatingsJson = reader.GetString(9); 

                        Dictionary<string, string> criteriaRatings = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(criteriaRatingsJson);


                        FeedbackList.Add(attempt, new FeedbackResult(feedbackId, attempt, teacherFeedback, fileName, fileData, notes, grade, feedbackText, nextStep, criteriaRatings, StudentId, Id));
                    }
                }
            }
        }


        // Delete the assessment and related data from the database
        public void DeleteAssessmentFromDatabase()
        {
            foreach (CheckList checkList in CheckList)
            {
                checkList.DeleteCheckListFromDatabase();
            }

            foreach (Criteria criteria in CriteriaList)
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
                    // Add the parameter for assessment ID
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Calculate the status of the assessment based on checklist items
        public void CalculateStatus()
        {
            if (CheckList.Count != 0)
            {
                int count = CheckList.Count(item => item.IsChecked);
                Status = (int)((count / (double)CheckList.Count) * 100);
            }
            else
            {
                Status = 0;
            }
        }

        // Update the assessment details in the database
        public void UpdateAssessmentToDatabase(string description, DateTime date, bool isFinalised)
        {
            Description = description;
            Date = date;
            IsFinalised = isFinalised;

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
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@mark", Mark);
                    cmd.Parameters.AddWithValue("@finalMark", FinalMark);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@isFinalised", isFinalised);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update the assessment details in the database
        public void UpdateAssessmentToDatabase(string title, string description, DateTime date, string type, double mark, double weight, bool individual, bool group, string canvasLink)
        {
            foreach (Criteria criteria in CriteriaList)
            {
                criteria.DeleteCriteriaFromDatabase();
            }

            Name = title;
            Description = description;
            Date = date;
            Type = type;
            Mark = mark;
            Weight = weight;
            Individual = individual;
            Group = group;
            CanvasLink = canvasLink;

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
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@name", Name);
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
