using Smartloop_Feedback.Objects;
using System;
using System.Diagnostics;
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
            PopulateAssessmentView();
            PopulateEventView();
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
                foreach (Assessment assessment in course.assessmentList)
                {
                    ListViewItem item = new ListViewItem(assessment.name);
                    item.SubItems.Add(assessment.type);
                    item.SubItems.Add(assessment.date.ToString());
                    item.SubItems.Add(assessment.status);
                    item.SubItems.Add(assessment.mark.ToString());
                    item.SubItems.Add(assessment.weight.ToString());

                    assessmentLv.Items.Add(item);
                }
            }
        }

        private void PopulateEventView()
        {
            course.GetEventsFromDatabase();
            if (course.eventList != null)
            {
                foreach (Event events in course.eventList)
                {
                    ListViewItem item = new ListViewItem(events.name);
                    item.SubItems.Add(events.date.ToString());

                    eventLv.Items.Add(item);
                }
            }
        }

        private void assessmentLv_ItemActivate(object sender, EventArgs e)
        {
            if (assessmentLv.SelectedItems.Count > 0)
            {
                mainForm.position[3] = assessmentLv.SelectedIndices[0];
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

        }

        private void eventLv_ItemActivate(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
        }
    }
}
