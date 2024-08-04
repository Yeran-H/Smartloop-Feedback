using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class EventListForm : Form
    {
        public Event selectedEvent { get; private set; } // Selected event for edit or delete
        public bool IsEdit { get; private set; } // Flag indicating if the action is edit
        public bool IsDelete { get; private set; } // Flag indicating if the action is delete

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

        // Constructor for EventListForm, initializes the form with a list of events
        public EventListForm(List<Event> eventList)
        {
            InitializeComponent();
            eventLst.DataSource = eventList; // Bind the event list to the ListBox
            eventLst.DisplayMember = "Name"; // Display the event name in the ListBox
            formTitle.Text = eventList[0].Date.ToString("dd MMMM yyyy"); // Set the form title to the date of the first event
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25)); // Apply rounded corners to the form
        }

        // Event handler for the exit picture box click event
        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Set the dialog result to cancel
            this.Close(); // Close the form
        }

        // Event handler for the edit button click event
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (eventLst.SelectedItem != null) // Check if an event is selected
            {
                selectedEvent = (Event)eventLst.SelectedItem; // Set the selected event
                IsEdit = true; // Set the edit flag to true
                IsDelete = false; // Set the delete flag to false
                this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                this.Close(); // Close the form
            }
        }

        // Event handler for the delete button click event
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (eventLst.SelectedItem != null) // Check if an event is selected
            {
                selectedEvent = (Event)eventLst.SelectedItem; // Set the selected event
                IsEdit = false; // Set the edit flag to false
                IsDelete = true; // Set the delete flag to true
                this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                this.Close(); // Close the form
            }
        }
    }
}
