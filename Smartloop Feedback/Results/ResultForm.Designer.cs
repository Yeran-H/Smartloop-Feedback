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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.resultDgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.titlePl = new System.Windows.Forms.Panel();
            this.wamTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpaTb = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.wamTabPage = new System.Windows.Forms.TabPage();
            this.wamChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gpaTabPage = new System.Windows.Forms.TabPage();
            this.gpaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.filterCb = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usernamePb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).BeginInit();
            this.tabControl.SuspendLayout();
            this.wamTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wamChart)).BeginInit();
            this.gpaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpaChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePb)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDgv
            // 
            this.resultDgv.AllowUserToAddRows = false;
            this.resultDgv.AllowUserToDeleteRows = false;
            this.resultDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.resultDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDgv.GridColor = System.Drawing.Color.White;
            this.resultDgv.Location = new System.Drawing.Point(10, 50);
            this.resultDgv.Name = "resultDgv";
            this.resultDgv.ReadOnly = true;
            this.resultDgv.RowHeadersVisible = false;
            this.resultDgv.Size = new System.Drawing.Size(450, 389);
            this.resultDgv.TabIndex = 0;
            this.resultDgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.resultDgv_ColumnHeaderMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(12, 445);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "WAM: ";
            // 
            // titlePl
            // 
            this.titlePl.BackColor = System.Drawing.Color.White;
            this.titlePl.Location = new System.Drawing.Point(66, 468);
            this.titlePl.Name = "titlePl";
            this.titlePl.Size = new System.Drawing.Size(100, 1);
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
            this.wamTb.Location = new System.Drawing.Point(69, 445);
            this.wamTb.Name = "wamTb";
            this.wamTb.Size = new System.Drawing.Size(97, 20);
            this.wamTb.TabIndex = 27;
            this.wamTb.TabStop = false;
            this.wamTb.Text = "Marks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(182, 445);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "GPA: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(227, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 1);
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
            this.gpaTb.Location = new System.Drawing.Point(231, 445);
            this.gpaTb.Name = "gpaTb";
            this.gpaTb.Size = new System.Drawing.Size(96, 20);
            this.gpaTb.TabIndex = 30;
            this.gpaTb.TabStop = false;
            this.gpaTb.Text = "Marks";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.wamTabPage);
            this.tabControl.Controls.Add(this.gpaTabPage);
            this.tabControl.Location = new System.Drawing.Point(483, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(255, 294);
            this.tabControl.TabIndex = 35;
            // 
            // wamTabPage
            // 
            this.wamTabPage.Controls.Add(this.wamChart);
            this.wamTabPage.Location = new System.Drawing.Point(4, 22);
            this.wamTabPage.Name = "wamTabPage";
            this.wamTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.wamTabPage.Size = new System.Drawing.Size(247, 268);
            this.wamTabPage.TabIndex = 0;
            this.wamTabPage.Text = "WAM";
            this.wamTabPage.UseVisualStyleBackColor = true;
            // 
            // wamChart
            // 
            chartArea5.Name = "ChartArea1";
            this.wamChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.wamChart.Legends.Add(legend5);
            this.wamChart.Location = new System.Drawing.Point(0, 0);
            this.wamChart.Name = "wamChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "WAM";
            this.wamChart.Series.Add(series5);
            this.wamChart.Size = new System.Drawing.Size(241, 262);
            this.wamChart.TabIndex = 0;
            this.wamChart.Text = "chart";
            // 
            // gpaTabPage
            // 
            this.gpaTabPage.Controls.Add(this.gpaChart);
            this.gpaTabPage.Location = new System.Drawing.Point(4, 22);
            this.gpaTabPage.Name = "gpaTabPage";
            this.gpaTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.gpaTabPage.Size = new System.Drawing.Size(242, 234);
            this.gpaTabPage.TabIndex = 1;
            this.gpaTabPage.Text = "GPA";
            this.gpaTabPage.UseVisualStyleBackColor = true;
            // 
            // gpaChart
            // 
            chartArea6.Name = "ChartArea2";
            this.gpaChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend2";
            this.gpaChart.Legends.Add(legend6);
            this.gpaChart.Location = new System.Drawing.Point(0, 0);
            this.gpaChart.Name = "gpaChart";
            series6.ChartArea = "ChartArea2";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend2";
            series6.Name = "GPA";
            this.gpaChart.Series.Add(series6);
            this.gpaChart.Size = new System.Drawing.Size(242, 234);
            this.gpaChart.TabIndex = 0;
            this.gpaChart.Text = "chart";
            // 
            // filterCb
            // 
            this.filterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCb.FormattingEnabled = true;
            this.filterCb.Items.AddRange(new object[] {
            "Year",
            "Semester"});
            this.filterCb.Location = new System.Drawing.Point(609, 15);
            this.filterCb.Name = "filterCb";
            this.filterCb.Size = new System.Drawing.Size(121, 21);
            this.filterCb.TabIndex = 36;
            this.filterCb.SelectedIndexChanged += new System.EventHandler(this.filterCb_SelectedIndexChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Aptos", 12F);
            this.filterLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.filterLabel.Location = new System.Drawing.Point(555, 15);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(48, 20);
            this.filterLabel.TabIndex = 37;
            this.filterLabel.Text = "Filter:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("Aptos", 12F);
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.searchTextBox.Location = new System.Drawing.Point(303, 15);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(123, 20);
            this.searchTextBox.TabIndex = 33;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(273, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 1);
            this.panel2.TabIndex = 29;
            // 
            // usernamePb
            // 
            this.usernamePb.Image = global::Smartloop_Feedback.Properties.Resources.search;
            this.usernamePb.Location = new System.Drawing.Point(271, 8);
            this.usernamePb.Name = "usernamePb";
            this.usernamePb.Size = new System.Drawing.Size(27, 27);
            this.usernamePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.usernamePb.TabIndex = 38;
            this.usernamePb.TabStop = false;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.usernamePb);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.filterCb);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel2);
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
            this.tabControl.ResumeLayout(false);
            this.wamTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wamChart)).EndInit();
            this.gpaTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpaChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView resultDgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel titlePl;
        private System.Windows.Forms.TextBox wamTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox gpaTb;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage wamTabPage;
        private System.Windows.Forms.TabPage gpaTabPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart wamChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart gpaChart;
        private System.Windows.Forms.ComboBox filterCb;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox usernamePb;
    }
}
