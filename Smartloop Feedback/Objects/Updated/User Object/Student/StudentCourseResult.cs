using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartloop_Feedback.Objects
{
    public class StudentCourseResult
    {
        // Public properties for course result details
        public int Year { get; set; } // Academic year of the course
        public string Semester { get; set; } // Semester of the course
        public string Course { get; set; } // Name of the course
        public string Grade { get; private set; } // Grade received in the course
        public double Score { get; set; } // Score received in the course
        public int CreditPoint { get; set; } // Credit points of the course

        // Constructor to initialize a CourseResult object with default values
        public StudentCourseResult()
        {
            Year = 0;
            Semester = string.Empty;
            Course = string.Empty;
            Grade = string.Empty;
            Score = 0.00;
            CreditPoint = 0;
        }

        // Calculate the grade based on the score
        public void CalculateGrade()
        {
            switch (Score)
            {
                case double s when (s >= 85 && s <= 100):
                    Grade = "HD"; // High Distinction
                    break;
                case double s when (s >= 75 && s < 85):
                    Grade = "D"; // Distinction
                    break;
                case double s when (s >= 65 && s < 75):
                    Grade = "C"; // Credit
                    break;
                case double s when (s >= 50 && s < 65):
                    Grade = "P"; // Pass
                    break;
                default:
                    Grade = "F"; // Fail
                    break;
            }
        }

        // Get the grade point corresponding to the grade
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
