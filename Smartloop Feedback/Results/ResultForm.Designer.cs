namespace Smartloop_Feedback.Results
{
    partial class ResultForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.resultDgv = new System.Windows.Forms.DataGridView();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.titlePl = new System.Windows.Forms.Panel();
            this.wamTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpaTb = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDgv
            // 
            this.resultDgv.AllowUserToAddRows = false;
            this.resultDgv.AllowUserToDeleteRows = false;
            this.resultDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.resultDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.year,
            this.semester,
            this.course,
            this.Grade,
            this.Score,
            this.CreditPoints});
            this.resultDgv.GridColor = System.Drawing.Color.White;
            this.resultDgv.Location = new System.Drawing.Point(40, 70);
            this.resultDgv.Name = "resultDgv";
            this.resultDgv.ReadOnly = true;
            this.resultDgv.RowHeadersVisible = false;
            this.resultDgv.Size = new System.Drawing.Size(644, 318);
            this.resultDgv.TabIndex = 0;
            this.resultDgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.resultDgv_ColumnHeaderMouseClick);
            // 
            // year
            // 
            this.year.HeaderText = "Year";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // semester
            // 
            this.semester.HeaderText = "Semester";
            this.semester.Name = "semester";
            this.semester.ReadOnly = true;
            this.semester.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // course
            // 
            this.course.HeaderText = "Course";
            this.course.Name = "course";
            this.course.ReadOnly = true;
            this.course.Width = 150;
            this.course.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            this.Score.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CreditPoints
            // 
            this.CreditPoints.HeaderText = "Credit Points";
            this.CreditPoints.Name = "CreditPoints";
            this.CreditPoints.ReadOnly = true;
            this.CreditPoints.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(347, 400);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "WAM: ";
            // 
            // titlePl
            // 
            this.titlePl.BackColor = System.Drawing.Color.White;
            this.titlePl.Location = new System.Drawing.Point(351, 423);
            this.titlePl.Name = "titlePl";
            this.titlePl.Size = new System.Drawing.Size(125, 1);
            this.titlePl.TabIndex = 28;
            // 
            // wamTb
            // 
            this.wamTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.wamTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wamTb.Enabled = false;
            this.wamTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.wamTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.wamTb.HideSelection = false;
            this.wamTb.Location = new System.Drawing.Point(405, 400);
            this.wamTb.Name = "wamTb";
            this.wamTb.Size = new System.Drawing.Size(71, 20);
            this.wamTb.TabIndex = 27;
            this.wamTb.TabStop = false;
            this.wamTb.Text = "Marks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(520, 400);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "GPA: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(524, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 1);
            this.panel1.TabIndex = 31;
            // 
            // gpaTb
            // 
            this.gpaTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.gpaTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gpaTb.Enabled = false;
            this.gpaTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.gpaTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.gpaTb.HideSelection = false;
            this.gpaTb.Location = new System.Drawing.Point(570, 400);
            this.gpaTb.Name = "gpaTb";
            this.gpaTb.Size = new System.Drawing.Size(79, 20);
            this.gpaTb.TabIndex = 30;
            this.gpaTb.TabStop = false;
            this.gpaTb.Text = "Marks";
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("Aptos", 12F);
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.searchTextBox.Location = new System.Drawing.Point(560, 30);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(150, 20);
            this.searchTextBox.TabIndex = 33;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Aptos", 12F);
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.searchLabel.Location = new System.Drawing.Point(500, 30);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(62, 20);
            this.searchLabel.TabIndex = 34;
            this.searchLabel.Text = "Search:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(560, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 1);
            this.panel2.TabIndex = 29;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(700, 70);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "GPA";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "WAM";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(300, 318);
            this.chart.TabIndex = 35;
            this.chart.Text = "chart";
            // 
            // filterComboBox
            // 
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "All",
            "Year",
            "Semester"});
            this.filterComboBox.Location = new System.Drawing.Point(700, 30);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(121, 21);
            this.filterComboBox.TabIndex = 36;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Aptos", 12F);
            this.filterLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.filterLabel.Location = new System.Drawing.Point(650, 30);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(44, 20);
            this.filterLabel.TabIndex = 37;
            this.filterLabel.Text = "Filter:";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1024, 438);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpaTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titlePl);
            this.Controls.Add(this.wamTb);
            this.Controls.Add(this.resultDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView resultDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel titlePl;
        private System.Windows.Forms.TextBox wamTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox gpaTb;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Label filterLabel;
    }
}
