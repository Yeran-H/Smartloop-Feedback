﻿namespace Smartloop_Feedback
{
    partial class AssessmentForm
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
            this.datePl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.titlePl = new System.Windows.Forms.Panel();
            this.markTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionRb = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checklistCb = new System.Windows.Forms.CheckedListBox();
            this.itemBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.canvasBtn = new System.Windows.Forms.Button();
            this.rubricBtn = new System.Windows.Forms.Button();
            this.submissionBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.titleCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.improvementCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.finaliseCb = new System.Windows.Forms.CheckBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.bacBtn = new System.Windows.Forms.Button();
            this.criteriaDgv = new System.Windows.Forms.DataGridView();
            this.panelColumnInputs = new System.Windows.Forms.Panel();
            this.submitBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.columnBtn = new System.Windows.Forms.Button();
            this.dateP = new Smartloop_Feedback.Objects.DatePicker();
            this.panelDetails.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // datePl
            // 
            this.datePl.BackColor = System.Drawing.Color.White;
            this.datePl.Location = new System.Drawing.Point(517, 47);
            this.datePl.Name = "datePl";
            this.datePl.Size = new System.Drawing.Size(200, 1);
            this.datePl.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(513, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Due Date:";
            // 
            // titlePl
            // 
            this.titlePl.BackColor = System.Drawing.Color.White;
            this.titlePl.Location = new System.Drawing.Point(283, 44);
            this.titlePl.Name = "titlePl";
            this.titlePl.Size = new System.Drawing.Size(200, 1);
            this.titlePl.TabIndex = 25;
            // 
            // markTb
            // 
            this.markTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.markTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.markTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.markTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.markTb.HideSelection = false;
            this.markTb.Location = new System.Drawing.Point(373, 21);
            this.markTb.Name = "markTb";
            this.markTb.Size = new System.Drawing.Size(110, 20);
            this.markTb.TabIndex = 24;
            this.markTb.TabStop = false;
            this.markTb.Text = "Marks";
            this.markTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.markTb_KeyPress);
            this.markTb.Leave += new System.EventHandler(this.markTb_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(279, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Total Marks";
            // 
            // descriptionRb
            // 
            this.descriptionRb.Location = new System.Drawing.Point(31, 19);
            this.descriptionRb.Name = "descriptionRb";
            this.descriptionRb.Size = new System.Drawing.Size(217, 117);
            this.descriptionRb.TabIndex = 27;
            this.descriptionRb.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(459, 330);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 23);
            this.progressBar.TabIndex = 29;
            // 
            // checklistCb
            // 
            this.checklistCb.FormattingEnabled = true;
            this.checklistCb.Location = new System.Drawing.Point(459, 170);
            this.checklistCb.Name = "checklistCb";
            this.checklistCb.Size = new System.Drawing.Size(200, 154);
            this.checklistCb.TabIndex = 30;
            this.checklistCb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checklistCb_ItemCheck);
            // 
            // itemBtn
            // 
            this.itemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.itemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.itemBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.itemBtn.Location = new System.Drawing.Point(489, 359);
            this.itemBtn.Name = "itemBtn";
            this.itemBtn.Size = new System.Drawing.Size(141, 52);
            this.itemBtn.TabIndex = 31;
            this.itemBtn.Text = "Add Item";
            this.itemBtn.UseVisualStyleBackColor = false;
            this.itemBtn.Click += new System.EventHandler(this.itemBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.backBtn.Location = new System.Drawing.Point(11, 371);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(141, 52);
            this.backBtn.TabIndex = 34;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // canvasBtn
            // 
            this.canvasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.canvasBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.canvasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canvasBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.canvasBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.canvasBtn.Location = new System.Drawing.Point(340, 66);
            this.canvasBtn.Name = "canvasBtn";
            this.canvasBtn.Size = new System.Drawing.Size(141, 52);
            this.canvasBtn.TabIndex = 35;
            this.canvasBtn.Text = "Canvas Link";
            this.canvasBtn.UseVisualStyleBackColor = false;
            this.canvasBtn.Click += new System.EventHandler(this.canvasBtn_Click);
            // 
            // rubricBtn
            // 
            this.rubricBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.rubricBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rubricBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rubricBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.rubricBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.rubricBtn.Location = new System.Drawing.Point(487, 66);
            this.rubricBtn.Name = "rubricBtn";
            this.rubricBtn.Size = new System.Drawing.Size(141, 52);
            this.rubricBtn.TabIndex = 36;
            this.rubricBtn.Text = "Rubric";
            this.rubricBtn.UseVisualStyleBackColor = false;
            this.rubricBtn.Click += new System.EventHandler(this.rubricBtn_Click);
            // 
            // submissionBtn
            // 
            this.submissionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.submissionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submissionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submissionBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.submissionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.submissionBtn.Location = new System.Drawing.Point(267, 359);
            this.submissionBtn.Name = "submissionBtn";
            this.submissionBtn.Size = new System.Drawing.Size(141, 52);
            this.submissionBtn.TabIndex = 38;
            this.submissionBtn.Text = "Add New Attempt";
            this.submissionBtn.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleCh,
            this.improvementCh});
            this.listView1.Font = new System.Drawing.Font("Aptos", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.HotTracking = true;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(231, 170);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(213, 183);
            this.listView1.TabIndex = 40;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // titleCh
            // 
            this.titleCh.Text = "Name";
            this.titleCh.Width = 150;
            // 
            // improvementCh
            // 
            this.improvementCh.Text = "Date";
            this.improvementCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.improvementCh.Width = 70;
            // 
            // finaliseCb
            // 
            this.finaliseCb.AutoSize = true;
            this.finaliseCb.Font = new System.Drawing.Font("Aptos", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finaliseCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.finaliseCb.Location = new System.Drawing.Point(349, 124);
            this.finaliseCb.Name = "finaliseCb";
            this.finaliseCb.Size = new System.Drawing.Size(242, 31);
            this.finaliseCb.TabIndex = 41;
            this.finaliseCb.Text = "Assessment Finalised";
            this.finaliseCb.UseVisualStyleBackColor = true;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.finaliseCb);
            this.panelDetails.Controls.Add(this.listView1);
            this.panelDetails.Controls.Add(this.submissionBtn);
            this.panelDetails.Controls.Add(this.rubricBtn);
            this.panelDetails.Controls.Add(this.canvasBtn);
            this.panelDetails.Controls.Add(this.backBtn);
            this.panelDetails.Controls.Add(this.itemBtn);
            this.panelDetails.Controls.Add(this.checklistCb);
            this.panelDetails.Controls.Add(this.progressBar);
            this.panelDetails.Controls.Add(this.descriptionRb);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.titlePl);
            this.panelDetails.Controls.Add(this.markTb);
            this.panelDetails.Controls.Add(this.datePl);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.dateP);
            this.panelDetails.Location = new System.Drawing.Point(1, 3);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(728, 432);
            this.panelDetails.TabIndex = 42;
            // 
            // panelCriteria
            // 
            this.panelCriteria.Controls.Add(this.loadBtn);
            this.panelCriteria.Controls.Add(this.submitBtn);
            this.panelCriteria.Controls.Add(this.columnBtn);
            this.panelCriteria.Controls.Add(this.bacBtn);
            this.panelCriteria.Controls.Add(this.criteriaDgv);
            this.panelCriteria.Controls.Add(this.panelColumnInputs);
            this.panelCriteria.Location = new System.Drawing.Point(3, 3);
            this.panelCriteria.Margin = new System.Windows.Forms.Padding(2);
            this.panelCriteria.Name = "panelCriteria";
            this.panelCriteria.Size = new System.Drawing.Size(736, 432);
            this.panelCriteria.TabIndex = 43;
            // 
            // bacBtn
            // 
            this.bacBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.bacBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bacBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bacBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.bacBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bacBtn.Location = new System.Drawing.Point(19, 367);
            this.bacBtn.Name = "bacBtn";
            this.bacBtn.Size = new System.Drawing.Size(141, 52);
            this.bacBtn.TabIndex = 24;
            this.bacBtn.Text = "Back";
            this.bacBtn.UseVisualStyleBackColor = false;
            this.bacBtn.Click += new System.EventHandler(this.bacBtn_Click);
            // 
            // criteriaDgv
            // 
            this.criteriaDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criteriaDgv.Location = new System.Drawing.Point(17, 16);
            this.criteriaDgv.Margin = new System.Windows.Forms.Padding(2);
            this.criteriaDgv.Name = "criteriaDgv";
            this.criteriaDgv.RowHeadersWidth = 51;
            this.criteriaDgv.RowTemplate.Height = 24;
            this.criteriaDgv.Size = new System.Drawing.Size(550, 337);
            this.criteriaDgv.TabIndex = 0;
            // 
            // panelColumnInputs
            // 
            this.panelColumnInputs.Location = new System.Drawing.Point(571, 16);
            this.panelColumnInputs.Margin = new System.Windows.Forms.Padding(2);
            this.panelColumnInputs.Name = "panelColumnInputs";
            this.panelColumnInputs.Size = new System.Drawing.Size(150, 337);
            this.panelColumnInputs.TabIndex = 4;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.submitBtn.Location = new System.Drawing.Point(486, 367);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(141, 52);
            this.submitBtn.TabIndex = 26;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            // 
            // loadBtn
            // 
            this.loadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.loadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.loadBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.loadBtn.Location = new System.Drawing.Point(313, 367);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(141, 52);
            this.loadBtn.TabIndex = 27;
            this.loadBtn.Text = "Load Data";
            this.loadBtn.UseVisualStyleBackColor = false;
            // 
            // columnBtn
            // 
            this.columnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.columnBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.columnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.columnBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.columnBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.columnBtn.Location = new System.Drawing.Point(166, 367);
            this.columnBtn.Name = "columnBtn";
            this.columnBtn.Size = new System.Drawing.Size(141, 52);
            this.columnBtn.TabIndex = 25;
            this.columnBtn.Text = "Add Column";
            this.columnBtn.UseVisualStyleBackColor = false;
            // 
            // dateP
            // 
            this.dateP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.dateP.BorderSize = 0;
            this.dateP.Enabled = false;
            this.dateP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP.Location = new System.Drawing.Point(587, 9);
            this.dateP.MinimumSize = new System.Drawing.Size(4, 35);
            this.dateP.Name = "dateP";
            this.dateP.Size = new System.Drawing.Size(130, 35);
            this.dateP.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dateP.TabIndex = 21;
            this.dateP.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            // 
            // AssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(730, 438);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssessmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssessmentForm";
            this.Load += new System.EventHandler(this.AssessmentForm_Load);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel datePl;
        private System.Windows.Forms.Label label1;
        private Objects.DatePicker dateP;
        private System.Windows.Forms.Panel titlePl;
        private System.Windows.Forms.TextBox markTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox descriptionRb;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckedListBox checklistCb;
        private System.Windows.Forms.Button itemBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button canvasBtn;
        private System.Windows.Forms.Button rubricBtn;
        private System.Windows.Forms.Button submissionBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader titleCh;
        private System.Windows.Forms.ColumnHeader improvementCh;
        private System.Windows.Forms.CheckBox finaliseCb;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelCriteria;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button columnBtn;
        private System.Windows.Forms.Button bacBtn;
        private System.Windows.Forms.DataGridView criteriaDgv;
        private System.Windows.Forms.Panel panelColumnInputs;
    }
}