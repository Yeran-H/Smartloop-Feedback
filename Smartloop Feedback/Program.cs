using Smartloop_Feedback.Academic_Portfolio.AI;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    internal static class Program
    {
        private static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;";
        private static string databaseName = "smartloop_feedbackdb";
        private static string sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Smartloop Feedback\SQL\smartloop FeedbackDB.sql");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!DatabaseExists())
            {
                ExecuteSqlFile();
            }

            Application.Run(new LoginForm());
        }

        private static bool DatabaseExists()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT database_id FROM sys.databases WHERE Name = '{databaseName}'", connection);
                var result = command.ExecuteScalar();
                return result != null;
            }
        }

        private static void ExecuteSqlFile()
        {
            try
            {
                string script = File.ReadAllText(sqlFilePath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(script, connection);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Database created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
