using Smartloop_Feedback.Coordinator_Folder;
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

namespace Smartloop_Feedback.Coordinator
{
    public partial class CoordinatorCourse : Form
    {
        private Course course;
        private CoordinatorMain mainForm;
        public CoordinatorCourse(Course course, CoordinatorMain mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
        }

        private void CoordinatorCourse_Load(object sender, EventArgs e)
        {
            codeTb.Text = course.Code.ToString();
            nameTb.Text = course.Name;
            creditTb.Text = course.CreditPoint.ToString();
            descriptionTb.Text = course.Description;
            canvasTb.Text = course.CanvasLink;
            yearTb.Text = course.Year.ToString();

            switch (course.Semester)
            {
                case "Summer":
                    summerRb.Checked = true;
                    break;
                case "Autumn":
                    autumnRb.Checked = true;
                    break;
                case "Winter":
                    winterRb.Checked = true;
                    break;
                case "Spring":
                    springRb.Checked = true;
                    break;
            }
        }

        // Event handler to allow only digits in the code TextBox
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore non-digit input
                }
            }
        }

        // Event handler for when any TextBox receives focus
        private void TextBox_Enter(object sender, EventArgs e)
        {
            defaultUI(); // Reset UI to default state

            TextBox currentTextBox = sender as TextBox;

            // Update UI to indicate the TextBox is active
            if (currentTextBox == codeTb)
            {
                codePl.BackColor = Color.FromArgb(254, 0, 57);
                codeTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == nameTb)
            {
                namePl.BackColor = Color.FromArgb(254, 0, 57);
                nameTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == creditTb)
            {
                creditPl.BackColor = Color.FromArgb(254, 0, 57);
                creditTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == yearTb)
            {
                yearPl.BackColor = Color.FromArgb(254, 0, 57);
                yearTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == canvasTb)
            {
                canvasPl.BackColor = Color.FromArgb(254, 0, 57);
                canvasTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
        }

        // Reset UI to default state
        private void defaultUI()
        {
            namePl.BackColor = Color.FromArgb(193, 193, 193);
            nameTb.ForeColor = Color.FromArgb(193, 193, 193);

            codePl.BackColor = Color.FromArgb(193, 193, 193);
            codeTb.ForeColor = Color.FromArgb(193, 193, 193);

            creditPl.BackColor = Color.FromArgb(193, 193, 193);
            creditTb.ForeColor = Color.FromArgb(193, 193, 193);

            yearPl.BackColor = Color.FromArgb(193, 193, 193);
            yearTb.ForeColor = Color.FromArgb(193, 193, 193);

            canvasPl.BackColor = Color.FromArgb(193, 193, 193);
            canvasTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string semester = autumnRb.Checked ? "Autumn" :
                                summerRb.Checked ? "Summer" :
                                springRb.Checked ? "Spring" :
                                winterRb.Checked ? "Winter" : null;

            if (!string.IsNullOrEmpty(nameTb.Text) || !string.IsNullOrEmpty(descriptionTb.Text) || !string.IsNullOrEmpty(canvasTb.Text) || !string.IsNullOrEmpty(yearTb.Text))
            {
                course.UpdateCourseToDatabase(Int32.Parse(codeTb.Text), nameTb.Text, Int32.Parse(creditTb.Text), descriptionTb.Text, yearTb.Text, semester, canvasTb.Text);
            }
            else
            {
                MessageBox.Show("Please fill out all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if any field is empty
            }
        }
    }
}
