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

namespace Smartloop_Feedback
{
    public partial class mainForm : Form
    {
        private Student student;

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

        public mainForm(Student student)
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
            dashboard.FormboarderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(dashboard);
            dashboard.Show();
             */

            this.student = student;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            nameLb.Text = student.name;
            studentIdLb.Text = student.studentId.ToString();
            if(student.profileImage != null)
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
            dashboard.FormboarderStyle = FormBorderStyle.None;
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
            result.FormboarderStyle = FormBorderStyle.None;
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

            titleLb.Text = "Academic Portfolio";
            this.formLoaderPl.Controls.Clear();
            /*
            academicForm academic = new academicForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            academic.FormboarderStyle = FormBorderStyle.None;
            this.formLoaderPl.Controls.Add(academic);
            academic.Show();
             */
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
            setting.FormboarderStyle = FormBorderStyle.None;
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

        private void exitPb_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                loginForm login = new loginForm();
                login.Show();
                this.Hide();
            }
        }
    }
}
