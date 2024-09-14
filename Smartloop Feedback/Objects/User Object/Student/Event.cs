using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace Smartloop_Feedback.Objects
{
    public class Event
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; // Database connection string

        // Public properties for event details
        public int Id { get; private set; } // Event ID
        public string Name { get; set; } // Event name
        public DateTime Date { get; set; } // Event date
        public TimeSpan StartTime { get; set; } // Event start time
        public TimeSpan EndTime { get; set; } // Event end time
        public int StudentId { get; set; } // ID of the student associated with the event
        public int CourseId { get; set; } // ID of the course associated with the event
        public string Category { get; set; } // Event category
        public int Color { get; set; } // Event color

        // Constructor to initialize an Event object with all details
        public Event(int id, string name, DateTime date, TimeSpan startTime, TimeSpan endTime, int studentId, int courseId, string category, int color)
        {
            Id = id;
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            StudentId = studentId;
            CourseId = courseId;
            Category = category;
            Color = color;
        }

        // Constructor to initialize an Event object and add it to the database
        public Event(string name, DateTime date, TimeSpan startTime, TimeSpan endTime, string category, int color, int studentId, int courseId)
        {
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            StudentId = studentId;
            CourseId = courseId;
            Category = category;
            Color = color;
            AddEventToDatabase(); // Add the event to the database
        }

        // Constructor to initialize an Event object without interacting with the database
        public Event(string name, DateTime date, TimeSpan startTime, TimeSpan endTime, string category, int color)
        {
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Category = category;
            Color = color;
        }

        // Add the event to the database and get the generated ID
        private void AddEventToDatabase()
        {
            if (Category == "None")
            {
                CourseId = 0; // Set CourseId to 0 if category is "None"
            }

            using (SqlConnection conn = new SqlConnection(connStr)) // Establish a database connection
            {
                conn.Open(); // Open the connection
                string sql = "INSERT INTO event (name, date, startTime, endTime, category, color, courseId, studentId) VALUES (@name, @date, @startTime, @endTime, @category, @color, @courseId, @studentId); SELECT SCOPE_IDENTITY();"; // SQL query to insert event and get the generated ID

                using (SqlCommand cmd = new SqlCommand(sql, conn)) // Create a command
                {
                    cmd.Parameters.AddWithValue("@name", Name); // Set the name parameter
                    cmd.Parameters.AddWithValue("@date", Date); // Set the date parameter
                    cmd.Parameters.AddWithValue("@startTime", StartTime); // Set the start time parameter
                    cmd.Parameters.AddWithValue("@endTime", EndTime); // Set the end time parameter
                    cmd.Parameters.AddWithValue("@category", Category); // Set the category parameter
                    cmd.Parameters.AddWithValue("@color", Color); // Set the color parameter
                    cmd.Parameters.AddWithValue("@courseId", CourseId); // Set the courseId parameter
                    cmd.Parameters.AddWithValue("@studentId", StudentId); // Set the studentId parameter
                    Id = Convert.ToInt32(cmd.ExecuteScalar()); // Execute the query and get the generated ID
                }
            }
        }

        // Update the event details in the database
        public void UpdateEventInDatabase(Event selectedEvent)
        {
            Name = selectedEvent.Name;
            Date = selectedEvent.Date;
            StartTime = selectedEvent.StartTime;
            EndTime = selectedEvent.EndTime;
            Category = selectedEvent.Category;
            CourseId = selectedEvent.CourseId;
            Color = selectedEvent.Color;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE event
                    SET 
                        name = @name,
                        date = @date,
                        startTime = @startTime,
                        endTime = @endTime,
                        courseId = @courseId,
                        category = @category,
                        color = @color
                    WHERE
                        id = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@date", Date);
                    cmd.Parameters.AddWithValue("@startTime", StartTime);
                    cmd.Parameters.AddWithValue("@endTime", EndTime);
                    cmd.Parameters.AddWithValue("@courseId", CourseId);
                    cmd.Parameters.AddWithValue("@category", Category);
                    cmd.Parameters.AddWithValue("@color", Color);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete the event from the database
        public void DeleteEventFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string deleteQuery = @"
                    DELETE FROM event
                    WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Execute the delete command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
