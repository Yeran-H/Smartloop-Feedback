using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Dashboard
{
    public partial class DashboardForm : Form
    {
        public User user;
        public MainForm mainForm;
        private bool isHourlyView = false;

        public DashboardForm(User user, MainForm mainForm)
        {
            InitializeComponent();
            this.user = user;
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

            foreach (Objects.Updated.User_Object.YearAssociation year in user.YearList.Values)
            {
                foreach (SemesterAssociation semester in year.SemesterList.Values)
                {
                    foreach (StudentCourse course in semester.CourseList.Values)
                    {
                        if (!course.IsCompleted)
                        {
                            int rowIndex = courseDgv.Rows.Add(course.Code, course.Name, "", "");
                            courseDgv.Rows[rowIndex].Cells["Tags"].Tag = new List<object> { year.Name, semester.Name, course.Code, 0, 0 };
                        }
                    }
                }
            }

            DataGridColor(courseDgv);
        }

        private void courseDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tags = courseDgv.Rows[e.RowIndex].Cells["Tags"].Tag as List<object>;

                if (e.ColumnIndex == courseDgv.Columns["canvasBtn"].Index)
                {
                   string canvasLink = user.YearList[(int)tags[0]].SemesterList[(string)tags[1]].CourseList[(int)tags[2]].CanvasLink;
                   OpenUrl(canvasLink);
                }
                else if (e.ColumnIndex == courseDgv.Columns["courseBtn"].Index)
                {
                    mainForm.position = tags;
                    mainForm.MainPannel(1);
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

            foreach (Event events in user.EventList.Values)
            {
                if (events.Date >= today)
                {
                    eventDgv.Rows.Add(events.Name, events.Date, events.Category);
                }
            }

            DataGridColor(eventDgv);
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

            foreach (Event events in user.EventList.Values)
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

            DataGridColor(eventDgv);
        }

        private void PopulateComboBox()
        {
            filterCb.Items.Clear();
            filterCb.Items.Add("All");
            filterCb.Items.AddRange(user.GetCourseList().ToArray());
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
                    foreach (Event events in user.EventList.Values)
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

                    foreach (Event events in user.EventList.Values)
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
