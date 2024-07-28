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
    public partial class SettingYearBar : Form
    {
        public MainForm mainForm;
        public Student student;

        private Button[] buttons = new Button[4]; // Array to hold the course buttons
        private Button[] allButtons;


        public SettingYearBar(Student student, MainForm mainForm)
        {
            InitializeComponent();
            navPl.Height = backBtn.Height;
            navPl.Top = backBtn.Top;
            navPl.Left = backBtn.Left;

            this.mainForm = mainForm;
            this.student = student;
        }

        private void SettingYearBar_Load(object sender, EventArgs e)
        {
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn };

            int buttonCount = 0;
            foreach (Year year in student.yearList.Values)
            {
                Button btn = allButtons[buttonCount]; 
                btn.Visible = true;
                btn.Text = year.name; 
                buttons[buttonCount] = btn; 
                buttons[buttonCount].Click += YearButton_Click; 

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
            mainForm.MenuPannel(1);
        }

        private void YearButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                mainForm.position[0] = clickedButton.Text; 
                mainForm.MenuPannel(2); 
            }
        }
    }
}
