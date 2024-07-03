using System;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class AcademicSemesterBar : Form
    {
        private MainForm mainForm; // Reference to the main form
        private Year year; // Reference to the current year

        // Constructor for academicSemesterBar
        public AcademicSemesterBar(MainForm form, Year year)
        {
            InitializeComponent(); // Initialize form components
            mainForm = form; // Set the main form reference
            this.year = year; // Set the year reference
            InitializeBar(); // Initialize the semester bar
        }

        // Initialize the semester bar with visible buttons based on the semesters in the year
        private void InitializeBar()
        {
            // Array of all semester buttons
            Button[] semesterButtons = { summerBtn, autumnBtn, winterBtn, springBtn };
            // Array of semester names corresponding to the buttons
            string[] semesterNames = { "Summer", "Autumn", "Winter", "Spring" };

            // Loop through each semester in the year's semester list
            foreach (Semester semester in year.semesterList)
            {
                // Get the index of the semester name
                int index = Array.IndexOf(semesterNames, semester.name);
                if (index >= 0)
                {
                    semesterButtons[index].Visible = true; // Make the corresponding button visible
                }
            }
        }

        // Event handler for the back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPannel(0); // Navigate to the main menu panel
        }

        // Common event handler for all semester button clicks
        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button; // Get the clicked button
            string semesterName = clickedButton.Text; // Get the semester name from the button text
            mainForm.position[1] = year.SemesterIndex(semesterName); // Set the main form's position to the selected semester
            mainForm.MenuPannel(3); // Navigate to the corresponding semester panel
        }
    }
}
