namespace Smartloop_Feedback
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
            this.components = new System.ComponentModel.Container();
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
            this.attemptBtn = new System.Windows.Forms.Button();
            this.finaliseCb = new System.Windows.Forms.CheckBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.attemptDgv = new System.Windows.Forms.DataGridView();
            this.dateP = new Smartloop_Feedback.Objects.DatePicker();
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.bacBtn = new System.Windows.Forms.Button();
            this.criteriaDgv = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.feedbackRb = new System.Windows.Forms.RichTextBox();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attemptDgv)).BeginInit();
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
            this.toolTip1.SetToolTip(this.markTb, "Make sure to leave format xx/xx");
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
            this.descriptionRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.descriptionRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.descriptionRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.descriptionRb.Location = new System.Drawing.Point(31, 19);
            this.descriptionRb.Name = "descriptionRb";
            this.descriptionRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.descriptionRb.Size = new System.Drawing.Size(217, 117);
            this.descriptionRb.TabIndex = 27;
            this.descriptionRb.Text = "Description";
            this.toolTip1.SetToolTip(this.descriptionRb, "Desciption of Assessment");
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(521, 329);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 23);
            this.progressBar.TabIndex = 29;
            this.toolTip1.SetToolTip(this.progressBar, "Progress of Task");
            // 
            // checklistCb
            // 
            this.checklistCb.FormattingEnabled = true;
            this.checklistCb.Location = new System.Drawing.Point(521, 169);
            this.checklistCb.Name = "checklistCb";
            this.checklistCb.Size = new System.Drawing.Size(200, 154);
            this.checklistCb.TabIndex = 30;
            this.toolTip1.SetToolTip(this.checklistCb, "List of task to complete for assessment");
            this.checklistCb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checklistCb_ItemCheck);
            // 
            // itemBtn
            // 
            this.itemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.itemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.itemBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.itemBtn.Location = new System.Drawing.Point(551, 358);
            this.itemBtn.Name = "itemBtn";
            this.itemBtn.Size = new System.Drawing.Size(141, 52);
            this.itemBtn.TabIndex = 31;
            this.itemBtn.Text = "Add Item";
            this.toolTip1.SetToolTip(this.itemBtn, "Add Checklist Item");
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
            // attemptBtn
            // 
            this.attemptBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.attemptBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attemptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attemptBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.attemptBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.attemptBtn.Location = new System.Drawing.Point(340, 335);
            this.attemptBtn.Name = "attemptBtn";
            this.attemptBtn.Size = new System.Drawing.Size(141, 52);
            this.attemptBtn.TabIndex = 38;
            this.attemptBtn.Text = "Add New Attempt";
            this.attemptBtn.UseVisualStyleBackColor = false;
            this.attemptBtn.Click += new System.EventHandler(this.attemptBtn_Click);
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
            this.toolTip1.SetToolTip(this.finaliseCb, "Check when Assessment is marked and completed");
            this.finaliseCb.UseVisualStyleBackColor = true;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.feedbackRb);
            this.panelDetails.Controls.Add(this.attemptDgv);
            this.panelDetails.Controls.Add(this.finaliseCb);
            this.panelDetails.Controls.Add(this.attemptBtn);
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
            // attemptDgv
            // 
            this.attemptDgv.AllowUserToAddRows = false;
            this.attemptDgv.AllowUserToDeleteRows = false;
            this.attemptDgv.AllowUserToOrderColumns = true;
            this.attemptDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.attemptDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attemptDgv.Location = new System.Drawing.Point(300, 178);
            this.attemptDgv.Name = "attemptDgv";
            this.attemptDgv.ReadOnly = true;
            this.attemptDgv.Size = new System.Drawing.Size(206, 151);
            this.attemptDgv.TabIndex = 42;
            this.attemptDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.attemptDgv_CellClick);
            // 
            // dateP
            // 
            this.dateP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.dateP.BorderSize = 0;
            this.dateP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP.Location = new System.Drawing.Point(587, 9);
            this.dateP.MinimumSize = new System.Drawing.Size(4, 35);
            this.dateP.Name = "dateP";
            this.dateP.Size = new System.Drawing.Size(130, 35);
            this.dateP.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dateP.TabIndex = 21;
            this.dateP.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.toolTip1.SetToolTip(this.dateP, "Due Date of Assessment");
            // 
            // panelCriteria
            // 
            this.panelCriteria.Controls.Add(this.bacBtn);
            this.panelCriteria.Controls.Add(this.criteriaDgv);
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
            this.criteriaDgv.AllowUserToAddRows = false;
            this.criteriaDgv.AllowUserToDeleteRows = false;
            this.criteriaDgv.AllowUserToOrderColumns = true;
            this.criteriaDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.criteriaDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criteriaDgv.Location = new System.Drawing.Point(17, 16);
            this.criteriaDgv.Margin = new System.Windows.Forms.Padding(2);
            this.criteriaDgv.Name = "criteriaDgv";
            this.criteriaDgv.ReadOnly = true;
            this.criteriaDgv.RowHeadersWidth = 51;
            this.criteriaDgv.RowTemplate.Height = 24;
            this.criteriaDgv.Size = new System.Drawing.Size(696, 337);
            this.criteriaDgv.TabIndex = 0;
            this.toolTip1.SetToolTip(this.criteriaDgv, "Rubric of Assessment");
            // 
            // feedbackRb
            // 
            this.feedbackRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.feedbackRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackRb.Enabled = false;
            this.feedbackRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.feedbackRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.feedbackRb.Location = new System.Drawing.Point(31, 142);
            this.feedbackRb.Name = "feedbackRb";
            this.feedbackRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.feedbackRb.Size = new System.Drawing.Size(217, 219);
            this.feedbackRb.TabIndex = 43;
            this.feedbackRb.Text = "Feedback";
            this.toolTip1.SetToolTip(this.feedbackRb, "General Feedback on Assessment");
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
            ((System.ComponentModel.ISupportInitialize)(this.attemptDgv)).EndInit();
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
        private System.Windows.Forms.Button attemptBtn;
        private System.Windows.Forms.CheckBox finaliseCb;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelCriteria;
        private System.Windows.Forms.Button bacBtn;
        private System.Windows.Forms.DataGridView criteriaDgv;
        private System.Windows.Forms.DataGridView attemptDgv;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox feedbackRb;
    }
}