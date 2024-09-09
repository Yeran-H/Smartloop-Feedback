using Smartloop_Feedback.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting.Bar
{
    public partial class SettingYearBar : Form
    {
        public StudentMainForm mainForm; // Reference to the main form
        public OLDStudent student; // Reference to the student object

        private Button[] buttons = new Button[5]; // Array to hold the year buttons
        private Button[] allButtons; // Array to hold all predefined buttons

        // Constructor for SettingYearBar, initializes the form with the student and main form references
        public SettingYearBar(OLDStudent student, StudentMainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.student = student;
        }

        // Event handler for form load
        private void SettingYearBar_Load(object sender, EventArgs e)
        {
            // Initialize the array with predefined buttons
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn };

            int buttonCount = 0; // Counter for the number of buttons

            // Create a button for each year in the student's year list
            //foreach (StudentYear year in student.YearList.Values)
            //{
            //    Button btn = allButtons[buttonCount]; // Get the button from the predefined array
            //    btn.Visible = true; // Make the button visible
            //    btn.Text = year.Name.ToString(); // Set the button text to the year name
            //    buttons[buttonCount] = btn; // Add the button to the buttons array
            //    buttons[buttonCount].Click += YearButton_Click; // Add event handler for button click

            //    buttonCount++;
            //}

            Controls.Clear(); // Clear existing controls

            // Add buttons to the form in reverse order
            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Controls.Add(buttons[i]);
                buttons[i].Dock = DockStyle.Top; // Dock the button to the top
            }
            Controls.Add(backBtn); // Add the back button to the form
            backBtn.Dock = DockStyle.Top; // Dock the back button to the top
        }

        // Event handler for back button click to navigate back to the previous panel
        private void backBtn_Click(object sender, EventArgs e)
        {
            student.LoadEventsFromDatabase(); // Load events from the database
            mainForm.MenuPanel(1); // Navigate to the menu panel
        }

        // Event handler for year button click to navigate to the year details panel
        private void YearButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                mainForm.position[0] = Int32.Parse(clickedButton.Text); // Set the main form's position to the year
                mainForm.MenuPanel(5); // Navigate to the menu panel
                mainForm.MainPannel(7); // Navigate to the year details panel
            }
        }
    }
}
