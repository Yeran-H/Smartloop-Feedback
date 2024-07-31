using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartloop_Feedback.Objects
{
    public  class CourseResult
    {
        public string Year { get; set; }
        public string Semester { get; set; }
        public string Course { get; set; }
        public string Grade { get; set; }
        public double Score { get; set; }
        public int CreditPoint { get; set; }

        public CourseResult()
        {
            Year = string.Empty;
            Semester = string.Empty;
            Course = string.Empty;
            Grade = string.Empty;
            Score = 0.00;
            CreditPoint = 0;
        }

        public void CalculateGrade()
        {
            switch (Score)
            {
                case double s when (s >= 85 && s <= 100):
                    Grade =  "HD";
                    break;
                case double s when (s >= 75 && s < 85):
                    Grade = "D";
                    break;
                case double s when (s >= 65 && s < 75):
                    Grade = "C";
                    break;
                case double s when (s >= 50 && s < 65):
                    Grade = "P";
                    break;
                default:
                    Grade = "F";
                    break;
            }
        }

        public double GetGradePoint()
        {
            switch (Grade)
            {
                case "HD":
                    return 7.0;
                case "D":
                    return 6.0;
                case "C":
                    return 5.0;
                case "P":
                    return 4.0;
                case "F":
                    return 0.0;
                default:
                    return 0.0;
            }
        }

    }
}
