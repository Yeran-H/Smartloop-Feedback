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
            course.GetEventsFromDatabase();
            PopulateAssessmentView();
            PopulateEventView();
            currentTb.Text = course.CalculateCurrentMark().ToString("F2") + "%";
            cTb.Text = course.CalculateTargetMark(0.65).ToString("F2") + "%";
            dTb.Text = course.CalculateTargetMark(0.75).ToString("F2") + "%";
            hdTb.Text = course.CalculateTargetMark(0.85).ToString("F2") + "%";
        }

        private void canvasBtn_Click(object sender, EventArgs e)
        {
            OpenUrl(course.canvasLink);
        }

        private void handbookBtn_Click(object sender, EventArgs e)
        {
            OpenUrl($"https://handbook.uts.edu.au/subjects/details/{course.code}.html");
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
            if (course.assessmentList != null)
            {
                foreach (Assessment assessment in course.assessmentList.Values)
                {
                    double percentage = (assessment.finalMark / assessment.mark) * 100;

                    ListViewItem item = new ListViewItem(assessment.name);
                    item.SubItems.Add(assessment.type);
                    item.SubItems.Add(assessment.date.ToString());
                    item.SubItems.Add(assessment.status.ToString());
                    item.SubItems.Add(percentage.ToString("F2") + "%");
                    item.SubItems.Add(assessment.weight.ToString());
                    item.Tag = assessment.id;

                    assessmentLv.Items.Add(item);
                }
            }
        }

        private void PopulateEventView()
        {
            if (course.eventList != null)
            {
                foreach (Event events in course.eventList.Values)
                {
                    ListViewItem item = new ListViewItem(events.name);
                    item.SubItems.Add(events.date.ToString());
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
            courseName.Add(course.title);

            using (AddEventForm addEventForm = new AddEventForm(courseName, null))
            {
                if (addEventForm.ShowDialog() == DialogResult.OK)
                {
                    new Event(addEventForm.newEvent.name, addEventForm.newEvent.date, course.title, addEventForm.newEvent.color, course.studentId, course.id);
                    PopulateEventView();
                }
            }
        }

        private void eventLv_ItemActivate(object sender, EventArgs e)
        {
            if (eventLv.SelectedItems.Count > 0)
            {
                List<string> courseName = new List<string>();
                courseName.Add(course.title);

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
