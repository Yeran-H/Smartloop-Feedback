using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Settings
{
    public partial class EditYearForm : Form
    {
        public Student student;
        public object[] position;
        public EditYearForm(Student student, object[] position)
        {
            InitializeComponent();
            this.student = student;
            this.position = position;
        }

        private void EditYearForm_Load(object sender, EventArgs e)
        {
            tabPage1.Text = (string)position[0];
            yearTb.Text = (string)position[0];
            AddTabs();
            CheckItemsInCheckedListBox();
        }

        private void AddTabs()
        {
            foreach (Semester semester in student.yearList[(string)position[0]].semesterList.Values)
            {
                TabPage tabPage = new TabPage(semester.name);
                yearTab.Controls.Add(tabPage);
            }
        }

        private void CheckItemsInCheckedListBox()
        {
            foreach (string item in student.yearList[(string)position[0]].semesterList.Keys)
            {
                int index = semesterCb.Items.IndexOf(item);
                if (index != -1)
                {
                    semesterCb.SetItemChecked(index, true);
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string yearName = yearTb.Text;
            // Validate that the year name is not empty, unique, and semesters are selected
            if (!string.IsNullOrEmpty(yearName) && student.UniqueYear(yearName))
            {
                student.yearList[(string)position[0]].UpdateToDatabase(yearName);

                Year year = student.yearList[(string)position[0]];

                student.yearList.Remove((string)position[0]);
                student.yearList[yearName] = year;

                position[0] = yearName;
                tabPage1.Text = year.name;
                yearTb.Text = year.name;
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
                student.DeleteYearFromDatabase((string)position[0]);
                this.Close();
            }
        }

        private void yearTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = yearTab.SelectedTab;

            if (selectedTab != null && selectedTab.Controls.Count == 0)
            {
                string name = selectedTab.Text;

                if (name != (string)position[0])
                {
                    position[1] = name;
                    EditCourseForms courseForm = new EditCourseForms(student.yearList[(string)position[0]].semesterList[(string)position[1]], position)
                    {
                        Dock = DockStyle.Fill,
                        TopLevel = false,
                        TopMost = true,
                        FormBorderStyle = FormBorderStyle.None
                    };

                    // Clear any existing controls in the selected tab page
                    selectedTab.Controls.Clear();

                    // Add the form to the selected tab page
                    selectedTab.Controls.Add(courseForm);
                    courseForm.Show();
                }
            }
        }

        private void addSemsterBtn_Click(object sender, EventArgs e)
        {
            foreach (string item in semesterCb.CheckedItems)
            {
                if (!student.yearList[(string)position[0]].semesterList.ContainsKey(item))
                {
                    student.yearList[(string)position[0]].semesterList.Add(item, new Semester(item, student.yearList[(string)position[0]].id, student.studentId));
                }
            }
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
                for (int i = 0; i < semesterCb.Items.Count; i++)
                {
                    if(!semesterCb.GetItemChecked(i))
                    {
                        student.yearList[(string)position[0]].DeleteSemesterFromDatabase(semesterCb.Items[i].ToString());
                    }
                }
            }
        }
    }
}
