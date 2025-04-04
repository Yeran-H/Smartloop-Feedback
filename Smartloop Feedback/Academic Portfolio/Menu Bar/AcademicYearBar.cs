﻿using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using Smartloop_Feedback.Objects.Updated.User_Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class AcademicYearBar : Form
    {
        private MainForm mainForm; // Reference to the main form
        private User user;

        // Constructor for the AcademicYearBar form
        public AcademicYearBar(MainForm form, User user)
        {
            InitializeComponent(); // Initialize form components
            mainForm = form; // Set the main form reference
            this.user = user;
            InitializeBar(); // Initialize the year bar with buttons
        }

        // Initialize the bar with year buttons based on the student's number of years
        private void InitializeBar()
        {
            Image buttonImage = Properties.Resources.calendar;
            int buttonCount = 0;

            foreach (int yearName in user.YearList.Keys)
            {
                Button btn = new Button
                {
                    Text = yearName.ToString(),
                    Dock = DockStyle.Top,
                    Height = 42,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Aptos", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193),
                    FlatAppearance = { BorderSize = 0 },
                    Image = buttonImage,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };
                btn.Click += new EventHandler(YearButton_Click);
                Controls.Add(btn);
                buttonCount++;
            }

            addBtn.Dock = DockStyle.Top;
            Controls.Add(addBtn);
            backBtn.Dock = DockStyle.Top;
            Controls.Add(backBtn);

            int totalHeight = backBtn.Height + addBtn.Height + 42 * buttonCount;
            this.ClientSize = new Size(170, totalHeight);
        }

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(0); // Navigate to the previous menu panel
        }

        // Event handler for the add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var addYearForm = new AddYearForm(user)) // Open the add year form
            {
                if (addYearForm.ShowDialog() == DialogResult.OK) // Check if the dialog result is OK
                {
                    int yearName = addYearForm.yearName; // Get the new year's name

                    user.YearList.Add(yearName, new Objects.Updated.User_Object.YearAssociation(yearName, user.Id, user.IsStudent, addYearForm.semesterNames)); // Add the new year to the student's year list
                    InitializeBar(); //Refresh the Bar
                }
            }
        }

        // Event handler for any year button click, navigates to the corresponding year's panel
        private void YearButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                mainForm.position[0] = Int32.Parse(clickedButton.Text); // Set the main form's position with the button text
                mainForm.MenuPanel(2); // Navigate to the corresponding year's panel
            }
        }
    }
}
