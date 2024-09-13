using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Asn1.X509;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;

namespace Smartloop_Feedback.Objects.Updated.User_Object.Student
{
    public class StudentCourse : CourseAssociation
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
        public bool IsCompleted { get; set; }
        public double CourseMark { get; set; }
        public Tutorial Tutorial { get; set; }
        public SortedDictionary<int, StudentAssessment> StudentAssessmentList { get; set; }
        public SortedDictionary<int, Event> EventList { get; private set; }

        public StudentCourse(int id, int courseId, int userId, int semesterId, bool isStudent)
            : base(id, courseId, userId, semesterId, isStudent)
        {
            LoadStudentCourseFromDatabase();

            StudentAssessmentList = new SortedDictionary<int, StudentAssessment>();
            EventList = new SortedDictionary<int, Event>();
            LoadAssessmentFromDatabase();
        }

        public StudentCourse(int courseId, int userId, int semesterId, bool isStudent, int tutorialId)
            : base(courseId, userId, semesterId, isStudent)
        {
            IsCompleted = false;
            CourseMark = 0.00;
            Tutorial = new Tutorial(tutorialId);
            AddStudentCourseToDatabase();

            StudentAssessmentList = new SortedDictionary<int, StudentAssessment>();
            EventList = new SortedDictionary<int, Event>();
            AddAssessmentToDatabase();
        }

        // Add the student course to the database
        private void AddStudentCourseToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO studentCourse (courseAssociationId, isCompleted, courseMark, tutorialId, userId) VALUES (@courseAssociationId, @isCompleted, @courseMark, @tutorialId, @userId);"; // SQL query to insert student course

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@courseAssociationId", Id); // Use the generated ID from CourseAssociation
                    cmd.Parameters.AddWithValue("@isCompleted", IsCompleted); // Set the isCompleted parameter
                    cmd.Parameters.AddWithValue("@courseMark", CourseMark); // Set the courseMarks parameter
                    cmd.Parameters.AddWithValue("@tutorialId", Tutorial.Id);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    cmd.ExecuteNonQuery(); // Execute the query
                }
            }
        }

        // Fetch courses from the database and initialize the course list
        private void LoadStudentCourseFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT isCompleted, courseMark, tutorialId FROM studentCourse WHERE courseAssociationId = @Id"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        if (reader.Read()) // Read each row
                        {
                            IsCompleted = reader.GetBoolean(0);
                            CourseMark = (double)reader.GetDecimal(1);
                            Tutorial = new Tutorial(reader.GetInt32(2));
                        }
                    }
                }
            }
        }

        // Fetch assessments from the database and initialize the assessment list
        private void LoadAssessmentFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id, assessmentId, status, studentMark, isFinalised, feedback FROM studentAssessment WHERE courseId = @courseId AND userId = @userId", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@courseId", Id); // Set the courseId parameter
                cmd.Parameters.AddWithValue("@userId", UserId); // Set the studentId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int studentAssessmentId = reader.GetInt32(0);
                        int assessmentId = reader.GetInt32(1);
                        int status = reader.GetInt32(2);
                        double mark = (double)reader.GetDecimal(3);
                        bool isFinalised = reader.GetBoolean(4);
                        string feedback = reader.GetString(5);

                        // Add the assessment to the assessment list
                        StudentAssessmentList.Add(studentAssessmentId, new StudentAssessment(studentAssessmentId, assessmentId, status, mark, isFinalised, feedback, Id, UserId));
                    }
                }
            }
        }

        private void AddAssessmentToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("SELECT id FROM assessment WHERE courseId = @courseId", conn); // SQL query to fetch assessments
                cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter

                using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                {
                    while (reader.Read()) // Read each row
                    {
                        int assessmentId = reader.GetInt32(0); // Get the assessment ID

                        StudentAssessment studentAssessment = new StudentAssessment(assessmentId, Id, UserId);

                        // Add the assessment to the assessment list
                        StudentAssessmentList.Add(studentAssessment.Id, studentAssessment);
                    }
                }
            }
        }

        // Calculate the current mark for the course
        public double CalculateCurrentMark()
        {
            double totalWeightedMarks = 0.0;
            double totalWeight = 0.0;

            foreach (var assessment in StudentAssessmentList.Values)
            {
                if (assessment.IsFinalised && assessment.Weight > 0)
                {
                    totalWeightedMarks += (assessment.StudentMark / assessment.Mark) * assessment.Weight;
                    totalWeight += assessment.Weight;
                }
            }

            if(totalWeightedMarks != 0 && (totalWeightedMarks / totalWeight) * 100 != CourseMark )
            {
                CourseMark = (totalWeightedMarks / totalWeight) * 100;
                UpdateCourseMarkIntoDatabase();
            }

            return totalWeight > 0 ? (totalWeightedMarks / totalWeight) * 100 : 0.0;
        }

        private void UpdateCourseMarkIntoDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE studentCourse
                    SET 
                        courseMark = @courseMark
                    WHERE
                        courseAssociationId = @courseAssociationId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@courseAssociationId", Id);
                    cmd.Parameters.AddWithValue("@courseMark", CourseMark);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Calculate the target mark required for the course
        public double CalculateTargetMark(double targetMark)
        {
            double totalWeightedMarks = 0.0;
            double totalWeight = 0.0;
            double remainingWeight = 0.0;

            foreach (var assessment in StudentAssessmentList.Values)
            {
                if (assessment.IsFinalised && assessment.Weight > 0)
                {
                    totalWeightedMarks += (assessment.StudentMark / assessment.Mark) * assessment.Weight;
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
                        EventList.Add(id, new Event(id, name, date, startTime, endTime, UserId, Id, category, color));
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

        public void UpdateTutorialToDatabase(int tutorialId)
        {
            Tutorial = new Tutorial(tutorialId);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE studentCourse
                    SET 
                        tutorialId = @tutorialId,
                    WHERE
                        courseAssociationId = @courseAssociationId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@courseAssociationId", Id);
                    cmd.Parameters.AddWithValue("@tutorialId", Tutorial.Id);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
