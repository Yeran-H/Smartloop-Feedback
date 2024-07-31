namespace Smartloop_Feedback.Forms
{
    partial class AddAssessmentForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.descriptionTb = new System.Windows.Forms.TextBox();
            this.canvasPl = new System.Windows.Forms.Panel();
            this.canvasTb = new System.Windows.Forms.TextBox();
            this.weightPl = new System.Windows.Forms.Panel();
            this.weightTb = new System.Windows.Forms.TextBox();
            this.markPl = new System.Windows.Forms.Panel();
            this.markTb = new System.Windows.Forms.TextBox();
            this.groupRbtn = new System.Windows.Forms.RadioButton();
            this.individualRbtn = new System.Windows.Forms.RadioButton();
            this.nextBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.typeCb = new System.Windows.Forms.ComboBox();
            this.datePl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionPl = new System.Windows.Forms.Panel();
            this.titlePl = new System.Windows.Forms.Panel();
            this.titleTb = new System.Windows.Forms.TextBox();
            this.dateP = new Smartloop_Feedback.Objects.DatePicker();
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.loadBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.columnBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.criteriaDgv = new System.Windows.Forms.DataGridView();
            this.panelColumnInputs = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelDetails.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.descriptionTb);
            this.panelDetails.Controls.Add(this.canvasPl);
            this.panelDetails.Controls.Add(this.canvasTb);
            this.panelDetails.Controls.Add(this.weightPl);
            this.panelDetails.Controls.Add(this.weightTb);
            this.panelDetails.Controls.Add(this.markPl);
            this.panelDetails.Controls.Add(this.markTb);
            this.panelDetails.Controls.Add(this.groupRbtn);
            this.panelDetails.Controls.Add(this.individualRbtn);
            this.panelDetails.Controls.Add(this.nextBtn);
            this.panelDetails.Controls.Add(this.cancelBtn);
            this.panelDetails.Controls.Add(this.typeCb);
            this.panelDetails.Controls.Add(this.datePl);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.descriptionPl);
            this.panelDetails.Controls.Add(this.titlePl);
            this.panelDetails.Controls.Add(this.titleTb);
            this.panelDetails.Controls.Add(this.dateP);
            this.panelDetails.Location = new System.Drawing.Point(0, 5);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(734, 434);
            this.panelDetails.TabIndex = 1;
            // 
            // descriptionTb
            // 
            this.descriptionTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.descriptionTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.descriptionTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.descriptionTb.HideSelection = false;
            this.descriptionTb.Location = new System.Drawing.Point(133, 94);
            this.descriptionTb.Multiline = true;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.Size = new System.Drawing.Size(200, 128);
            this.descriptionTb.TabIndex = 29;
            this.descriptionTb.TabStop = false;
            this.descriptionTb.Text = "Description";
            this.toolTip1.SetToolTip(this.descriptionTb, "Please enter description of assessment");
            this.descriptionTb.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // canvasPl
            // 
            this.canvasPl.BackColor = System.Drawing.Color.White;
            this.canvasPl.Location = new System.Drawing.Point(386, 282);
            this.canvasPl.Name = "canvasPl";
            this.canvasPl.Size = new System.Drawing.Size(200, 1);
            this.canvasPl.TabIndex = 20;
            // 
            // canvasTb
            // 
            this.canvasTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.canvasTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.canvasTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.canvasTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.canvasTb.HideSelection = false;
            this.canvasTb.Location = new System.Drawing.Point(386, 263);
            this.canvasTb.Name = "canvasTb";
            this.canvasTb.Size = new System.Drawing.Size(200, 20);
            this.canvasTb.TabIndex = 19;
            this.canvasTb.TabStop = false;
            this.canvasTb.Text = "Canvas Link";
            this.toolTip1.SetToolTip(this.canvasTb, "Please provide canvas link to Assessment");
            this.canvasTb.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // weightPl
            // 
            this.weightPl.BackColor = System.Drawing.Color.White;
            this.weightPl.Location = new System.Drawing.Point(387, 193);
            this.weightPl.Name = "weightPl";
            this.weightPl.Size = new System.Drawing.Size(200, 1);
            this.weightPl.TabIndex = 28;
            // 
            // weightTb
            // 
            this.weightTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.weightTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.weightTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.weightTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.weightTb.HideSelection = false;
            this.weightTb.Location = new System.Drawing.Point(387, 174);
            this.weightTb.Name = "weightTb";
            this.weightTb.Size = new System.Drawing.Size(200, 20);
            this.weightTb.TabIndex = 27;
            this.weightTb.TabStop = false;
            this.weightTb.Text = "Weight";
            this.toolTip1.SetToolTip(this.weightTb, "Please enter weight of assessment");
            this.weightTb.Enter += new System.EventHandler(this.textBox_Enter);
            this.weightTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly_KeyPress);
            // 
            // markPl
            // 
            this.markPl.BackColor = System.Drawing.Color.White;
            this.markPl.Location = new System.Drawing.Point(387, 159);
            this.markPl.Name = "markPl";
            this.markPl.Size = new System.Drawing.Size(200, 1);
            this.markPl.TabIndex = 20;
            // 
            // markTb
            // 
            this.markTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.markTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.markTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.markTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.markTb.HideSelection = false;
            this.markTb.Location = new System.Drawing.Point(387, 140);
            this.markTb.Name = "markTb";
            this.markTb.Size = new System.Drawing.Size(200, 20);
            this.markTb.TabIndex = 19;
            this.markTb.TabStop = false;
            this.markTb.Text = "Total Mark";
            this.toolTip1.SetToolTip(this.markTb, "Please enter Total marks of assessment ");
            this.markTb.Enter += new System.EventHandler(this.textBox_Enter);
            this.markTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly_KeyPress);
            // 
            // groupRbtn
            // 
            this.groupRbtn.AutoSize = true;
            this.groupRbtn.Font = new System.Drawing.Font("Aptos", 12F);
            this.groupRbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.groupRbtn.Location = new System.Drawing.Point(428, 224);
            this.groupRbtn.Name = "groupRbtn";
            this.groupRbtn.Size = new System.Drawing.Size(109, 24);
            this.groupRbtn.TabIndex = 26;
            this.groupRbtn.Text = "Group Work";
            this.toolTip1.SetToolTip(this.groupRbtn, "Select if assessment is group");
            this.groupRbtn.UseVisualStyleBackColor = true;
            // 
            // individualRbtn
            // 
            this.individualRbtn.AutoSize = true;
            this.individualRbtn.Checked = true;
            this.individualRbtn.Font = new System.Drawing.Font("Aptos", 12F);
            this.individualRbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.individualRbtn.Location = new System.Drawing.Point(428, 201);
            this.individualRbtn.Name = "individualRbtn";
            this.individualRbtn.Size = new System.Drawing.Size(95, 24);
            this.individualRbtn.TabIndex = 25;
            this.individualRbtn.TabStop = true;
            this.individualRbtn.Text = "Individual";
            this.toolTip1.SetToolTip(this.individualRbtn, "Select if assessment is individual");
            this.individualRbtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.nextBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.nextBtn.Location = new System.Drawing.Point(367, 316);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(141, 52);
            this.nextBtn.TabIndex = 24;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.cancelBtn.Location = new System.Drawing.Point(220, 316);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(141, 52);
            this.cancelBtn.TabIndex = 23;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // typeCb
            // 
            this.typeCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.typeCb.Font = new System.Drawing.Font("Aptos", 12F);
            this.typeCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.typeCb.FormattingEnabled = true;
            this.typeCb.Items.AddRange(new object[] {
            "Reflection",
            "Report",
            "Coding",
            "Project",
            "Quiz",
            "Test",
            "Presentation",
            "Essay",
            "Peer Review"});
            this.typeCb.Location = new System.Drawing.Point(386, 101);
            this.typeCb.Name = "typeCb";
            this.typeCb.Size = new System.Drawing.Size(201, 28);
            this.typeCb.TabIndex = 21;
            this.typeCb.Text = "Type of Assessment";
            this.toolTip1.SetToolTip(this.typeCb, "Type or Select the type of assessment");
            // 
            // datePl
            // 
            this.datePl.BackColor = System.Drawing.Color.White;
            this.datePl.Location = new System.Drawing.Point(133, 282);
            this.datePl.Name = "datePl";
            this.datePl.Size = new System.Drawing.Size(200, 1);
            this.datePl.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(129, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Due Date:";
            // 
            // descriptionPl
            // 
            this.descriptionPl.BackColor = System.Drawing.Color.White;
            this.descriptionPl.Location = new System.Drawing.Point(133, 224);
            this.descriptionPl.Name = "descriptionPl";
            this.descriptionPl.Size = new System.Drawing.Size(200, 1);
            this.descriptionPl.TabIndex = 19;
            // 
            // titlePl
            // 
            this.titlePl.BackColor = System.Drawing.Color.White;
            this.titlePl.Location = new System.Drawing.Point(134, 87);
            this.titlePl.Name = "titlePl";
            this.titlePl.Size = new System.Drawing.Size(200, 1);
            this.titlePl.TabIndex = 18;
            // 
            // titleTb
            // 
            this.titleTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.titleTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.titleTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.titleTb.HideSelection = false;
            this.titleTb.Location = new System.Drawing.Point(134, 68);
            this.titleTb.Name = "titleTb";
            this.titleTb.Size = new System.Drawing.Size(200, 20);
            this.titleTb.TabIndex = 17;
            this.titleTb.TabStop = false;
            this.titleTb.Text = "Title";
            this.toolTip1.SetToolTip(this.titleTb, "Please enter Title of Assessment");
            this.titleTb.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // dateP
            // 
            this.dateP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.dateP.BorderSize = 0;
            this.dateP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP.Location = new System.Drawing.Point(203, 241);
            this.dateP.MinimumSize = new System.Drawing.Size(4, 35);
            this.dateP.Name = "dateP";
            this.dateP.Size = new System.Drawing.Size(130, 35);
            this.dateP.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dateP.TabIndex = 9;
            this.dateP.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.toolTip1.SetToolTip(this.dateP, "Please enter due date of assessment");
            // 
            // panelCriteria
            // 
            this.panelCriteria.Controls.Add(this.loadBtn);
            this.panelCriteria.Controls.Add(this.submitBtn);
            this.panelCriteria.Controls.Add(this.columnBtn);
            this.panelCriteria.Controls.Add(this.backBtn);
            this.panelCriteria.Controls.Add(this.criteriaDgv);
            this.panelCriteria.Controls.Add(this.panelColumnInputs);
            this.panelCriteria.Location = new System.Drawing.Point(-2, 5);
            this.panelCriteria.Margin = new System.Windows.Forms.Padding(2);
            this.panelCriteria.Name = "panelCriteria";
            this.panelCriteria.Size = new System.Drawing.Size(736, 432);
            this.panelCriteria.TabIndex = 2;
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
            this.toolTip1.SetToolTip(this.loadBtn, "Click to add more columns to criteria");
            this.loadBtn.UseVisualStyleBackColor = false;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
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
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
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
            this.toolTip1.SetToolTip(this.columnBtn, "Click to add more columns to criteria");
            this.columnBtn.UseVisualStyleBackColor = false;
            this.columnBtn.Click += new System.EventHandler(this.columnBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.backBtn.Location = new System.Drawing.Point(19, 367);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(141, 52);
            this.backBtn.TabIndex = 24;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
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
            // AddAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(738, 438);
            this.Controls.Add(this.panelCriteria);
            this.Controls.Add(this.panelDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAssessmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addAssessmentForm";
            this.Load += new System.EventHandler(this.addAssessmentForm_Load);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetails;
        private Smartloop_Feedback.Objects.DatePicker dateP;
        private System.Windows.Forms.Panel titlePl;
        private System.Windows.Forms.TextBox titleTb;
        private System.Windows.Forms.Panel descriptionPl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeCb;
        private System.Windows.Forms.Panel datePl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.RadioButton groupRbtn;
        private System.Windows.Forms.RadioButton individualRbtn;
        private System.Windows.Forms.Panel canvasPl;
        private System.Windows.Forms.TextBox canvasTb;
        private System.Windows.Forms.Panel weightPl;
        private System.Windows.Forms.TextBox weightTb;
        private System.Windows.Forms.Panel markPl;
        private System.Windows.Forms.TextBox markTb;
        private System.Windows.Forms.Panel panelCriteria;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button columnBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.DataGridView criteriaDgv;
        private System.Windows.Forms.Panel panelColumnInputs;
        private System.Windows.Forms.TextBox descriptionTb;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button loadBtn;
    }
}