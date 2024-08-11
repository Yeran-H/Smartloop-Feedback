using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;

namespace Smartloop_Feedback.Objects
{
    public class FeedbackResult
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        public int Id { get; set; }
        public int Attempt {  get; set; }
        public string TeacherFeedback { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string Notes { get; set; }
        public string Feedback { get; set; }
        public int[] PreviousAttemptId { get; set; }
        public int StudentId { get; set; }
        public int AssessmentId { get; set; }

        public FeedbackResult(int attempt, string teacherFeedback, string fileName, byte[] fileData, string notes, string feedback, int[] previousAttemptId, int studentId, int assessmentId)
        {
            Attempt = attempt;
            TeacherFeedback = teacherFeedback;
            FileName = fileName;
            FileData = fileData;
            Notes = notes;
            Feedback = feedback;
            StudentId = studentId;
            AssessmentId = assessmentId;
            PreviousAttemptId = previousAttemptId;
            AddFeedbackToDatabase();
        }

        public FeedbackResult(int id, int attempt, string teacherFeedback, string fileName, byte[] fileData, string notes, string feedback, int[] previousAttemptId, int studentId, int assessmentId)
        {
            Id = id;
            Attempt = attempt;
            TeacherFeedback = teacherFeedback;
            FileName = fileName;
            FileData = fileData;
            Notes = notes;
            Feedback = feedback;
            PreviousAttemptId = previousAttemptId;
            StudentId = studentId;
            AssessmentId = assessmentId;
        }

        private void AddFeedbackToDatabase()
        {
            string previousAttemptId = null;

            foreach(int attempt in PreviousAttemptId)
            {
                previousAttemptId += attempt + ",";
            }

            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open(); 
                string sql = "INSERT INTO feedbackResult (attempt, teacherFeedback, fileName, fileData, notes, feedback, previousAttemptId, studentId, assessmentId) VALUES (@attempt, @teacherFeedback, @fileName, @fileData, @notes, @feedback, @previousAttemptId, @studentId, @assessmentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@attempt", Attempt);
                    cmd.Parameters.AddWithValue("@teacherFeedback", (object)TeacherFeedback ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@fileName", FileName); 
                    cmd.Parameters.AddWithValue("@fileData", FileData);
                    cmd.Parameters.AddWithValue("@notes", (object)Notes ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@feedback", Feedback); 
                    cmd.Parameters.AddWithValue("@previousAttemptId", (object)previousAttemptId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@studentId", StudentId); 
                    cmd.Parameters.AddWithValue("@assessmentId", AssessmentId);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); 
                }
            }
        }
    }
}
