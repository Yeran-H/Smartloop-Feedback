namespace Smartloop_Feedback
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
            this.backBtn = new System.Windows.Forms.Button();
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
            this.descriptionTb = new System.Windows.Forms.TextBox();
            this.exit1Pb = new System.Windows.Forms.PictureBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.yearTb = new System.Windows.Forms.TextBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.formTitle = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.pannelCourse = new System.Windows.Forms.Panel();
            this.pannelYear = new System.Windows.Forms.Panel();
            this.autumnRb = new System.Windows.Forms.RadioButton();
            this.winterRb = new System.Windows.Forms.RadioButton();
            this.springRb = new System.Windows.Forms.RadioButton();
            this.summerRb = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yearPl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.exit1Pb)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.pannelCourse.SuspendLayout();
            this.pannelYear.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.backBtn.Location = new System.Drawing.Point(13, 359);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(211, 55);
            this.backBtn.TabIndex = 16;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.saveBtn.Location = new System.Drawing.Point(13, 289);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(211, 55);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save Course";
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
            this.codeTb.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.codeTb.Enter += new System.EventHandler(this.TextBox_Enter);
            this.codeTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
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
            this.nameTb.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.nameTb.Enter += new System.EventHandler(this.TextBox_Enter);
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
            this.creditTb.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.creditTb.Enter += new System.EventHandler(this.TextBox_Enter);
            this.creditTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
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
            this.canvasTb.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.canvasTb.Enter += new System.EventHandler(this.TextBox_Enter);
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
            this.descriptionTb.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.descriptionTb.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // exit1Pb
            // 
            this.exit1Pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit1Pb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exit1Pb.Location = new System.Drawing.Point(203, 10);
            this.exit1Pb.Name = "exit1Pb";
            this.exit1Pb.Size = new System.Drawing.Size(21, 21);
            this.exit1Pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exit1Pb.TabIndex = 9;
            this.exit1Pb.TabStop = false;
            this.toolTip1.SetToolTip(this.exit1Pb, "Go Back");
            this.exit1Pb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.cancelBtn.Location = new System.Drawing.Point(12, 358);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(211, 55);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.toolTip1.SetToolTip(this.cancelBtn, "Go Back");
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.nextBtn.Location = new System.Drawing.Point(12, 288);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(211, 55);
            this.nextBtn.TabIndex = 24;
            this.nextBtn.Text = "Next";
            this.toolTip1.SetToolTip(this.nextBtn, "Save Year");
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // yearTb
            // 
            this.yearTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.yearTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.yearTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.yearTb.HideSelection = false;
            this.yearTb.Location = new System.Drawing.Point(13, 97);
            this.yearTb.Name = "yearTb";
            this.yearTb.Size = new System.Drawing.Size(206, 20);
            this.yearTb.TabIndex = 23;
            this.yearTb.TabStop = false;
            this.yearTb.Text = "Eg. 2024";
            this.toolTip1.SetToolTip(this.yearTb, "Enter the Year");
            this.yearTb.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.yearTb.Enter += new System.EventHandler(this.TextBox_Enter);
            this.yearTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
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
            // pannelCourse
            // 
            this.pannelCourse.Controls.Add(this.canvasPl);
            this.pannelCourse.Controls.Add(this.headerPanel);
            this.pannelCourse.Controls.Add(this.canvasTb);
            this.pannelCourse.Controls.Add(this.descriptionPl);
            this.pannelCourse.Controls.Add(this.descriptionTb);
            this.pannelCourse.Controls.Add(this.creditPl);
            this.pannelCourse.Controls.Add(this.creditTb);
            this.pannelCourse.Controls.Add(this.namePl);
            this.pannelCourse.Controls.Add(this.nameTb);
            this.pannelCourse.Controls.Add(this.codePl);
            this.pannelCourse.Controls.Add(this.backBtn);
            this.pannelCourse.Controls.Add(this.saveBtn);
            this.pannelCourse.Controls.Add(this.codeTb);
            this.pannelCourse.Location = new System.Drawing.Point(267, 3);
            this.pannelCourse.Name = "pannelCourse";
            this.pannelCourse.Size = new System.Drawing.Size(237, 437);
            this.pannelCourse.TabIndex = 25;
            // 
            // pannelYear
            // 
            this.pannelYear.Controls.Add(this.autumnRb);
            this.pannelYear.Controls.Add(this.winterRb);
            this.pannelYear.Controls.Add(this.springRb);
            this.pannelYear.Controls.Add(this.summerRb);
            this.pannelYear.Controls.Add(this.label3);
            this.pannelYear.Controls.Add(this.panel3);
            this.pannelYear.Controls.Add(this.label2);
            this.pannelYear.Controls.Add(this.yearPl);
            this.pannelYear.Controls.Add(this.cancelBtn);
            this.pannelYear.Controls.Add(this.nextBtn);
            this.pannelYear.Controls.Add(this.yearTb);
            this.pannelYear.Location = new System.Drawing.Point(1, 3);
            this.pannelYear.Name = "pannelYear";
            this.pannelYear.Size = new System.Drawing.Size(233, 437);
            this.pannelYear.TabIndex = 26;
            // 
            // autumnRb
            // 
            this.autumnRb.AutoSize = true;
            this.autumnRb.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autumnRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.autumnRb.Location = new System.Drawing.Point(113, 200);
            this.autumnRb.Name = "autumnRb";
            this.autumnRb.Size = new System.Drawing.Size(84, 24);
            this.autumnRb.TabIndex = 34;
            this.autumnRb.Text = "Autumn";
            this.autumnRb.UseVisualStyleBackColor = true;
            // 
            // winterRb
            // 
            this.winterRb.AutoSize = true;
            this.winterRb.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winterRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.winterRb.Location = new System.Drawing.Point(18, 230);
            this.winterRb.Name = "winterRb";
            this.winterRb.Size = new System.Drawing.Size(76, 24);
            this.winterRb.TabIndex = 33;
            this.winterRb.Text = "Winter";
            this.winterRb.UseVisualStyleBackColor = true;
            // 
            // springRb
            // 
            this.springRb.AutoSize = true;
            this.springRb.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.springRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.springRb.Location = new System.Drawing.Point(113, 230);
            this.springRb.Name = "springRb";
            this.springRb.Size = new System.Drawing.Size(73, 24);
            this.springRb.TabIndex = 32;
            this.springRb.Text = "Spring";
            this.springRb.UseVisualStyleBackColor = true;
            // 
            // summerRb
            // 
            this.summerRb.AutoSize = true;
            this.summerRb.Checked = true;
            this.summerRb.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summerRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.summerRb.Location = new System.Drawing.Point(18, 200);
            this.summerRb.Name = "summerRb";
            this.summerRb.Size = new System.Drawing.Size(89, 24);
            this.summerRb.TabIndex = 31;
            this.summerRb.TabStop = true;
            this.summerRb.Text = "Summer";
            this.summerRb.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(74, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 36);
            this.label3.TabIndex = 30;
            this.label3.Text = "Year";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.exit1Pb);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 40);
            this.panel3.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Add Course";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(42, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 36);
            this.label2.TabIndex = 28;
            this.label2.Text = "Semester";
            // 
            // yearPl
            // 
            this.yearPl.BackColor = System.Drawing.Color.White;
            this.yearPl.Location = new System.Drawing.Point(13, 119);
            this.yearPl.Name = "yearPl";
            this.yearPl.Size = new System.Drawing.Size(206, 1);
            this.yearPl.TabIndex = 26;
            // 
            // AddCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(515, 441);
            this.Controls.Add(this.pannelYear);
            this.Controls.Add(this.pannelCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addSubjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.exit1Pb)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.pannelCourse.ResumeLayout(false);
            this.pannelCourse.PerformLayout();
            this.pannelYear.ResumeLayout(false);
            this.pannelYear.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel codePl;
        private System.Windows.Forms.Button backBtn;
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
        private System.Windows.Forms.Panel pannelCourse;
        private System.Windows.Forms.Panel pannelYear;
        private System.Windows.Forms.RadioButton autumnRb;
        private System.Windows.Forms.RadioButton winterRb;
        private System.Windows.Forms.RadioButton springRb;
        private System.Windows.Forms.RadioButton summerRb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox exit1Pb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel yearPl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.TextBox yearTb;
    }
}