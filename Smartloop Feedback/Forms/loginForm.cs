using Smartloop_Feedback.Coordinator;
using Smartloop_Feedback.Coordinator_Folder;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using Smartloop_Feedback.Objects.User_Object.Tutor;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class LoginForm : Form
    {
        // Connection string for the database, retrieved from configuration settings
        private string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Importing external method to create a rounded rectangle region for the form
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

        // Fields to track dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Constructor for the login form
        public LoginForm()
        {
            InitializeComponent();

            // Set the form's region to a rounded rectangle
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Attach TextChanged event handler to all textboxes on the form
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += new EventHandler(TextBox_TextChanged);
                    (control as TextBox).Enter += new EventHandler(TextBox_Enter);
                }
            }

            // Load saved credentials if available
            LoadCredentials();
        }

        // Event handler to enable the sign-in button if all textboxes are filled
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFilled = this.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text));
            signBtn.Enabled = allFilled;
        }

        // Common event handler for when any textbox receives focus
        private void TextBox_Enter(object sender, EventArgs e)
        {
            DefaultUI(); // Reset UI to default state

            TextBox currentTextBox = sender as TextBox;

            // Update UI to indicate the textbox is active
            if (currentTextBox == usernameTb)
            {
                usernamePb.Image = Properties.Resources.person2;
                usernamePl.BackColor = Color.FromArgb(254, 0, 57);
                usernameTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == passwordTb)
            {
                passwordTb.PasswordChar = '*';
                passwordPb.Image = Properties.Resources.pass2;
                passwordPl.BackColor = Color.FromArgb(254, 0, 57);
                passwordTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
        }

        // Method to reset the UI to the default state
        private void DefaultUI()
        {
            // Reset username UI elements to default colors and images
            usernamePb.Image = Properties.Resources.person1;
            usernamePl.BackColor = Color.FromArgb(193, 193, 193);
            usernameTb.ForeColor = Color.FromArgb(193, 193, 193);

            // Reset password UI elements to default colors and images
            passwordPb.Image = Properties.Resources.pass1;
            passwordPl.BackColor = Color.FromArgb(193, 193, 193);
            passwordTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        // Event handler to restrict the username textbox to only accept digits
        private void usernameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Reject non-digit input
                }
            }
        }

        // Event handler for the exit picture box click event to close the form
        private void exitPb_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the application
        }

        // Event handler for the register button click event to open the registration form
        private void registerStudentBtn_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm(true); // Create a new registration form
            register.Show(); // Show the registration form
            this.Hide(); // Hide the current form
        }

        // Event handler for the sign-in button click event to authenticate the user
        private void signBtn_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(usernameTb.Text); // Get ID from username textbox
            string password = passwordTb.Text; // Get password from password textbox

            if (string.IsNullOrEmpty(usernameTb.Text) || usernameTb.Text == "Student ID" || usernameTb.Text == "Tutor ID")
            {
                MessageBox.Show("Please enter your ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(password) || password == "Password")
            {
                MessageBox.Show("Please enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(studetnRb.Checked)
            {
                ValidateStudent(Id, password);
            }
            else
            {
                ValidateTutor(Id, password);
            }

            SaveCredentials(); // Save credentials if Remember Me is checked
        }

        public async void ValidateStudent(int studentId, string password)
        {
            await Task.Run(() =>
            {
                // Create a new SQL connection using the connection string
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open(); // Open the connection
                    // Create a SQL command to select student details
                    SqlCommand cmd = new SqlCommand("SELECT studentID, name, email, degree, password, profileImage FROM Student WHERE studentID = @studentID AND password = @password", conn);
                    cmd.Parameters.AddWithValue("@studentId", studentId); // Add student ID parameter
                    cmd.Parameters.AddWithValue("@password", password); // Add password parameter

                    // Execute the command and read the results
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If a matching record is found
                        {
                            // Create a new Student object from the database record
                            Student student = new Student(
                                reader.GetInt32(0),
                                reader.IsDBNull(1) ? null : reader.GetString(1),
                                reader.IsDBNull(2) ? null : reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3),
                                reader.IsDBNull(4) ? null : reader.GetString(4),
                                reader.IsDBNull(5) ? null : reader.GetFieldValue<byte[]>(5)
                            );

                            // Invoke to update UI thread
                            this.Invoke(new Action(() =>
                            {
                                // Create and show the main form, passing the student object
                                MainForm main = new MainForm(student);
                                main.Show();
                                this.Hide(); // Hide the login form
                            }));
                        }
                        else
                        {
                            // Invoke to update UI thread
                            this.Invoke(new Action(() =>
                            {
                                // Show an error message if login fails
                                MessageBox.Show("Incorrect Login", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                        }
                    }
                }
            });
        }

        public async void ValidateTutor(int tutorId, string password)
        {
            await Task.Run(() =>
            {
                // Create a new SQL connection using the connection string
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open(); // Open the connection
                    // Create a SQL command to select student details
                    SqlCommand cmd = new SqlCommand("SELECT tutorID, name, email, password, profileImage FROM Tutor WHERE tutorID = @tutorID AND password = @password", conn);
                    cmd.Parameters.AddWithValue("@tutorId", tutorId); // Add student ID parameter
                    cmd.Parameters.AddWithValue("@password", password); // Add password parameter

                    // Execute the command and read the results
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If a matching record is found
                        {
                            // Create a new Student object from the database record
                            Tutor tutor = new Tutor(
                                reader.GetInt32(0),
                                reader.IsDBNull(1) ? null : reader.GetString(1),
                                reader.IsDBNull(2) ? null : reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3),
                                reader.IsDBNull(4) ? null : reader.GetFieldValue<byte[]>(4)
                            );

                            // Invoke to update UI thread
                            this.Invoke(new Action(() =>
                            {
                                // Create and show the main form, passing the student object
                                //MainForm main = new MainForm(tutor);
                                //main.Show();
                                //this.Hide(); // Hide the login form
                            }));
                        }
                        else
                        {
                            // Invoke to update UI thread
                            this.Invoke(new Action(() =>
                            {
                                // Show an error message if login fails
                                MessageBox.Show("Incorrect Login", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                        }
                    }
                }
            });
        }

        // Override ProcessCmdKey to detect Enter key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                signBtn.PerformClick(); // Simulate a click on the sign-in button
                return true; // Indicate that the key press has been handled
            }
            return base.ProcessCmdKey(ref msg, keyData); // Call the base method for other key presses
        }

        // Event handler for Show Password checkbox
        private void showPasswordCb_CheckedChanged(object sender, EventArgs e)
        {
            passwordTb.PasswordChar = showPasswordCb.Checked ? '\0' : '*';
        }

        // Method to save credentials if Remember Me is checked
        private void SaveCredentials()
        {
            if (rememberMeCb.Checked)
            {
                Properties.Settings.Default.Username = usernameTb.Text;
                Properties.Settings.Default.Password = passwordTb.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        // Method to load saved credentials if available
        private void LoadCredentials()
        {
            usernameTb.Text = Properties.Settings.Default.Username;
            passwordTb.Text = Properties.Settings.Default.Password;
            passwordTb.PasswordChar = '*';
            rememberMeCb.Checked = !string.IsNullOrEmpty(Properties.Settings.Default.Username);
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void headerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void registerTutorBtn_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm(false); // Create a new registration form
            register.Show(); // Show the registration form
            this.Hide(); // Hide the current form
        }

        private void coordinatorBtn_Click(object sender, EventArgs e)
        {
            Smartloop_Feedback.Objects.Coordinator coordinator = new Smartloop_Feedback.Objects.Coordinator();
            CoordinatorMainForm coordintaorMain = new CoordinatorMainForm(coordinator);
            coordintaorMain.Show();
            this.Hide();
        }
    }
}
