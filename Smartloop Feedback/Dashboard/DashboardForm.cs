using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Smartloop_Feedback.Dashboard
{
    public partial class DashboardForm : Form
    {
        public Student student;
        public MainForm mainForm;
        public DashboardForm(Student student, MainForm mainForm)
        {
            InitializeComponent();
            this.student = student;
            this.mainForm = mainForm;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            PopulateCourse();
            PopulateEvent();
            PopulateComboBox();
            filterCb.SelectedItem = "All";
        }

        private void PopulateCourse()
        {
            courseDgv.Columns.Add("Code", "Code");
            courseDgv.Columns.Add("Title", "Title");

            // Create and add the button column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "canvasBtn";
            buttonColumn.HeaderText = "Canvas Button";
            buttonColumn.Text = "View Canvas";
            buttonColumn.UseColumnTextForButtonValue = true; // This line is important to display the text on the button

            courseDgv.Columns.Add(buttonColumn);

            buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "courseBtn";
            buttonColumn.HeaderText = "Course Button";
            buttonColumn.Text = "View Course";
            buttonColumn.UseColumnTextForButtonValue = true; // This line is important to display the text on the button

            courseDgv.Columns.Add(buttonColumn);

            DataGridViewTextBoxColumn tagsColumn = new DataGridViewTextBoxColumn
            {
                Name = "Tags",
                HeaderText = "Tags",
                Visible = false
            };
            courseDgv.Columns.Add(tagsColumn);

            foreach (Year year in student.yearList.Values)
            {
                foreach (Semester semester in year.semesterList.Values)
                {
                    foreach (Course course in semester.courseList.Values)
                    {
                        if (!course.isCompleted)
                        {
                            int rowIndex = courseDgv.Rows.Add(course.code, course.title, "", "");
                            courseDgv.Rows[rowIndex].Cells["Tags"].Tag = new List<object> { year.name, semester.name, course.id };
                        }
                    }
                }
            }
        }

        private void courseDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var tags = courseDgv.Rows[e.RowIndex].Cells["Tags"].Tag as List<object>;

                if(e.ColumnIndex == courseDgv.Columns["canvasBtn"].Index)
                {
                    string canvasLink = student.yearList[(string)tags[0]].semesterList[(string)tags[1]].courseList[(int)tags[2]].canvasLink;
                    OpenUrl(canvasLink);
                }
                else if (e.ColumnIndex == courseDgv.Columns["courseBtn"].Index)
                {
                    mainForm.position = tags;
                    mainForm.MainPannel(0);
                }
            }
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

        private void PopulateEvent()
        {
            eventDgv.Columns.Add("Name", "Name");
            eventDgv.Columns.Add("Date", "Date");
            eventDgv.Columns.Add("Category", "Category");

            DateTime today = DateTime.Today;

            foreach (Event events in student.eventList.Values)
            {
                if(events.date >= today)
                {
                    eventDgv.Rows.Add(events.name, events.date, events.category);
                }
            }
        }

        private void PopulateComboBox()
        {
            filterCb.Items.Clear();
            filterCb.Items.Add("All");
            filterCb.Items.AddRange(student.GetCourseList().ToArray());
        }

        private void filterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = filterCb.SelectedItem as string;

            eventDgv.Rows.Clear();

            if(selectedCourse != "All")
            {
                foreach (Event events in student.eventList.Values)
                {
                    if (events.category == selectedCourse)
                    {
                        eventDgv.Rows.Add(events.name, events.date, events.category);
                    }
                }
            }
            else
            {
                DateTime today = DateTime.Today;

                foreach (Event events in student.eventList.Values)
                {
                    if (events.date >= today)
                    {
                        eventDgv.Rows.Add(events.name, events.date, events.category);
                    }
                }
            }
        }
    }
}
