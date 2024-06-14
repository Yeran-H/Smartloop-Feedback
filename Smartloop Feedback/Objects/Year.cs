using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Smartloop_Feedback
{
    public class Year
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public string name { get; set; }
        public int studentId { get; }
        public int id { get; set; }
        public List<Semester> semesterList { get; set; }

        public Year(string name, int studentId, int id)
        {
            this.name = name;
            this.studentId = studentId;
            this.id = id;
            semesterList = new List<Semester>();
            getSemesterFromDatabase();
        }

        public Year(string name, int studentId, List<string> semesterName)
        {
            this.name = name;
            this.studentId = studentId;
            semesterList = new List<Semester>();
            addYearToDatabase();
            addSemesterToDatabase(semesterName);
        }

        public void addYearToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO year (name, studentId) VALUES (@name, @studentId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void addSemesterToDatabase(List<string> semesterName)
        {
            foreach(string name in semesterName) 
            {
                semesterList.Add(new Semester(name, id, studentId));
            }
        }

        private void getSemesterFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT name, id FROM semester WHERE yearId = @yearId AND studentId = @studentId", conn);
                cmd.Parameters.AddWithValue("@yearId", id);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        semesterList.Add(new Semester(name, id, this.id, studentId));
                    }
                }
            }
        }

        public int numSemester()
        {
            return semesterList == null ? 0 : semesterList.Count;
        }

        public int semesterIndex(string semesterName)
        {
            for (int i = 0; i < numSemester(); i++) 
            {
                if (semesterList[i].name == semesterName)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
