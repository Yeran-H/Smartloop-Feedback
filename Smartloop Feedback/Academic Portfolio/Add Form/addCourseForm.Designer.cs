﻿namespace Smartloop_Feedback
{
    partial class AddCourseForm
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
            this.components = new System.ComponentModel.Container();
            this.codePl = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.codeTb = new System.Windows.Forms.TextBox();
            this.namePl = new System.Windows.Forms.Panel();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.creditPl = new System.Windows.Forms.Panel();
            this.creditTb = new System.Windows.Forms.TextBox();
            this.descriptionPl = new System.Windows.Forms.Panel();
            this.canvasPl = new System.Windows.Forms.Panel();
            this.canvasTb = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.headerPanel = new System.Windows.Forms.Panel();
            this.formTitle = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.descriptionTb = new System.Windows.Forms.TextBox();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.SuspendLayout();
            // 
            // codePl
            // 
            this.codePl.BackColor = System.Drawing.Color.White;
            this.codePl.Location = new System.Drawing.Point(17, 79);
            this.codePl.Name = "codePl";
            this.codePl.Size = new System.Drawing.Size(206, 1);
            this.codePl.TabIndex = 17;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.cancelBtn.Location = new System.Drawing.Point(13, 359);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(211, 55);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Enabled = false;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.saveBtn.Location = new System.Drawing.Point(13, 289);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(211, 55);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save Subject";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // codeTb
            // 
            this.codeTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.codeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.codeTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.codeTb.HideSelection = false;
            this.codeTb.Location = new System.Drawing.Point(17, 57);
            this.codeTb.Name = "codeTb";
            this.codeTb.Size = new System.Drawing.Size(206, 20);
            this.codeTb.TabIndex = 1;
            this.codeTb.Text = "Course Code";
            this.toolTip1.SetToolTip(this.codeTb, "Please enter the Course Code");
            this.codeTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codeTb_KeyPress);
            this.codeTb.Leave += new System.EventHandler(this.codeTb_Leave);
            // 
            // namePl
            // 
            this.namePl.BackColor = System.Drawing.Color.White;
            this.namePl.Location = new System.Drawing.Point(17, 106);
            this.namePl.Name = "namePl";
            this.namePl.Size = new System.Drawing.Size(206, 1);
            this.namePl.TabIndex = 19;
            // 
            // nameTb
            // 
            this.nameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.nameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.nameTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.nameTb.HideSelection = false;
            this.nameTb.Location = new System.Drawing.Point(17, 84);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(206, 20);
            this.nameTb.TabIndex = 2;
            this.nameTb.Text = "Course Name";
            this.toolTip1.SetToolTip(this.nameTb, "Please enter the Course Name");
            // 
            // creditPl
            // 
            this.creditPl.BackColor = System.Drawing.Color.White;
            this.creditPl.Location = new System.Drawing.Point(16, 133);
            this.creditPl.Name = "creditPl";
            this.creditPl.Size = new System.Drawing.Size(206, 1);
            this.creditPl.TabIndex = 21;
            // 
            // creditTb
            // 
            this.creditTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.creditTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creditTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.creditTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.creditTb.HideSelection = false;
            this.creditTb.Location = new System.Drawing.Point(16, 114);
            this.creditTb.Name = "creditTb";
            this.creditTb.Size = new System.Drawing.Size(206, 20);
            this.creditTb.TabIndex = 3;
            this.creditTb.Text = "Credit Point";
            this.toolTip1.SetToolTip(this.creditTb, "Please enter the credit point");
            this.creditTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.creditTb_KeyPress);
            // 
            // descriptionPl
            // 
            this.descriptionPl.BackColor = System.Drawing.Color.White;
            this.descriptionPl.Location = new System.Drawing.Point(18, 231);
            this.descriptionPl.Name = "descriptionPl";
            this.descriptionPl.Size = new System.Drawing.Size(206, 1);
            this.descriptionPl.TabIndex = 23;
            // 
            // canvasPl
            // 
            this.canvasPl.BackColor = System.Drawing.Color.White;
            this.canvasPl.Location = new System.Drawing.Point(17, 257);
            this.canvasPl.Name = "canvasPl";
            this.canvasPl.Size = new System.Drawing.Size(206, 1);
            this.canvasPl.TabIndex = 19;
            // 
            // canvasTb
            // 
            this.canvasTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.canvasTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.canvasTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.canvasTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.canvasTb.HideSelection = false;
            this.canvasTb.Location = new System.Drawing.Point(17, 235);
            this.canvasTb.Name = "canvasTb";
            this.canvasTb.Size = new System.Drawing.Size(206, 20);
            this.canvasTb.TabIndex = 5;
            this.canvasTb.Text = "Please Enter Canvas Link";
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
            this.headerPanel.TabIndex = 24;
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(10, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(97, 21);
            this.formTitle.TabIndex = 7;
            this.formTitle.Text = "Add Course";
            // 
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exitPb.Location = new System.Drawing.Point(206, 10);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 9;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // descriptionTb
            // 
            this.descriptionTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.descriptionTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.descriptionTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.descriptionTb.HideSelection = false;
            this.descriptionTb.Location = new System.Drawing.Point(14, 140);
            this.descriptionTb.Multiline = true;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTb.Size = new System.Drawing.Size(206, 85);
            this.descriptionTb.TabIndex = 4;
            this.descriptionTb.Text = "Description";
            this.toolTip1.SetToolTip(this.descriptionTb, "Please Enter Course Description");
            // 
            // AddCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(237, 441);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.canvasPl);
            this.Controls.Add(this.canvasTb);
            this.Controls.Add(this.descriptionPl);
            this.Controls.Add(this.descriptionTb);
            this.Controls.Add(this.creditPl);
            this.Controls.Add(this.creditTb);
            this.Controls.Add(this.namePl);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.codePl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.codeTb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addSubjectForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel codePl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox codeTb;
        private System.Windows.Forms.Panel namePl;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Panel creditPl;
        private System.Windows.Forms.TextBox creditTb;
        private System.Windows.Forms.Panel descriptionPl;
        private System.Windows.Forms.Panel canvasPl;
        private System.Windows.Forms.TextBox canvasTb;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.PictureBox exitPb;
        private System.Windows.Forms.TextBox descriptionTb;
    }
}