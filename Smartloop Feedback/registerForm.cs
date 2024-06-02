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
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void nameTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            nameTb.Clear();
            namePb.Image = Properties.Resources.person2;
            namePl.BackColor = Color.FromArgb(254, 0, 57);
            nameTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void studentTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            studentTb.Clear();
            studentPb.Image = Properties.Resources.person2;
            studentPl.BackColor = Color.FromArgb(254, 0, 57);
            studentTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void passwordTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            passwordTb.Clear();
            passwordPb.Image = Properties.Resources.pass2;
            passwordPl.BackColor = Color.FromArgb(254, 0, 57);
            passwordTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void degreeTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            degreeTb.Clear();
            degreePb.Image = Properties.Resources.degree2;
            degreePl.BackColor = Color.FromArgb(254, 0, 57);
            degreeTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void defaultUI()
        {
            namePb.Image = Properties.Resources.person1;
            namePl.BackColor = Color.FromArgb(193, 193, 193);
            nameTb.ForeColor = Color.FromArgb(193, 193, 193);

            studentPb.Image = Properties.Resources.person1;
            studentPl.BackColor = Color.FromArgb(193, 193, 193);
            studentTb.ForeColor = Color.FromArgb(193, 193, 193);

            passwordPb.Image = Properties.Resources.pass1;
            passwordPl.BackColor = Color.FromArgb(193, 193, 193);
            passwordTb.ForeColor = Color.FromArgb(193, 193, 193);

            degreePb.Image = Properties.Resources.degree1;
            degreePl.BackColor = Color.FromArgb(193, 193, 193);
            degreeTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    profilePb.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
