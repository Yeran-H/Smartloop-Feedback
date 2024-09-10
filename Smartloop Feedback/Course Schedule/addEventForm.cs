using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class AddEventForm : Form
    {
        public Event newEvent; // The new or edited event
        public List<string> courseList; // List of courses for the category dropdown

        // Import CreateRoundRectRgn function from Gdi32.dll to create rounded corners for the form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Constructor for AddEventForm, initializes the form with a list of courses and an optional selected event
        public AddEventForm(List<string> courseList, Event selectedEvent)
        {
            InitializeComponent();
            this.courseList = courseList; // Set the course list
            this.newEvent = selectedEvent; // Set the selected event if editing
            FillCategory(); // Populate the category dropdown

            // Apply rounded corners to the form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        // Event handler for form load
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // If an event is being edited, fill the form with its details
            if (newEvent != null)
            {
                eventTb.Text = newEvent.Name;
                dateDp.Value = newEvent.Date;
                categoryCb.SelectedItem = newEvent.Category;
                colourBtn.BackColor = Color.FromArgb(newEvent.Color);
                startTimeDp.Value = DateTime.Today.Add(newEvent.StartTime);
                endTimeDp.Value = DateTime.Today.Add(newEvent.EndTime);
            }
        }

        // Populate the category dropdown with course names
        private void FillCategory()
        {
            categoryCb.Items.Clear(); // Clear any existing items
            categoryCb.Items.Add("None"); // Add a default option

            // Add each course name to the dropdown
            foreach (string name in courseList)
            {
                categoryCb.Items.Add(name);
            }

            categoryCb.SelectedIndex = 0; // Set the default selected item
        }

        // Event handler for event name TextBox click event
        private void eventTb_Click(object sender, EventArgs e)
        {
            eventTb.Clear(); // Clear the TextBox when clicked
        }

        // Event handler for color button click event
        private void colourBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colourBtn.BackColor = colorDialog.Color; // Set the button's background color to the selected color
            }
        }

        // Event handler for save button click event
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // If editing an existing event, update its properties
            if (newEvent != null)
            {
                newEvent.Name = eventTb.Text;
                newEvent.Date = dateDp.Value;
                newEvent.Category = categoryCb.SelectedItem?.ToString();
                newEvent.Color = colourBtn.BackColor.ToArgb();
                newEvent.StartTime = startTimeDp.Value.TimeOfDay;
                newEvent.EndTime = endTimeDp.Value.TimeOfDay;
            }
            else
            {
                // If creating a new event, initialize it with the form data
                newEvent = new Event(eventTb.Text, dateDp.Value, startTimeDp.Value.TimeOfDay, endTimeDp.Value.TimeOfDay, categoryCb.SelectedItem?.ToString(), colourBtn.BackColor.ToArgb());
            }

            this.DialogResult = DialogResult.OK; // Set the dialog result to OK
            this.Close(); // Close the form
        }

        // Event handler for cancel button click event
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Set the dialog result to Cancel
            this.Close(); // Close the form
        }

        // Event handler for exit picture box click event
        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Set the dialog result to Cancel
            this.Close(); // Close the form
        }
    }
}
