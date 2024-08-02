namespace Smartloop_Feedback.Forms
{
    partial class AddEventForm
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
            this.categoryCb = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.passwordPl = new System.Windows.Forms.Panel();
            this.eventTb = new System.Windows.Forms.TextBox();
            this.passwordPb = new System.Windows.Forms.PictureBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.colourBtn = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.formTitle = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.dateDp = new Smartloop_Feedback.Objects.DatePicker();
            this.startTimeDp = new System.Windows.Forms.DateTimePicker();
            this.endTimeDp = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryCb
            // 
            this.categoryCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.categoryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCb.Font = new System.Drawing.Font("Aptos", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.categoryCb.Location = new System.Drawing.Point(12, 141);
            this.categoryCb.Name = "categoryCb";
            this.categoryCb.Size = new System.Drawing.Size(260, 23);
            this.categoryCb.TabIndex = 8;
            // 
            // passwordPl
            // 
            this.passwordPl.BackColor = System.Drawing.Color.White;
            this.passwordPl.Location = new System.Drawing.Point(14, 94);
            this.passwordPl.Name = "passwordPl";
            this.passwordPl.Size = new System.Drawing.Size(250, 1);
            this.passwordPl.TabIndex = 15;
            // 
            // eventTb
            // 
            this.eventTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.eventTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.eventTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.eventTb.HideSelection = false;
            this.eventTb.Location = new System.Drawing.Point(45, 71);
            this.eventTb.Name = "eventTb";
            this.eventTb.Size = new System.Drawing.Size(219, 20);
            this.eventTb.TabIndex = 14;
            this.eventTb.Text = "Event Name";
            this.eventTb.Click += new System.EventHandler(this.eventTb_Click);
            // 
            // passwordPb
            // 
            this.passwordPb.Image = global::Smartloop_Feedback.Properties.Resources.Event;
            this.passwordPb.Location = new System.Drawing.Point(12, 61);
            this.passwordPb.Name = "passwordPb";
            this.passwordPb.Size = new System.Drawing.Size(27, 27);
            this.passwordPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPb.TabIndex = 16;
            this.passwordPb.TabStop = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.cancelBtn.Location = new System.Drawing.Point(144, 283);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(103, 32);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.saveBtn.Location = new System.Drawing.Point(35, 283);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(103, 32);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // colourBtn
            // 
            this.colourBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.colourBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colourBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colourBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.colourBtn.Location = new System.Drawing.Point(14, 245);
            this.colourBtn.Name = "colourBtn";
            this.colourBtn.Size = new System.Drawing.Size(262, 32);
            this.colourBtn.TabIndex = 19;
            this.colourBtn.TabStop = false;
            this.colourBtn.Text = "Pick Colour";
            this.colourBtn.UseVisualStyleBackColor = false;
            this.colourBtn.Click += new System.EventHandler(this.colourBtn_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.headerPanel.Controls.Add(this.formTitle);
            this.headerPanel.Controls.Add(this.exitPb);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(288, 40);
            this.headerPanel.TabIndex = 22;
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(10, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(88, 21);
            this.formTitle.TabIndex = 7;
            this.formTitle.Text = "Add Event";
            // 
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exitPb.Location = new System.Drawing.Point(251, 10);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 9;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // dateDp
            // 
            this.dateDp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.dateDp.BorderSize = 0;
            this.dateDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateDp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDp.Location = new System.Drawing.Point(74, 101);
            this.dateDp.MinimumSize = new System.Drawing.Size(4, 35);
            this.dateDp.Name = "dateDp";
            this.dateDp.Size = new System.Drawing.Size(130, 35);
            this.dateDp.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.dateDp.TabIndex = 10;
            this.dateDp.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            // 
            // startTimeDp
            // 
            this.startTimeDp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimeDp.ShowUpDown = true;
            this.startTimeDp.Location = new System.Drawing.Point(12, 170);
            this.startTimeDp.Name = "startTimeDp";
            this.startTimeDp.Size = new System.Drawing.Size(260, 23);
            this.startTimeDp.TabIndex = 23;
            // 
            // endTimeDp
            // 
            this.endTimeDp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimeDp.ShowUpDown = true;
            this.endTimeDp.Location = new System.Drawing.Point(12, 210);
            this.endTimeDp.Name = "endTimeDp";
            this.endTimeDp.Size = new System.Drawing.Size(260, 23);
            this.endTimeDp.TabIndex = 24;
            // 
            // addEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(288, 355);
            this.Controls.Add(this.endTimeDp);
            this.Controls.Add(this.startTimeDp);
            this.Controls.Add(this.dateDp);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.colourBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.passwordPb);
            this.Controls.Add(this.passwordPl);
            this.Controls.Add(this.eventTb);
            this.Controls.Add(this.categoryCb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addEventForm";
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox categoryCb;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.PictureBox passwordPb;
        private System.Windows.Forms.Panel passwordPl;
        private System.Windows.Forms.TextBox eventTb;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button colourBtn;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.PictureBox exitPb;
        private Smartloop_Feedback.Objects.DatePicker dateDp;
        private System.Windows.Forms.DateTimePicker startTimeDp;
        private System.Windows.Forms.DateTimePicker endTimeDp;
    }
}
