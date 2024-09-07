using Smartloop_Feedback.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting.Bar
{
    public partial class SettingAssessmentBar : Form
    {
        public StudentCourse course; // Reference to the course object
        public MainForm mainForm; // Reference to the main form

        // Constructor for SettingAssessmentBar, initializes the form with the course and main form references
        public SettingAssessmentBar(StudentCourse course, MainForm mainForm)
        {
            InitializeComponent();
            navPl.Height = backBtn.Height; // Set the navigation panel height to match the back button height
            navPl.Top = backBtn.Top; // Align the navigation panel with the back button
            navPl.Left = backBtn.Left; // Align the navigation panel with the back button

            this.course = course;
            this.mainForm = mainForm;
        }

        // Event handler for form load
        private void SettingAssessmentBar_Load(object sender, EventArgs e)
        {
            Image buttonImage = Properties.Resources.School; // Image for the assessment buttons

            int buttonCount = 0; // Counter for the number of buttons

            // Create a button for each assessment in the course
            foreach (Assessment assessment in course.AssessmentList.Values)
            {
                Button btn = new Button
                {
                    Text = assessment.Name,
                    Tag = assessment.Id,
                    Dock = DockStyle.Top,
                    Height = 42,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Aptos", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193),
                    FlatAppearance = { BorderSize = 0 },
                    Image = buttonImage,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                btn.Click += new EventHandler(AssessmentBtn_Click); // Event handler for button click
                btn.Leave += new EventHandler(ResetButtonColor); // Event handler to reset button color when focus is lost

                Controls.Add(btn); // Add the button to the form
                buttonCount++;
            }

            backBtn.Dock = DockStyle.Top; // Dock the back button to the top
            Controls.Add(backBtn); // Add the back button to the form

            // Set the form's client size based on the total height of buttons and the back button
            int totalHeight = backBtn.Height + 42 * buttonCount;
            this.ClientSize = new Size(170, totalHeight);
        }

        // Event handler for back button click to navigate back to the previous panel
        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MenuPanel(6); // Navigate to the menu panel
            mainForm.MainPannel(7); // Navigate to the main panel
        }

        // Event handler for assessment button click to navigate to the assessment details panel
        private void AssessmentBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                navPl.Height = clickedButton.Height; // Adjust the navigation panel height
                navPl.Top = clickedButton.Top; // Move the navigation panel to the clicked button's position
                navPl.Left = clickedButton.Left; // Align the navigation panel with the clicked button
                clickedButton.BackColor = Color.FromArgb(16, 34, 61); // Change the clicked button's background color

                int assessmentId = Int32.Parse(clickedButton.Tag.ToString()); // Get the assessment ID from the button's tag
                mainForm.position[3] = assessmentId; // Set the main form's position to the assessment ID
                mainForm.MainPannel(9); // Navigate to the assessment details panel
            }
        }

        // Event handler to reset the button color when focus is lost
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
