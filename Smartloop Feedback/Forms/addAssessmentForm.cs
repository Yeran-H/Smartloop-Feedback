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
    public partial class addAssessmentForm : Form
    {
        private Course course;
        private mainForm mainForm;
        private Dictionary<TextBox, bool> textBoxClicked = new Dictionary<TextBox, bool>();

        public addAssessmentForm(Course course, mainForm mainForm)
        {
            InitializeComponent();
            this.course = course;
            this.mainForm = mainForm;

            textBoxClicked[titleTb] = false;
            textBoxClicked[descriptionTb] = false;
            textBoxClicked[markTb] = false;
            textBoxClicked[weightTb] = false;
            textBoxClicked[canvasTb] = false;
        }

        private void addAssessmentForm_Load(object sender, EventArgs e)
        {
            panelDetails.Visible = true;
            panelCriteria.Visible = false;

            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            criteriaDgv.ColumnCount = 1;
            criteriaDgv.Columns[0].Name = "Criteria";
            criteriaDgv.Columns[0].Width = 300;

            // Allow the user to add rows
            criteriaDgv.AllowUserToAddRows = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            mainForm.mainPannel(0);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelCriteria.Visible = true;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = true;
            panelCriteria.Visible = false;
        }

        private void columnBtn_Click(object sender, EventArgs e)
        {
            int columnIndex = criteriaDgv.ColumnCount;
            if(columnIndex < 10)
            {
                string columnName = "Rating " + columnIndex;
                criteriaDgv.Columns.Add(columnName, columnName);

                // Add TextBox and Label for column header input
                AddColumnInputControls(columnIndex);
            }
        }

        private void AddColumnInputControls(int columnIndex)
        {
            int textBoxWidth = 100;
            int controlHeight = 30;
            int panelHeight = 1;
            int verticalGap = 5; // Gap between TextBox and Panel
            int gapBetweenControls = 5; // Gap between consecutive TextBox-Panel pairs

            int startY = (controlHeight + panelHeight + verticalGap + gapBetweenControls) * columnIndex;

            // Create the TextBox
            TextBox txt = new TextBox();
            txt.Name = "txtColumn" + columnIndex;
            txt.Text = $"Add Column {columnIndex} Rating";
            txt.Size = new System.Drawing.Size(textBoxWidth, controlHeight);
            txt.Location = new System.Drawing.Point(10, startY);
            txt.BackColor = Color.FromArgb(16, 34, 61);
            txt.ForeColor = Color.FromArgb(193, 193, 193);
            txt.Tag = columnIndex;
            txt.BorderStyle = BorderStyle.None;
            txt.TextChanged += new EventHandler(ColumnTextBox_TextChanged);
            txt.Click += new EventHandler(ColumnTextBox_Click);

            // Create the Panel
            Panel panel = new Panel();
            panel.Size = new System.Drawing.Size(textBoxWidth, panelHeight);
            panel.Location = new System.Drawing.Point(10, startY + controlHeight + verticalGap);
            panel.BackColor = Color.FromArgb(193, 193, 193);

            // Add TextBox and Panel to the panelColumnInputs
            panelColumnInputs.Controls.Add(txt);
            panelColumnInputs.Controls.Add(panel);

            // Adjust panelColumnInputs size to accommodate new controls
            int totalControlHeight = controlHeight + panelHeight + verticalGap + gapBetweenControls;
            int panelHeightTotal = (columnIndex + 1) * totalControlHeight;
            panelColumnInputs.AutoScrollMinSize = new System.Drawing.Size(panelColumnInputs.Width - 50, panelHeightTotal);

            panelColumnInputs.HorizontalScroll.Maximum = 0;
            panelColumnInputs.AutoScroll = true;
        }



        private void ColumnTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                int columnIndex = (int)txt.Tag;
                criteriaDgv.Columns[columnIndex].HeaderText = txt.Text;
            }
        }

        private void ColumnTextBox_Click(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                txt.Clear();
            }
        }


        private void submitBtn_Click(object sender, EventArgs e)
        {
            mainForm.mainPannel(0);
        }

        private void titleTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[titleTb])
            {
                titleTb.Clear();
                textBoxClicked[titleTb] = true;
            }
            titlePl.BackColor = Color.FromArgb(254, 0, 57);
            titleTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void markTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[markTb])
            {
                markTb.Clear();
                textBoxClicked[markTb] = true;
            }
            markPl.BackColor = Color.FromArgb(254, 0, 57);
            markTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void weightTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[weightTb])
            {
                weightTb.Clear();
                textBoxClicked[weightTb] = true;
            }
            weightPl.BackColor = Color.FromArgb(254, 0, 57);
            weightTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void canvasTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[canvasTb])
            {
                canvasTb.Clear();
                textBoxClicked[canvasTb] = true;
            }
            canvasPl.BackColor = Color.FromArgb(254, 0, 57);
            canvasTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void descriptionTb_Click(object sender, EventArgs e)
        {
            defaultUI();
            if (!textBoxClicked[descriptionTb])
            {
                descriptionTb.Clear();
                textBoxClicked[descriptionTb] = true;
            }
            descriptionPl.BackColor = Color.FromArgb(254, 0, 57);
            descriptionTb.ForeColor = Color.FromArgb(254, 0, 57);
        }

        private void defaultUI()
        {
            titlePl.BackColor = Color.FromArgb(193, 193, 193);
            titleTb.ForeColor = Color.FromArgb(193, 193, 193);

            weightPl.BackColor = Color.FromArgb(193, 193, 193);
            weightTb.ForeColor = Color.FromArgb(193, 193, 193);

            markPl.BackColor = Color.FromArgb(193, 193, 193);
            markTb.ForeColor = Color.FromArgb(193, 193, 193);

            canvasPl.BackColor = Color.FromArgb(193, 193, 193);
            canvasTb.ForeColor = Color.FromArgb(193, 193, 193);

            descriptionPl.BackColor = Color.FromArgb(193, 193, 193);
            descriptionTb.ForeColor = Color.FromArgb(193, 193, 193);
        }

        private void markTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void weightTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
