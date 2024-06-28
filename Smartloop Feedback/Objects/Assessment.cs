using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartloop_Feedback.Objects;
using Org.BouncyCastle.Asn1.X509;

namespace Smartloop_Feedback.Objects
{
    public class Assessment
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public int weight { get; set; }
        public int mark { get; set; }
        public bool individual { get; set; }
        public bool group { get; set; }
        public string canvasLink { get; set; }
        public List<Criteria> criteriaList { get; set; }
        public int courseId { get; set; }
        public int studentId { get; set; }

        public Assessment(int id, string name, string description, string type, DateTime date, string status, int weight, int mark, bool individual, bool group, string canvasLink, int courseId, int studentId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.type = type;
            this.date = date;
            this.status = status;
            this.weight = weight;
            this.mark = mark;
            this.individual = individual;
            this.group = group;
            this.canvasLink = canvasLink;
            this.courseId = courseId;
            this.studentId = studentId;
            criteriaList = new List<Criteria>();
            getCriteriaFromDatabase();
        }

        public Assessment(string name, string description, string type, DateTime date, string status, int weight, int mark, bool individual, bool group, string canvasLink, int courseId, int studentId)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.date = date;
            this.status = status;
            this.weight = weight;
            this.mark = mark;
            this.individual = individual;
            this.group = group;
            this.canvasLink = canvasLink;
            criteriaList = new List<Criteria>();
            this.courseId = courseId;
            this.studentId = studentId;
            addAssessmentToDatabase();
        }

        public Assessment(string name, string description, string type, DateTime date, string status, int weight, int mark, bool individual, bool group, string canvasLink)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.date = date;
            this.status = status;
            this.weight = weight;
            this.mark = mark;
            this.individual = individual;
            this.group = group;
            this.canvasLink = canvasLink;
            criteriaList = new List<Criteria>();
        }

        public void addAssessmentToDatabase() 
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO assessment (name, description, type, date, status, weight, mark, individual, [group], canvasLink, courseId, studentId) VALUES (@name, @description, @type, @date, @status, @weight, @mark, @individual, @group, @canvasLink, @courseId, @studentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@weight", weight);
                    cmd.Parameters.AddWithValue("@mark", mark);
                    cmd.Parameters.AddWithValue("@individual", individual);
                    cmd.Parameters.AddWithValue("@group", group);
                    cmd.Parameters.AddWithValue("@canvasLink", canvasLink);
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void getCriteriaFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, description FROM criteria WHERE assessmentId = @assessmentId AND studentId = @studentId", conn);
                cmd.Parameters.AddWithValue("@assessmentId", id);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string description = reader.GetString(1);
                        criteriaList.Add(new Criteria(id, description, this.id, studentId));
                    }
                }
            }
        }
    }
}
