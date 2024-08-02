using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class CourseForm : Form
    {
        private Course course;
        private MainForm mainForm;
        public CourseForm(Course course, MainForm mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            course.LoadEventsFromDatabase();
            PopulateAssessmentView();
            PopulateEventView();
            currentTb.Text = course.CalculateCurrentMark().ToString("F2") + "%";
            cTb.Text = course.CalculateTargetMark(0.65).ToString("F2") + "%";
            dTb.Text = course.CalculateTargetMark(0.75).ToString("F2") + "%";
            hdTb.Text = course.CalculateTargetMark(0.85).ToString("F2") + "%";
        }

        private void canvasBtn_Click(object sender, EventArgs e)
        {
            OpenUrl(course.CanvasLink);
        }

        private void handbookBtn_Click(object sender, EventArgs e)
        {
            OpenUrl($"https://handbook.uts.edu.au/subjects/details/{course.Code}.html");
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(1);
        }

        private void PopulateAssessmentView()
        {
            if (course.AssessmentList != null)
            {
                foreach (Assessment assessment in course.AssessmentList.Values)
                {
                    double percentage = (assessment.FinalMark / assessment.Mark) * 100;

                    ListViewItem item = new ListViewItem(assessment.Name);
                    item.SubItems.Add(assessment.Type);
                    item.SubItems.Add(assessment.Date.ToString());
                    item.SubItems.Add(assessment.Status.ToString());
                    item.SubItems.Add(percentage.ToString("F2") + "%");
                    item.SubItems.Add(assessment.Weight.ToString());
                    item.Tag = assessment.Id;

                    assessmentLv.Items.Add(item);
                }
            }
        }

        private void PopulateEventView()
        {
            if (course.EventList != null)
            {
                foreach (Event events in course.EventList.Values)
                {
                    ListViewItem item = new ListViewItem(events.Name);
                    item.SubItems.Add(events.Date.ToString());
                    item.Tag = events;

                    eventLv.Items.Add(item);
                }
            }
        }

        private void assessmentLv_ItemActivate(object sender, EventArgs e)
        {
            if (assessmentLv.SelectedItems.Count > 0)
            {
                mainForm.position[3] = assessmentLv.SelectedItems[0].Tag;
                mainForm.MainPannel(2);
            }
        }

        private void assessmentLv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void assessmentLv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color color = Color.FromArgb(254, 0, 57);
            SolidBrush forBrush = new SolidBrush(color);
            color = Color.FromArgb(16, 34, 61);
            SolidBrush backBrush = new SolidBrush(color);


            if (e.ColumnIndex == 3)
            {
                int status = int.Parse(e.SubItem.Text);
                Rectangle bounds = e.Bounds;
                e.Graphics.FillRectangle(backBrush, bounds);
                e.Graphics.FillRectangle(forBrush, bounds.X, bounds.Y, bounds.Width * status / 100, bounds.Height);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void eventBtn_Click(object sender, EventArgs e)
        {
            List<string> courseName = new List<string>();
            courseName.Add(course.Title);

            using (AddEventForm addEventForm = new AddEventForm(courseName, null))
            {
                if (addEventForm.ShowDialog() == DialogResult.OK)
                {
                    new Event(addEventForm.newEvent.Name, addEventForm.newEvent.Date, addEventForm.newEvent.StartTime, addEventForm.newEvent.EndTime, course.Title, addEventForm.newEvent.Color, course.StudentId, course.Id);
                    PopulateEventView();
                }
            }
        }

        private void eventLv_ItemActivate(object sender, EventArgs e)
        {
            if (eventLv.SelectedItems.Count > 0)
            {
                List<string> courseName = new List<string>();
                courseName.Add(course.Title);

                using (AddEventForm editEventForm = new AddEventForm(courseName, (Event)eventLv.SelectedItems[0].Tag))
                {
                    if (editEventForm.ShowDialog() == DialogResult.OK)
                    {
                        course.UpdateEvent(editEventForm.newEvent);
                        PopulateEventView();
                    }
                }
            }
        }
    }
}
