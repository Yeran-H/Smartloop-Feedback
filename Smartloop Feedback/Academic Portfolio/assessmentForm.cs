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

namespace Smartloop_Feedback
{
    public partial class AssessmentForm : Form
    {
        public Assessment assessment;
        public MainForm mainForm;

        public AssessmentForm(Assessment assessment, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.assessment = assessment;
        }

        private void AssessmentForm_Load(object sender, EventArgs e)
        {
            markTb.Text = assessment.finalMark.ToString() + "/" + assessment.mark.ToString();
            dateP.Value = assessment.date;
            descriptionRb.Text = assessment.description;
        }

        private void canvasBtn_Click(object sender, EventArgs e)
        {
            OpenUrl(assessment.canvasLink);
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(1);
        }
    }
}
