using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class AcademicCourseBar : Form
    {
        private MainForm mainForm; // Reference to the main form
        private Semester semester; // Reference to the current semester

        private int buttonCount = 0; // Counter for the number of buttons
        private Button[] buttons = new Button[5]; // Array to hold the course buttons
        private Button[] allButtons;

        // Constructor for academicCourseBar
        public AcademicCourseBar(MainForm form, Semester semester)
        {
            InitializeComponent(); // Initialize form components

            mainForm = form; // Set the main form reference
            this.semester = semester; // Set the semester reference
            InitializeBar(); // Initialize the course bar

            navPl.Height = backBtn.Height;
            navPl.Top = backBtn.Top;
            navPl.Left = backBtn.Left - navPl.Width; // Adjust the position
        }

        // Initialize the course bar with course buttons based on the number of courses
        private void InitializeBar()
        {
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn };

            buttonCount = 0;
            foreach (Course course in semester.CourseList.Values)
            {
                Button btn = allButtons[buttonCount]; // Get the button for the current course
                btn.Visible = true; // Make the button visible
                btn.Text = course.Code.ToString(); // Set the button text to the course code
                buttons[buttonCount] = btn; // Store the button in the array
                btn.Tag = course.Id;

                buttonCount++;
            }

            if (buttonCount == 5)
            {
                addBtn.Visible = false; // Hide the add button if the maximum number of buttons is reached
            }

            UpdatePanel(); // Update the panel to reflect changes
        }

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(2); // Navigate to the previous menu panel
        }

        // Event handler for the add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (semester == null)
            {
                MessageBox.Show("Semester object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (semester.CourseList == null)
            {
                semester.CourseList = new SortedDictionary<int,Course>();
            }

            using (var addCourseForm = new AddCourseForm())
            {
                if (addCourseForm.ShowDialog() == DialogResult.OK)
                {
                    if (buttonCount < 5)
                    {
                        Course course = addCourseForm.course;
                        if (course != null)
                        {
                            Course temp = new Course(course.Code, course.Title, course.CreditPoint, course.Description, false, course.CanvasLink, semester.Id, semester.StudentId);
                            semester.CourseList.Add(temp.Id, temp);
                        }
                        else
                        {
                            MessageBox.Show("Course is not properly initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        InitializeBar(); // Update the panel to reflect changes
                    }
                }
            }
        }

        // Update the panel by re-adding controls in the correct order
        private void UpdatePanel()
        {
            Controls.Clear(); // Clear all controls

            // Add the year buttons in reverse order to dock them at the top
            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Controls.Add(buttons[i]);
                buttons[i].Dock = DockStyle.Top;
            }

            // Add the add button if there are less than 5 buttons
            if (buttonCount < 5)
            {
                Controls.Add(addBtn);
                addBtn.Dock = DockStyle.Top;
            }
            Controls.Add(backBtn); // Add the back button
            backBtn.Dock = DockStyle.Top;
        }

        // Common event handler for all course button clicks
        private void CourseBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                mainForm.position[2] = clickedButton.Tag; // Set the main form's position with the button text
                mainForm.MainPannel(0); // Navigate to the corresponding year's panel
            }

            navPl.Height = clickedButton.Height;
            navPl.Top = clickedButton.Top;
            navPl.Left = clickedButton.Left - navPl.Width;
            clickedButton.BackColor = Color.FromArgb(16, 34, 61); // Change the button color
        }

        // Reset button color when focus is lost
        private void ResetButtonColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(10, 22, 39);
        }
    }
}
