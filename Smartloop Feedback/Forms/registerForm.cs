using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using Org.BouncyCastle.Tls;
using System.Windows.Forms.DataVisualization.Charting;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback
{
    public partial class RegisterForm : Form
    {
        // Connection string for the database
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        private bool isStudent;

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

        // Fields to track dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public RegisterForm(bool isStudent)
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
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += TextBox_TextChanged;
                    textBox.Enter += TextBox_Enter;
                }
            }

            this.isStudent = isStudent;
            
            if (isStudent)
            {
                studentTb.Text = "Teacher ID";
                degreeTb.Visible = false;
                degreePl.Visible = false;
                degreePb.Visible = false;
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
            UpdateTextBoxUI(currentTextBox);
        }

        // Update the UI to indicate the active textbox
        private void UpdateTextBoxUI(TextBox textBox)
        {
            if (textBox == nameTb)
            {
                namePb.Image = Properties.Resources.person2;
                namePl.BackColor = Color.FromArgb(254, 0, 57);
                nameTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (textBox == emailTb)
            {
                emailPb.Image = Properties.Resources.email2;
                emailPl.BackColor = Color.FromArgb(254, 0, 57);
                emailTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (textBox == studentTb)
            {
                studentPb.Image = Properties.Resources.person2;
                studentPl.BackColor = Color.FromArgb(254, 0, 57);
                studentTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (textBox == passwordTb)
            {
                passwordPb.Image = Properties.Resources.pass2;
                passwordPl.BackColor = Color.FromArgb(254, 0, 57);
                passwordTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (textBox == degreeTb)
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
        private void registerBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string email = emailTb.Text;
            int userId = Convert.ToInt32(studentTb.Text);
            string password = passwordTb.Text;
            byte[] profileImage = null;
            string degree = isStudent ? degreeTb.Text : null;

            // Convert the profile image to a byte array
            if (profilePb.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePb.Image.Save(ms, profilePb.Image.RawFormat);
                    profileImage = ms.ToArray();
                }
            }

            User newUser = new User(userId, name, email, password, profileImage, isStudent);
            
            // Validate user input
            if (!newUser.ValidateUserInput()) return;

            if(isStudent)
            {
                Student student = new Student(userId, name, email, password, degree, profileImage, true);
                
                MainForm main = new MainForm(student);
                main.Show();
                this.Hide();
            }
            else
            {
                Tutor tutor = new Tutor(userId, name, email, password, profileImage, true);

                /*MainForm main = new MainForm(tutor);
                main.Show();
                this.Hide(); */
            }
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

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = System.Windows.Forms.Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(System.Windows.Forms.Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void headerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
