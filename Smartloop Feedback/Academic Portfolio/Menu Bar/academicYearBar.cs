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
        private Student student; // Reference to the student object

        private int buttonCount = 0; // Counter for the number of buttons
        private Button[] buttons = new Button[5]; // Array to hold the year buttons
        private Button[] allButtons; // Array to hold all possible buttons

        // Constructor for the AcademicYearBar form
        public AcademicYearBar(MainForm form, Student student)
        {
            InitializeComponent(); // Initialize form components
            mainForm = form; // Set the main form reference
            this.student = student; // Set the student reference
            InitializeBar(); // Initialize the year bar with buttons
        }

        // Initialize the bar with year buttons based on the student's number of years
        private void InitializeBar()
        {
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn }; // Array of all possible buttons

            buttonCount = 0;
            foreach (Year year in student.YearList.Values)
            {
                Button btn = allButtons[buttonCount]; // Get the button for the current year
                btn.Visible = true; // Make the button visible
                btn.Text = year.Name.ToString(); // Set the button text to the year's name
                buttons[buttonCount] = btn; // Store the button in the array
                buttons[buttonCount].Click += YearButton_Click; // Attach the event handler to the button

                buttonCount++;
            }

            // Hide the add button if the maximum number of buttons (5) is reached
            if (buttonCount == 5)
            {
                addBtn.Visible = false;
            }

            UpdatePanel(); // Update the panel to reflect changes
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

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(1); // Navigate to the previous menu panel
        }

        // Event handler for the add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var addYearForm = new AddYearForm(student)) // Open the add year form
            {
                if (addYearForm.ShowDialog() == DialogResult.OK) // Check if the dialog result is OK
                {
                    int yearName = addYearForm.yearName; // Get the new year's name

                    if (buttonCount < 5) // Ensure the button count is less than 5
                    {
                        Year year = new Year(yearName, student.StudentId, addYearForm.semesterNames);
                        student.YearList.Add(year.Name, year); // Add the new year to the student's year list
                        InitializeBar(); //Refresh the Bar
                    }
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
