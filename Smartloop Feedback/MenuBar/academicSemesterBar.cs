using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class academicSemesterBar : Form
    {
        private mainForm mainForm;
        private Year year;
        public academicSemesterBar(mainForm form, Year year)
        {
            InitializeComponent();
            mainForm = form;
            this.year = year;
            initaliseBar();
        }

        private void initaliseBar()
        {
            foreach(Semester semester in year.semesterList)
            {
                switch(semester.name)
                {
                    case "Summer":
                        summerBtn.Visible = true;
                        break;
                    case "Autumn":
                        autumnBtn.Visible = true;
                        break;
                    case "Winter":
                        winterBtn.Visible = true;
                        break;
                    case "Spring":
                        springBtn.Visible = true;
                        break;

                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.menuPannel(0);
        }

        private void summerBtn_Click(object sender, EventArgs e)
        {
            mainForm.position[1] = year.semesterIndex("Summer");
            mainForm.menuPannel(3);
        }

        private void autumnBtn_Click(object sender, EventArgs e)
        {
            mainForm.position[1] = year.semesterIndex("Autumn");
            mainForm.menuPannel(3);
        }

        private void winterBtn_Click(object sender, EventArgs e)
        {
            mainForm.position[1] = year.semesterIndex("Winter");
            mainForm.menuPannel(3);
        }

        private void springBtn_Click(object sender, EventArgs e)
        {
            mainForm.position[1] = year.semesterIndex("Spring");
            mainForm.menuPannel(3);
        }
    }
}
