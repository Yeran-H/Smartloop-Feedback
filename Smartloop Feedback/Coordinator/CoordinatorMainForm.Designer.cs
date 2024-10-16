namespace Smartloop_Feedback.Coordinator_Folder
{
    partial class CoordinatorMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoordinatorMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.navPl = new System.Windows.Forms.Panel();
            this.dashboardBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nameLb = new System.Windows.Forms.Label();
            this.profilePb = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.centrePannel = new System.Windows.Forms.Panel();
            this.formLoaderPl = new System.Windows.Forms.Panel();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.titleLb = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.centrePannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.navPl);
            this.panel1.Controls.Add(this.dashboardBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 538);
            this.panel1.TabIndex = 0;
            // 
            // navPl
            // 
            this.navPl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.navPl.Location = new System.Drawing.Point(3, 202);
            this.navPl.Name = "navPl";
            this.navPl.Size = new System.Drawing.Size(3, 100);
            this.navPl.TabIndex = 5;
            // 
            // dashboardBtn
            // 
            this.dashboardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardBtn.FlatAppearance.BorderSize = 0;
            this.dashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.dashboardBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.dashboardBtn.Image = global::Smartloop_Feedback.Properties.Resources.home;
            this.dashboardBtn.Location = new System.Drawing.Point(0, 202);
            this.dashboardBtn.Name = "dashboardBtn";
            this.dashboardBtn.Size = new System.Drawing.Size(186, 42);
            this.dashboardBtn.TabIndex = 1;
            this.dashboardBtn.Text = "Dashboard";
            this.dashboardBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardBtn.UseVisualStyleBackColor = true;
            this.dashboardBtn.Click += new System.EventHandler(this.dashboardBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nameLb);
            this.panel2.Controls.Add(this.profilePb);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 202);
            this.panel2.TabIndex = 0;
            // 
            // nameLb
            // 
            this.nameLb.AutoSize = true;
            this.nameLb.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.nameLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.nameLb.Location = new System.Drawing.Point(19, 160);
            this.nameLb.Name = "nameLb";
            this.nameLb.Size = new System.Drawing.Size(149, 19);
            this.nameLb.TabIndex = 1;
            this.nameLb.Text = "Subject Coordinator";
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
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exitPb.Location = new System.Drawing.Point(718, 7);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 10;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
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
            // CoordinatorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(935, 538);
            this.Controls.Add(this.centrePannel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CoordinatorMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.centrePannel.ResumeLayout(false);
            this.centrePannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox profilePb;
        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.Button dashboardBtn;
        private System.Windows.Forms.Panel navPl;
        private System.Windows.Forms.Panel centrePannel;
        private System.Windows.Forms.Label titleLb;
        private System.Windows.Forms.PictureBox exitPb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel formLoaderPl;
    }
}