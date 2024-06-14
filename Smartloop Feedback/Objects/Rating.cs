using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartloop_Feedback.Objects;
using System.Xml.Linq;

namespace Smartloop_Feedback.Objects
{
    public class Rating
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public int id { get; set; }
        public string description { get; set; }
        public string grade { get; set; }
        public int criteriaId { get; set; }
        public int studentId { get; set; }
        public Rating(int id, string description, string grade, int criteriaId, int studentId)
        {
            this.id = id;
            this.description = description;
            this.grade = grade;
            this.criteriaId = criteriaId;
            this.studentId = studentId;       
        }

        public Rating(string description, string grade, int criteriaId, int studentId)
        {
            this.description = description;
            this.grade = grade;
            this.criteriaId = criteriaId;
            this.studentId = studentId;
            addRatingToDatabase();
        }

        public Rating(string description, string grade)
        {
            this.description= description;
            this.grade = grade;
        }

        public void addRatingToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO rating (description, grade, criteriaId, studentId) VALUES (@description, @grade, @criteriaId, @studentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@grade", grade);
                    cmd.Parameters.AddWithValue("@criteriaId", criteriaId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
