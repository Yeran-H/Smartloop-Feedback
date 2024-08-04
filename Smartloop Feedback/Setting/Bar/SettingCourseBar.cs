using Smartloop_Feedback.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting.Bar
{
    public partial class SettingCourseBar : Form
    {
        public Semester semester; // Reference to the semester object
        public MainForm mainForm; // Reference to the main form
        private Button[] buttons = new Button[5]; // Array to hold course buttons
        private Button[] allButtons; // Array to hold all buttons for the form

        // Constructor for SettingCourseBar, initializes the form with the semester and main form references
        public SettingCourseBar(Semester semester, MainForm mainForm)
        {
            InitializeComponent();
            this.semester = semester;
            this.mainForm = mainForm;
        }

        // Event handler for form load
        private void SettingCourseBar_Load(object sender, EventArgs e)
        {
            // Initialize the array with predefined buttons
            allButtons = new Button[] { oneBtn, secondBtn, thirdBtn, fourthBtn, fifthBtn };

            int buttonCount = 0; // Counter for the number of buttons

            // Create a button for each course in the semester
            foreach (Course course in semester.CourseList.Values)
            {
                Button btn = allButtons[buttonCount]; // Get the button from the predefined array
                btn.Visible = true; // Make the button visible
                btn.Text = course.Code.ToString(); // Set the button text to the course code
                buttons[buttonCount] = btn; // Add the button to the buttons array
                btn.Tag = course.Id; // Set the button tag to the course ID

                btn.Click += new EventHandler(CourseBtn_Click); // Add event handler for button click

                buttonCount++;
            }

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
            mainForm.MenuPanel(5); // Navigate to the menu panel
        }

        // Event handler for course button click to navigate to the course details panel
        private void CourseBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                mainForm.position[2] = clickedButton.Tag; // Set the main form's position to the course ID
                mainForm.MenuPanel(7); // Navigate to the menu panel
                mainForm.MainPannel(8); // Navigate to the course details panel
            }
        }
    }
}
