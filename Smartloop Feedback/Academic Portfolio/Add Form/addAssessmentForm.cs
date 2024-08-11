using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class AddAssessmentForm : Form
    {
        private Course course; // Reference to the course object
        private MainForm mainForm; // Reference to the main form
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>(); // Track if TextBox has been clicked

        public AddAssessmentForm(Course course, MainForm mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;

            // Initialize the dictionary to track if TextBox has been clicked
            textBoxClicked[titleTb] = false;
            textBoxClicked[descriptionTb] = false;
            textBoxClicked[markTb] = false;
            textBoxClicked[weightTb] = false;
            textBoxClicked[canvasTb] = false;
        }

        // Event handler for form load
        private void addAssessmentForm_Load(object sender, EventArgs e)
        {
            // Set initial visibility of panels
            panelDetails.Visible = true;
            panelCriteria.Visible = false;

            // Configure the DataGridView for criteria
            ConfigureDataGridView();
            DataGridColor(criteriaDgv);
        }

        // Configure the DataGridView for criteria input
        private void ConfigureDataGridView()
        {
            // Set up the initial DataGridView column
            criteriaDgv.ColumnCount = 1;
            criteriaDgv.Columns[0].Name = "Criteria";
            criteriaDgv.Columns[0].Width = 300;

            // Allow the user to add rows
            criteriaDgv.AllowUserToAddRows = true;
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

        // Event handler for cancel button click
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Go back to the main panel
            mainForm.MainPannel(0);
        }

        // Event handler for next button click
        private void nextBtn_Click(object sender, EventArgs e)
        {
            // Switch to the criteria panel
            panelDetails.Visible = false;
            panelCriteria.Visible = true;
        }

        // Event handler for back button click
        private void backBtn_Click(object sender, EventArgs e)
        {
            // Switch back to the details panel
            panelDetails.Visible = true;
            panelCriteria.Visible = false;
        }

        // Event handler for adding a new column
        private void columnBtn_Click(object sender, EventArgs e)
        {
            int columnIndex = criteriaDgv.ColumnCount;
            if (columnIndex < 10) // Limit the number of columns to 10
            {
                string columnName = "Rating " + columnIndex;
                criteriaDgv.Columns.Add(columnName, columnName);

                // Add TextBox and Label for column header input
                AddColumnInputControls(columnIndex);
            }
        }

        // Add TextBox and Label for column header input
        private void AddColumnInputControls(int columnIndex)
        {
            // Define the size and position of the TextBox
            int textBoxWidth = 100;
            int controlHeight = 30;
            int gapBetweenControls = 5;
            int startY = (controlHeight + gapBetweenControls) * columnIndex;

            TextBox txt = new TextBox
            {
                Name = "txtColumn" + columnIndex,
                Text = $"Click to change Column {columnIndex} Rating",
                Size = new System.Drawing.Size(textBoxWidth, controlHeight),
                Location = new System.Drawing.Point(10, startY),
                BackColor = Color.FromArgb(16, 34, 61),
                ForeColor = Color.FromArgb(193, 193, 193)
            };
            toolTip1.SetToolTip(txt, "Please enter Rating for the column e.g HD, D, C, P");
            txt.Tag = columnIndex;
            txt.TextChanged += new EventHandler(ColumnTextBox_TextChanged);
            txt.Click += new EventHandler(ColumnTextBox_Click);

            panelColumnInputs.Controls.Add(txt);

            // Adjust the panel's scroll size
            int totalControlHeight = controlHeight + gapBetweenControls;
            int panelHeightTotal = (columnIndex + 1) * totalControlHeight;
            panelColumnInputs.AutoScrollMinSize = new System.Drawing.Size(panelColumnInputs.Width - 50, panelHeightTotal);

            panelColumnInputs.HorizontalScroll.Maximum = 0;
            panelColumnInputs.AutoScroll = true;
        }

        // Update the DataGridView column header text
        private void ColumnTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                int columnIndex = (int)txt.Tag;
                criteriaDgv.Columns[columnIndex].HeaderText = txt.Text;
            }
        }

        // Clear the TextBox text on click
        private void ColumnTextBox_Click(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                txt.Clear();
            }
        }

        // Event handler for submit button click
        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Validate before adding assessment
            if (titleTb.Text == null || titleTb.Text == "Title" || descriptionTb.Text == null || descriptionTb.Text == "Description" || weightTb.Text == null || weightTb.Text == "Weight" || markTb.Text == null || markTb.Text == "Total Mark"|| canvasTb.Text == null || canvasTb.Text == "Canvas Link" || typeCb.Text == "Type of Assessment")
            {
                MessageBox.Show("Make sure all fields are filled out.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else if (course.WeightTotal(double.Parse(weightTb.Text)))
            {
                MessageBox.Show("Total weight for the course exceeds 100. Please enter a lower number for weight.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Add a new assessment to the course
            Assessment assessment = new Assessment(titleTb.Text, descriptionTb.Text, course.Description, typeCb.Text, dateP.Value.Date, 0, double.Parse(weightTb.Text), double.Parse(markTb.Text), 0, individualRbtn.Checked, groupRbtn.Checked, false, canvasTb.Text, course.Id, course.StudentId);
            course.AssessmentList.Add(assessment.Id, assessment);

            // Prepare column names for ratings
            List<string> columnNameList = new List<string>();
            foreach (DataGridViewColumn column in criteriaDgv.Columns)
            {
                columnNameList.Add(column.HeaderText);
            }
            columnNameList.RemoveAt(0); // Remove the criteria column

            // Add criteria and ratings to the assessment
            foreach (DataGridViewRow row in criteriaDgv.Rows)
            {
                if (row.IsNewRow) continue;

                var criteria = new Criteria(row.Cells[0].Value.ToString(), assessment.Id, assessment.StudentId);
                course.AssessmentList[assessment.Id].CriteriaList.Add(criteria);

                for (int i = 0; i < columnNameList.Count(); i++)
                {
                    course.AssessmentList[assessment.Id].CriteriaList.Last().RatingList.Add(new Rating(row.Cells[i + 1].Value.ToString(), columnNameList[i], criteria.Id, assessment.StudentId));
                }
            }

            // Go back to the main panel
            mainForm.MainPannel(0);
        }

        // Event handler for TextBox enter event
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!textBoxClicked[textBox])
            {
                textBox.Clear();
                textBoxClicked[textBox] = true;
            }
            textBox.ForeColor = Color.FromArgb(254, 0, 57);
        }

        // Event handler to allow only numbers to be entered in the TextBox
        private void numberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Event handler for load button click
        private void loadBtn_Click(object sender, EventArgs e)
        {
            // Open file dialog to select CSV file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(openFileDialog.FileName);
            }
        }

        // Load data from a CSV file into the DataGridView
        private void LoadData(string filePath)
        {
            // Clear existing data and controls
            criteriaDgv.Rows.Clear();
            criteriaDgv.Columns.Clear();
            panelColumnInputs.Controls.Clear();

            // Read data from CSV file
            var lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                // Add columns from CSV headers
                var headers = lines[0].Split(',');
                for (int i = 0; i < headers.Length; i++)
                {
                    criteriaDgv.Columns.Add(headers[i], headers[i]);
                    if (i > 0) // Skip the first column as it's the criteria column
                    {
                        AddColumnInputControls(i);
                        // Set the header text in the TextBox
                        TextBox textBox = panelColumnInputs.Controls.Find("txtColumn" + i, true).FirstOrDefault() as TextBox;
                        if (textBox != null)
                        {
                            textBox.Text = headers[i];
                        }
                    }
                }

                // Add rows from CSV data
                for (int i = 1; i < lines.Length; i++)
                {
                    var cells = lines[i].Split(',');
                    criteriaDgv.Rows.Add(cells);
                }
            }
        }
    }
}
