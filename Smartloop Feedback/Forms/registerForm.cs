using System.Data.SqlClient;
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
using System.Runtime.InteropServices;

namespace Smartloop_Feedback
{
    public partial class RegisterForm : Form
    {
        // Connection string for the database
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Dictionary to track if a textbox has been clicked
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>();

        // P/Invoke to create a rounded rectangle region
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public RegisterForm()
        {
            InitializeComponent();

            // Initialize dictionary with textboxes
            textBoxClicked[nameTb] = false;
            textBoxClicked[emailTb] = false;
            textBoxClicked[studentTb] = false;
            textBoxClicked[passwordTb] = false;
            textBoxClicked[degreeTb] = false;

            // Set the form's region to a rounded rectangle
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Attach TextChanged and Enter event handlers to all textboxes
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += new EventHandler(TextBox_TextChanged);
                    (control as TextBox).Enter += new EventHandler(TextBox_Enter);
                }
            }
        }

        // Event handler to enable the register button if all textboxes are filled
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFilled = this.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text));
            registerBtn.Enabled = allFilled;
        }

        // Common event handler for when any textbox receives focus
        private void TextBox_Enter(object sender, EventArgs e)
        {
            DefaultUI(); // Reset UI to default state

            TextBox currentTextBox = sender as TextBox;

            // Clear the textbox on first focus
            if (!textBoxClicked[currentTextBox])
            {
                currentTextBox.Clear();
                textBoxClicked[currentTextBox] = true;
            }

            // Update UI to indicate the textbox is active
            if (currentTextBox == nameTb)
            {
                namePb.Image = Properties.Resources.person2;
                namePl.BackColor = Color.FromArgb(254, 0, 57);
                nameTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == emailTb)
            {
                emailPb.Image = Properties.Resources.email2;
                emailPl.BackColor = Color.FromArgb(254, 0, 57);
                emailTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == studentTb)
            {
                studentPb.Image = Properties.Resources.person2;
                studentPl.BackColor = Color.FromArgb(254, 0, 57);
                studentTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == passwordTb)
            {
                passwordPb.Image = Properties.Resources.pass2;
                passwordPl.BackColor = Color.FromArgb(254, 0, 57);
                passwordTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == degreeTb)
            {
                degreePb.Image = Properties.Resources.degree2;
                degreePl.BackColor = Color.FromArgb(254, 0, 57);
                degreeTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
        }

        // Reset the UI to its default state
        private void DefaultUI()
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

        // Ensure the student ID textbox only accepts numeric input
        private void studentTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Close the form when the exit picture box is clicked
        private void exitPb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Navigate back to the login form when the back button is clicked
        private void backBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        // Allow the user to upload a profile image
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

        // Handle the registration button click event
        private void resgisterBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string email = emailTb.Text;
            int studentId = Convert.ToInt32(studentTb.Text);
            string password = passwordTb.Text;
            string degree = degreeTb.Text;
            byte[] profileImage = null;

            // Convert the profile image to a byte array
            if (profilePb.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePb.Image.Save(ms, profilePb.Image.RawFormat);
                    profileImage = ms.ToArray();
                }
            }

            Student newStudent = new Student(studentId, name, email, password, degree, profileImage);

            // Validate the password
            if (!newStudent.ValidatePassword())
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the student ID
            if (!newStudent.ValidateStudentId())
            {
                MessageBox.Show("Student ID must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the email address
            if (!newStudent.ValidateEmail())
            {
                MessageBox.Show("Email must end with @student.uts.edu.au or @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert the new student record into the database
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO student (name, email, studentId, password, degree, profileImage) VALUES (@name, @mail, @studentId, @password, @degree, @profileImage)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

            // Show the main form and hide the current form
            MainForm main = new MainForm(newStudent);
            main.Show();
            this.Hide();
        }

        // Override ProcessCmdKey to detect Enter key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                registerBtn.PerformClick(); // Simulate a click on the register button
                return true; // Indicate that the key press has been handled
            }
            return base.ProcessCmdKey(ref msg, keyData); // Call the base method for other key presses
        }
    }
}
