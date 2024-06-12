using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class loginForm : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHieghtEllipse
        );

        public loginForm()
        {
            InitializeComponent();
            textBoxClicked[usernameTb] = false;
            textBoxClicked[passwordTb] = false;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void usernameTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[usernameTb])
            {
                usernameTb.Clear();
                textBoxClicked[usernameTb] = true;
            }
            usernamePb.Image = Properties.Resources.person2;
            usernamePl.BackColor = Color.FromArgb(254, 0, 57);
            usernameTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void passwordTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[passwordTb])
            {
                passwordTb.Clear();
                textBoxClicked[passwordTb] = true;
            }
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

        private void usernameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
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

            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT studentID, name, email, degree, password, profileImage FROM Student WHERE studentID = @studentID AND password = @password", conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Student student = new Student(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetString(3),reader.GetString(4),reader.GetFieldValue<byte[]>(5));

                        mainForm main = new mainForm(student);
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Login", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
