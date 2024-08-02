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
    public partial class SettingCourseBar : Form
    {
        public Semester semester;
        public MainForm mainForm;
        private Button[] buttons = new Button[5]; 
        private Button[] allButtons;

        public SettingCourseBar(Semester semester, MainForm mainForm)
        {
            InitializeComponent();
            this.semester = semester;
            this.mainForm = mainForm;
        }

        private void SettingCourseBar_Load(object sender, EventArgs e)
        {
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn };

            int buttonCount = 0;
            foreach (Course course in semester.CourseList.Values)
            {
                Button btn = allButtons[buttonCount]; 
                btn.Visible = true; 
                btn.Text = course.Code.ToString(); 
                buttons[buttonCount] = btn; 
                btn.Tag = course.Id;

                buttonCount++;
            }

            Controls.Clear(); 

            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Controls.Add(buttons[i]);
                buttons[i].Dock = DockStyle.Top;
            }

            Controls.Add(backBtn);
            backBtn.Dock = DockStyle.Top;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPannel(5);
        }

        private void CourseBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            mainForm.position[2] = clickedButton.Tag;
            mainForm.MenuPannel(7);
            mainForm.MainPannel(8);
        }
    }
}
