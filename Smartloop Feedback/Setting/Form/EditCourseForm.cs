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

namespace Smartloop_Feedback.Setting
{
    public partial class EditCourseForm : Form
    {
        public Semester semester;
        public MainForm mainForm;
        public int courseId;

        public EditCourseForm(Semester semester, MainForm mainForm, int courseId)
        {
            InitializeComponent();
            this.semester = semester;
            this.mainForm = mainForm;
            this.courseId = courseId;
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            codeTb.Text = semester.CourseList[courseId].Code.ToString();
            nameTb.Text = semester.CourseList[courseId].Title;
            creditTb.Text = semester.CourseList[courseId].CreditPoint.ToString();
            descriptionTb.Text = semester.CourseList[courseId].Description;
            canvasTb.Text = semester.CourseList[courseId].CanvasLink;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            semester.CourseList[courseId].UpdateCourseToDatabase(Int32.Parse(codeTb.Text), nameTb.Text, Int32.Parse(creditTb.Text), descriptionTb.Text, canvasTb.Text);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete the course record? This will result in removing all associated objects as well.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                semester.DeleteCourseFromDatabase(courseId);
                mainForm.MainPannel(7);
                mainForm.MenuPannel(6);
            }
        }
    }
}
