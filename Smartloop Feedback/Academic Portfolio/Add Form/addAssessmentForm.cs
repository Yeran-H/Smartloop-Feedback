using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Forms
{
    public partial class AddAssessmentForm : Form
    {
        private Course course;
        private MainForm mainForm;
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>();

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

        private void addAssessmentForm_Load(object sender, EventArgs e)
        {
            // Set initial visibility of panels
            panelDetails.Visible = true;
            panelCriteria.Visible = false;

            // Configure the DataGridView for criteria
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Set up the initial DataGridView column
            criteriaDgv.ColumnCount = 1;
            criteriaDgv.Columns[0].Name = "Criteria";
            criteriaDgv.Columns[0].Width = 300;

            // Allow the user to add rows
            criteriaDgv.AllowUserToAddRows = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Go back to the main panel
            mainForm.MainPannel(0);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            // Switch to the criteria panel
            panelDetails.Visible = false;
            panelCriteria.Visible = true;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            // Switch back to the details panel
            panelDetails.Visible = true;
            panelCriteria.Visible = false;
        }

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

        private void AddColumnInputControls(int columnIndex)
        {
            // Define the size and position of the TextBox
            int textBoxWidth = 100;
            int controlHeight = 30;
            int gapBetweenControls = 5;
            int startY = (controlHeight + gapBetweenControls) * columnIndex;

            TextBox txt = new TextBox();
            txt.Name = "txtColumn" + columnIndex;
            txt.Text = $"Click to change Column {columnIndex} Rating";
            txt.Size = new System.Drawing.Size(textBoxWidth, controlHeight);
            txt.Location = new System.Drawing.Point(10, startY);
            txt.BackColor = Color.FromArgb(16, 34, 61);
            txt.ForeColor = Color.FromArgb(193, 193, 193);
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

        private void ColumnTextBox_TextChanged(object sender, EventArgs e)
        {
            // Update the DataGridView column header text
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                int columnIndex = (int)txt.Tag;
                criteriaDgv.Columns[columnIndex].HeaderText = txt.Text;
            }
        }

        private void ColumnTextBox_Click(object sender, EventArgs e)
        {
            // Clear the TextBox text on click
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                txt.Clear();
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Add a new assessment to the course
            Assessment assessment = new Assessment(titleTb.Text, descriptionTb.Text, typeCb.Text, dateP.Value.Date, 0, Int32.Parse(weightTb.Text), Int32.Parse(markTb.Text), 0, individualRbtn.Checked, groupRbtn.Checked, false, canvasTb.Text, course.Id, course.StudentId);
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

        private void textBox_Enter(object sender, EventArgs e)
        {
            // Handle the first click on TextBox to clear the text and change color
            TextBox textBox = sender as TextBox;
            if (!textBoxClicked[textBox])
            {
                textBox.Clear();
                textBoxClicked[textBox] = true;
            }
            textBox.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void numberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers to be entered in the TextBox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            // Open file dialog to select CSV file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(openFileDialog.FileName);
            }
        }

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
