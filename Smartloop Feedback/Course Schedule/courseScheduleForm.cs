using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class CourseScheduleForm : Form
    {
        private DateTime currentMonth;
        private DateTime currentWeek;
        public Student student;
        private bool isWeeklyView = false;

        public CourseScheduleForm(Student student)
        {
            InitializeComponent();
            InitializeCalendar();
            currentMonth = DateTime.Now;
            currentWeek = DateTime.Now;
            this.student = student;
            DisplayCurrentMonth();
        }

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

        private void DisplayCurrentMonth()
        {
            monthLb.Text = currentMonth.ToString("MMMM yyyy");
            calendarTable.Controls.Clear();
            InitializeCalendar();
            DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;

            for (int i = 0; i < startDay; i++)
            {
                calendarTable.Controls.Add(new Label() { Text = "", BorderStyle = BorderStyle.FixedSingle }, i, 1);
            }

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
                    FlatStyle = date.Date == DateTime.Today ? FlatStyle.Flat : FlatStyle.Flat
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

        private void DisplayCurrentWeek()
        {
            calendarTable.Controls.Clear();
            calendarTable.ColumnCount = 8;
            calendarTable.RowCount = 25;
            calendarTable.ColumnStyles.Clear();
            calendarTable.RowStyles.Clear();

            calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            for (int i = 1; i <= 7; i++)
            {
                calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.57F));
            }

            for (int i = 0; i < 25; i++)
            {
                calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            }

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

            for (int day = 0; day < 7; day++)
            {
                DateTime date = startOfWeek.AddDays(day);
                var dayEvents = student.eventList.Values.Where(e => e.date.Date == date.Date).ToList();
                foreach (var dayEvent in dayEvents)
                {
                    for (int hour = dayEvent.startTime.Hours; hour <= dayEvent.endTime.Hours; hour++)
                    {
                        Button eventButton = new Button()
                        {
                            Text = dayEvent.name,
                            Dock = DockStyle.Fill,
                            BackColor = Color.FromArgb(dayEvent.color),
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


        private Color GetEventColor(DateTime date)
        {
            var eventForDate = student.eventList.Values.FirstOrDefault(e => e.date.Date == date.Date);
            return eventForDate != null ? Color.FromArgb(eventForDate.color) : SystemColors.Control;
        }

        private bool HasEvents(DateTime date)
        {
            return student.eventList.Values.Any(e => e.date.Date == date.Date);
        }

        private void DayButton_Click(object sender, EventArgs e, DateTime date)
        {
            var dayEvents = student.eventList.Values.Where(ev => ev.date.Date == date.Date).ToList();
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (AddEventForm addEventForm = new AddEventForm(student.GetCourseList(), null))
            {
                if (addEventForm.ShowDialog() == DialogResult.OK)
                {
                    Event events = new Event(addEventForm.newEvent.name, addEventForm.newEvent.date, addEventForm.newEvent.startTime, addEventForm.newEvent.endTime, addEventForm.newEvent.category, addEventForm.newEvent.color, student.studentId, student.FindCourseId(addEventForm.newEvent.category));
                    student.eventList.Add(events.id, events);
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

        private void ToggleViewButton_Click(object sender, EventArgs e)
        {
            isWeeklyView = !isWeeklyView;
            if (isWeeklyView)
            {
                DisplayCurrentWeek();
                toggleViewBtn.Text = "Toggle to Weekly View";
            }
            else
            {
                DisplayCurrentMonth();
                toggleViewBtn.Text = "Toggle to Monthly View";
            }
        }
    }
}
