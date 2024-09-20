using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Academic_Portfolio
{
    public partial class TutorialStudentAssessmentForm : Form
    {
        public StudentAssessment assessment;
        public MainForm mainForm;
        public TutorialStudentAssessmentForm(StudentAssessment assessment, MainForm mainForm)
        {
            InitializeComponent();
            this.assessment = assessment;
            this.mainForm = mainForm;
            tutorialLb.Text = "Student: " + assessment.UserId + Environment.NewLine + "Assessment: " + assessment.Name;
            markTb.Text = assessment.StudentMark.ToString() + "/" + assessment.Mark.ToString();
            feedbackRb.Text = assessment.Feedback;

            if (assessment.FeedbackList.Count != 0)
            {
                LoadAttemptData();
            }
        }

        private void LoadAttemptData()
        {
            attemptDgv.Rows.Clear(); // Clear existing rows
            attemptDgv.Columns.Clear(); // Clear existing columns

            DataGridViewButtonColumn attemptColumn = new DataGridViewButtonColumn
            {
                Name = "Attempt",
                HeaderText = "Attempt",
                UseColumnTextForButtonValue = false,
                CellTemplate = new StyledButtonCell()
            };
            attemptDgv.Columns.Add(attemptColumn);
            attemptDgv.Columns.Add("File", "File");

            foreach (FeedbackResult feedbackResult in assessment.FeedbackList.Values)
            {
                int rowIndex = attemptDgv.Rows.Add(feedbackResult.Attempt.ToString(), feedbackResult.FileName);
                DataGridViewRow row = attemptDgv.Rows[rowIndex];
                row.Tag = feedbackResult.Attempt;
            }

            DataGridColor(attemptDgv);
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(1);
        }

        private void attemptDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.attemptDgv.Rows[e.RowIndex];
                mainForm.position[6] = (int)row.Tag;
                mainForm.MainPannel(3); 
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string[] parts = markTb.Text.Split('/');

            if (parts.Length == 2)
            {
                double firstNumber = double.Parse(parts[0]);
                double secondNumber = double.Parse(parts[1]);

                if (firstNumber > secondNumber)
                {
                    MessageBox.Show("Please ensure that the total mark is not more then 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                assessment.StudentMark = firstNumber;
                assessment.UpdateAssessmentToDatabase(true);
            }
            else
            {
                MessageBox.Show("Please enter marks as xx/xx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
