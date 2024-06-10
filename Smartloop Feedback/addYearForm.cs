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
    public partial class addYearForm : Form
    {
        public string yearName { get; set; } 
        public addYearForm()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            yearName = yearTb.Text;
            if(!string.IsNullOrEmpty(yearName))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a year name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
