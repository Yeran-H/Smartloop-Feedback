using Smartloop_Feedback.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting
{
    public partial class EditCourseForm : Form
    {
        public Semester semester; // Reference to the semester object
        public MainForm mainForm; // Reference to the main form
        public int courseId; // ID of the course being edited

        // Constructor for EditCourseForm, initializes the form with the semester, main form, and course ID
        public EditCourseForm(Semester semester, MainForm mainForm, int courseId)
        {
            InitializeComponent();
            this.semester = semester;
            this.mainForm = mainForm;
            this.courseId = courseId;
        }

        // Event handler for form load
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            // Populate the form fields with the course's current information
            codeTb.Text = semester.CourseList[courseId].Code.ToString();
            nameTb.Text = semester.CourseList[courseId].Title;
            creditTb.Text = semester.CourseList[courseId].CreditPoint.ToString();
            descriptionTb.Text = semester.CourseList[courseId].Description;
            canvasTb.Text = semester.CourseList[courseId].CanvasLink;
        }

        // Event handler for update button click to update the course information
        private void updateBtn_Click(object sender, EventArgs e)
        {
            semester.CourseList[courseId].UpdateCourseToDatabase(
                Int32.Parse(codeTb.Text), nameTb.Text, Int32.Parse(creditTb.Text),
                descriptionTb.Text, canvasTb.Text
            );
        }

        // Event handler for delete button click to delete the course record
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the course record? This will result in removing all associated objects as well.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                semester.DeleteCourseFromDatabase(courseId);
                mainForm.MainPannel(7);
                mainForm.MenuPanel(6);
            }
        }
    }
}
