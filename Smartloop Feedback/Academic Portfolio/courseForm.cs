using Microsoft.Extensions.Logging;
using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class CourseForm : Form
    {
        private Course course; // The course object associated with this form
        private MainForm mainForm; // Reference to the main form

        public CourseForm(Course course, MainForm mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
        }

        // Event handler for form load
        private void CourseForm_Load(object sender, EventArgs e)
        {
            course.LoadEventsFromDatabase(); // Load events from the database
            PopulateAssessmentView(); // Populate the assessment DataGridView
            PopulateEventView(); // Populate the event DataGridView

            // Display calculated marks in the text boxes
            currentTb.Text = course.CalculateCurrentMark().ToString("F2") + "%";
            cTb.Text = course.CalculateTargetMark(0.65).ToString("F2") + "%";
            dTb.Text = course.CalculateTargetMark(0.75).ToString("F2") + "%";
            hdTb.Text = course.CalculateTargetMark(0.85).ToString("F2") + "%";
        }

        // Event handler for Canvas button click
        private void canvasBtn_Click(object sender, EventArgs e)
        {
            OpenUrl(course.CanvasLink); // Open the Canvas link
        }

        // Event handler for Handbook button click
        private void handbookBtn_Click(object sender, EventArgs e)
        {
            OpenUrl($"https://handbook.uts.edu.au/subjects/details/{course.Code}.html"); // Open the course handbook link
        }

        // Method to open a URL in the default web browser
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the URL: " + ex.Message); // Show error message if URL cannot be opened
            }
        }

        // Event handler for Add button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(1); // Navigate to the main panel
        }

        // Populate the assessment DataGridView
        private void PopulateAssessmentView()
        {
            if (course.AssessmentList != null)
            {
                assessmentDgv.Rows.Clear(); // Clear existing rows
                assessmentDgv.Columns.Clear(); // Clear existing columns

                // Add columns to the DataGridView
                DataGridViewButtonColumn nameColumn = new DataGridViewButtonColumn
                {
                    Name = "Name",
                    HeaderText = "Name",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                assessmentDgv.Columns.Add(nameColumn);

                assessmentDgv.Columns.Add("Type", "Type");
                assessmentDgv.Columns.Add("Date", "Date");

                DataGridViewColumn statusColumn = new DataGridViewColumn(new Objects.DataGridView())
                {
                    Name = "Status",
                    HeaderText = "Status"
                };
                assessmentDgv.Columns.Add(statusColumn);

                assessmentDgv.Columns.Add("Final Mark", "Final Mark");
                assessmentDgv.Columns.Add("Weight", "Weight");

                // Add rows to the DataGridView
                foreach (Assessment assessment in course.AssessmentList.Values)
                {
                    double percentage = (assessment.FinalMark / assessment.Mark) * 100;
                    int rowIndex = assessmentDgv.Rows.Add(assessment.Name, assessment.Type, assessment.Date, (int)assessment.Status, percentage.ToString("F2") + "%", assessment.Weight);
                    DataGridViewRow row = assessmentDgv.Rows[rowIndex];
                    row.Tag = assessment.Id; // Tag the row with the assessment ID
                }

                DataGridColor(assessmentDgv); // Apply color formatting to the DataGridView
            }
        }

        // Populate the event DataGridView
        private void PopulateEventView()
        {
            if (course.EventList != null)
            {
                eventDgv.Rows.Clear(); // Clear existing rows
                eventDgv.Columns.Clear(); // Clear existing columns

                // Add columns to the DataGridView
                DataGridViewButtonColumn nameColumn = new DataGridViewButtonColumn
                {
                    Name = "Name",
                    HeaderText = "Name",
                    UseColumnTextForButtonValue = false,
                    CellTemplate = new StyledButtonCell()
                };
                eventDgv.Columns.Add(nameColumn);

                eventDgv.Columns.Add("Date", "Date");
                eventDgv.Columns.Add("Time", "Time");

                DateTime today = DateTime.Today;

                // Add rows to the DataGridView
                foreach (Event events in course.EventList.Values)
                {
                    if (events.Date >= today)
                    {
                        int rowIndex = eventDgv.Rows.Add(events.Name, events.Date, events.StartTime);
                        DataGridViewRow row = eventDgv.Rows[rowIndex];
                        row.Tag = events; // Tag the row with the event object
                    }
                }

                DataGridColor(eventDgv); // Apply color formatting to the DataGridView
            }
        }

        // Apply custom color formatting to a DataGridView
        private void DataGridColor(System.Windows.Forms.DataGridView grid)
        {
            // Set DataGridView properties
            grid.BackgroundColor = Color.FromArgb(16, 34, 61);
            grid.GridColor = Color.FromArgb(254, 0, 57);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.DefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set column header style
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set row header style
            grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set cell border style
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set button cell style specifically
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.CellTemplate is StyledButtonCell)
                {
                    col.DefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
                    col.DefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
                    col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
                    col.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);
                }
            }
        }

        // Event handler for assessment DataGridView cell click
        private void assessmentDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.assessmentDgv.Rows[e.RowIndex];
                mainForm.position[3] = (int)row.Tag; // Set position for navigation
                mainForm.MainPannel(2); // Navigate to the main panel
            }
        }

        // Event handler for Event button click
        private void eventBtn_Click(object sender, EventArgs e)
        {
            List<string> courseName = new List<string> { course.Title };

            // Open AddEventForm to add a new event
            using (AddEventForm addEventForm = new AddEventForm(courseName, null))
            {
                if (addEventForm.ShowDialog() == DialogResult.OK)
                {
                    // Create and add new event to the course
                    Event newEvent = new Event(addEventForm.newEvent.Name, addEventForm.newEvent.Date, addEventForm.newEvent.StartTime, addEventForm.newEvent.EndTime, course.Title, addEventForm.newEvent.Color, course.StudentId, course.Id);
                    course.EventList.Add(newEvent.Id, newEvent);
                    PopulateEventView(); // Refresh event DataGridView
                }
            }
        }

        // Event handler for event DataGridView cell click
        private void eventDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.eventDgv.Rows[e.RowIndex];
                List<string> courseName = new List<string> { course.Title };

                // Open AddEventForm to edit the event
                using (AddEventForm editEventForm = new AddEventForm(courseName, (Event)row.Tag))
                {
                    if (editEventForm.ShowDialog() == DialogResult.OK)
                    {
                        course.UpdateEvent(editEventForm.newEvent); // Update the event in the course
                        PopulateEventView(); // Refresh event DataGridView
                    }
                }
            }
        }
    }
}
