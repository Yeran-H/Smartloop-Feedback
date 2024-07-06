using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Google.Protobuf.WellKnownTypes;
using Smartloop_Feedback.Forms;

namespace Smartloop_Feedback
{
    public partial class MainForm : Form
    {
        private Student student;
        public List<object> position;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHieghtEllipse
        );

        public MainForm(Student student)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            navPl.Height = dashboardBtn.Height;
            navPl.Top = dashboardBtn.Top;
            navPl.Left = dashboardBtn.Left;
            dashboardBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Dashboard";
            this.formLoaderPl.Controls.Clear();
            /*
            dashboardForm dashboard = new dashboardForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(dashboard);
            dashboard.Show();
            */

            this.student = student;
            position = new List<object>(new object[5]);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            nameLb.Text = student.name;
            studentIdLb.Text = student.studentId.ToString();
            if (student.profileImage != null)
            {
                using (MemoryStream ms = new MemoryStream(student.profileImage))
                {
                    profilePb.Image = Image.FromStream(ms);
                }
            }
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = dashboardBtn.Height;
            navPl.Top = dashboardBtn.Top;
            navPl.Left = dashboardBtn.Left;
            dashboardBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Dashboard";
            this.formLoaderPl.Controls.Clear();
            /*
            dashboardForm dashboard = new dashboardForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(dashboard);
            dashboard.Show();
            */
        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = resultBtn.Height;
            navPl.Top = resultBtn.Top;
            navPl.Left = resultBtn.Left;
            resultBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Results";
            this.formLoaderPl.Controls.Clear();
            /*
            resultForm result = new resultForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            result.FormBorderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(result);
            result.Show();
             */
        }

        private void academicBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = academicBtn.Height;
            navPl.Top = academicBtn.Top;
            navPl.Left = academicBtn.Left;
            academicBtn.BackColor = Color.FromArgb(16, 34, 61);

            MenuPannel(0);

            /*
            titleLb.Text = "Academic Portfolio";
            this.formLoaderPl.Controls.Clear();
            academicForm academic = new academicForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            academic.FormBorderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(academic);
            academic.Show();
             */
        }

        private void courseBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = courseBtn.Height;
            navPl.Top = courseBtn.Top;
            navPl.Left = courseBtn.Left;
            courseBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Course Schedule";
            this.formLoaderPl.Controls.Clear();
            
            CourseScheduleForm course = new CourseScheduleForm(student) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            course.FormBorderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(course);
            course.Show();
             
        }

        private void setttingBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = setttingBtn.Height;
            navPl.Top = setttingBtn.Top;
            navPl.Left = setttingBtn.Left;
            setttingBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Settings";
            this.formLoaderPl.Controls.Clear();
            /*
            settingForm setting = new settingForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setting.FormBorderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(setting);
            setting.Show();
             */
        }

        private void dashboardBtn_Leave(object sender, EventArgs e)
        {
            dashboardBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void resultBtn_Leave(object sender, EventArgs e)
        {
            resultBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void academicBtn_Leave(object sender, EventArgs e)
        {
            academicBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void setttingBtn_Leave(object sender, EventArgs e)
        {
            setttingBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void courseBtn_Leave(object sender, EventArgs e)
        {
            courseBtn.BackColor = Color.FromArgb(10, 22, 39);
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
        }

        public void MenuPannel(int num)
        {
            menuDropPl.Controls.Clear();

            switch (num)
            {
                case 0:
                    AcademicYearBar year = new AcademicYearBar(this, student) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    year.FormBorderStyle = FormBorderStyle.None;
                    menuDropPl.Visible = true;
                    this.menuDropPl.Controls.Add(year);
                    year.Show();
                    break;
                case 1:
                    menuDropPl.Visible = false;
                    dashboardBtn_Click(this, EventArgs.Empty);
                    break;
                case 2:
                    AcademicSemesterBar semester = new AcademicSemesterBar(this, student.yearList[(string)position[0]]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    semester.FormBorderStyle = FormBorderStyle.None;
                    menuDropPl.Visible = true;
                    this.menuDropPl.Controls.Add(semester);
                    semester.Show();
                    break;
                case 3:
                    AcademicCourseBar subject = new AcademicCourseBar(this, student.yearList[(string)position[0]].semesterList[(string)position[1]]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    subject.FormBorderStyle = FormBorderStyle.None;
                    menuDropPl.Visible = true;
                    this.menuDropPl.Controls.Add(subject);
                    subject.Show();
                    break;

            }
        }

        public void MainPannel(int num)
        {
            switch (num)
            {
                case 0:
                    titleLb.Text = student.yearList[(string)position[0]].semesterList[(string)position[1]].courseList[(int)position[2]].title;
                    this.formLoaderPl.Controls.Clear();
                    CourseForm course = new CourseForm(student.yearList[(string)position[0]].semesterList[(string)position[1]].courseList[(int)position[2]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    course.FormBorderStyle = FormBorderStyle.None;
                    this.formLoaderPl.Controls.Add(course);
                    course.Show();
                    break;
                case 1:
                    titleLb.Text = student.yearList[(string)position[0]].semesterList[(string)position[1]].courseList[(int)position[2]].title;
                    this.formLoaderPl.Controls.Clear();
                    AddAssessmentForm addAssessmentForm = new AddAssessmentForm(student.yearList[(string)position[0]].semesterList[(string)position[1]].courseList[(int)position[2]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    addAssessmentForm.FormBorderStyle = FormBorderStyle.None;
                    this.formLoaderPl.Controls.Add(addAssessmentForm);
                    addAssessmentForm.Show();
                    break;
                case 2:
                    titleLb.Text = student.yearList[(string)position[0]].semesterList[(string)position[1]].courseList[(int)position[2]].assessmentList[(int)position[3]].name;
                    this.formLoaderPl.Controls.Clear();
                    AssessmentForm assessmentForm = new AssessmentForm(student.yearList[(string)position[0]].semesterList[(string)position[1]].courseList[(int)position[2]].assessmentList[(int)position[3]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    assessmentForm.FormBorderStyle = FormBorderStyle.None;
                    this.formLoaderPl.Controls.Add(assessmentForm);
                    assessmentForm.Show();
                    break;
            }
        }
    }
}
