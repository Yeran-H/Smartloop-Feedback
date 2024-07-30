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

namespace Smartloop_Feedback.Setting.Bar
{
    public partial class SettingAssessmentBar : Form
    {
        public Course course;
        public MainForm mainForm;
        public SettingAssessmentBar(Course course, MainForm mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
        }

        private void SettingAssessmentBar_Load(object sender, EventArgs e)
        {
            backBtn.Dock = DockStyle.Top;
            Controls.Add(backBtn);
            Image buttonImage = Image.FromFile("resources/School.png");

            int buttonCount = 0;
            foreach (Assessment assessment in course.assessmentList.Values)
            {
                Button btn = new Button
                {
                    Text = assessment.name,
                    Tag = assessment.id,
                    Dock = DockStyle.Top,
                    Height = 42, 
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Aptos", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193),
                    FlatAppearance = { BorderSize = 0 },
                    Image = buttonImage,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                Controls.Add(btn);
                buttonCount++;
            }

            int totalHeight = backBtn.Height + 42 * buttonCount; 
            this.ClientSize = new Size(170, totalHeight);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
