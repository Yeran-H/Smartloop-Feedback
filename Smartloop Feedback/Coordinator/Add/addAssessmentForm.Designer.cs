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
            this.nextBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
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
            this.typePl = new System.Windows.Forms.Panel();
            this.typeTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fileTb = new System.Windows.Forms.TextBox();
            this.loadAssessmentBtn = new System.Windows.Forms.Button();
            this.panelDetails.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.panel2);
            this.panelDetails.Controls.Add(this.fileTb);
            this.panelDetails.Controls.Add(this.loadAssessmentBtn);
            this.panelDetails.Controls.Add(this.typePl);
            this.panelDetails.Controls.Add(this.typeTb);
            this.panelDetails.Controls.Add(this.descriptionTb);
            this.panelDetails.Controls.Add(this.canvasPl);
            this.panelDetails.Controls.Add(this.canvasTb);
            this.panelDetails.Controls.Add(this.weightPl);
            this.panelDetails.Controls.Add(this.weightTb);
            this.panelDetails.Controls.Add(this.markPl);
            this.panelDetails.Controls.Add(this.markTb);
            this.panelDetails.Controls.Add(this.nextBtn);
            this.panelDetails.Controls.Add(this.cancelBtn);
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
            this.descriptionTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            this.canvasPl.Location = new System.Drawing.Point(386, 192);
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
            this.canvasTb.Location = new System.Drawing.Point(386, 173);
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
            this.weightPl.Location = new System.Drawing.Point(386, 154);
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
            this.weightTb.Location = new System.Drawing.Point(386, 135);
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
            this.markPl.Location = new System.Drawing.Point(386, 120);
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
            this.markTb.Location = new System.Drawing.Point(386, 101);
            this.markTb.Name = "markTb";
            this.markTb.Size = new System.Drawing.Size(200, 20);
            this.markTb.TabIndex = 19;
            this.markTb.TabStop = false;
            this.markTb.Text = "Total Mark";
            this.toolTip1.SetToolTip(this.markTb, "Please enter Total marks of assessment ");
            this.markTb.Enter += new System.EventHandler(this.textBox_Enter);
            this.markTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly_KeyPress);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.nextBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.nextBtn.Location = new System.Drawing.Point(366, 330);
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
            this.cancelBtn.Location = new System.Drawing.Point(219, 330);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(141, 52);
            this.cancelBtn.TabIndex = 23;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
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
            this.criteriaDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
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
            // typePl
            // 
            this.typePl.BackColor = System.Drawing.Color.White;
            this.typePl.Location = new System.Drawing.Point(386, 87);
            this.typePl.Name = "typePl";
            this.typePl.Size = new System.Drawing.Size(200, 1);
            this.typePl.TabIndex = 31;
            // 
            // typeTb
            // 
            this.typeTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.typeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.typeTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.typeTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.typeTb.HideSelection = false;
            this.typeTb.Location = new System.Drawing.Point(386, 61);
            this.typeTb.Name = "typeTb";
            this.typeTb.Size = new System.Drawing.Size(200, 20);
            this.typeTb.TabIndex = 30;
            this.typeTb.TabStop = false;
            this.typeTb.Text = "Type of Assessment";
            this.toolTip1.SetToolTip(this.typeTb, "Please enter Total marks of assessment ");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(382, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "File";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(386, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 47;
            // 
            // fileTb
            // 
            this.fileTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.fileTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.fileTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.fileTb.HideSelection = false;
            this.fileTb.Location = new System.Drawing.Point(420, 214);
            this.fileTb.Name = "fileTb";
            this.fileTb.Size = new System.Drawing.Size(166, 20);
            this.fileTb.TabIndex = 46;
            this.fileTb.TabStop = false;
            // 
            // loadAssessmentBtn
            // 
            this.loadAssessmentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.loadAssessmentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadAssessmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadAssessmentBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.loadAssessmentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.loadAssessmentBtn.Location = new System.Drawing.Point(423, 249);
            this.loadAssessmentBtn.Name = "loadAssessmentBtn";
            this.loadAssessmentBtn.Size = new System.Drawing.Size(141, 52);
            this.loadAssessmentBtn.TabIndex = 45;
            this.loadAssessmentBtn.Text = "Load Assessment";
            this.loadAssessmentBtn.UseVisualStyleBackColor = false;
            this.loadAssessmentBtn.Click += new System.EventHandler(this.loadAssessmentBtn_Click);
            // 
            // AddAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(738, 438);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelCriteria);
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
        private System.Windows.Forms.Panel datePl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button nextBtn;
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
        private System.Windows.Forms.Panel typePl;
        private System.Windows.Forms.TextBox typeTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox fileTb;
        private System.Windows.Forms.Button loadAssessmentBtn;
    }
}