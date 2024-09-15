using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Asn1.X509;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System.Linq;
using System.ComponentModel;

namespace Smartloop_Feedback.Objects.User_Object.Tutor
{
    public class TutorCourse : CourseAssociation
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Connection string for the database
        public SortedDictionary<int, TutorialAssociation> TutorTutorialList { get; set; }

        public TutorCourse(int id, int courseId, int userId, int seemsterId, bool isStudent)
            :base(id, courseId, userId, seemsterId, isStudent)
        {
            TutorTutorialList = new SortedDictionary<int, TutorialAssociation>();

            LoadTutorCourseFromDatabase();
        }

        public TutorCourse(int courseId, int userId, int seemsterId, bool isStudent, List<int> tutorialId)
            : base(courseId, userId, seemsterId, isStudent)
        {
            TutorTutorialList = new SortedDictionary<int, TutorialAssociation>();
            AddTutorCourseToDatabase(tutorialId);
        }


        // Add the student course to the database
        private void AddTutorCourseToDatabase(List<int> tutorialId)
        {
            string tutorialList = null;

            foreach (int num in tutorialId)
            {
                TutorTutorialList.Add(num, new TutorialAssociation(num));
                tutorialList += num + ",";
            }

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO tutorCourse (courseAssociationId, tutorialId, userId) VALUES (@courseAssociationId, @tutorialId, @userId);"; // SQL query to insert student course

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@courseAssociationId", Id); // Use the generated ID from CourseAssociation
                    cmd.Parameters.AddWithValue("@tutorialId", tutorialList);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    cmd.ExecuteNonQuery(); // Execute the query
                }
            }
        }

        // Fetch courses from the database and initialize the course list
        private void LoadTutorCourseFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "SELECT tutorialId FROM tutorCourse WHERE courseAssociationId = @Id"; // SQL query to fetch courses

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@Id", Id); // Set the studentId parameter

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get a reader
                    {
                        if (reader.Read()) // Read each row
                        {
                            string tutorialId = reader.GetString(0);

                            int[] intArray;

                            if (!string.IsNullOrEmpty(tutorialId))
                            {
                                intArray = tutorialId
                                    .Split(',')
                                    .Where(s => !string.IsNullOrWhiteSpace(s))
                                    .Select(int.Parse)
                                    .ToArray();
                            }
                            else
                            {
                                intArray = new int[0];
                            }

                            for(int i = 0; i < intArray.Length; i++)
                            {
                                TutorTutorialList.Add(intArray[i], new TutorialAssociation(intArray[i]));
                            }
                        }
                    }
                }
            }
        }
    }
}
