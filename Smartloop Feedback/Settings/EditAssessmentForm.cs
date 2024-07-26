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
using System.Xml.Linq;

namespace Smartloop_Feedback.Settings
{
    public partial class EditAssessmentForm : Form
    {
        public Course course;
        public object[] position;
        public EditAssessmentForm(Course course, object[] position)
        {
            InitializeComponent();
            this.course = course;
            this.position = position;
        }

        private void EditAssessmentForm_Load(object sender, EventArgs e)
        {
            foreach (Assessment assessment in course.assessmentList.Values)
            {
                var tabPage = CreateTabPage(assessment);

                assessmentTab.Controls.Add(tabPage);
            }
        }

        private TabPage CreateTabPage(Assessment assessment)
        {
            var tabPage = new TabPage(assessment.name)
            {
                Tag = assessment.name
            };

            var panelDetails = new Panel
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Size = new System.Drawing.Size(736, 424),
                Location = new System.Drawing.Point(2, 2)
            };

            var descriptionTb = new TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(133, 94),
                Multiline = true,
                Size = new System.Drawing.Size(200, 128),
                Text = "Description"
            };

            var canvasPl = new Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(386, 282),
                Size = new System.Drawing.Size(200, 1)
            };

            var canvasTb = new TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(386, 263),
                Size = new System.Drawing.Size(200, 20),
                Text = "Canvas Link"
            };

            var weightPl = new Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(387, 193),
                Size = new System.Drawing.Size(200, 1)
            };

            var weightTb = new TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(387, 174),
                Size = new System.Drawing.Size(200, 20),
                Text = "Weight"
            };

            var markPl = new Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(387, 159),
                Size = new System.Drawing.Size(200, 1)
            };

            var markTb = new TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(387, 140),
                Size = new System.Drawing.Size(200, 20),
                Text = "Total Mark"
            };

            var groupRbtn = new RadioButton
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(428, 224),
                Size = new System.Drawing.Size(109, 24),
                Text = "Group Work"
            };

            var individualRbtn = new RadioButton
            {
                AutoSize = true,
                Checked = true,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(428, 201),
                Size = new System.Drawing.Size(95, 24),
                Text = "Individual"
            };

            var nextBtn = new Button
            {
                BackColor = System.Drawing.Color.FromArgb(254, 0, 57),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Location = new System.Drawing.Point(367, 316),
                Size = new System.Drawing.Size(141, 52),
                Text = "Next"
            };

            var cancelBtn = new Button
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(254, 0, 57),
                Location = new System.Drawing.Point(220, 316),
                Size = new System.Drawing.Size(141, 52),
                Text = "Cancel"
            };

            var typeCb = new ComboBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(386, 101),
                Size = new System.Drawing.Size(201, 28),
                Text = "Type of Assessment"
            };

            typeCb.Items.AddRange(new object[]
            {
                "Reflection", "Report", "Coding", "Project", "Quiz", "Test", "Presentation", "Essay", "Peer Review"
            });

            var datePl = new Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(133, 282),
                Size = new System.Drawing.Size(200, 1)
            };

            var label1 = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(129, 249),
                Size = new System.Drawing.Size(78, 20),
                Text = "Due Date:"
            };

            var descriptionPl = new Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(133, 224),
                Size = new System.Drawing.Size(200, 1)
            };

            var titlePl = new Panel
            {
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(134, 87),
                Size = new System.Drawing.Size(200, 1)
            };

            var titleTb = new TextBox
            {
                BackColor = System.Drawing.Color.FromArgb(16, 34, 61),
                BorderStyle = BorderStyle.None,
                Font = new System.Drawing.Font("Aptos", 12F),
                ForeColor = System.Drawing.Color.FromArgb(193, 193, 193),
                Location = new System.Drawing.Point(134, 68),
                Size = new System.Drawing.Size(200, 20),
                Text = "Title"
            };

            var dateP = new Smartloop_Feedback.Objects.DatePicker
            {
                BorderColor = System.Drawing.Color.FromArgb(254, 0, 57),
                BorderSize = 0,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F),
                Format = DateTimePickerFormat.Short,
                Location = new System.Drawing.Point(203, 241),
                MinimumSize = new System.Drawing.Size(4, 35),
                Size = new System.Drawing.Size(130, 35),
                SkinColor = System.Drawing.Color.FromArgb(16, 34, 61),
                TextColor = System.Drawing.Color.FromArgb(193, 193, 193)
            };

            panelDetails.Controls.Add(descriptionTb);
            panelDetails.Controls.Add(canvasPl);
            panelDetails.Controls.Add(canvasTb);
            panelDetails.Controls.Add(weightPl);
            panelDetails.Controls.Add(weightTb);
            panelDetails.Controls.Add(markPl);
            panelDetails.Controls.Add(markTb);
            panelDetails.Controls.Add(groupRbtn);
            panelDetails.Controls.Add(individualRbtn);
            panelDetails.Controls.Add(nextBtn);
            panelDetails.Controls.Add(cancelBtn);
            panelDetails.Controls.Add(typeCb);
            panelDetails.Controls.Add(datePl);
            panelDetails.Controls.Add(label1);
            panelDetails.Controls.Add(descriptionPl);
            panelDetails.Controls.Add(titlePl);
            panelDetails.Controls.Add(titleTb);
            panelDetails.Controls.Add(dateP);

            tabPage.Controls.Add(panelDetails);

            return tabPage;
        }

    }
}
