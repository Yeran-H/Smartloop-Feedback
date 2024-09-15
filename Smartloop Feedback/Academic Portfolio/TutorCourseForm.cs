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
                mainForm.MainPannel(2); // Navigate to the main panel
            }
        }
    }
}
