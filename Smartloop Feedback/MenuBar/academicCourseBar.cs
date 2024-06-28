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

namespace Smartloop_Feedback
{
    public partial class academicCourseBar : Form
    {
        private mainForm mainForm;
        private Semester semester;

        private int buttonCount = 0;
        Button[] buttons = new Button[5];

        public academicCourseBar(mainForm form, Semester semester)
        {
            InitializeComponent();
            navPl.Height = backBtn.Height;
            navPl.Top = backBtn.Top;
            navPl.Left = backBtn.Left;

            mainForm = form;
            this.semester = semester;
            initaliseBar();
        }

        private void initaliseBar()
        {
            buttonCount = semester.numCourse();

            for (int i = 1; i <= buttonCount; i++)
            {
                Button btn = null;
                switch (i)
                {
                    case 1:
                        btn = oneBtn;
                        break;
                    case 2:
                        btn = secondBtn;
                        break;
                    case 3:
                        btn = thirdBtn;
                        break;
                    case 4:
                        btn = fourthBtn;
                        break;
                    case 5:
                        btn = fifthBtn;
                        addBtn.Visible = false;
                        break;
                }

                if (btn != null)
                {
                    btn.Visible = true;
                    btn.Text = semester.courseList[i - 1].code.ToString();
                    buttons[i - 1] = btn;
                }
            }

            UpdatePanel();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.menuPannel(2);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (semester == null)
            {
                MessageBox.Show("Semester object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (semester.courseList == null)
            {
                semester.courseList = new List<Course>();
            }

            using (var addCourseForm = new addCourseForm())
            {
                if (addCourseForm.ShowDialog() == DialogResult.OK)
                {
                    if (buttonCount < 5)
                    {
                        Course course = addCourseForm.course;
                        if (course != null)
                        {
                            semester.courseList.Add(new Course(course.code, course.title, course.creditPoint, course.description, course.canvasLink, semester.id, semester.studentId));
                        }
                        else
                        {
                            MessageBox.Show("Course is not properly initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        buttonCount++;
                        Button btn = null;
                        switch (buttonCount)
                        {
                            case 1:
                                btn = oneBtn;
                                break;
                            case 2:
                                btn = secondBtn;
                                break;
                            case 3:
                                btn = thirdBtn;
                                break;
                            case 4:
                                btn = fourthBtn;
                                break;
                            case 5:
                                btn = fifthBtn;
                                addBtn.Visible = false;
                                break;
                        }

                        if (btn != null)
                        {
                            btn.Visible = true;
                            btn.Text = course.code.ToString();
                            buttons[buttonCount - 1] = btn;
                            UpdatePanel();
                        }
                    }
                }
            }
        }

        private void UpdatePanel()
        {
            for (int i = 0; i < buttonCount; i++)
            {
                Controls.Remove(buttons[i]);
            }

            if (buttonCount < 5)
            {
                Controls.Remove(addBtn);
            }
            Controls.Remove(backBtn);

            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Controls.Add(buttons[i]);
                buttons[i].Dock = DockStyle.Top;
            }

            if (buttonCount < 5)
            {
                Controls.Add(addBtn);
                addBtn.Dock = DockStyle.Top;
            }
            Controls.Add(backBtn);
            backBtn.Dock = DockStyle.Top;
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = oneBtn.Height;
            navPl.Top = oneBtn.Top;
            navPl.Left = oneBtn.Left;
            oneBtn.BackColor = Color.FromArgb(16, 34, 61);

            mainForm.position[2] = 0;
            mainForm.mainPannel(0);
        }

        private void secondBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = secondBtn.Height;
            navPl.Top = secondBtn.Top;
            navPl.Left = secondBtn.Left;
            oneBtn.BackColor = Color.FromArgb(16, 34, 61);

            mainForm.position[2] = 1;
            mainForm.mainPannel(0);
        }

        private void thirdBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = thirdBtn.Height;
            navPl.Top = thirdBtn.Top;
            navPl.Left = thirdBtn.Left;
            thirdBtn.BackColor = Color.FromArgb(16, 34, 61);

            mainForm.position[2] = 2;
            mainForm.mainPannel(0);
        }

        private void fourthBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = fourthBtn.Height;
            navPl.Top = fourthBtn.Top;
            navPl.Left = fourthBtn.Left;
            fourthBtn.BackColor = Color.FromArgb(16, 34, 61);

            mainForm.position[2] = 3;
            mainForm.mainPannel(0);
        }

        private void fifthBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = fifthBtn.Height;
            navPl.Top = fifthBtn.Top;
            navPl.Left = fifthBtn.Left;
            fifthBtn.BackColor = Color.FromArgb(16, 34, 61);

            mainForm.position[2] = 4;
            mainForm.mainPannel(0);
        }

        private void oneBtn_Leave(object sender, EventArgs e)
        {
            oneBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void secondBtn_Leave(object sender, EventArgs e)
        {
            secondBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void thirdBtn_Leave(object sender, EventArgs e)
        {
            thirdBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void fourthBtn_Leave(object sender, EventArgs e)
        {
            fourthBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void fifthBtn_Leave(object sender, EventArgs e)
        {
            fifthBtn.BackColor = Color.FromArgb(10, 22, 39);
        }
    }
}
