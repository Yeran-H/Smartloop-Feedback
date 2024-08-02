using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting
{
    public partial class EditYearForms : Form
    {
        public Student student;
        public MainForm mainForm;
        public EditYearForms(Student student, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.student = student;
        }

        private void EditYearForms_Load(object sender, EventArgs e)
        {
            yearTb.Text = student.YearList[(string)mainForm.position[0]].Name;
            PopulateCheckedList();
        }

        private void PopulateCheckedList()
        {
            addSemesterCb.Items.Clear();
            deleteSemesterCb.Items.Clear();
            string[] semesters = { "Summer", "Autumn", "Winter", "Spring" };

            foreach (string semster in semesters)
            {
                if (student.YearList[(string)mainForm.position[0]].SemesterList.ContainsKey(semster))
                {
                    deleteSemesterCb.Items.Add(semster);
                }
                else
                {
                    addSemesterCb.Items.Add(semster);
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string yearName = yearTb.Text;
            // Validate that the year name is not empty, unique, and semesters are selected
            if (!string.IsNullOrEmpty(yearName) && student.UniqueYear(yearName))
            {
                student.YearList[(string)mainForm.position[0]].UpdateYearInDatabase(yearName);

                Year year = student.YearList[(string)mainForm.position[0]];

                student.YearList.Remove((string)mainForm.position[0]);
                student.YearList[yearName] = year;

                mainForm.position[0] = yearName;
            }
            else
            {
                MessageBox.Show("Please enter a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                student.DeleteYearFromDatabase((string)mainForm.position[0]);
                mainForm.MenuPannel(4);
                mainForm.MainPannel(4);
            }
        }

        private void addSemsterBtn_Click(object sender, EventArgs e)
        {
            foreach (string item in addSemesterCb.CheckedItems)
            {
                student.YearList[(string)mainForm.position[0]].SemesterList.Add(item, new Semester(item, student.YearList[(string)mainForm.position[0]].Id, student.StudentId));
            }

            PopulateCheckedList();
            mainForm.MenuPannel(5);
        }

        private void deleteSemesterBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete? The boxes Unselected will be removed and associated objects as well.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

            if (result == DialogResult.Yes)
            {
                foreach (string item in deleteSemesterCb.CheckedItems)
                {
                    student.YearList[(string)mainForm.position[0]].DeleteSemesterFromDatabase(item);
                }

                PopulateCheckedList();
                mainForm.MenuPannel(5);
            }
        }
    }
}
