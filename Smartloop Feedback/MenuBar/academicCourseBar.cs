using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class academicCourseBar : Form
    {
        private mainForm mainForm; // Reference to the main form
        private Semester semester; // Reference to the current semester

        private int buttonCount = 0; // Counter for the number of buttons
        private Button[] buttons = new Button[5]; // Array to hold the course buttons
        private Button[] allButtons;

        // Constructor for academicCourseBar
        public academicCourseBar(mainForm form, Semester semester)
        {
            InitializeComponent(); // Initialize form components
            navPl.Height = backBtn.Height;
            navPl.Top = backBtn.Top;
            navPl.Left = backBtn.Left;

            mainForm = form; // Set the main form reference
            this.semester = semester; // Set the semester reference
            InitializeBar(); // Initialize the course bar
        }

        // Initialize the course bar with course buttons based on the number of courses
        private void InitializeBar()
        {
            buttonCount = semester.numCourse(); // Get the number of courses in the semester

            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn };

            for (int i = 0; i < buttonCount; i++)
            {
                Button btn = allButtons[i]; // Get the button for the current course
                btn.Visible = true; // Make the button visible
                btn.Text = semester.courseList[i].code.ToString(); // Set the button text to the course code
                buttons[i] = btn; // Store the button in the array
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
            mainForm.menuPannel(2); // Navigate to the previous menu panel
        }

        // Event handler for the add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (semester == null)
            {
                MessageBox.Show("Semester object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (semester.courseList == null)
            {
                semester.courseList = new List<Course>();
            }

            using (var addCourseForm = new addCourseForm())
            {
                if (addCourseForm.ShowDialog() == DialogResult.OK)
                {
                    if (buttonCount < 5)
                    {
                        Course course = addCourseForm.course;
                        if (course != null)
                        {
                            semester.courseList.Add(new Course(course.code, course.title, course.creditPoint, course.description, course.canvasLink, semester.id, semester.studentId));
                        }
                        else
                        {
                            MessageBox.Show("Course is not properly initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Button btn = allButtons[buttonCount];
                        btn.Visible = true;
                        btn.Text = course.code.ToString();
                        buttonCount++;

                        if (buttonCount == 5)
                        {
                            addBtn.Visible = false; // Hide the add button if the maximum number of buttons is reached
                        }

                        UpdatePanel(); // Update the panel to reflect changes
                    }
                }
            }
        }

        // Update the panel by re-adding controls in the correct order
        private void UpdatePanel()
        {
            Controls.Clear(); // Clear all controls

            // Add the course buttons in reverse order to dock them at the top
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
            Button clickedButton = sender as Button; // Get the clicked button
            int index = Array.IndexOf(buttons, clickedButton); // Get the index of the clicked button
            if (index >= 0)
            {
                mainForm.position[2] = index; // Set the main form's position to the selected course
                mainForm.mainPannel(0); // Navigate to the corresponding course panel
            }

            navPl.Height = clickedButton.Height; // Adjust the navigation panel to the clicked button
            navPl.Top = clickedButton.Top;
            navPl.Left = clickedButton.Left;
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
