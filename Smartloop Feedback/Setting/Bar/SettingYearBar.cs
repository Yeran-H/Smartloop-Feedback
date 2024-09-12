using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting.Bar
{
    public partial class SettingYearBar : Form
    {
        public MainForm mainForm; // Reference to the main form
        public User user; // Reference to the student object

        // Constructor for SettingYearBar, initializes the form with the student and main form references
        public SettingYearBar(User user, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.user = user;
        }

        // Event handler for form load
        private void SettingYearBar_Load(object sender, EventArgs e)
        {
            Image buttonImage = Properties.Resources.calendar;
            int buttonCount = 0;

            // Create a button for each year in the student's year list
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

            backBtn.Dock = DockStyle.Top;
            Controls.Add(backBtn);

            int totalHeight = backBtn.Height + 42 * buttonCount;
            this.ClientSize = new Size(170, totalHeight);
        }

        // Event handler for back button click to navigate back to the previous panel
        private void backBtn_Click(object sender, EventArgs e)
        {
            user.LoadEventsFromDatabase(); // Load events from the database
            mainForm.MenuPanel(0); // Navigate to the menu panel
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
