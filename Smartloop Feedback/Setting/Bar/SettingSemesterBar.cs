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
    public partial class SettingSemesterBar : Form
    {
        public Year year;
        public MainForm mainForm;
        public SettingSemesterBar(Year year, MainForm mainForm)
        {
            InitializeComponent();
            this.year = year;
            this.mainForm = mainForm;
        }

        private void SettingSemesterBar_Load(object sender, EventArgs e)
        {
            Button[] semesterButtons = { summerBtn, autumnBtn, winterBtn, springBtn };

            semesterButtons
                .Where(button => year.SemesterList.Keys.Contains(button.Text))
                .ToList()
                .ForEach(button => button.Visible = true);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(4);
            mainForm.MainPannel(4);
        }

        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button; 
            mainForm.position[1] = clickedButton.Text; 
            mainForm.MenuPanel(6);
        }
    }
}
