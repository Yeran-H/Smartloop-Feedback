using MySql.Data.MySqlClient;
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
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO years (name, studentId) VALUES (@name, @studentId); SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
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
                semesterList.Add(new Semester(name, id));
            }
        }

        private void getSemesterFromDatabase()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT name, id FROM semesters WHERE yearId = @yearId", conn);
                cmd.Parameters.AddWithValue("@yearId", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        semesterList.Add(new Semester(name, id, this.id));
                    }
                }
            }
        }

        public int numSemester()
        {
            return semesterList == null ? 0 : semesterList.Count;
        }
    }
}
