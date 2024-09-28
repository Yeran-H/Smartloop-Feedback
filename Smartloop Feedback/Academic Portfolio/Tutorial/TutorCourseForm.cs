using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.User_Object.Tutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Web.UI;

namespace Smartloop_Feedback.Academic_Portfolio
{
    public partial class TutorCourseForm : Form
    {
        public TutorCourse tutorCourse;
        public MainForm mainForm;
        public TutorCourseForm(TutorCourse tutorCourse, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.tutorCourse = tutorCourse;
            studentDgv.Visible = false;
            feedbackRb.Visible = false;
            tutorialLb.Visible = false;
            feedbackLb.Visible = false;
            feedbackCb.Visible = false;
            assessmentCb.Visible = false;
            PopulateTutorialDGV();
        }

        private void PopulateTutorialDGV()
        {
            if (tutorCourse.TutorTutorialList != null)
            {
                tutorialDgv.Rows.Clear(); // Clear existing rows
                tutorialDgv.Columns.Clear(); // Clear existing columns

                // Add columns to the DataGridView
                DataGridViewButtonColumn nameColumn = new DataGridViewButtonColumn
                {
                    Name = "Name",
                    HeaderText = "Name",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                tutorialDgv.Columns.Add(nameColumn);

                // Add rows to the DataGridView
                foreach (TutorialAssociation tutorial in tutorCourse.TutorTutorialList.Values)
                {
                    int rowIndex = tutorialDgv.Rows.Add(tutorial.Name);
                    DataGridViewRow row = tutorialDgv.Rows[rowIndex];
                    row.Tag = tutorial.Id; // Tag the row with the assessment ID
                }

                DataGridColor(tutorialDgv); // Apply color formatting to the DataGridView
            }
        }

        // Apply custom color formatting to a DataGridView
        private void DataGridColor(System.Windows.Forms.DataGridView grid)
        {
            // Set DataGridView properties
            grid.BackgroundColor = Color.FromArgb(16, 34, 61);
            grid.GridColor = Color.FromArgb(254, 0, 57);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.DefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set column header style
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set row header style
            grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set cell border style
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set button cell style specifically
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.CellTemplate is StyledButtonCell)
                {
                    col.DefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
                    col.DefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
                    col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
                    col.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);
                }
            }
        }

        private void tutorialDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tutorialDgv.Rows[e.RowIndex];
                mainForm.position[3] = (int)row.Tag; // Set position for navigation
                PopulateTutorial();
            }
        }

        private void PopulateTutorial()
        {
            studentDgv.Visible = true;
            feedbackRb.Visible = true;
            tutorialLb.Visible = true;
            feedbackLb.Visible = true;
            feedbackCb.Visible = true;
            assessmentCb.Visible = true;


            tutorialLb.Text = "Tutorial " + tutorCourse.TutorTutorialList[(int)mainForm.position[3]].Name + " Student List";
            PopulateStudentDGV();
            PopulateFeedback();
        }

        private void PopulateStudentDGV()
        {
            if (tutorCourse.TutorTutorialList[(int)mainForm.position[3]].StudentList != null)
            {
                // Clear existing rows and columns
                studentDgv.Rows.Clear();
                studentDgv.Columns.Clear();

                // Add the Student ID column
                studentDgv.Columns.Add("Student ID", "Student ID");

                // Counter to keep track of assessments
                int count = 0;

                // Add columns for each assessment
                foreach (Assessment assessment in tutorCourse.TutorTutorialList[(int)mainForm.position[3]].StudentList.First().Value.StudentAssessmentList.Values)
                {
                    count++;
                    DataGridViewButtonColumn assessmentColumn = new DataGridViewButtonColumn
                    {
                        Name = assessment.Name,
                        HeaderText = assessment.Name,
                        UseColumnTextForButtonValue = true, // Ensure text is used on the button
                        Text = "View", // Set the text to display on the button
                        CellTemplate = new StyledButtonCell() // Make sure this does not interfere with button text
                    };
                    studentDgv.Columns.Add(assessmentColumn);
                }

                // Add rows to the DataGridView
                foreach (StudentCourse studentCourse in tutorCourse.TutorTutorialList[(int)mainForm.position[3]].StudentList.Values)
                {
                    // Add a new row with the Student ID
                    int rowIndex = studentDgv.Rows.Add(studentCourse.UserId.ToString());

                    DataGridViewRow row = studentDgv.Rows[rowIndex];
                    row.Tag = studentCourse.Id; // Store the student ID in the row's tag

                    // Populate cells for each assessment with the "View" button
                    foreach (Assessment assessment in studentCourse.StudentAssessmentList.Values)
                    {
                        row.Cells[assessment.Name].Value = "View"; // Use assessment.Name to reference the correct column
                    }
                }

                // Apply color formatting to the DataGridView
                DataGridColor(studentDgv);

            }
        }

        private void studentDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.studentDgv.Rows[e.RowIndex];
                StudentCourse studentCourse = tutorCourse.TutorTutorialList[(int)mainForm.position[3]].StudentList[(int)row.Tag];

                foreach (StudentAssessment assessment in studentCourse.StudentAssessmentList.Values)
                {
                    if (assessment.Name == studentDgv.Columns[e.ColumnIndex].Name)
                    {
                        mainForm.position[4] = studentCourse.Id;
                        mainForm.position[5] = assessment.Id;
                        mainForm.MainPannel(9);
                    }
                }
            }
        }

        private void PopulateFeedback()
        {
            assessmentCb.DisplayMember = "Key";
            feedbackCb.DisplayMember = "Key";

            foreach (TutorialAssessment tutorialAssessment in tutorCourse.TutorTutorialList[(int)mainForm.position[3]].AssessmentList.Values)
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(tutorialAssessment.Name, tutorialAssessment.Id);
                assessmentCb.Items.Add(pair);

                if (tutorialAssessment.IsCompleted)
                {
                    assessmentCb.SetItemChecked(feedbackCb.Items.Count - 1, true);
                }

                feedbackCb.Items.Add(pair);
            }

            feedbackCb.Items.Add(new KeyValuePair<string, int>("General Feedback", -1));
        }

        private void feedbackCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (feedbackCb.SelectedIndex >= 0)
            {
                var selectedItem = (KeyValuePair<string, int>)feedbackCb.Items[feedbackCb.SelectedIndex];
                int tag = (int)selectedItem.Value;

                if(tag == -1)
                {
                    feedbackRb.Text = tutorCourse.TutorTutorialList[(int)mainForm.position[3]].GeneralFeedback;
                }
                else
                {
                    feedbackRb.Text = tutorCourse.TutorTutorialList[(int)mainForm.position[3]].AssessmentList[tag].General;
                }
            }
        }

        private async void assessmentCb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedItem = assessmentCb.Items[e.Index];

            var item = (KeyValuePair<string, int>)selectedItem;
            int tag = item.Value;

            if (e.NewValue == CheckState.Checked)
            {
                await tutorCourse.TutorTutorialList[(int)mainForm.position[3]].AssessmentList[tag].UpdateAssessmentToDatabase(true);
                await tutorCourse.TutorTutorialList[(int)mainForm.position[3]].GetGeneralFeedback();
            }
        }
    }
}
