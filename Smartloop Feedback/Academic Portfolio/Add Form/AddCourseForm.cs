using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Academic_Portfolio.Add_Form
{
    public partial class AddCourseForm : Form
    {
        private Semester Semester;
        private Smartloop_Feedback.Objects.Coordinator Coordinator;
        public Course course;
        public int tutorialId;
        private bool IsStudent;

        public AddCourseForm(Semester semester, bool IsStudent)
        {
            InitializeComponent();
            this.Semester = semester;
            this.IsStudent = IsStudent;
            Coordinator = new Smartloop_Feedback.Objects.Coordinator(semester);
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
            if(Coordinator.CourseList != null)
            {
                courseDgv.Rows.Clear();
                courseDgv.Columns.Clear();

                courseDgv.Columns.Add("Code", "Code");
                courseDgv.Columns.Add("Name", "Name");

                DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn
                {
                    Name = "Select",
                    HeaderText = "Select",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                courseDgv.Columns.Add(addColumn);

                foreach (Course course in Coordinator.CourseList.Values)
                {
                    int rowIndex = courseDgv.Rows.Add(course.Code, course.Name, "Select");
                    DataGridViewRow row = courseDgv.Rows[rowIndex];
                    row.Tag = course.CourseId;
                }

                DataGridColor(courseDgv);
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

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string filterText = searchTb.Text.ToLower();

            // Clear the current rows
            courseDgv.Rows.Clear();

            // Iterate through the course list and add only those that match the filter
            foreach (Course course in Coordinator.CourseList.Values)
            {
                // Check if the code or name contains the filter text
                if (course.Code.ToString().Contains(filterText) || course.Name.ToLower().Contains(filterText))
                {
                    int rowIndex = courseDgv.Rows.Add(course.Code, course.Name, "Select");
                    DataGridViewRow row = courseDgv.Rows[rowIndex];
                    row.Tag = course.CourseId;
                }
            }
        }

        private void searchTb_Enter(object sender, EventArgs e)
        {
            searchTb.Clear();
        }

        private void courseDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = courseDgv.Rows[e.RowIndex];
                course = Coordinator.CourseList[(int)row.Tag];

                if (course.TutorialList != null)
                {
                    tutorialDgv.Rows.Clear();
                    tutorialDgv.Columns.Clear();

                    tutorialDgv.Columns.Add("Name", "Name");

                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Select",
                        HeaderText = "Select"
                    };
                    tutorialDgv.Columns.Add(checkBoxColumn);

                    foreach (Tutorial tutorial in course.TutorialList.Values)
                    {
                        int rowIndex = tutorialDgv.Rows.Add(tutorial.Name, false);
                        DataGridViewRow line = tutorialDgv.Rows[rowIndex];
                        line.Tag = course.CourseId;
                    }

                    DataGridColor(tutorialDgv);
                }
            }
        }

        private void tutorialDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on the checkbox column
            if (e.ColumnIndex == tutorialDgv.Columns["Select"].Index && e.RowIndex >= 0)
            {
                // Toggle the checkbox value
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)tutorialDgv.Rows[e.RowIndex].Cells["Select"];
                checkBoxCell.Value = !(checkBoxCell.Value == null ? false : (bool)checkBoxCell.Value);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(course != null)
            {
                if(IsStudent)
                {
                    if(NumChecked() == 1)
                    {
                        foreach (DataGridViewRow row in tutorialDgv.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Select"].Value))
                            {
                                tutorialId = (int)row.Tag;
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Must pick one tutorial class only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Course muct be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int NumChecked()
        {
            int count = 0;

            foreach(DataGridViewRow row in tutorialDgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    count++;
                }
            }

            return count;
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
