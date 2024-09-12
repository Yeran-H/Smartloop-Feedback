using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.Hosting;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting
{
    public partial class EditAccountForm : Form
    {
        public User user; // Reference to the student object
        public MainForm mainForm; // Reference to the main form

        // Constructor for EditAccountForm, initializes the form with the student and main form references
        public EditAccountForm(User user, MainForm mainForm)
        {
            InitializeComponent();
            this.user = user;
            this.mainForm = mainForm;
        }

        // Event handler for form load
        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            // Populate the form fields with the student's current information
            nameTb.Text = user.Name;
            emailTb.Text = user.Email;
            passwordTb.Text = user.Password;
            if(user is Student student)
            {
                degreeTb.Text = student.Degree;
            }
            else
            {
                degreeTb.Visible = false;
                degreePl.Visible = false;
                degreePb.Visible = false;
            }

            // If the student has a profile image, display it
            if (user.ProfileImage != null)
            {
                using (var ms = new MemoryStream(user.ProfileImage))
                {
                    profilePb.Image = Image.FromStream(ms);
                }
            }
        }

        // Event handler for profile button click to select a new profile image
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

        // Event handler for update button click to update student information
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
                    profileImage = user.ProfileImage;
                }
            }

            User newUser = new User(0, name, email, password, profileImage, user.IsStudent);

            // Validate the password
            if (!newUser.ValidatePassword())
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the email address
            if (!newUser.ValidateEmail())
            {
                MessageBox.Show("Email must end with @student.uts.edu.au or @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the user information in the database
            if(user is Student student)
            {
                student.Name = name;
                student.Email = email;
                student.Password = password;
                student.Degree = degree;
                student.ProfileImage = profileImage;
                student.UpdateToDatabase();
            }

            // Navigate to the main panel
            mainForm.MainPannel(6);
        }

        // Event handler for delete button click to delete the student record
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
                // Delete the student record from the database
                //student.DeleteStudentFromDatabase();
            }

            // Navigate to the main panel
            mainForm.MainPannel(3);
        }
    }
}
