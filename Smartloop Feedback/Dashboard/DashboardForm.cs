using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Dashboard
{
    public partial class DashboardForm : Form
    {
        public Student student;
        public MainForm mainForm;
        private bool isHourlyView = false;

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

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = "canvasBtn",
                HeaderText = "Canvas Button",
                Text = "View Canvas",
                UseColumnTextForButtonValue = true
            };
            courseDgv.Columns.Add(buttonColumn);

            buttonColumn = new DataGridViewButtonColumn
            {
                Name = "courseBtn",
                HeaderText = "Course Button",
                Text = "View Course",
                UseColumnTextForButtonValue = true
            };
            courseDgv.Columns.Add(buttonColumn);

            DataGridViewTextBoxColumn tagsColumn = new DataGridViewTextBoxColumn
            {
                Name = "Tags",
                HeaderText = "Tags",
                Visible = false
            };
            courseDgv.Columns.Add(tagsColumn);

            foreach (Year year in student.YearList.Values)
            {
                foreach (Semester semester in year.SemesterList.Values)
                {
                    foreach (StudentCourse course in semester.CourseList.Values)
                    {
                        if (!course.IsCompleted)
                        {
                            int rowIndex = courseDgv.Rows.Add(course.Code, course.Title, "", "");
                            courseDgv.Rows[rowIndex].Cells["Tags"].Tag = new List<object> { year.Name, semester.Name, course.Id };
                        }
                    }
                }
            }
        }

        private void courseDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tags = courseDgv.Rows[e.RowIndex].Cells["Tags"].Tag as List<object>;

                if (e.ColumnIndex == courseDgv.Columns["canvasBtn"].Index)
                {
                    string canvasLink = student.YearList[(int)tags[0]].SemesterList[(string)tags[1]].CourseList[(int)tags[2]].CanvasLink;
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
            eventDgv.Rows.Clear();
            eventDgv.Columns.Clear();
            eventDgv.Columns.Add("Name", "Name");
            eventDgv.Columns.Add("Date", "Date");
            eventDgv.Columns.Add("Category", "Category");

            DateTime today = DateTime.Today;

            foreach (Event events in student.EventList.Values)
            {
                if (events.Date >= today)
                {
                    eventDgv.Rows.Add(events.Name, events.Date, events.Category);
                }
            }
        }

        private void PopulateHourlyView()
        {
            string selectedCourse = filterCb.SelectedItem as string;

            eventDgv.Rows.Clear();
            eventDgv.Columns.Clear();
            eventDgv.Columns.Add("Time", "Time");
            eventDgv.Columns.Add("Event", "Event");

            DateTime today = DateTime.Today;

            for (int i = 0; i < 24; i++)
            {
                DateTime hour = today.AddHours(i);
                eventDgv.Rows.Add(hour.ToString("HH:mm"), "");
            }

            foreach (Event events in student.EventList.Values)
            {
                if (events.Date.Date == today)
                {
                    if (selectedCourse == "All" || events.Category == selectedCourse)
                    {
                        for (int i = events.StartTime.Hours; i < events.EndTime.Hours; i++)
                        {
                            eventDgv.Rows[i].Cells["Event"].Value = events.Name;
                            eventDgv.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue; // Highlight the row
                        }
                    }
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
            if (isHourlyView)
            {
                PopulateHourlyView();
            }
            else
            {
                string selectedCourse = filterCb.SelectedItem as string;

                eventDgv.Rows.Clear();

                if (selectedCourse != "All")
                {
                    foreach (Event events in student.EventList.Values)
                    {
                        if (events.Category == selectedCourse)
                        {
                            eventDgv.Rows.Add(events.Name, events.Date.ToShortDateString(), events.Category);
                        }
                    }
                }
                else
                {
                    DateTime today = DateTime.Today;

                    foreach (Event events in student.EventList.Values)
                    {
                        if (events.Date >= today)
                        {
                            eventDgv.Rows.Add(events.Name, events.Date.ToShortDateString(), events.Category);
                        }
                    }
                }
            }
        }

        private void toggleViewBtn_Click(object sender, EventArgs e)
        {
            if (isHourlyView)
            {
                PopulateEvent();
                toggleViewBtn.Text = "Toggle to Hourly View";
            }
            else
            {
                PopulateHourlyView();
                toggleViewBtn.Text = "Toggle to Default View";
            }
            isHourlyView = !isHourlyView;
        }
    }
}
