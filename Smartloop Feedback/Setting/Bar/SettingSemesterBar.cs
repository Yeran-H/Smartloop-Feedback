using Smartloop_Feedback.Objects.Updated.User_Object;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting.Bar
{
    public partial class SettingSemesterBar : Form
    {
        public YearAssociation year;
        public MainForm mainForm; // Reference to the main form

        // Constructor for SettingSemesterBar, initializes the form with the year and main form references
        public SettingSemesterBar(YearAssociation year, MainForm mainForm)
        {
            InitializeComponent();
            this.year = year;
            this.mainForm = mainForm;

            navPl.Height = backBtn.Height; // Set the navigation panel height to match the back button height
            navPl.Top = backBtn.Top; // Align the navigation panel with the back button
            navPl.Left = backBtn.Left; // Align the navigation panel with the back button
        }

        // Event handler for form load
        private void SettingSemesterBar_Load(object sender, EventArgs e)
        {
            // Array of predefined semester buttons
            Button[] semesterButtons = { summerBtn, autumnBtn, winterBtn, springBtn };

            // Set visibility of semester buttons based on the year object
            semesterButtons
                .Where(button => year.SemesterList.Keys.Contains(button.Text))
                .ToList()
                .ForEach(button => button.Visible = true);
        }

        // Event handler for back button click to navigate back to the previous panel
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(4); // Navigate to the menu panel
            mainForm.MainPannel(5); // Navigate to the main panel
        }

        // Event handler for semester button click to navigate to the semester details panel
        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                navPl.Height = clickedButton.Height; // Adjust the navigation panel height
                navPl.Top = clickedButton.Top; // Move the navigation panel to the clicked button's position
                navPl.Left = clickedButton.Left; // Align the navigation panel with the clicked button
                clickedButton.BackColor = Color.FromArgb(16, 34, 61); // Change the clicked button's background color

                mainForm.position[1] = clickedButton.Text; // Set the main form's position to the semester
                mainForm.MainPannel(7); // Navigate to the menu panel
            }
        }

        private void ResetButtonColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(10, 22, 39); // Reset the button's background color
            }
        }
    }
}
