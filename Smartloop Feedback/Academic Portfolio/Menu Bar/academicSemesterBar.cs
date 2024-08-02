using System;
using System.Linq;
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

            // Loop through each semester in the year's semester list
            semesterButtons
                .Where(button => year.semesterList.Keys.Contains(button.Text))
                .ToList()
                .ForEach(button => button.Visible = true);
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
            mainForm.position[1] = clickedButton.Text; // Get the semester name from the button text
            mainForm.MenuPannel(3); // Navigate to the corresponding semester panel
        }
    }
}
