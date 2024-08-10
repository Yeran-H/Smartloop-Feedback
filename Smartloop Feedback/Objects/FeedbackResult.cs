using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

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
        public string Grade {  get; set; }
        public string Feedback { get; set; }
        public string NextStep { get; set; }
        public int StudentId { get; set; }
        public int AssessmentId { get; set; }
        public Dictionary<string, string> CriteriaRatings { get; set; }

        public FeedbackResult(int Attempt, string TeacherFeedback, int StudentId, int AssessmentId) {
            this.Attempt = Attempt;
            this.TeacherFeedback = TeacherFeedback;
            this.StudentId = StudentId;
            this.AssessmentId = AssessmentId;
            CriteriaRatings = new Dictionary<string, string>();
        } 

        public FeedbackResult(int id, int attempt, string teacherFeedback, string fileName, byte[] fileData, string notes, string grade, string feedback, string nextStep, Dictionary<string, string> criteriaRatings, int studentId, int assessmentId)
        {
            Id = id;
            Attempt = attempt;
            TeacherFeedback = teacherFeedback;
            FileName = fileName;
            FileData = fileData;
            this.Notes = notes;
            Grade = grade;
            Feedback = feedback;
            NextStep = nextStep;
            StudentId = studentId;
            AssessmentId = assessmentId;
            CriteriaRatings = criteriaRatings;
        }

        private void AddFeedbackToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open(); 
                string sql = "INSERT INTO feedbackResult (attempt, teacherFeedback, fileName, fileData, notes, grade, feedback, nextStep, studentId, assessmentId) VALUES (@attempt, @teacherFeedback, @fileName, @fileData, @notes, @grade, @feedback, @nextStep, @studentId, @assessmentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert assessment and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@attempt", Attempt);
                    cmd.Parameters.AddWithValue("@teacherFeedback", TeacherFeedback); 
                    cmd.Parameters.AddWithValue("@fileName", FileName); 
                    cmd.Parameters.AddWithValue("@fileData", FileData);
                    cmd.Parameters.AddWithValue("@notes", Notes); 
                    cmd.Parameters.AddWithValue("@grade", Grade); 
                    cmd.Parameters.AddWithValue("@feedback", Feedback); 
                    cmd.Parameters.AddWithValue("@studentId", StudentId); 
                    cmd.Parameters.AddWithValue("@assessmentId", AssessmentId);
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); 
                }
            }
        }
    }
}
