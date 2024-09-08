using Smartloop_Feedback.Academic_Portfolio.Add_Form;
using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class AssessmentForm : Form
    {
        public StudentAssessment assessment;
        public MainForm mainForm;

        public AssessmentForm(StudentAssessment assessment, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.assessment = assessment;
        }

        private void AssessmentForm_Load(object sender, EventArgs e)
        {
            markTb.Text = assessment.FinalMark.ToString() + "/" + assessment.Mark.ToString();
            dateP.Value = assessment.Date;
            descriptionRb.Text = assessment.Description;
            finaliseCb.Checked = assessment.IsFinalised;
            feedbackRb.Text = assessment.FinalFeedback;

            PopulateCheckListBox();

            // Set initial visibility of panels
            panelDetails.Visible = true;
            panelCriteria.Visible = false;

            // Configure the DataGridView for criteria
            if(assessment.CriteriaList.Count != 0)
            {
                LoadCriteriaData();
            }
            if(assessment.FeedbackList.Count != 0)
            {
                LoadAttemptData();
            }
            isFinalised();
        }

        private void PopulateCheckListBox()
        {
            checklistCb.Items.Clear();

            foreach(var item in assessment.CheckList)
            {
                // Add item to the CheckedListBox
                int index = checklistCb.Items.Add(item.Name);

                // Set the checked state based on isChecked property
                checklistCb.SetItemChecked(index, item.IsChecked);
            }

            assessment.CalculateStatus();
            progressBar.Value = assessment.Status;
        }

        private void LoadCriteriaData()
        {
            // Set up the initial DataGridView column
            criteriaDgv.ColumnCount = 1;
            criteriaDgv.Columns[0].Name = "Criteria";
            criteriaDgv.Columns[0].Width = 300;

            // Allow the user to add rows
            criteriaDgv.AllowUserToAddRows = true;

            foreach(Rating rating in assessment.CriteriaList[0].RatingList)
            {
                criteriaDgv.Columns.Add(rating.Grade, rating.Grade);
            }

            for(int i = 0; i < assessment.CriteriaList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(criteriaDgv);
                row.Cells[0].Value = assessment.CriteriaList[i].Description;

                for(int j = 0; j < assessment.CriteriaList[i].RatingList.Count; j++)
                {
                    row.Cells[j+1].Value = assessment.CriteriaList[i].RatingList[j].Description;
                }

                criteriaDgv.Rows.Add(row);
            }

            DataGridColor(criteriaDgv);
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

        private void isFinalised()
        {
            if(assessment.IsFinalised)
            {
                markTb.Enabled = false;
                dateP.Enabled = false;
                descriptionRb.Enabled = false;
                checklistCb.Enabled = false;
                itemBtn.Enabled = false;
                attemptBtn.Enabled = false;
            }
        }

        private void canvasBtn_Click(object sender, EventArgs e)
        {
            OpenUrl(assessment.CanvasLink);
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the URL: " + ex.Message);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            assessment.UpdateAssessmentToDatabase(descriptionRb.Text, dateP.Value, finaliseCb.Checked);
            mainForm.MainPannel(0);
        }

        private void itemBtn_Click(object sender, EventArgs e)
        {
            using (var addCheckList = new AddCheckListForm()) // Open the add year form
            {
                if (addCheckList.ShowDialog() == DialogResult.OK) // Check if the dialog result is OK
                {
                    string name = addCheckList.name; // Get the new year's name

                    assessment.CheckList.Add(new CheckList(name, assessment.StudentId, false, assessment.Id));
                    
                    PopulateCheckListBox();
                }
            }
        }

        private void checklistCb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            bool isChecked = e.NewValue == CheckState.Checked;
            assessment.CheckList[index].UpdateChecked(isChecked);

            assessment.CalculateStatus();
            progressBar.Value = assessment.Status;
        }

        private void markTb_Leave(object sender, EventArgs e)
        {
            string[] parts = markTb.Text.Split('/');

            if(parts.Length == 2)
            {
                double firstNumber = double.Parse(parts[0]);
                double secondNumber = double.Parse(parts[1]);

                if(firstNumber > secondNumber)
                {
                    MessageBox.Show("Please ensure that the total mark is not more then 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                assessment.FinalMark = firstNumber;
                assessment.Mark = secondNumber;
            }
            else
            {
                MessageBox.Show("Please enter marks as xx/xx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void markTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is not a digit, '/', or another allowed character like '.'
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                // If it's not an allowed character, then handle the event and prevent the character from being entered
                e.Handled = true;
            }

        }

        private void bacBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = true;
            panelCriteria.Visible = false;
        }

        private void rubricBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelCriteria.Visible = true;
        }

        private void attemptBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(10);
        }

        private void attemptDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.attemptDgv.Rows[e.RowIndex];
                mainForm.position[4] = (int)row.Tag;
                mainForm.MainPannel(10); // Navigate to the main panel
            }
        }
    }
}
