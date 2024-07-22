using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Smartloop_Feedback.Settings
{
    public partial class SettingForm : Form
    {
        public Student student;
        public MainForm mainForm;
        public SettingForm(Student student, MainForm mainForm)
        {
            InitializeComponent();
            this.student = student;
            this.mainForm = mainForm;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            PopulateValue();
        }

        private void settingsTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = settingsTab.SelectedTab;

            if (selectedTab != null && selectedTab.Controls.Count == 0)
            {
                string name = selectedTab.Text;

                switch (name)
                {
                    case "Assessment":
                        EditAssessmentForm assessmentForm = new EditAssessmentForm(student)
                        {
                            Dock = DockStyle.Fill,
                            TopLevel = false,
                            TopMost = true,
                            FormBorderStyle = FormBorderStyle.None
                        };

                        // Clear any existing controls in the selected tab page
                        selectedTab.Controls.Clear();

                        // Add the form to the selected tab page
                        selectedTab.Controls.Add(assessmentForm);
                        assessmentForm.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        private void PopulateValue()
        {
            nameTb.Text = student.name;
            emailTb.Text = student.email;
            passwordTb.Text = student.password;
            degreeTb.Text = student.degree;
            if (student.profileImage != null)
            {
                using (var ms = new System.IO.MemoryStream(student.profileImage))
                {
                    profilePb.Image = System.Drawing.Image.FromStream(ms);
                }
            }
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string email = emailTb.Text;
            string password = passwordTb.Text;
            string degree = degreeTb.Text;
            byte[] profileImage = null;

            // Convert the profile image to a byte array
            if (profilePb.Image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        profilePb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        profileImage = ms.ToArray();
                    }
                }
                catch (ExternalException)
                {
                    profileImage = student.profileImage;
                }
            }

            Student newStudent = new Student(0, name, email, password, degree, profileImage);

            // Validate the password
            if (!newStudent.ValidatePassword())
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the email address
            if (!newStudent.ValidateEmail())
            {
                MessageBox.Show("Email must end with @student.uts.edu.au or @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            student.UpdateInDatabase(newStudent);

            mainForm.MainPannel(3);
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the student record? This will result in removing all associated objects as well.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                student.DeleteStudentFromDatabase();
            }

            mainForm.MainPannel(4);
        }
    }
}
