namespace Smartloop_Feedback
{
    partial class AddYearForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddYearForm));
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.yearTb = new System.Windows.Forms.TextBox();
            this.yearPl = new System.Windows.Forms.Panel();
            this.semesterCb = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.formTitle = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.saveBtn.Location = new System.Drawing.Point(12, 264);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(211, 55);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save Year";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.cancelBtn.Location = new System.Drawing.Point(12, 334);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(211, 55);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // yearTb
            // 
            this.yearTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.yearTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.yearTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.yearTb.HideSelection = false;
            this.yearTb.Location = new System.Drawing.Point(18, 60);
            this.yearTb.Name = "yearTb";
            this.yearTb.Size = new System.Drawing.Size(206, 20);
            this.yearTb.TabIndex = 1;
            this.yearTb.TabStop = false;
            this.yearTb.Text = "Eg. 2024";
            this.yearTb.Click += new System.EventHandler(this.yearTb_Click);
            // 
            // yearPl
            // 
            this.yearPl.BackColor = System.Drawing.Color.White;
            this.yearPl.Location = new System.Drawing.Point(18, 82);
            this.yearPl.Name = "yearPl";
            this.yearPl.Size = new System.Drawing.Size(206, 1);
            this.yearPl.TabIndex = 10;
            // 
            // semesterCb
            // 
            this.semesterCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.semesterCb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.semesterCb.Font = new System.Drawing.Font("Aptos", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.semesterCb.FormattingEnabled = true;
            this.semesterCb.Items.AddRange(new object[] {
            "Summer",
            "Autumn",
            "Winter",
            "Spring"});
            this.semesterCb.Location = new System.Drawing.Point(50, 139);
            this.semesterCb.Name = "semesterCb";
            this.semesterCb.Size = new System.Drawing.Size(146, 104);
            this.semesterCb.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(30, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 36);
            this.label1.TabIndex = 12;
            this.label1.Text = "Add Semester";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.headerPanel.Controls.Add(this.formTitle);
            this.headerPanel.Controls.Add(this.exitPb);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(237, 40);
            this.headerPanel.TabIndex = 22;
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(10, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(185, 21);
            this.formTitle.TabIndex = 7;
            this.formTitle.Text = "Add Year and Semester";
            // 
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exitPb.Location = new System.Drawing.Point(203, 10);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 9;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // addYearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(237, 407);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.semesterCb);
            this.Controls.Add(this.yearPl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.yearTb);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addYearForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "academicYearForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox yearTb;
        private System.Windows.Forms.Panel yearPl;
        private System.Windows.Forms.CheckedListBox semesterCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.PictureBox exitPb;
    }
}