using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting
{
    public partial class EditYearForms : Form
    {
        public Student student; // Reference to the student object
        public MainForm mainForm; // Reference to the main form

        // Constructor for EditYearForms, initializes the form with the student and main form references
        public EditYearForms(Student student, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.student = student;
        }

        // Event handler for form load
        private void EditYearForms_Load(object sender, EventArgs e)
        {
            // Set the year TextBox to the selected year's name
            yearTb.Text = student.YearList[(int)mainForm.position[0]].Name.ToString();
            PopulateCheckedList(); // Populate the semester checklists
        }

        // Populate the add and delete semester checklists
        private void PopulateCheckedList()
        {
            addSemesterCb.Items.Clear(); // Clear existing items
            deleteSemesterCb.Items.Clear(); // Clear existing items
            string[] semesters = { "Summer", "Autumn", "Winter", "Spring" };

            // Populate the checklists based on whether the semester exists
            foreach (string semester in semesters)
            {
                if (student.YearList[(int)mainForm.position[0]].SemesterList.ContainsKey(semester))
                {
                    deleteSemesterCb.Items.Add(semester); // Add to delete checklist if exists
                }
                else
                {
                    addSemesterCb.Items.Add(semester); // Add to add checklist if not exists
                }
            }
        }

        // Event handler for update button click
        private void updateBtn_Click(object sender, EventArgs e)
        {
            int yearName = Int32.Parse(yearTb.Text);
            // Validate that the year name is not empty, unique, and within a valid range
            if (yearName >= 2019 && student.UniqueYear(yearName))
            {
                student.YearList[(int)mainForm.position[0]].UpdateYearInDatabase(yearName);

                Year year = student.YearList[(int)mainForm.position[0]];

                student.YearList.Remove((int)mainForm.position[0]);
                student.YearList[yearName] = year;

                mainForm.position[0] = yearName;
            }
            else
            {
                MessageBox.Show("Please enter a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for delete button click
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the year record? This will result in removing all associated objects as well.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                student.DeleteYearFromDatabase((int)mainForm.position[0]);
                mainForm.MenuPanel(4);
                mainForm.MainPannel(4);
            }
        }

        // Event handler for add semester button click
        private void addSemsterBtn_Click(object sender, EventArgs e)
        {
            // Add selected semesters to the year's semester list
            foreach (string item in addSemesterCb.CheckedItems)
            {
                student.YearList[(int)mainForm.position[0]].SemesterList.Add(item, new Semester(item, student.YearList[(int)mainForm.position[0]].Id, student.StudentId));
            }

            PopulateCheckedList(); // Refresh the checklists
            mainForm.MenuPanel(5); // Update the menu panel
        }

        // Event handler for delete semester button click
        private void deleteSemesterBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete? The selected semesters will be removed along with associated objects.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Delete selected semesters from the year's semester list
                foreach (string item in deleteSemesterCb.CheckedItems)
                {
                    student.YearList[(int)mainForm.position[0]].DeleteSemesterFromDatabase(item);
                }

                PopulateCheckedList(); // Refresh the checklists
                mainForm.MenuPanel(5); // Update the menu panel
            }
        }

        private void yearTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Reject non-digit input
                }
            }
        }
    }
}
