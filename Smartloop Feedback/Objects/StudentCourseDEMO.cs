using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class StudentCourseDEMO
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for course details
        public int Id { get; private set; } // Course ID
        public int Code { get; set; } // Course code
        public string Title { get; set; } // Course title
        public int CreditPoint { get; set; } // Course credit points
        public string Description { get; set; } // Course description
        public bool IsCompleted { get; set; } // Completion status of the course
        public int SemesterId { get; set; } // ID of the semester associated with the course
        public int StudentId { get; set; } // ID of the student associated with the course
        public string CanvasLink { get; set; } // Link to the course's Canvas page
        public SortedDictionary<int, StudentAssessment> AssessmentList { get; private set; } // List of assessments for the course
        public SortedDictionary<int, Event> EventList { get; private set; } // List of events for the course

        // Constructor to initialize a Course object and fetch assessments from the database
        public StudentCourseDEMO(int id, int code, string title, int creditPoint, string description, bool isCompleted, string canvasLink, int semesterId, int studentId)
        {
            Id = id;
            Code = code;
            Title = title;
            CreditPoint = creditPoint;
            Description = description;
            IsCompleted = isCompleted;
            CanvasLink = canvasLink;
            SemesterId = semesterId;
            StudentId = studentId;
            AssessmentList = new SortedDictionary<int, StudentAssessment>(); // Initialize the assessment list
            EventList = new SortedDictionary<int, Event>(); // Initialize the event list
            LoadAssessmentsFromDatabase(); // Fetch assessments from the database
        }

        // Constructor to initialize a Course object and add it to the database
        public StudentCourseDEMO(int code, string title, int creditPoint, string description, bool isCompleted, string canvasLink, int semesterId, int studentId)
        {
            Code = code;
            Title = title;
            CreditPoint = creditPoint;
            Description = description;
            IsCompleted = isCompleted;
            CanvasLink = canvasLink;
            SemesterId = semesterId;
            StudentId = studentId;
            AssessmentList = new SortedDictionary<int, StudentAssessment>(); // Initialize the assessment list
            EventList = new SortedDictionary<int, Event>(); // Initialize the event list
            AddCourseToDatabase(); // Add the course to the database
        }

        // Constructor to initialize a Course object without interacting with the database
        public StudentCourseDEMO(int code, string title, int creditPoint, string description, bool isCompleted, string canvasLink)
        {
            Code = code;
            Title = title;
            CreditPoint = creditPoint;
            Description = description;
            IsCompleted = isCompleted;
            CanvasLink = canvasLink;
            AssessmentList = new SortedDictionary<int, StudentAssessment>(); // Initialize the assessment list
        }

        // Add the course to the database and get the generated ID
        private void AddCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO course (code, title, creditPoint, description, isCompleted, canvasLink, semesterId, studentId) VALUES (@code, @title, @creditPoint, @description, @isCompleted, @canvasLink, @semesterId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert course and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@code", Code); // Set the code parameter
                    cmd.Parameters.AddWithValue("@title", Title); // Set the title parameter
                    cmd.Parameters.AddWithValue("@creditPoint", CreditPoint); // Set the creditPoint parameter
                    cmd.Parameters.AddWithValue("@description", Description); // Set the description parameter
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted); // Set the isCompleted parameter
                    cmd.Parameters.AddWithValue("@canvasLink", CanvasLink); // Set the canvasLink parameter
                    cmd.Parameters.AddWithValue("@semesterId", SemesterId); // Set the semesterId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Fetch assessments from the database and initialize the assessment list
        private void LoadAssessmentsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, name, description, courseDescription, type, date, status, weight, mark, finalMark, individual, [group], isFinalised, canvasLink, finalFeedback FROM assessment WHERE courseId = @courseId AND studentId = @studentId", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@courseId", Id); // Set the courseId parameter
                cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter

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
                        int status = reader.GetInt32(6); // Get the assessment status
                        double weight = (double)reader.GetDecimal(7); // Get the assessment weight
                        double mark = (double)reader.GetDecimal(8); // Get the assessment mark
                        double finalMark = (double)reader.GetDecimal(9); // Get the final mark
                        bool individual = reader.GetBoolean(10); // Get the individual status
                        bool group = reader.GetBoolean(11); // Get the group status
                        bool isFinalised = reader.GetBoolean(12); // Get the finalised status
                        string canvasLink = reader.GetString(13); // Get the assessment canvas link
                        string finalFeedback = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);

                        // Add the assessment to the assessment list
                        AssessmentList.Add(assessmentId, new StudentAssessment(assessmentId, name, description, courseDescription, type, date, status, weight, mark, finalMark, individual, group, isFinalised, canvasLink, finalFeedback, Id, StudentId));
                    }
                }
            }
        }

        // Update the course details in the database
        public void UpdateCourseToDatabase(int code, string title, int creditPoint, string description, string canvasLink)
        {
            Code = code;
            Title = title;
            CreditPoint = creditPoint;
            Description = description;
            CanvasLink = canvasLink;

            foreach(StudentAssessment assessment in AssessmentList.Values)
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
                        title = @title,
                        creditPoint = @creditPoint,
                        description = @description,
                        canvasLink = @canvasLink
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@creditPoint", creditPoint);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete the course and related data from the database
        public void DeleteCourseFromDatabase()
        {
            LoadEventsFromDatabase();

            // Delete all assessments associated with the course
            foreach (StudentAssessment assessment in AssessmentList.Values)
            {
                assessment.DeleteAssessmentFromDatabase();
            }

            // Delete all events associated with the course
            foreach (Event ev in EventList.Values)
            {
                ev.DeleteEventFromDatabase();
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

        // Delete an assessment from the database
        public void DeleteAssessmentFromDatabase(int assessmentId)
        {
            if (AssessmentList.ContainsKey(assessmentId))
            {
                AssessmentList[assessmentId].DeleteAssessmentFromDatabase(); // Delete the assessment from the database
                AssessmentList.Remove(assessmentId); // Remove the assessment from the list
            }
        }

        // Fetch events from the database and initialize the event list
        public void LoadEventsFromDatabase()
        {
            EventList.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, name, date, startTime, endTime, category, color FROM event WHERE courseId = @courseId ORDER BY date", conn);
                cmd.Parameters.AddWithValue("@courseId", Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime date = reader.GetDateTime(2);
                        TimeSpan startTime = reader.GetTimeSpan(3);
                        TimeSpan endTime = reader.GetTimeSpan(4);
                        string category = reader.GetString(5);
                        int color = reader.GetInt32(6);
                        EventList.Add(id, new Event(id, name, date, startTime, endTime, StudentId, Id, category, color));
                    }
                }
            }
        }

        // Update an event in the database
        public void UpdateEvent(Event selectedEvent)
        {
            if (EventList.ContainsKey(selectedEvent.Id))
            {
                EventList[selectedEvent.Id].UpdateEventInDatabase(selectedEvent);
            }
        }

        public bool WeightTotal(double weight)
        {
            double total = weight;

            foreach(StudentAssessment assessment in  AssessmentList.Values)
            {
                total += assessment.Weight;
            }

            return total > 100;
        }

        // Calculate the current mark for the course
        public double CalculateCurrentMark()
        {
            double totalWeightedMarks = 0.0;
            double totalWeight = 0.0;

            foreach (var assessment in AssessmentList.Values)
            {
                if (assessment.IsFinalised && assessment.Weight > 0)
                {
                    totalWeightedMarks += (assessment.FinalMark / assessment.Mark) * assessment.Weight;
                    totalWeight += assessment.Weight;
                }
            }

            return totalWeight > 0 ? (totalWeightedMarks / totalWeight) * 100 : 0.0;
        }

        // Calculate the target mark required for the course
        public double CalculateTargetMark(double targetMark)
        {
            double totalWeightedMarks = 0.0;
            double totalWeight = 0.0;
            double remainingWeight = 0.0;

            foreach (var assessment in AssessmentList.Values)
            {
                if (assessment.IsFinalised && assessment.Weight > 0)
                {
                    totalWeightedMarks += (assessment.FinalMark / assessment.Mark) * assessment.Weight;
                    totalWeight += assessment.Weight;
                }
                else
                {
                    remainingWeight += assessment.Weight;
                }
            }

            remainingWeight += 100 - totalWeight - remainingWeight;

            if (remainingWeight == 0)
            {
                // All assessments are finalized
                double currentMark = totalWeight > 0 ? totalWeightedMarks / totalWeight : 0.0;
                IsCompleted = true;
                return currentMark >= targetMark ? 0.0 : double.NaN; // Return NaN if it's not possible to achieve the target
            }
            else
            {
                IsCompleted = false;
            }

            double requiredTotalMarks = targetMark * (totalWeight + remainingWeight);
            double requiredAdditionalMarks = requiredTotalMarks - totalWeightedMarks;

            return (requiredAdditionalMarks / remainingWeight) * 100;
        }
    }
}
