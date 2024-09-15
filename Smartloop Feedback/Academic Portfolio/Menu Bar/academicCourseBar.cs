using Smartloop_Feedback.Academic_Portfolio.Add_Form;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using Smartloop_Feedback.Objects.User_Object.Tutor;
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
        private SemesterAssociation semester; // Reference to the current semester

        // Constructor for academicCourseBar
        public AcademicCourseBar(MainForm form, SemesterAssociation semester)
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
            Image buttonImage = Properties.Resources.School;
            int buttonCount = 0;

            foreach (int code in semester.CourseList.Keys)
            {
                Button btn = new Button
                {
                    Text = code.ToString(),
                    Dock = DockStyle.Top,
                    Height = 42,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Aptos", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193),
                    FlatAppearance = { BorderSize = 0 },
                    Image = buttonImage,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };
                btn.Click += new EventHandler(CourseBtn_Click);
                Controls.Add(btn);
                buttonCount++;
            }

            addBtn.Dock = DockStyle.Top;
            Controls.Add(addBtn);
            backBtn.Dock = DockStyle.Top;
            Controls.Add(backBtn);

            int totalHeight = backBtn.Height + addBtn.Height + 42 * buttonCount;
            this.ClientSize = new Size(170, totalHeight);
        }

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(2); // Navigate to the previous menu panel
        }

        // Event handler for the add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var addCourseForm = new AddCourseForm(semester, semester.IsStudent)) 
            {
                if (addCourseForm.ShowDialog() == DialogResult.OK) 
                {
                    if(semester.IsStudent)
                    {
                        semester.CourseList.Add(addCourseForm.course.Code, new StudentCourse(addCourseForm.course.CourseId, semester.UserId, semester.Id, semester.IsStudent, addCourseForm.tutorialId[0]));
                    }
                    else
                    {
                        semester.CourseList.Add(addCourseForm.course.Code, new TutorCourse(addCourseForm.course.CourseId, semester.UserId, semester.Id, semester.IsStudent, addCourseForm.tutorialId));
                    }

                    InitializeBar();
                }
            }
        }

        // Common event handler for all course button clicks
        private void CourseBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                mainForm.position[2] = Int32.Parse(clickedButton.Text); // Set the main form's position with the button text
                mainForm.MainPannel(1); 
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
