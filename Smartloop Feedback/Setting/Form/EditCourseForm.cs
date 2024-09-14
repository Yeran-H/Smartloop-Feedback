using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting
{
    public partial class EditCourseForm : Form
    {
        public SemesterAssociation semester; // Reference to the semester object
        public MainForm mainForm; // Reference to the main form
        private int courseCode;

        // Constructor for EditCourseForm, initializes the form with the semester, main form, and course ID
        public EditCourseForm(SemesterAssociation semester, MainForm mainForm)
        {
            InitializeComponent();
            this.semester = semester;
            this.mainForm = mainForm;
        }

        // Event handler for form load
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            if (semester.CourseList != null)
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

                foreach (Course course in semester.CourseList.Values)
                {
                    int rowIndex = courseDgv.Rows.Add(course.Code, course.Name, "Select");
                    DataGridViewRow row = courseDgv.Rows[rowIndex];
                    row.Tag = course.Code;
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

        // Event handler for update button click to update the course information
        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in tutorialDgv.Rows)
            {
                // Assuming the checkbox column is at index 0
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];

                // Check if the checkbox is checked
                if (checkBoxCell.Value != null && (bool)checkBoxCell.Value == true)
                {

                    if (semester.CourseList[courseCode] is StudentCourse studentCourse)
                    {
                        studentCourse.UpdateTutorialToDatabase((int)row.Tag);
                        return;
                    }
                }
            }
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
                semester.DeleteCourseFromDatabase(courseCode);
                mainForm.MainPannel(7);
                mainForm.MenuPanel(5);
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string filterText = searchTb.Text.ToLower();

            // Clear the current rows
            courseDgv.Rows.Clear();

            // Iterate through the course list and add only those that match the filter
            foreach (Course course in semester.CourseList.Values)
            {
                // Check if the code or name contains the filter text
                if (course.Code.ToString().Contains(filterText) || course.Name.ToLower().Contains(filterText))
                {
                    int rowIndex = courseDgv.Rows.Add(course.Code, course.Name, "Select");
                    DataGridViewRow row = courseDgv.Rows[rowIndex];
                    row.Tag = course.Code;
                }
            }
        }

        private void searchTb_Enter(object sender, EventArgs e)
        {
            searchTb.Clear();
        }

        private void courseDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = courseDgv.Rows[e.RowIndex];
                CourseAssociation course = semester.CourseList[(int)row.Tag];
                courseCode = course.Id;

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
                        if(course is StudentCourse studentCourse)
                        {
                            int rowIndex;

                            if(tutorial.Name == studentCourse.Tutorial.Name)
                            {
                                rowIndex = tutorialDgv.Rows.Add(tutorial.Name, true);
                            }
                            else
                            {
                                rowIndex = tutorialDgv.Rows.Add(tutorial.Name, false);
                            }

                            DataGridViewRow line = tutorialDgv.Rows[rowIndex];
                            line.Tag = tutorial.Id;
                        }
                    }

                    DataGridColor(tutorialDgv);
                }
            }
        }
    }
}
