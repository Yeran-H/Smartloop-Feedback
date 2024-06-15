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
    }
}
