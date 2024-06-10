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

        public Year(string name, int studentId, int id)
        {
            this.name = name;
            this.studentId = studentId;
            this.id = id;
        }

        public Year(string name, int studentId)
        {
            this.name = name;
            this.studentId = studentId;
            addYearToDatabase();
        }

        public void addYearToDatabase()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO years (name, studentId) VALUES (@name, @studentId)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
