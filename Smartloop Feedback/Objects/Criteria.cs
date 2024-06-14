using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Objects
{
    public class Criteria
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public int id { get; set; }
        public string description { get; set; }
        public int assessmentId { get; set; }
        public List<Rating> ratingList { get; set; }
        public int studentId { get; set; }
        public Criteria(int id, string description, int assessmentId, int studentId)
        {
            this.id = id;
            this.description = description;
            this.ratingList = ratingList;
            this.assessmentId = assessmentId;
            this.studentId = studentId;
            ratingList = new List<Rating>();
            getRatingFromDatabase();
        }

        public Criteria(string description, int assessmentId, int studentId)
        {
            this.description = description;
            this.ratingList = ratingList;
            this.assessmentId = assessmentId;
            this.studentId = studentId;
            addCriteriaToDatabase();
        }

        public Criteria(string description)
        {
            this.description = description;
        }

        public void addCriteriaToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO criteria (description, assessmentId, studentId) VALUES (@description, @assessmentId, @studentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@assessmentId", assessmentId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void getRatingFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id,  description, grade FROM rating WHERE criteriaId = @criteriaId AND studentId = @studentId", conn);
                cmd.Parameters.AddWithValue("@criteriaId", id);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string description = reader.GetString(1);
                        string grade = reader.GetString(2);
                        ratingList.Add(new Rating(id, description, grade, this.id, studentId));
                    }
                }
            }
        }
    }
}
