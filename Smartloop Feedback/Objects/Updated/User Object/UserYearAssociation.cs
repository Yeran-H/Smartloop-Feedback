using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Crypto.Paddings;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;

namespace Smartloop_Feedback.Objects.Updated.User_Object
{
    public class UserYearAssociation
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string
        public int Id { get; set; }
        public Year Year { get; set; }
        public int userId { get; set; }
        public bool isStudent { get; set; }

        public UserYearAssociation(int id, int yearName, int userId, bool isStudent)
        {
            this.Id = id;
            this.userId = userId;
            this.isStudent = isStudent;
            Year = new Year(yearName);
        }

        public UserYearAssociation(int yearName, int userId, bool isStudent)
        {
            this.userId = userId;
            this.isStudent = isStudent;
            Year = new Year(yearName);
        }
    }
}
