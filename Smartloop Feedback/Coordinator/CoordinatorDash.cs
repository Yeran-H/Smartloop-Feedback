using Smartloop_Feedback.Coordinator_Folder;
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
    public partial class CoordinatorDash : Form
    {
        private Smartloop_Feedback.Objects.Coordinator coordinator;
        private CoordinatorMain mainForm;

        public CoordinatorDash(Smartloop_Feedback.Objects.Coordinator coordinator, CoordinatorMain mainForm)
        {
            InitializeComponent();
            this.coordinator = coordinator;
            this.mainForm = mainForm;
        }

        private void CoordinatorDash_Load(object sender, EventArgs e)
        {
            if (coordinator.courseList != null)
            {
                courseDgv.Rows.Clear(); // Clear existing rows
                courseDgv.Columns.Clear(); // Clear existing columns

                // Add columns to the DataGridView
                courseDgv.Columns.Add("Year", "Year");
                courseDgv.Columns.Add("Semester", "Semester");
                courseDgv.Columns.Add("Course Code", "Course Code");
                courseDgv.Columns.Add("Course Name", "Course Name");

                DataGridViewButtonColumn viewColumn = new DataGridViewButtonColumn
                {
                    Name = "View",
                    HeaderText = "View",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                courseDgv.Columns.Add(viewColumn);

                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                courseDgv.Columns.Add(editColumn);

                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                courseDgv.Columns.Add(deleteColumn);


                // Add rows to the DataGridView
                foreach (Course course in coordinator.courseList.Values)
                {
                    int rowIndex = courseDgv.Rows.Add(course.Year, course.Semester, course.Code, course.Name);
                    DataGridViewRow row = courseDgv.Rows[rowIndex];
                    row.Tag = course.Id; // Tag the row with the assessment ID
                }

                DataGridColor(courseDgv); // Apply color formatting to the DataGridView
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
    }
}
