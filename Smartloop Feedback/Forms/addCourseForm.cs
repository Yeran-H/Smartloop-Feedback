using Smartloop_Feedback.Objects;
using System;
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
    public partial class addCourseForm : Form
    {
        public Course course;
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>();
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

        public addCourseForm()
        {
            InitializeComponent();
            textBoxClicked[codeTb] = false;
            textBoxClicked[nameTb] = false;
            textBoxClicked[creditTb] = false;
            textBoxClicked[descriptionTb] = false;
            textBoxClicked[canvasTb] = false;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            course = new Course(Int32.Parse(codeTb.Text), nameTb.Text, Int32.Parse(creditTb.Text), descriptionTb.Text, canvasTb.Text);
            if (!string.IsNullOrEmpty(course.title) || !string.IsNullOrEmpty(course.description) || !string.IsNullOrEmpty(course.canvasLink))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill out all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void codeTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void creditTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void codeTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[codeTb])
            {
                codeTb.Clear();
                textBoxClicked[codeTb] = true;
            }
            codePl.BackColor = Color.FromArgb(254, 0, 57);
            codeTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void nameTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[nameTb])
            {
                nameTb.Clear();
                textBoxClicked[nameTb] = true;
            }
            namePl.BackColor = Color.FromArgb(254, 0, 57);
            nameTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void creditTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[creditTb])
            {
                creditTb.Clear();
                textBoxClicked[creditTb] = true;
            }
            creditPl.BackColor = Color.FromArgb(254, 0, 57);
            creditTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void descriptionTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[descriptionTb])
            {
                descriptionTb.Clear();
                textBoxClicked[descriptionTb] = true;
            }
            descriptionPl.BackColor = Color.FromArgb(254, 0, 57);
            descriptionTb.ForeColor = Color.FromArgb(254, 0, 57);
        }
        private void canvasTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[canvasTb])
            {
                canvasTb.Clear();
                textBoxClicked[canvasTb] = true;
            }
            canvasPl.BackColor = Color.FromArgb(254, 0, 57);
            canvasTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void defaultUI()
        {
            namePl.BackColor = Color.FromArgb(193, 193, 193);
            nameTb.ForeColor = Color.FromArgb(193, 193, 193);

            codePl.BackColor = Color.FromArgb(193, 193, 193);
            codeTb.ForeColor = Color.FromArgb(193, 193, 193);

            creditPl.BackColor = Color.FromArgb(193, 193, 193);
            creditTb.ForeColor = Color.FromArgb(193, 193, 193);

            descriptionPl.BackColor = Color.FromArgb(193, 193, 193);
            descriptionTb.ForeColor = Color.FromArgb(193, 193, 193);

            canvasPl.BackColor = Color.FromArgb(193, 193, 193);
            canvasTb.ForeColor = Color.FromArgb(193, 193, 193);
        }
    }
}
