using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smartloop_Feedback.Forms
{
    public partial class courseForm : Form
    {
        private Course course;
        private mainForm mainForm;
        public courseForm(Course course, mainForm mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
            PopulateListView();
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
            mainForm.mainPannel(1);
        }

        private void PopulateListView()
        {
            if(course.assessmentList != null)
            {
                foreach (Assessment assessment in course.assessmentList)
                {
                    ListViewItem item = new ListViewItem(assessment.name);
                    item.SubItems.Add(assessment.type);
                    item.SubItems.Add(assessment.date.ToString());
                    item.SubItems.Add(assessment.status);
                    item.SubItems.Add(assessment.mark.ToString());
                    item.SubItems.Add(assessment.weight.ToString());
                    item.Tag = assessment;

                    assessmentLv.Items.Add(item);
                }
            }
        }

        private void assessmentLv_ItemActivate(object sender, EventArgs e)
        {
            if (assessmentLv.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = assessmentLv.SelectedItems[0];
                MessageBox.Show("You clicked: " + selectedItem.Text);
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
    }
}
