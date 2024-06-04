using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;

namespace Smartloop_Feedback
{
    public partial class registerForm : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>();

        public registerForm()
        {
            InitializeComponent();

            textBoxClicked[nameTb] = false;
            textBoxClicked[emailTb] = false;
            textBoxClicked[studentTb] = false;
            textBoxClicked[passwordTb] = false;
            textBoxClicked[degreeTb] = false;
        }

        private void nameTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[nameTb])
            {
                nameTb.Clear();
                textBoxClicked[nameTb] = true;
            }
            namePb.Image = Properties.Resources.person2;
            namePl.BackColor = Color.FromArgb(254, 0, 57);
            nameTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void emailTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[emailTb])
            {
                emailTb.Clear();
                textBoxClicked[emailTb] = true;
            }
            emailPb.Image = Properties.Resources.email2;
            emailPl.BackColor = Color.FromArgb(254, 0, 57);
            emailTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void studentTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[studentTb])
            {
                studentTb.Clear();
                textBoxClicked[studentTb] = true;
            }
            studentPb.Image = Properties.Resources.person2;
            studentPl.BackColor = Color.FromArgb(254, 0, 57);
            studentTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void passwordTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[passwordTb])
            {
                passwordTb.Clear();
                textBoxClicked[passwordTb] = true;
            }
            passwordPb.Image = Properties.Resources.pass2;
            passwordPl.BackColor = Color.FromArgb(254, 0, 57);
            passwordTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void degreeTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[degreeTb])
            {
                degreeTb.Clear();
                textBoxClicked[degreeTb] = true;
            }
            degreePb.Image = Properties.Resources.degree2;
            degreePl.BackColor = Color.FromArgb(254, 0, 57);
            degreeTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void defaultUI()
        {
            namePb.Image = Properties.Resources.person1;
            namePl.BackColor = Color.FromArgb(193, 193, 193);
            nameTb.ForeColor = Color.FromArgb(193, 193, 193);

            emailPb.Image = Properties.Resources.email1;
            emailPl.BackColor = Color.FromArgb(193, 193, 193);
            emailTb.ForeColor = Color.FromArgb(193, 193, 193);

            studentPb.Image = Properties.Resources.person1;
            studentPl.BackColor = Color.FromArgb(193, 193, 193);
            studentTb.ForeColor = Color.FromArgb(193, 193, 193);

            passwordPb.Image = Properties.Resources.pass1;
            passwordPl.BackColor = Color.FromArgb(193, 193, 193);
            passwordTb.ForeColor = Color.FromArgb(193, 193, 193);

            degreePb.Image = Properties.Resources.degree1;
            degreePl.BackColor = Color.FromArgb(193, 193, 193);
            degreeTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        private void studentTb_KeyPress(object sender, KeyPressEventArgs e)
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    profilePb.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void resgisterBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string email = emailTb.Text;
            int studentId = Convert.ToInt32(studentTb.Text);
            string password = passwordTb.Text;
            string degree = degreeTb.Text;
            byte[] profileImage = null;

            if (profilePb.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePb.Image.Save(ms, profilePb.Image.RawFormat);
                    profileImage = ms.ToArray();
                }
            }

            Student newStudent = new Student(name, email, studentId, password, degree, profileImage);

            if (!newStudent.ValidatePassword())
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!newStudent.ValidateStudentId())
            {
                MessageBox.Show("Student ID must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!newStudent.ValidateEmail())
            {
                MessageBox.Show("Email must end with @student.uts.edu.au or @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO students (name, email, studentId, password, degree, profileImage) VALUES (@name, @mail, @studentId, @password, @degree, @profileImage)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@degree", degree);
                    cmd.Parameters.AddWithValue("@profileImage", profileImage);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
