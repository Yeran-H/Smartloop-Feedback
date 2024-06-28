﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class addYearForm : Form
    {
        public string yearName { get; set; } 
        public Student student { get; }
        public List<string> semesterNames { get; set; }
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

        public addYearForm(Student student)
        {
            InitializeComponent();
            this.student = student;
            semesterNames = new List<string>();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            yearName = yearTb.Text;
            if(!string.IsNullOrEmpty(yearName) && student.uniqueYear(yearName) && semesterCb.CheckedItems.Count > 0)
            {
                foreach(string item in semesterCb.CheckedItems)
                {
                    semesterNames.Add(item);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a unique name. And add Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void yearTb_Click(object sender, EventArgs e)
        {
            yearTb.Clear();
            yearPl.BackColor = Color.FromArgb(254, 0, 57);
            yearTb.ForeColor = Color.FromArgb(254, 0, 57);
        }
    }
}
