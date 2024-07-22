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
    public partial class SettingForm : Form
    {
        public Student student;
        public SettingForm(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void settingsTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = settingsTab.SelectedTab;

            if(selectedTab != null && selectedTab.Controls.Count == 0)
            {
                string name = selectedTab.Text;

                switch (name)
                {
                    case "Assessment":
                        EditAssessmentForm assessmentForm = new EditAssessmentForm(student)
                        {
                            Dock = DockStyle.Fill,
                            TopLevel = false,
                            TopMost = true,
                            FormBorderStyle = FormBorderStyle.None
                        };

                        // Clear any existing controls in the selected tab page
                        selectedTab.Controls.Clear();

                        // Add the form to the selected tab page
                        selectedTab.Controls.Add(assessmentForm);
                        assessmentForm.Show();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
