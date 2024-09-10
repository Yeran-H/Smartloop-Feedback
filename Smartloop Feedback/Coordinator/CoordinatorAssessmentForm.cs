using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using Smartloop_Feedback.Coordinator_Folder;
using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smartloop_Feedback.Setting
{
    public partial class CoordinatorAssessmentForm : Form
    {
        public Assessment assessment; // Reference to the course object
        public CoordinatorMainForm mainForm; // Reference to the main form

        // Constructor for EditAssessmentForm, initializes the form with the course, main form, and assessment ID
        public CoordinatorAssessmentForm(Assessment assessment, CoordinatorMainForm mainForm)
        {
            InitializeComponent();
            this.assessment = assessment;
            this.mainForm = mainForm;

            this.Size = new System.Drawing.Size(750, 477); // Set the form size
        }

        // Event handler for form load
        private void EditAssessmentForm_Load(object sender, EventArgs e)
        {
            // Populate the form fields with the assessment's current information
            titleTb.Text = assessment.Name;
            descriptionTb.Text = assessment.Description;
            dateP.Value = assessment.Date;
            typeTb.Text = assessment.Type;
            markTb.Text = assessment.Mark.ToString();
            weightTb.Text = assessment.Weight.ToString();
            canvasTb.Text = assessment.CanvasLink;
            fileTb.Text = assessment.FileName;

            PopulateCriteria(); // Populate the criteria DataGridView
        }

        // Populate the criteria DataGridView with the assessment's criteria and ratings
        private void PopulateCriteria()
        {
            // Set up the initial DataGridView column
            criteriaDgv.ColumnCount = 1;
            criteriaDgv.Columns[0].Name = "Criteria";
            criteriaDgv.Columns[0].Width = 300;

            // Allow the user to add rows
            criteriaDgv.AllowUserToAddRows = true;
            int columnIndex = 1;

            // Add columns for each rating
            foreach (Rating rating in assessment.CriteriaList[0].RatingList)
            {
                criteriaDgv.Columns.Add(rating.Grade, rating.Grade);
                AddColumnInputControls(columnIndex, rating.Grade);
                columnIndex++;
            }

            // Add rows for each criteria and its ratings
            foreach (Criteria criteria in assessment.CriteriaList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(criteriaDgv);
                row.Cells[0].Value = criteria.Description;

                for (int j = 0; j < criteria.RatingList.Count; j++)
                {
                    row.Cells[j + 1].Value = criteria.RatingList[j].Description;
                }

                criteriaDgv.Rows.Add(row);
            }

            DataGridColor(criteriaDgv); // Apply custom color formatting
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

        // Event handler for next button click to navigate to the criteria panel
        private void nextBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Location = new Point(875, 4);
            panelCriteria.Location = new Point(0, 0);
        }

        // Event handler for back button click to navigate back to the details panel
        private void backBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Location = new Point(0, 0);
            panelCriteria.Location = new Point(875, 4);
        }

        // Event handler for adding a new column
        private void columnBtn_Click(object sender, EventArgs e)
        {
            int columnIndex = criteriaDgv.ColumnCount;
            if (columnIndex < 10) // Limit the number of columns to 10
            {
                string columnName = "Rating " + columnIndex;
                criteriaDgv.Columns.Add(columnName, columnName);

                // Add TextBox and Button for column header input
                AddColumnInputControls(columnIndex, null);
            }
        }

        // Add TextBox and Button for column header input
        private void AddColumnInputControls(int columnIndex, string name)
        {
            // Define the size and position of the TextBox and Button
            int textBoxWidth = 100;
            int buttonWidth = 100;
            int controlHeight = 30;
            int gapBetweenControls = 5;
            int startY = (controlHeight + gapBetweenControls) * columnIndex;

            // Create and configure the TextBox
            TextBox txt = new TextBox
            {
                Name = "txtColumn" + columnIndex,
                Text = name ?? $"Click to change Column {columnIndex} Rating",
                Size = new System.Drawing.Size(textBoxWidth, controlHeight),
                Location = new System.Drawing.Point(10, startY),
                BackColor = Color.FromArgb(16, 34, 61),
                ForeColor = Color.FromArgb(193, 193, 193)
            };
            toolTip1.SetToolTip(txt, "Please enter Rating for the column e.g HD, D, C, P");
            txt.Tag = columnIndex;
            txt.TextChanged += new EventHandler(ColumnTextBox_TextChanged);
            txt.Click += new EventHandler(ColumnTextBox_Click);

            // Create and configure the Button
            Button btn = new Button
            {
                Name = "btnDeleteColumn" + columnIndex,
                Text = "Delete Column",
                Size = new System.Drawing.Size(buttonWidth, controlHeight),
                Location = new System.Drawing.Point(10 + textBoxWidth + gapBetweenControls, startY),
                BackColor = Color.FromArgb(16, 34, 61),
                ForeColor = Color.FromArgb(254, 0, 57),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Aptos Black", 11.25F, FontStyle.Bold)
            };
            btn.Click += new EventHandler((sender, e) => DeleteColumnButton_Click(sender, e, columnIndex));

            // Add TextBox and Button to the panel
            panelColumnInputs.Controls.Add(txt);
            panelColumnInputs.Controls.Add(btn);

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

        // Event handler for loading data from a CSV file
        private void loadBtn_Click(object sender, EventArgs e)
        {
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
                        AddColumnInputControls(i, "txtColumn" + i);
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

        // Event handler for deleting a column
        private void DeleteColumnButton_Click(object sender, EventArgs e, int columnIndex)
        {
            Control txt = panelColumnInputs.Controls["txtColumn" + columnIndex];
            Control btn = panelColumnInputs.Controls["btnDeleteColumn" + columnIndex];
            panelColumnInputs.Controls.Remove(txt);
            panelColumnInputs.Controls.Remove(btn);

            if (columnIndex < criteriaDgv.Columns.Count)
            {
                criteriaDgv.Columns.RemoveAt(columnIndex);
            }
        }

        // Event handler for update button click to update the assessment information
        private void updateBtn_Click(object sender, EventArgs e)
        {
            string fileName = assessment.FileName;
            byte[] fileData = assessment.FileData;

            if(uploadTb.Text != "")
            {
                fileName = System.IO.Path.GetFileName(uploadTb.Text);
                fileData = Encoding.UTF8.GetBytes(ExtractTextFromPdf(uploadTb.Text));
            }

            assessment.UpdateAssessmentToDatabase(
                titleTb.Text, descriptionTb.Text, dateP.Value, typeTb.Text,
                double.Parse(markTb.Text), double.Parse(weightTb.Text), fileName, fileData,
                canvasTb.Text
            );

            List<string> columnNameList = new List<string>();
            foreach (DataGridViewColumn column in criteriaDgv.Columns)
            {
                columnNameList.Add(column.HeaderText);
            }
            columnNameList.RemoveAt(0);

            foreach (DataGridViewRow row in criteriaDgv.Rows)
            {
                if (row.IsNewRow) continue;

                var criteria = new Criteria(row.Cells[0].Value.ToString(), assessment.AssessmentId);
                assessment.CriteriaList.Add(criteria);

                for (int i = 0; i < columnNameList.Count(); i++)
                {
                    assessment.CriteriaList.Last().RatingList.Add(
                        new Rating(row.Cells[i + 1].Value.ToString(), columnNameList[i], criteria.Id)
                    );
                }
            }

            mainForm.MainPannel(1);
        }

        private void downloadAssessmentBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = assessment.FileName;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, assessment.FileData);
                MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadAssessmentBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileTb.Text = openFileDialog.FileName;
            }
        }

        private string ExtractTextFromPdf(string filePath)
        {
            StringBuilder text = new StringBuilder();

            using (PdfReader reader = new PdfReader(filePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }

        private void back1Btn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(1);
        }
    }
}
