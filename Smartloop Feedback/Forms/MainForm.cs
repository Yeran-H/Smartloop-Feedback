﻿using System;
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
using Smartloop_Feedback.Results;
using Smartloop_Feedback.Dashboard;
using Smartloop_Feedback.Setting;
using Smartloop_Feedback.Setting.Bar;
using Smartloop_Feedback.Academic_Portfolio.AI;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object;

namespace Smartloop_Feedback
{
    public partial class MainForm : Form
    {
        private User user;
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

        // Fields to track dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public MainForm(User user)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            navPl.Height = dashboardBtn.Height;
            navPl.Top = dashboardBtn.Top;
            navPl.Left = dashboardBtn.Left;
            dashboardBtn.BackColor = Color.FromArgb(16, 34, 61);
            
            this.user = user;
            position = new List<object>(new object[5]);

            MainPannel(0);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            nameLb.Text = user.Name;
            studentIdLb.Text = user.Id.ToString();
            if (user.ProfileImage != null)
            {
                using (MemoryStream ms = new MemoryStream(user.ProfileImage))
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

            MainPannel(5);
        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = resultBtn.Height;
            navPl.Top = resultBtn.Top;
            navPl.Left = resultBtn.Left;
            resultBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Results";
            this.formLoaderPl.Controls.Clear();
            
            //ResultForm result = new ResultForm(student) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //result.FormBorderStyle = FormBorderStyle.None;
            //this.formLoaderPl.Controls.Add(result);
            //result.Show();           
        }

        private void academicBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = academicBtn.Height;
            navPl.Top = academicBtn.Top;
            navPl.Left = academicBtn.Left;
            academicBtn.BackColor = Color.FromArgb(16, 34, 61);

            MenuPanel(1);
        }

        private void courseBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = courseBtn.Height;
            navPl.Top = courseBtn.Top;
            navPl.Left = courseBtn.Left;
            courseBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Course Schedule";
            this.formLoaderPl.Controls.Clear();
            
