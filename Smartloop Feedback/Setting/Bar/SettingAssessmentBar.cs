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
            navPl.Height = backBtn.Height;
            navPl.Top = backBtn.Top;
            navPl.Left = backBtn.Left;

            this.course = course;
            this.mainForm = mainForm;
        }

        private void SettingAssessmentBar_Load(object sender, EventArgs e)
        {
            Image buttonImage = Properties.Resources.School;

            int buttonCount = 0;
            foreach (Assessment assessment in course.AssessmentList.Values)
            {
                Button btn = new Button
                {
                    Text = assessment.Name,
                    Tag = assessment.Id,
                    Dock = DockStyle.Top,
                    Height = 42, 
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Aptos", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193),
                    FlatAppearance = { BorderSize = 0 },
                    Image = buttonImage,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                btn.Click += new EventHandler(AssessmentBtn_Click);
                btn.Leave += new EventHandler(ResetButtonColor);

                Controls.Add(btn);
                buttonCount++;
            }

            backBtn.Dock = DockStyle.Top;
            Controls.Add(backBtn);

            int totalHeight = backBtn.Height + 42 * buttonCount; 
            this.ClientSize = new Size(170, totalHeight);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(6);
            mainForm.MainPannel(7);
        }

        private void AssessmentBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                navPl.Height = clickedButton.Height;
                navPl.Top = clickedButton.Top;
                navPl.Left = clickedButton.Left;
                clickedButton.BackColor = Color.FromArgb(16, 34, 61);

                int assessmentId = Int32.Parse(clickedButton.Tag.ToString());
                mainForm.position[3] = assessmentId;
                mainForm.MainPannel(9);
            }
        }

        private void ResetButtonColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(10, 22, 39);
        }
    }
}
