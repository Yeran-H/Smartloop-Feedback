using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
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

namespace Smartloop_Feedback.Academic_Portfolio
{
    public partial class TutorialClassForm : Form
    {
        public TutorialAssociation tutorialAssociation;
        public MainForm mainForm;

        public TutorialClassForm(TutorialAssociation tutorialAssociation, MainForm mainForm)
        {
            InitializeComponent();
            this.tutorialAssociation = tutorialAssociation;
            this.mainForm = mainForm;
            tutorialLb.Text = "Tutorial " + tutorialAssociation.Name + " Student List";
            PopulateStudentDGV();
        }

        private void PopulateStudentDGV()
        {
            if (tutorialAssociation.StudentList != null)
            {
                // Clear existing rows and columns
                studentDgv.Rows.Clear();
                studentDgv.Columns.Clear();

                // Add the Student ID column
                studentDgv.Columns.Add("Student ID", "Student ID");

                // Counter to keep track of assessments
                int count = 0;

                // Add columns for each assessment
                foreach (Assessment assessment in tutorialAssociation.StudentList.First().Value.StudentAssessmentList.Values)
                {
                    count++;
                    DataGridViewButtonColumn assessmentColumn = new DataGridViewButtonColumn
                    {
                        Name = "assessment-" + count,
                        HeaderText = assessment.Name,
                        UseColumnTextForButtonValue = true, // Ensure text is used on the button
                        Text = "View", // Set the text to display on the button
                        CellTemplate = new StyledButtonCell() // Make sure this does not interfere with button text
                    };
                    studentDgv.Columns.Add(assessmentColumn);
                }

                // Add rows to the DataGridView
                foreach (StudentCourse studentCourse in tutorialAssociation.StudentList.Values)
                {
                    // Add a new row with the Student ID
                    int rowIndex = studentDgv.Rows.Add(studentCourse.UserId.ToString());

                    DataGridViewRow row = studentDgv.Rows[rowIndex];
                    row.Tag = studentCourse.Id; // Store the student ID in the row's tag

                    // Populate cells for each assessment with the "View" button
                    for (int i = 1; i <= count; i++)
                    {
                        row.Cells["assessment-" + i].Value = "View";
                    }
                }

                // Apply color formatting to the DataGridView
                DataGridColor(studentDgv);

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

        private void studentDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
