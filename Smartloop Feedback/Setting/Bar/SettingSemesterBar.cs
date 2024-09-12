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
                mainForm.position[1] = clickedButton.Text; // Set the main form's position to the semester
                mainForm.MenuPanel(6); // Navigate to the menu panel
            }
        }
    }
}
