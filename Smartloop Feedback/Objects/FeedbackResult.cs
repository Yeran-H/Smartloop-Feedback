using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartloop_Feedback.Objects
{
    public class FeedbackResult
    {
        public int Id { get; set; }
        public string TeacherFeedback { get; set; }
        public string FileName { get; set; }
        public string FileData { get; set; }
        public string notes { get; set; }
        public string Grade {  get; set; }
        public string Feedback { get; set; }
        public string NextStep { get; set; }
        public int StudentId { get; set; }
        public int AssessmentId { get; set; }
        public Dictionary<string, string> CriteriaRatings { get; set; }

        public FeedbackResult(string TeacherFeedback, int StudentId, int AssessmentId) { 
            this.TeacherFeedback = TeacherFeedback;
            this.StudentId = StudentId;
            this.AssessmentId = AssessmentId;
            CriteriaRatings = new Dictionary<string, string>();
        } 
    }
}
