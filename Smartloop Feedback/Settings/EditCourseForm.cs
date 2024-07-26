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

namespace Smartloop_Feedback.Settings
{
    public partial class EditCourseForm : Form
    {
        public Semester semester;
        public object[] position;
        public EditCourseForm(Semester semester, object[] position)
        {
            InitializeComponent();
            this.semester = semester;
            this.position = position;
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            foreach(Course course in semester.courseList.Values)
            {
                AddCourseTabPage(course);
            }
        }

        private void AddCourseTabPage(Course course)
        {
            var tabPage = new System.Windows.Forms.TabPage
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Text = course.title,
                Padding = new System.Windows.Forms.Padding(3),
                Size = new System.Drawing.Size(726, 398),
                TabIndex = 0,
                Tag = course.id
            };

            var label1 = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(201, 40),
                Name = "label1",
                Size = new System.Drawing.Size(55, 20),
                Text = "Code: "
            };

            var label2 = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(207, 64),
                Name = "label2",
                Size = new System.Drawing.Size(49, 20),
                Text = "Title: "
            };

            var label3 = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(154, 94),
                Name = "label3",
                Size = new System.Drawing.Size(102, 20),
                Text = "Credit Point: "
            };

            var label4 = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(154, 120),
                Name = "label4",
                Size = new System.Drawing.Size(101, 20),
                Text = "Description: "
            };

            var label5 = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(155, 215),
                Name = "label5",
                Size = new System.Drawing.Size(104, 20),
                Text = "Canvas Link: "
            };

            var codeTb = new System.Windows.Forms.TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                HideSelection = false,
                Location = new System.Drawing.Point(262, 37),
                Name = "codeTb",
                Size = new System.Drawing.Size(206, 20),
                Text = course.code.ToString()
            };

            var codePl = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(262, 59),
                Name = "codePl",
                Size = new System.Drawing.Size(206, 1)
            };

            var nameTb = new System.Windows.Forms.TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                HideSelection = false,
                Location = new System.Drawing.Point(262, 64),
                Name = "nameTb",
                Size = new System.Drawing.Size(206, 20),
                Text = course.title
            };

            var namePl = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(262, 86),
                Name = "namePl",
                Size = new System.Drawing.Size(206, 1)
            };

            var creditTb = new System.Windows.Forms.TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                HideSelection = false,
                Location = new System.Drawing.Point(261, 94),
                Name = "creditTb",
                Size = new System.Drawing.Size(206, 20),
                Text = course.creditPoint.ToString()
            };

            var creditPl = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(261, 113),
                Name = "creditPl",
                Size = new System.Drawing.Size(206, 1)
            };

            var descriptionTb = new System.Windows.Forms.TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                HideSelection = false,
                Location = new System.Drawing.Point(259, 120),
                Multiline = true,
                Name = "descriptionTb",
                Size = new System.Drawing.Size(206, 85),
                Text = course.description
            };

            var descriptionPl = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(263, 211),
                Name = "descriptionPl",
                Size = new System.Drawing.Size(206, 1)
            };

            var canvasTb = new System.Windows.Forms.TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                HideSelection = false,
                Location = new System.Drawing.Point(262, 215),
                Name = "canvasTb",
                Size = new System.Drawing.Size(206, 20),
                Text = course.canvasLink
            };

            var canvasPl = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(262, 237),
                Name = "canvasPl",
                Size = new System.Drawing.Size(206, 1)
            };

            var updateBtn = new System.Windows.Forms.Button
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(254, 0, 57),
                Location = new System.Drawing.Point(270, 293),
                Name = "updateBtn",
                Size = new System.Drawing.Size(211, 55),
                Text = "Update Course",
                UseVisualStyleBackColor = false
            };

            updateBtn.Click += new System.EventHandler(this.updateBtn_Click);

            var deleteBtn = new System.Windows.Forms.Button
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(254, 0, 57),
                Location = new System.Drawing.Point(487, 293),
                Name = "deleteBtn",
                Size = new System.Drawing.Size(211, 55),
                Text = "Delete Course",
                UseVisualStyleBackColor = false
            };

            deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);

            var assessmentBtn = new System.Windows.Forms.Button
            {
                BackColor = System.Drawing.Color.FromArgb(254, 0, 57),
                Cursor = System.Windows.Forms.Cursors.Hand,
                Enabled = false,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Location = new System.Drawing.Point(53, 293),
                Name = "assessmentBtn",
                Size = new System.Drawing.Size(211, 55),
                Text = "View Assessment",
                UseVisualStyleBackColor = false
            };

            assessmentBtn.Click += new System.EventHandler(this.assessmentBtn_Click);

            tabPage.Controls.Add(label1);
            tabPage.Controls.Add(label2);
            tabPage.Controls.Add(label3);
            tabPage.Controls.Add(label4);
            tabPage.Controls.Add(label5);
            tabPage.Controls.Add(codeTb);
            tabPage.Controls.Add(codePl);
            tabPage.Controls.Add(nameTb);
            tabPage.Controls.Add(namePl);
            tabPage.Controls.Add(creditTb);
            tabPage.Controls.Add(creditPl);
            tabPage.Controls.Add(descriptionTb);
            tabPage.Controls.Add(descriptionPl);
            tabPage.Controls.Add(canvasTb);
            tabPage.Controls.Add(canvasPl);
            tabPage.Controls.Add(updateBtn);
            tabPage.Controls.Add(deleteBtn);
            tabPage.Controls.Add(assessmentBtn);

            this.courseTab.Controls.Add(tabPage);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = courseTab.SelectedTab;

            if (selectedTab != null)
            {
                int courseId = (int)selectedTab.Tag;

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete the course record? This will result in removing all associated objects as well.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    semester.DeleteCourseFromDatabase(courseId);
                    this.Close();
                }
            }
        }

        private void assessmentBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
