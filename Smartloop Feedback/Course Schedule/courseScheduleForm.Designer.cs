namespace Smartloop_Feedback.Forms
{
    partial class CourseScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calendarTable = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.addBtn = new System.Windows.Forms.Button();
            this.previousPb = new System.Windows.Forms.PictureBox();
            this.nextPb = new System.Windows.Forms.PictureBox();
            this.monthLb = new System.Windows.Forms.Label();
            this.toggleViewBtn = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previousPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPb)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarTable
            // 
            this.calendarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 730F));
            this.calendarTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarTable.Location = new System.Drawing.Point(0, 50);
            this.calendarTable.Name = "calendarTable";
            this.calendarTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.calendarTable.Size = new System.Drawing.Size(730, 388);
            this.calendarTable.TabIndex = 6;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.addBtn);
            this.headerPanel.Controls.Add(this.previousPb);
            this.headerPanel.Controls.Add(this.nextPb);
            this.headerPanel.Controls.Add(this.monthLb);
            this.headerPanel.Controls.Add(this.toggleViewBtn);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(730, 50);
            this.headerPanel.TabIndex = 7;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.addBtn.Location = new System.Drawing.Point(578, 4);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(140, 43);
            this.addBtn.TabIndex = 9;
            this.addBtn.TabStop = false;
            this.addBtn.Text = "Add Event";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // previousPb
            // 
            this.previousPb.Image = global::Smartloop_Feedback.Properties.Resources.back1;
            this.previousPb.Location = new System.Drawing.Point(27, 3);
            this.previousPb.Name = "previousPb";
            this.previousPb.Size = new System.Drawing.Size(49, 49);
            this.previousPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previousPb.TabIndex = 8;
            this.previousPb.TabStop = false;
            this.previousPb.Click += new System.EventHandler(this.previousPb_Click);
            // 
            // nextPb
            // 
            this.nextPb.Image = global::Smartloop_Feedback.Properties.Resources.right_arrow;
            this.nextPb.Location = new System.Drawing.Point(82, 2);
            this.nextPb.Name = "nextPb";
            this.nextPb.Size = new System.Drawing.Size(49, 49);
            this.nextPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nextPb.TabIndex = 7;
            this.nextPb.TabStop = false;
            this.nextPb.Click += new System.EventHandler(this.nextPb_Click);
            // 
            // monthLb
            // 
            this.monthLb.AutoSize = true;
            this.monthLb.Font = new System.Drawing.Font("Aptos", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.monthLb.Location = new System.Drawing.Point(162, 9);
            this.monthLb.Name = "monthLb";
            this.monthLb.Size = new System.Drawing.Size(104, 27);
            this.monthLb.TabIndex = 0;
            this.monthLb.Text = "June 2024";
            // 
            // toggleViewBtn
            // 
            this.toggleViewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.toggleViewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleViewBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleViewBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.toggleViewBtn.Location = new System.Drawing.Point(427, 4);
            this.toggleViewBtn.Name = "toggleViewBtn";
            this.toggleViewBtn.Size = new System.Drawing.Size(140, 43);
            this.toggleViewBtn.TabIndex = 10;
            this.toggleViewBtn.TabStop = false;
            this.toggleViewBtn.Text = "Toggle View";
            this.toggleViewBtn.UseVisualStyleBackColor = false;
            this.toggleViewBtn.Click += new System.EventHandler(this.ToggleViewButton_Click);
            // 
            // CourseScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(730, 438);
            this.Controls.Add(this.calendarTable);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "courseScheduleForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previousPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel calendarTable;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label monthLb;
        private System.Windows.Forms.PictureBox nextPb;
        private System.Windows.Forms.PictureBox previousPb;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button toggleViewBtn;
    }
}
