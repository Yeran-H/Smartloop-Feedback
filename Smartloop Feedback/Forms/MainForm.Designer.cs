namespace Smartloop_Feedback
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuDropPl = new System.Windows.Forms.Panel();
            this.navPl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.studentIdLb = new System.Windows.Forms.Label();
            this.nameLb = new System.Windows.Forms.Label();
            this.centrePannel = new System.Windows.Forms.Panel();
            this.formLoaderPl = new System.Windows.Forms.Panel();
            this.titleLb = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.courseBtn = new System.Windows.Forms.Button();
            this.setttingBtn = new System.Windows.Forms.Button();
            this.academicBtn = new System.Windows.Forms.Button();
            this.resultBtn = new System.Windows.Forms.Button();
            this.dashboardBtn = new System.Windows.Forms.Button();
            this.profilePb = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.centrePannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.menuDropPl);
            this.panel1.Controls.Add(this.courseBtn);
            this.panel1.Controls.Add(this.setttingBtn);
            this.panel1.Controls.Add(this.academicBtn);
            this.panel1.Controls.Add(this.navPl);
            this.panel1.Controls.Add(this.resultBtn);
            this.panel1.Controls.Add(this.dashboardBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 538);
            this.panel1.TabIndex = 0;
            // 
            // menuDropPl
            // 
            this.menuDropPl.AutoScroll = true;
            this.menuDropPl.Location = new System.Drawing.Point(0, 201);
            this.menuDropPl.Name = "menuDropPl";
            this.menuDropPl.Size = new System.Drawing.Size(186, 294);
            this.menuDropPl.TabIndex = 8;
            this.menuDropPl.Visible = false;
            // 
            // navPl
            // 
            this.navPl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.navPl.Location = new System.Drawing.Point(3, 202);
            this.navPl.Name = "navPl";
            this.navPl.Size = new System.Drawing.Size(3, 100);
            this.navPl.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.studentIdLb);
            this.panel2.Controls.Add(this.nameLb);
            this.panel2.Controls.Add(this.profilePb);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 202);
            this.panel2.TabIndex = 0;
            // 
            // studentIdLb
            // 
            this.studentIdLb.AutoSize = true;
            this.studentIdLb.Font = new System.Drawing.Font("Aptos", 9F, System.Drawing.FontStyle.Bold);
            this.studentIdLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.studentIdLb.Location = new System.Drawing.Point(61, 181);
            this.studentIdLb.Name = "studentIdLb";
            this.studentIdLb.Size = new System.Drawing.Size(64, 15);
            this.studentIdLb.TabIndex = 2;
            this.studentIdLb.Text = "Student ID";
            // 
            // nameLb
            // 
            this.nameLb.AutoSize = true;
            this.nameLb.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.nameLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.nameLb.Location = new System.Drawing.Point(63, 162);
            this.nameLb.Name = "nameLb";
            this.nameLb.Size = new System.Drawing.Size(49, 19);
            this.nameLb.TabIndex = 1;
            this.nameLb.Text = "Name";
            // 
            // centrePannel
            // 
            this.centrePannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.centrePannel.Controls.Add(this.formLoaderPl);
            this.centrePannel.Controls.Add(this.exitPb);
            this.centrePannel.Controls.Add(this.titleLb);
            this.centrePannel.Dock = System.Windows.Forms.DockStyle.Right;
            this.centrePannel.Location = new System.Drawing.Point(185, 0);
            this.centrePannel.Name = "centrePannel";
            this.centrePannel.Size = new System.Drawing.Size(750, 538);
            this.centrePannel.TabIndex = 2;
            this.centrePannel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.centrePannel_MouseDown);
            this.centrePannel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.centrePannel_MouseMove);
            this.centrePannel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.centrePannel_MouseUp);
            // 
            // formLoaderPl
            // 
            this.formLoaderPl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.formLoaderPl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.formLoaderPl.Location = new System.Drawing.Point(0, 61);
            this.formLoaderPl.Name = "formLoaderPl";
            this.formLoaderPl.Size = new System.Drawing.Size(750, 477);
            this.formLoaderPl.TabIndex = 11;
            // 
            // titleLb
            // 
            this.titleLb.AutoSize = true;
            this.titleLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.titleLb.Location = new System.Drawing.Point(20, 17);
            this.titleLb.MaximumSize = new System.Drawing.Size(700, 0);
            this.titleLb.Name = "titleLb";
            this.titleLb.Size = new System.Drawing.Size(153, 36);
            this.titleLb.TabIndex = 0;
            this.titleLb.Text = "Dashboard";
            // 
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = ((System.Drawing.Image)(resources.GetObject("exitPb.Image")));
            this.exitPb.Location = new System.Drawing.Point(718, 7);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 10;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // courseBtn
            // 
            this.courseBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseBtn.FlatAppearance.BorderSize = 0;
            this.courseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.courseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.courseBtn.Image = global::Smartloop_Feedback.Properties.Resources.schedule;
            this.courseBtn.Location = new System.Drawing.Point(0, 337);
            this.courseBtn.Name = "courseBtn";
            this.courseBtn.Size = new System.Drawing.Size(186, 51);
            this.courseBtn.TabIndex = 6;
            this.courseBtn.Text = "Course\r\nSchedule";
            this.courseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courseBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.courseBtn.UseVisualStyleBackColor = true;
            this.courseBtn.Click += new System.EventHandler(this.courseBtn_Click);
            this.courseBtn.Leave += new System.EventHandler(this.courseBtn_Leave);
            // 
            // setttingBtn
            // 
            this.setttingBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setttingBtn.FlatAppearance.BorderSize = 0;
            this.setttingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setttingBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.setttingBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.setttingBtn.Image = global::Smartloop_Feedback.Properties.Resources.setting;
            this.setttingBtn.Location = new System.Drawing.Point(0, 496);
            this.setttingBtn.Name = "setttingBtn";
            this.setttingBtn.Size = new System.Drawing.Size(186, 42);
            this.setttingBtn.TabIndex = 4;
            this.setttingBtn.Text = " Settings";
            this.setttingBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setttingBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.setttingBtn.UseVisualStyleBackColor = true;
            this.setttingBtn.Click += new System.EventHandler(this.setttingBtn_Click);
            this.setttingBtn.Leave += new System.EventHandler(this.setttingBtn_Leave);
            // 
            // academicBtn
            // 
            this.academicBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.academicBtn.FlatAppearance.BorderSize = 0;
            this.academicBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.academicBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.academicBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.academicBtn.Image = global::Smartloop_Feedback.Properties.Resources.portfolio;
            this.academicBtn.Location = new System.Drawing.Point(0, 286);
            this.academicBtn.Name = "academicBtn";
            this.academicBtn.Size = new System.Drawing.Size(186, 51);
            this.academicBtn.TabIndex = 3;
            this.academicBtn.Text = "Academic\r\nPortfolio";
            this.academicBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.academicBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.academicBtn.UseVisualStyleBackColor = true;
            this.academicBtn.Click += new System.EventHandler(this.academicBtn_Click);
            this.academicBtn.Leave += new System.EventHandler(this.academicBtn_Leave);
            // 
            // resultBtn
            // 
            this.resultBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultBtn.FlatAppearance.BorderSize = 0;
            this.resultBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resultBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.resultBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.resultBtn.Image = global::Smartloop_Feedback.Properties.Resources.results;
            this.resultBtn.Location = new System.Drawing.Point(0, 244);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(186, 42);
            this.resultBtn.TabIndex = 2;
            this.resultBtn.Text = "Result          ";
            this.resultBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resultBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.resultBtn.UseVisualStyleBackColor = true;
            this.resultBtn.Click += new System.EventHandler(this.resultBtn_Click);
            this.resultBtn.Leave += new System.EventHandler(this.resultBtn_Leave);
            // 
            // dashboardBtn
            // 
            this.dashboardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardBtn.FlatAppearance.BorderSize = 0;
            this.dashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.dashboardBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.dashboardBtn.Image = ((System.Drawing.Image)(resources.GetObject("dashboardBtn.Image")));
            this.dashboardBtn.Location = new System.Drawing.Point(0, 202);
            this.dashboardBtn.Name = "dashboardBtn";
            this.dashboardBtn.Size = new System.Drawing.Size(186, 42);
            this.dashboardBtn.TabIndex = 1;
            this.dashboardBtn.Text = "Dashboard";
            this.dashboardBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardBtn.UseVisualStyleBackColor = true;
            this.dashboardBtn.Click += new System.EventHandler(this.dashboardBtn_Click);
            this.dashboardBtn.Leave += new System.EventHandler(this.dashboardBtn_Leave);
            // 
            // profilePb
            // 
            this.profilePb.Image = global::Smartloop_Feedback.Properties.Resources.person1;
            this.profilePb.Location = new System.Drawing.Point(60, 87);
            this.profilePb.Name = "profilePb";
            this.profilePb.Size = new System.Drawing.Size(63, 63);
            this.profilePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePb.TabIndex = 0;
            this.profilePb.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Smartloop_Feedback.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(-23, -32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(935, 538);
            this.Controls.Add(this.centrePannel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.centrePannel.ResumeLayout(false);
            this.centrePannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox profilePb;
        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.Button dashboardBtn;
        private System.Windows.Forms.Label studentIdLb;
        private System.Windows.Forms.Button setttingBtn;
        private System.Windows.Forms.Button academicBtn;
        private System.Windows.Forms.Button resultBtn;
        private System.Windows.Forms.Panel navPl;
        private System.Windows.Forms.Panel centrePannel;
        private System.Windows.Forms.Label titleLb;
        private System.Windows.Forms.PictureBox exitPb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel formLoaderPl;
        private System.Windows.Forms.Button courseBtn;
        private System.Windows.Forms.Panel menuDropPl;
    }
}
