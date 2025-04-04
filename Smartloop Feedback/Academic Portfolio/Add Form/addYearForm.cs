﻿using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object;
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
    public partial class AddYearForm : Form
    {
        // Public properties to hold the year name and semester names
        public int yearName { get; set; }
        public User user { get; set; }
        public List<string> semesterNames { get; set; }

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

        // Constructor to initialize the form with a student object
        public AddYearForm(User user)
        {
            InitializeComponent();
            this.user = user;
            semesterNames = new List<string>();
            // Set the form's region to a rounded rectangle
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        // Event handler for the save button click
        private void saveBtn_Click(object sender, EventArgs e)
        {
            yearName = Int32.Parse(yearTb.Text);
            // Validate that the year name is not empty, unique, and semesters are selected
            if (user.UniqueYear(yearName) && semesterCb.CheckedItems.Count > 0)
            {
                // Add selected semesters to the semesterNames list
                foreach (string item in semesterCb.CheckedItems)
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

        // Event handler for the cancel button click
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Event handler for the year text box click
        private void yearTb_Click(object sender, EventArgs e)
        {
            yearTb.Clear();
            yearPl.BackColor = Color.FromArgb(254, 0, 57);
            yearTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        // Override ProcessCmdKey to detect Enter key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                saveBtn.PerformClick(); // Simulate a click on the save button
                return true; // Indicate that the key press has been handled
            }
            return base.ProcessCmdKey(ref msg, keyData); // Call the base method for other key presses
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void yearTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Reject non-digit input
                }
            }
        }
    }
}
