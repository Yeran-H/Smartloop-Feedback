using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class loginForm : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public loginForm()
        {
            InitializeComponent();
        }

        private void usernameTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            usernameTb.Clear();
            usernamePb.Image = Properties.Resources.person2;
            usernamePl.BackColor = Color.FromArgb(254, 0, 57);
            usernameTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void passwordTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            passwordTb.Clear();
            passwordTb.PasswordChar = '*';
            passwordPb.Image = Properties.Resources.pass2;
            passwordPl.BackColor = Color.FromArgb(254, 0, 57);
            passwordTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void defaultUI()
        {
            usernamePb.Image = Properties.Resources.person1;
            usernamePl.BackColor = Color.FromArgb(193, 193, 193);
            usernameTb.ForeColor = Color.FromArgb(193, 193, 193);

            passwordPb.Image = Properties.Resources.pass1;
            passwordPl.BackColor = Color.FromArgb(193, 193, 193);
            passwordTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            registerForm register = new registerForm();
            register.Show();
            this.Hide();
        }

        private void signBtn_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(usernameTb.Text);
            string password = passwordTb.Text;

            using (MySqlConnection conn = new MySqlConnection(connStr)) 
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT StudentID FROM Students WHERE studentID = @studentID AND password = @password", conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@password", password);
                object result = cmd.ExecuteNonQuery();

                if(result != null)
                {
                    MessageBox.Show("Login into " + studentId + " is correct", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect Login", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
