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

namespace Smartloop_Feedback.Academic_Portfolio.Add_Form
{
    public partial class AddCheckListForm : Form
    {
        public string name;

        // P/Invoke to create a rounded rectangle region for the form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public AddCheckListForm()
        {
            InitializeComponent();
            // Set the form's region to a rounded rectangle
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Override ProcessCmdKey to detect Enter key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                addBtn.PerformClick(); // Simulate a click on the save button
                return true; // Indicate that the key press has been handled
            }
            return base.ProcessCmdKey(ref msg, keyData); // Call the base method for other key presses
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            name = itemTb.Text;
            // Validate that the year name is not empty, unique, and semesters are selected
            if (!string.IsNullOrEmpty(name))
            {

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter an Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemTb_Click(object sender, EventArgs e)
        {
            itemTb.Clear();
        }
    }
}
