using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class Course
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        public int Id { get; private set; } // Course ID
        public int Code { get; set; } // Course code
        public string Name { get; set; } // Course name
        public int CreditPoint { get; set; } // Course credit points
        public string Description { get; set; } // Course description
        public string Year { get; set; }
        public string Semester { get; set; }
        public string CanvasLink { get; set; }

        public Course(int id, int code, string name, int creditPoint, string description, string Year, string Semester, string CanvasLink)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.CreditPoint = creditPoint;
            this.Description = description;
            this.Year = Year;
            this.Semester = Semester;
            this.CanvasLink = CanvasLink;
        }
    }
}
