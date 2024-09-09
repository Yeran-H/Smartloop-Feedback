using Smartloop_Feedback.Objects; 
using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Data; 
using System.Drawing; 
using System.Linq; 
using System.Net.Http; 
using System.Runtime.InteropServices; 
using System.Text; 
using System.Threading.Tasks;
using System.Windows.Forms; 
using HtmlAgilityPack; 

namespace Smartloop_Feedback
{
    public partial class AddCourseForm : Form
    {
        public Course course; // Public Course object to store course details
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>(); // Dictionary to track if a TextBox has been clicked

        // Import the CreateRoundRectRgn function from Gdi32.dll to create rounded rectangles
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHieghtEllipse
        );

        public AddCourseForm()
        {
            InitializeComponent(); // Initialize form components

            // Initialize textBoxClicked dictionary for each TextBox
            textBoxClicked[codeTb] = false;
            textBoxClicked[nameTb] = false;
            textBoxClicked[creditTb] = false;
            textBoxClicked[descriptionTb] = false;
            textBoxClicked[canvasTb] = false;
            textBoxClicked[yearTb] = false;
            textBoxClicked[tutorialTb] = false;

            // Set the form's region to a rounded rectangle
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.Size = new System.Drawing.Size(237, 437);
        }

        // Event handler to enable the save button if all TextBoxes are filled
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFilled = this.Controls.OfType<TextBox>().All(tb => !string.IsNullOrEmpty(tb.Text));
            saveBtn.Enabled = allFilled;
        }

        // Event handler for when any TextBox receives focus
        private void TextBox_Enter(object sender, EventArgs e)
        {
            defaultUI(); // Reset UI to default state

            TextBox currentTextBox = sender as TextBox;

            // Clear the TextBox on first focus
            if (!textBoxClicked[currentTextBox])
            {
                currentTextBox.Clear();
                textBoxClicked[currentTextBox] = true;
            }

            // Update UI to indicate the TextBox is active
            if (currentTextBox == codeTb)
            {
                codePl.BackColor = Color.FromArgb(254, 0, 57);
                codeTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == nameTb)
            {
                namePl.BackColor = Color.FromArgb(254, 0, 57);
                nameTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == creditTb)
            {
                creditPl.BackColor = Color.FromArgb(254, 0, 57);
                creditTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == descriptionTb)
            {
                descriptionPl.BackColor = Color.FromArgb(254, 0, 57);
                descriptionTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == tutorialTb)
            {
                tutorPl.BackColor = Color.FromArgb(254, 0, 57);
                tutorialTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
            else if (currentTextBox == canvasTb)
            {
                canvasPl.BackColor = Color.FromArgb(254, 0, 57);
                canvasTb.ForeColor = Color.FromArgb(254, 0, 57);
            }
        }

        // Reset UI to default state
        private void defaultUI()
        {
            namePl.BackColor = Color.FromArgb(193, 193, 193);
            nameTb.ForeColor = Color.FromArgb(193, 193, 193);

            codePl.BackColor = Color.FromArgb(193, 193, 193);
            codeTb.ForeColor = Color.FromArgb(193, 193, 193);

            creditPl.BackColor = Color.FromArgb(193, 193, 193);
            creditTb.ForeColor = Color.FromArgb(193, 193, 193);

            descriptionPl.BackColor = Color.FromArgb(193, 193, 193);
            descriptionTb.ForeColor = Color.FromArgb(193, 193, 193);

            canvasPl.BackColor = Color.FromArgb(193, 193, 193);
            canvasTb.ForeColor = Color.FromArgb(193, 193, 193);

            tutorPl.BackColor = Color.FromArgb(193, 193, 193);
            tutorialTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        // Event handler for save button click
        private void saveBtn_Click(object sender, EventArgs e)
        {
            string semester = autumnRb.Checked ? "Autumn" :
                                summerRb.Checked ? "Summer" :
                                springRb.Checked ? "Spring" :
                                winterRb.Checked ? "Winter" : null;

            if (!string.IsNullOrEmpty(nameTb.Text) || !string.IsNullOrEmpty(descriptionTb.Text) || !string.IsNullOrEmpty(canvasTb.Text))
            {
                course = new Course(Int32.Parse(codeTb.Text), nameTb.Text, Int32.Parse(creditTb.Text), descriptionTb.Text, Int32.Parse(yearTb.Text), semester, canvasTb.Text, Int32.Parse(tutorialTb.Text));
                this.DialogResult = DialogResult.OK;
                this.Close(); // Close the form if all fields are valid
            }
            else
            {
                MessageBox.Show("Please fill out all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if any field is empty
            }
        }

        // Event handler for cancel button click
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Close the form without saving
        }

        // Event handler to allow only digits in the code TextBox
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore non-digit input
                }
            }
        }

        // Override ProcessCmdKey to handle Enter key press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                saveBtn.PerformClick(); // Trigger save button click on Enter key press
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Event handler to fetch course data when the code TextBox loses focus
        private async void codeTb_Leave(object sender, EventArgs e)
        {
            string courseCode = codeTb.Text;
            string url = $"https://handbook.uts.edu.au/{yearTb.Text}/subjects/{courseCode}.html"; // URL to fetch course data
            var data = await GetCourseDataAsync(url); // Fetch course data

            if (data != null && data.Count == 3)
            {
                nameTb.Text = data[0];
                creditTb.Text = data[1];
                descriptionTb.Text = data[2]; // Populate form fields with fetched data

                textBoxClicked[codeTb] = true;
                textBoxClicked[nameTb] = true;
                textBoxClicked[creditTb] = true;
                textBoxClicked[descriptionTb] = true;
            }
        }

        // Method to fetch course data asynchronously
        private async Task<List<string>> GetCourseDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url); // Fetch HTML response
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(response); // Load HTML into HtmlAgilityPack

                    // Select nodes for course data
                    var creditPointsNode = doc.DocumentNode.SelectSingleNode("//*[@id='content']/div[1]/em[1]");
                    var descriptionNode = doc.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[1]/p[2]");
                    var courseNameNode = doc.DocumentNode.SelectSingleNode("//h1");

                    // Extract course data
                    var creditPoints = creditPointsNode?.InnerText.Trim().Split(new string[] { "cp" }, StringSplitOptions.None)[0].Trim() ?? "N/A";
                    var courseName = string.Join(" ", courseNameNode?.InnerText.Trim().Split(' ').Skip(1).ToArray() ?? new string[] { "N/A" });
                    var description = descriptionNode?.InnerText.Trim() ?? "N/A";

                    // Return course data as a list
                    var data = new List<string>
                    {
                        courseName,
                        creditPoints,
                        description
                    };

                    return data;
                }
                catch (Exception)
                {
                    return null; // Return null if an error occurs
                }
            }
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Close the form without saving
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            pannelYear.Location = new Point(267, 3);
            pannelCourse.Location = new Point(0, 0);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            pannelCourse.Location = new Point(267, 3);
            pannelYear.Location = new Point(0, 0);
        }
    }
}
