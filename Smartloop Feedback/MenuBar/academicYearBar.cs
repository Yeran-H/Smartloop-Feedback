using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class academicYearBar : Form
    {
        private mainForm mainForm; // Reference to the main form
        private Student student; // Reference to the student object

        private int buttonCount = 0; // Counter for the number of buttons
        private Button[] buttons = new Button[5]; // Array to hold the year buttons
        private Button[] allButtons;

        // Constructor for the academicYearBar form
        public academicYearBar(mainForm form, Student student)
        {
            InitializeComponent(); // Initialize form components
            mainForm = form; // Set the main form reference
            this.student = student; // Set the student reference
            InitializeBar(); // Initialize the year bar with buttons
        }

        // Initialize the bar with year buttons based on the student's number of years
        private void InitializeBar()
        {
            buttonCount = student.numYears(); // Get the number of years for the student
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn }; // Array of all possible buttons

            // Loop through the number of years and make corresponding buttons visible
            for (int i = 0; i < buttonCount; i++)
            {
                Button btn = allButtons[i]; // Get the button for the current year
                btn.Visible = true; // Make the button visible
                btn.Text = student.yearList[i].name; // Set the button text to the year's name
                buttons[i] = btn; // Store the button in the array
                buttons[i].Click += YearButton_Click; // Attach the event handler to the button
            }

            // Hide the add button if the maximum number of buttons (5) is reached
            if (buttonCount == 5)
            {
                addBtn.Visible = false;
            }

            UpdatePanel(); // Update the panel to reflect changes
        }

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.menuPannel(1); // Navigate to the previous menu panel
        }

        // Event handler for the add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var addYearForm = new addYearForm(student)) // Open the add year form
            {
                if (addYearForm.ShowDialog() == DialogResult.OK) // Check if the dialog result is OK
                {
                    string yearName = addYearForm.yearName; // Get the new year's name

                    if (buttonCount < 5) // Ensure the button count is less than 5
                    {
                        student.yearList.Add(new Year(yearName, student.studentId, addYearForm.semesterNames)); // Add the new year to the student's year list
                        
                        Button btn = allButtons[buttonCount];
                        btn.Visible = true; // Make the new button visible
                        btn.Text = yearName; // Set the new button's text
                        btn.Click += YearButton_Click; // Attach the event handler to the button
                        buttons[buttonCount] = btn;
                        buttonCount++; // Increment the button count

                        if (buttonCount == 5) // Hide the add button if the maximum number of buttons is reached
                        {
                            addBtn.Visible = false;
                        }

                        UpdatePanel(); // Update the panel to reflect changes
                    }
                }
            }
        }

        // Update the panel by re-adding controls in the correct order
        private void UpdatePanel()
        {
            Controls.Clear(); // Clear all controls

            // Add the year buttons in reverse order to dock them at the top
            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Controls.Add(buttons[i]);
                buttons[i].Dock = DockStyle.Top;
            }

            // Add the add button if there are less than 5 buttons
            if (buttonCount < 5)
            {
                Controls.Add(addBtn);
                addBtn.Dock = DockStyle.Top;
            }
            Controls.Add(backBtn); // Add the back button
            backBtn.Dock = DockStyle.Top;
        }

        // Event handler for any year button click, navigates to the corresponding year's panel
        private void YearButton_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(buttons, sender); // Find the index of the clicked button
            if (index >= 0)
            {
                mainForm.position[0] = index; // Set the main form's position
                mainForm.menuPannel(2); // Navigate to the corresponding year's panel
            }
        }
    }
}
