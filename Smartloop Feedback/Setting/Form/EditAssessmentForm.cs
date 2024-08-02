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

namespace Smartloop_Feedback.Setting
{
    public partial class EditAssessmentForm : Form
    {
        public Course course;
        public MainForm mainForm;
        public int assessmentId;
        public EditAssessmentForm(Course course, MainForm mainForm, int assessmentId)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;
            this.assessmentId = assessmentId;

            this.Size = new System.Drawing.Size(750, 477);
        }

        private void EditAssessmentForm_Load(object sender, EventArgs e)
        {
            titleTb.Text = course.AssessmentList[assessmentId].Name;
            descriptionTb.Text = course.AssessmentList[assessmentId].Description;
            dateP.Value = course.AssessmentList[assessmentId].Date;
            typeCb.Text = course.AssessmentList[assessmentId].Type;
            markTb.Text = course.AssessmentList[assessmentId].Mark.ToString();
            weightTb.Text = course.AssessmentList[assessmentId].Weight.ToString();
            individualRbtn.Checked = course.AssessmentList[assessmentId].Individual;
            groupRbtn.Checked = course.AssessmentList[assessmentId].Group;
            canvasTb.Text = course.AssessmentList[assessmentId].CanvasLink;

            PopulateCriteria();
        }

        private void PopulateCriteria()
        {
            // Set up the initial DataGridView column
            criteriaDgv.ColumnCount = 1;
            criteriaDgv.Columns[0].Name = "Criteria";
            criteriaDgv.Columns[0].Width = 300;

            // Allow the user to add rows
            criteriaDgv.AllowUserToAddRows = true;
            int columnIndex = 1;

            foreach (Rating rating in course.AssessmentList[assessmentId].CriteriaList[0].RatingList)
            {
                criteriaDgv.Columns.Add(rating.Grade, rating.Grade);
                AddColumnInputControls(columnIndex, rating.Grade);
                columnIndex++;
            }

            for (int i = 0; i < course.AssessmentList[assessmentId].CriteriaList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(criteriaDgv);
                row.Cells[0].Value = course.AssessmentList[assessmentId].CriteriaList[i].Description;

                for (int j = 0; j < course.AssessmentList[assessmentId].CriteriaList[i].RatingList.Count; j++)
                {
                    row.Cells[j + 1].Value = course.AssessmentList[assessmentId].CriteriaList[i].RatingList[j].Description;
                }

                criteriaDgv.Rows.Add(row);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Location = new Point(875, 4);
            panelCriteria.Location = new Point(0, 0);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Location = new Point(0, 0);
            panelCriteria.Location = new Point(875, 4);

        }

        private void columnBtn_Click(object sender, EventArgs e)
        {
            int columnIndex = criteriaDgv.ColumnCount;
            if (columnIndex < 10) // Limit the number of columns to 10
            {
                string columnName = "Rating " + columnIndex;
                criteriaDgv.Columns.Add(columnName, columnName);

                // Add TextBox and Label for column header input
                AddColumnInputControls(columnIndex, null);
            }
        }

        private void AddColumnInputControls(int columnIndex, string name)
        {
            // Define the size and position of the TextBox and Button
            int textBoxWidth = 100;
            int buttonWidth = 100;
            int controlHeight = 30;
            int gapBetweenControls = 5;
            int startY = (controlHeight + gapBetweenControls) * columnIndex;

            // Create and configure the TextBox
            TextBox txt = new TextBox();
            txt.Name = "txtColumn" + columnIndex;
            txt.Text = name ?? $"Click to change Column {columnIndex} Rating";
            txt.Size = new System.Drawing.Size(textBoxWidth, controlHeight);
            txt.Location = new System.Drawing.Point(10, startY);
            txt.BackColor = Color.FromArgb(16, 34, 61);
            txt.ForeColor = Color.FromArgb(193, 193, 193);
            toolTip1.SetToolTip(txt, "Please enter Rating for the column e.g HD, D, C, P");
            txt.Tag = columnIndex;
            txt.TextChanged += new EventHandler(ColumnTextBox_TextChanged);
            txt.Click += new EventHandler(ColumnTextBox_Click);

            // Create and configure the Button
            Button btn = new Button();
            btn.Name = "btnDeleteColumn" + columnIndex;
            btn.Text = "Delete Column";
            btn.Size = new System.Drawing.Size(buttonWidth, controlHeight);
            btn.Location = new System.Drawing.Point(10 + textBoxWidth + gapBetweenControls, startY);
            btn.BackColor = Color.FromArgb(16, 34, 61);
            btn.ForeColor = Color.FromArgb(254, 0, 57);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Aptos Black", 11.25F, FontStyle.Bold);
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete the Assessment record? This will result in removing all associated objects as well.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                course.DeleteAssessmentFromDatabase(assessmentId);
                mainForm.MainPannel(8);
                mainForm.MenuPannel(7);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            course.AssessmentList[assessmentId].UpdateAssessmentToDatabase(titleTb.Text, descriptionTb.Text, dateP.Value, typeCb.Text, Double.Parse(markTb.Text), Double.Parse(weightTb.Text), individualRbtn.Checked, groupRbtn.Checked, canvasTb.Text);

            List<string> columnNameList = new List<string>();
            foreach (DataGridViewColumn column in criteriaDgv.Columns)
            {
                columnNameList.Add(column.HeaderText);
            }
            columnNameList.RemoveAt(0);

            foreach (DataGridViewRow row in criteriaDgv.Rows)
            {
                if (row.IsNewRow) continue;

                var criteria = new Criteria(row.Cells[0].Value.ToString(), assessmentId, course.AssessmentList[assessmentId].StudentId);
                course.AssessmentList[assessmentId].CriteriaList.Add(criteria);

                for (int i = 0; i < columnNameList.Count(); i++)
                {
                    course.AssessmentList[assessmentId].CriteriaList.Last().RatingList.Add(new Rating(row.Cells[i + 1].Value.ToString(), columnNameList[i], criteria.Id, course.AssessmentList[assessmentId].StudentId));
                }
            }

            mainForm.MenuPannel(7);
        }
    }
}
