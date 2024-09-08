using Smartloop_Feedback.Coordinator_Folder;
using Smartloop_Feedback.Forms;
using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Coordinator
{
    public partial class CoordinatorCourse : Form
    {
        private Course course;
        private CoordinatorMain mainForm;
        public CoordinatorCourse(Course course, CoordinatorMain mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
        }

        private void CoordinatorCourse_Load(object sender, EventArgs e)
        {
            codeTb.Text = course.Code.ToString();
            nameTb.Text = course.Name;
            creditTb.Text = course.CreditPoint.ToString();
            descriptionTb.Text = course.Description;
            canvasTb.Text = course.CanvasLink;
            yearTb.Text = course.Year.ToString();

            switch (course.Semester)
            {
                case "Summer":
                    summerRb.Checked = true;
                    break;
                case "Autumn":
                    autumnRb.Checked = true;
                    break;
                case "Winter":
                    winterRb.Checked = true;
                    break;
                case "Spring":
                    springRb.Checked = true;
                    break;
            }

            LoadAssessmentData();
        }

        private void LoadAssessmentData()
        {
            if (course.AssessmentList != null)
            {
                assessmentDgv.Rows.Clear(); // Clear existing rows
                assessmentDgv.Columns.Clear(); // Clear existing columns

                // Add columns to the DataGridView
                assessmentDgv.Columns.Add("Nam", "Name");
                assessmentDgv.Columns.Add("Date", "Date");
                assessmentDgv.Columns.Add("Weight", "Weight");
                assessmentDgv.Columns.Add("Mark", "Mark");

                DataGridViewButtonColumn viewColumn = new DataGridViewButtonColumn
                {
                    Name = "View",
                    HeaderText = "View",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                assessmentDgv.Columns.Add(viewColumn);

                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                assessmentDgv.Columns.Add(deleteColumn);

                // Add rows to the DataGridView
                foreach (Assessment assessment in course.AssessmentList.Values)
                {
                    int rowIndex = assessmentDgv.Rows.Add(assessment.Name, assessment.Date, assessment.Weight, assessment.Mark, "View", "Delete");
                    DataGridViewRow row = assessmentDgv.Rows[rowIndex];
                    row.Tag = assessment.Id;
                }

                DataGridColor(assessmentDgv); // Apply color formatting to the DataGridView
            }
        }

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

        // Event handler to allow only digits in the code TextBox
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore non-digit input
                }
            }
        }

        // Event handler for when any TextBox receives focus
        private void TextBox_Enter(object sender, EventArgs e)
        {
            defaultUI(); // Reset UI to default state

            TextBox currentTextBox = sender as TextBox;

            // Update UI to indicate the TextBox is active
            if (currentTextBox == codeTb)
            {
                codePl.BackColor = Color.FromArgb(254, 0, 57);
                codeTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == nameTb)
            {
                namePl.BackColor = Color.FromArgb(254, 0, 57);
                nameTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == creditTb)
            {
                creditPl.BackColor = Color.FromArgb(254, 0, 57);
                creditTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == yearTb)
            {
                yearPl.BackColor = Color.FromArgb(254, 0, 57);
                yearTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == canvasTb)
            {
                canvasPl.BackColor = Color.FromArgb(254, 0, 57);
                canvasTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
        }

        // Reset UI to default state
        private void defaultUI()
        {
            namePl.BackColor = Color.FromArgb(193, 193, 193);
            nameTb.ForeColor = Color.FromArgb(193, 193, 193);

            codePl.BackColor = Color.FromArgb(193, 193, 193);
            codeTb.ForeColor = Color.FromArgb(193, 193, 193);

            creditPl.BackColor = Color.FromArgb(193, 193, 193);
            creditTb.ForeColor = Color.FromArgb(193, 193, 193);

            yearPl.BackColor = Color.FromArgb(193, 193, 193);
            yearTb.ForeColor = Color.FromArgb(193, 193, 193);

            canvasPl.BackColor = Color.FromArgb(193, 193, 193);
            canvasTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string semester = autumnRb.Checked ? "Autumn" :
                                summerRb.Checked ? "Summer" :
                                springRb.Checked ? "Spring" :
                                winterRb.Checked ? "Winter" : null;

            if (!string.IsNullOrEmpty(nameTb.Text) || !string.IsNullOrEmpty(descriptionTb.Text) || !string.IsNullOrEmpty(canvasTb.Text) || !string.IsNullOrEmpty(yearTb.Text))
            {
                course.UpdateCourseToDatabase(Int32.Parse(codeTb.Text), nameTb.Text, Int32.Parse(creditTb.Text), descriptionTb.Text, yearTb.Text, semester, canvasTb.Text);
                mainForm.MainPannel(0);
            }
            else
            {
                MessageBox.Show("Please fill out all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if any field is empty
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(2);
        }
    }
}
