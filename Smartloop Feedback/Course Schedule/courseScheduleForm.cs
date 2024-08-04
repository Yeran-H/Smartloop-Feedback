using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class CourseScheduleForm : Form
    {
        private DateTime currentMonth; // Stores the current month being displayed
        private DateTime currentWeek; // Stores the current week being displayed
        public Student student; // Reference to the student object
        private bool isWeeklyView = false; // Flag to indicate whether the weekly view is active

        public CourseScheduleForm(Student student)
        {
            InitializeComponent();
            InitializeCalendar();
            currentMonth = DateTime.Now;
            currentWeek = DateTime.Now;
            this.student = student;
            DisplayCurrentMonth();
        }

        // Initialize the calendar structure
        private void InitializeCalendar()
        {
            calendarTable.ColumnCount = 7;
            calendarTable.RowCount = 7;
            calendarTable.ColumnStyles.Clear();
            for (int i = 0; i < 7; i++)
            {
                calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            }
            calendarTable.RowStyles.Clear();
            for (int i = 0; i < 7; i++)
            {
                calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28F));
            }

            // Add day labels to the calendar header
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < 7; i++)
            {
                Label lblDay = new Label()
                {
                    Text = days[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Aptos", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193)
                };
                calendarTable.Controls.Add(lblDay, i, 0);
            }
        }

        // Display the current month view
        private void DisplayCurrentMonth()
        {
            monthLb.Text = currentMonth.ToString("MMMM yyyy");
            calendarTable.Controls.Clear();
            InitializeCalendar();
            DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;

            // Add empty cells for the days before the first day of the month
            for (int i = 0; i < startDay; i++)
            {
                calendarTable.Controls.Add(new Label() { Text = "", BorderStyle = BorderStyle.FixedSingle }, i, 1);
            }

            // Add day buttons for each day of the month
            for (int day = 1; day <= daysInMonth; day++)
            {
                int row = (day + startDay - 1) / 7 + 1;
                int col = (day + startDay - 1) % 7;
                DateTime date = new DateTime(currentMonth.Year, currentMonth.Month, day);
                Button dayButton = new Button()
                {
                    Text = day.ToString(),
                    Dock = DockStyle.Fill,
                    BackColor = HasEvents(date) ? GetEventColor(date) : Color.FromArgb(16, 34, 61),
                    Font = new Font("Aptos", 12, FontStyle.Bold),
                    ForeColor = date.Date == DateTime.Today ? Color.FromArgb(254, 0, 57) : Color.FromArgb(254, 0, 57),
                    FlatStyle = FlatStyle.Flat
                };
                if (date.Date == DateTime.Today)
                {
                    dayButton.FlatAppearance.BorderColor = Color.Blue;
                    dayButton.FlatAppearance.BorderSize = 2;
                }
                dayButton.Click += (sender, e) => DayButton_Click(sender, e, date);
                calendarTable.Controls.Add(dayButton, col, row);
            }
        }

        // Display the current week view
        private void DisplayCurrentWeek()
        {
            calendarTable.Controls.Clear();
            calendarTable.ColumnCount = 8;
            calendarTable.RowCount = 25;
            calendarTable.ColumnStyles.Clear();
            calendarTable.RowStyles.Clear();

            // Set up column styles for the weekly view
            calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            for (int i = 1; i <= 7; i++)
            {
                calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.57F));
            }

            // Set up row styles for the hourly view
            for (int i = 0; i < 25; i++)
            {
                calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            }

            // Add day labels to the weekly view header
            string[] days = { "", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            for (int i = 0; i < 8; i++)
            {
                Label lblDay = new Label()
                {
                    Text = days[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Aptos", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193)
                };
                calendarTable.Controls.Add(lblDay, i, 0);
            }

            // Add hour labels to the first column
            for (int i = 0; i < 24; i++)
            {
                Label lblHour = new Label()
                {
                    Text = $"{i}:00",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Aptos", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(193, 193, 193)
                };
                calendarTable.Controls.Add(lblHour, 0, i + 1);
            }

            DateTime startOfWeek = currentWeek.AddDays(-(int)currentWeek.DayOfWeek + 1);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            monthLb.Text = $"{startOfWeek:dd/MM/yyyy} - {endOfWeek:dd/MM/yyyy}";

            // Add event buttons for each day of the week
            for (int day = 0; day < 7; day++)
            {
                DateTime date = startOfWeek.AddDays(day);
                var dayEvents = student.EventList.Values.Where(e => e.Date.Date == date.Date).ToList();
                foreach (var dayEvent in dayEvents)
                {
                    for (int hour = dayEvent.StartTime.Hours; hour <= dayEvent.EndTime.Hours; hour++)
                    {
                        Button eventButton = new Button()
                        {
                            Text = dayEvent.Name,
                            Dock = DockStyle.Fill,
                            BackColor = Color.FromArgb(dayEvent.Color),
                            Font = new Font("Aptos", 12, FontStyle.Bold),
                            ForeColor = Color.FromArgb(16, 34, 61),
                            FlatStyle = FlatStyle.Flat
                        };
                        eventButton.Click += (sender, e) => DayButton_Click(sender, e, date);
                        calendarTable.Controls.Add(eventButton, day + 1, hour + 1);
                    }
                }
            }
        }

        // Get the color for an event on a specific date
        private Color GetEventColor(DateTime date)
        {
            var eventForDate = student.EventList.Values.FirstOrDefault(e => e.Date.Date == date.Date);
            return eventForDate != null ? Color.FromArgb(eventForDate.Color) : SystemColors.Control;
        }

        // Check if there are any events on a specific date
        private bool HasEvents(DateTime date)
        {
            return student.EventList.Values.Any(e => e.Date.Date == date.Date);
        }

        // Event handler for day button click
        private void DayButton_Click(object sender, EventArgs e, DateTime date)
        {
            var dayEvents = student.EventList.Values.Where(ev => ev.Date.Date == date.Date).ToList();
            if (dayEvents.Count > 0)
            {
                using (EventListForm eventListForm = new EventListForm(dayEvents))
                {
                    if (eventListForm.ShowDialog() == DialogResult.OK)
                    {
                        var selectedEvent = eventListForm.selectedEvent;
                        if (eventListForm.IsEdit)
                        {
                            EditEvent(selectedEvent);
                        }
                        else if (eventListForm.IsDelete)
                        {
                            DeleteEvent(selectedEvent);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No events for " + date.ToString("d"));
            }
        }

        // Event handler for previous month/week button click
        private void previousPb_Click(object sender, EventArgs e)
        {
            if (isWeeklyView)
            {
                currentWeek = currentWeek.AddDays(-7);
                DisplayCurrentWeek();
            }
            else
            {
                currentMonth = currentMonth.AddMonths(-1);
                DisplayCurrentMonth();
            }
        }

        // Event handler for next month/week button click
        private void nextPb_Click(object sender, EventArgs e)
        {
            if (isWeeklyView)
            {
                currentWeek = currentWeek.AddDays(7);
                DisplayCurrentWeek();
            }
            else
            {
                currentMonth = currentMonth.AddMonths(1);
                DisplayCurrentMonth();
            }
        }

        // Event handler for add event button click
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (AddEventForm addEventForm = new AddEventForm(student.GetCourseList(), null))
            {
                if (addEventForm.ShowDialog() == DialogResult.OK)
                {
                    Event events = new Event(addEventForm.newEvent.Name, addEventForm.newEvent.Date, addEventForm.newEvent.StartTime, addEventForm.newEvent.EndTime, addEventForm.newEvent.Category, addEventForm.newEvent.Color, student.StudentId, student.FindCourseId(addEventForm.newEvent.Category));
                    student.EventList.Add(events.Id, events);
                    if (isWeeklyView)
                    {
                        DisplayCurrentWeek();
                    }
                    else
                    {
                        DisplayCurrentMonth();
                    }
                }
            }
        }

        // Edit an existing event
        private void EditEvent(Event selectedEvent)
        {
            using (AddEventForm editEventForm = new AddEventForm(student.GetCourseList(), selectedEvent))
            {
                if (editEventForm.ShowDialog() == DialogResult.OK)
                {
                    student.UpdateEvent(editEventForm.newEvent);
                    if (isWeeklyView)
                    {
                        DisplayCurrentWeek();
                    }
                    else
                    {
                        DisplayCurrentMonth();
                    }
                }
            }
        }

        // Delete an existing event
        private void DeleteEvent(Event selectedEvent)
        {
            student.DeleteEvent(selectedEvent);
            if (isWeeklyView)
            {
                DisplayCurrentWeek();
            }
            else
            {
                DisplayCurrentMonth();
            }
        }

        // Toggle between monthly and weekly view
        private void ToggleViewButton_Click(object sender, EventArgs e)
        {
            isWeeklyView = !isWeeklyView;
            if (isWeeklyView)
            {
                DisplayCurrentWeek();
                toggleViewBtn.Text = "Toggle to Monthly View";
            }
            else
            {
                DisplayCurrentMonth();
                toggleViewBtn.Text = "Toggle to Weekly View";
            }
        }
    }
}