            //CourseScheduleForm course = new CourseScheduleForm(student) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //course.FormBorderStyle = FormBorderStyle.None;
            //this.formLoaderPl.Controls.Add(course);
            //course.Show();            
        }

        private void setttingBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = setttingBtn.Height;
            navPl.Top = setttingBtn.Top;
            navPl.Left = setttingBtn.Left;
            setttingBtn.BackColor = Color.FromArgb(16, 34, 61);

            titleLb.Text = "Settings";
            MainPannel(4);
            MenuPanel(4);
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

        public void MenuPanel(int num)
        {
            menuDropPl.Controls.Clear();
            switch (num) 
            {
                case 0:
                    menuDropPl.Visible = false;
                    dashboardBtn_Click(this, EventArgs.Empty);
                    break;
                case 1:
                    AcademicYearBar year = new AcademicYearBar(this, user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    year.FormBorderStyle = FormBorderStyle.None;
                    menuDropPl.Visible = true;
                    this.menuDropPl.Controls.Add(year);
                    year.Show();
                    break;
                case 2:
                    AcademicSemesterBar semester = new AcademicSemesterBar(this, user.YearList[(int)position[0]]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    semester.FormBorderStyle = FormBorderStyle.None;
                    menuDropPl.Visible = true;
                    this.menuDropPl.Controls.Add(semester);
                    semester.Show();
                    break;
                case 3:
                    AcademicCourseBar subject = new AcademicCourseBar(this, user.YearList[(int)position[0]].SemesterList[(string)position[1]]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    subject.FormBorderStyle = FormBorderStyle.None;
                    menuDropPl.Visible = true;
                    this.menuDropPl.Controls.Add(subject);
                    subject.Show();
                    break;
            }

        }

        //public void MenuPanel(int num)
        //{
        //    menuDropPl.Controls.Clear();
        //    switch (num)
        //    {
        //        case 0:
        //            AcademicYearBar year = new AcademicYearBar(this, student) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //year.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(year);
        //            year.Show();
        //            break;
        //        case 1:
        //            menuDropPl.Visible = false;
        //            dashboardBtn_Click(this, EventArgs.Empty);
        //            break;
        //        case 2:
        //            AcademicSemesterBar semester = new AcademicSemesterBar(this, student.YearList[(int)position[0]]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            semester.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(semester);
        //            semester.Show();
        //            break;
        //        case 3:
        //            AcademicCourseBar subject = new AcademicCourseBar(this, student.YearList[(int)position[0]].SemesterList[(string)position[1]]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            subject.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(subject);
        //            subject.Show();
        //            break;
        //        case 4:
        //            SettingYearBar yearBar = new SettingYearBar(student, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            yearBar.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(yearBar);
        //            yearBar.Show();
        //            break;
        //        case 5:
        //            SettingSemesterBar semesterBar = new SettingSemesterBar(student.YearList[(int)position[0]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            semesterBar.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(semesterBar);
        //            semesterBar.Show();
        //            break;
        //        case 6:
        //            SettingCourseBar courseBar = new SettingCourseBar(student.YearList[(int)position[0]].SemesterList[(string)position[1]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            courseBar.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(courseBar);
        //            courseBar.Show();
        //            break;
        //        case 7:
        //            SettingAssessmentBar assessmentBar = new SettingAssessmentBar(student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            assessmentBar.FormBorderStyle = FormBorderStyle.None;
        //            menuDropPl.Visible = true;
        //            this.menuDropPl.Controls.Add(assessmentBar);
        //            assessmentBar.Show();
        //            break;

        //    }
        //}

        public void MainPannel(int num)
        {
            switch(num)
            {
                case 0:
                    titleLb.Text = "Dashboard";
                    this.formLoaderPl.Controls.Clear();

                    //DashboardForm dashboard = new DashboardForm(student, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    //dashboard.FormBorderStyle = FormBorderStyle.None;
                    //this.formLoaderPl.Controls.Add(dashboard);
                    //dashboard.Show();
                    break;
            }
        }

        //public void MainPannel(int num)
        //{
        //    switch (num)
        //    {
        //        case 0:
        //            titleLb.Text = student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]].Title;
        //            this.formLoaderPl.Controls.Clear();
        //            StudentCourseForm course = new StudentCourseForm(student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            course.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(course);
        //            course.Show();
        //            break;
        //        case 1:
        //            //titleLb.Text = student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]].Title;
        //            //this.formLoaderPl.Controls.Clear();
        //            //AddAssessmentForm addAssessmentForm = new AddAssessmentForm(student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            //addAssessmentForm.FormBorderStyle = FormBorderStyle.None;
        //            //this.formLoaderPl.Controls.Add(addAssessmentForm);
        //            //addAssessmentForm.Show();
        //            break;
        //        case 2:
        //            titleLb.Text = student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]].AssessmentList[(int)position[3]].Name;
        //            this.formLoaderPl.Controls.Clear();
        //            AssessmentForm assessmentForm = new AssessmentForm(student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]].AssessmentList[(int)position[3]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            assessmentForm.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(assessmentForm);
        //            assessmentForm.Show();
        //            break;
        //        case 3:
        //            LoginForm login = new LoginForm();
        //            login.Show();
        //            this.Hide();
        //            break;
        //        case 4:
        //            this.formLoaderPl.Controls.Clear();
        //            EditAccountForm accountForm = new EditAccountForm(student, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            accountForm.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(accountForm);
        //            accountForm.Show();
        //            break;
        //        case 5:
        //            titleLb.Text = "Dashboard";
        //            this.formLoaderPl.Controls.Clear();

        //            DashboardForm dashboard = new DashboardForm(student, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            dashboard.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(dashboard);
        //            dashboard.Show();
        //            break;
        //        case 6:
        //            nameLb.Text = student.Name;
        //            studentIdLb.Text = student.Id.ToString();
        //            if (student.ProfileImage != null)
        //            {
        //                using (MemoryStream ms = new MemoryStream(student.ProfileImage))
        //                {
        //                    profilePb.Image = Image.FromStream(ms);
        //                }
        //            }
        //            break;
        //        case 7:
        //            this.formLoaderPl.Controls.Clear();
        //            EditYearForms yearForms = new EditYearForms(student, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            yearForms.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(yearForms);
        //            yearForms.Show();
        //            break;
        //        case 8:
        //            this.formLoaderPl.Controls.Clear();
        //            EditCourseForm courseForm = new EditCourseForm(student.YearList[(int)position[0]].SemesterList[(string)position[1]], this, (int)position[2]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            courseForm.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(courseForm);
        //            courseForm.Show();
        //            break;
        //        case 9:
        //            //this.formLoaderPl.Controls.Clear();
        //            //CoordinatorAssessmentForm assessmentForm1 = new CoordinatorAssessmentForm(student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]], this, (int)position[3]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            //assessmentForm1.FormBorderStyle = FormBorderStyle.None;
        //            //this.formLoaderPl.Controls.Add(assessmentForm1);
        //            //assessmentForm1.Show();
        //            //break;
        //        case 10:
        //            this.formLoaderPl.Controls.Clear();
        //            AIForm aIForm = new AIForm(student.YearList[(int)position[0]].SemesterList[(string)position[1]].CourseList[(int)position[2]].AssessmentList[(int)position[3]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        //            aIForm.FormBorderStyle = FormBorderStyle.None;
        //            this.formLoaderPl.Controls.Add(aIForm);
        //            aIForm.Show();
        //            break;
        //    }
        //}

        private void centrePannel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void centrePannel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void centrePannel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
