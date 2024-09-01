using System.Windows.Forms;

namespace Smartloop_Feedback
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.studentPl = new System.Windows.Forms.Panel();
            this.studentTb = new System.Windows.Forms.TextBox();
            this.namePl = new System.Windows.Forms.Panel();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.passwordPl = new System.Windows.Forms.Panel();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.degreePl = new System.Windows.Forms.Panel();
            this.degreeTb = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.degreePb = new System.Windows.Forms.PictureBox();
            this.passwordPb = new System.Windows.Forms.PictureBox();
            this.studentPb = new System.Windows.Forms.PictureBox();
            this.namePb = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.profilePb = new System.Windows.Forms.PictureBox();
            this.profileBtn = new System.Windows.Forms.Button();
            this.emailPb = new System.Windows.Forms.PictureBox();
            this.emailPl = new System.Windows.Forms.Panel();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.formTitle = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.degreePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailPb)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.SuspendLayout();
            // 
            // studentPl
            // 
            this.studentPl.BackColor = System.Drawing.Color.White;
            this.studentPl.Location = new System.Drawing.Point(41, 256);
            this.studentPl.Name = "studentPl";
            this.studentPl.Size = new System.Drawing.Size(250, 1);
            this.studentPl.TabIndex = 16;
            // 
            // studentTb
            // 
            this.studentTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.studentTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studentTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.studentTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.studentTb.HideSelection = false;
            this.studentTb.Location = new System.Drawing.Point(72, 233);
            this.studentTb.Name = "studentTb";
            this.studentTb.Size = new System.Drawing.Size(219, 20);
            this.studentTb.TabIndex = 3;
            this.studentTb.Text = "Student ID";
            this.toolTip1.SetToolTip(this.studentTb, "Please enter your ID.");
            this.studentTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNextOnEnter);
            this.studentTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.studentTb_KeyPress);
            // 
            // namePl
            // 
            this.namePl.BackColor = System.Drawing.Color.White;
            this.namePl.Location = new System.Drawing.Point(41, 175);
            this.namePl.Name = "namePl";
            this.namePl.Size = new System.Drawing.Size(250, 1);
            this.namePl.TabIndex = 14;
            // 
            // nameTb
            // 
            this.nameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.nameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.nameTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.nameTb.HideSelection = false;
            this.nameTb.Location = new System.Drawing.Point(72, 153);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(219, 20);
            this.nameTb.TabIndex = 1;
            this.nameTb.Text = "Name";
            this.toolTip1.SetToolTip(this.nameTb, "Please enter your full name.");
            this.nameTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNextOnEnter);
            // 
            // passwordPl
            // 
            this.passwordPl.BackColor = System.Drawing.Color.White;
            this.passwordPl.Location = new System.Drawing.Point(41, 305);
            this.passwordPl.Name = "passwordPl";
            this.passwordPl.Size = new System.Drawing.Size(250, 1);
            this.passwordPl.TabIndex = 20;
            // 
            // passwordTb
            // 
            this.passwordTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.passwordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.passwordTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.passwordTb.HideSelection = false;
            this.passwordTb.Location = new System.Drawing.Point(72, 282);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(219, 20);
            this.passwordTb.TabIndex = 4;
            this.passwordTb.Text = "Password";
            this.toolTip1.SetToolTip(this.passwordTb, "Please enter a secure password.");
            this.passwordTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNextOnEnter);
            // 
            // degreePl
            // 
            this.degreePl.BackColor = System.Drawing.Color.White;
            this.degreePl.Location = new System.Drawing.Point(41, 349);
            this.degreePl.Name = "degreePl";
            this.degreePl.Size = new System.Drawing.Size(250, 1);
            this.degreePl.TabIndex = 23;
            // 
            // degreeTb
            // 
            this.degreeTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.degreeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.degreeTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.degreeTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.degreeTb.HideSelection = false;
            this.degreeTb.Location = new System.Drawing.Point(72, 326);
            this.degreeTb.Name = "degreeTb";
            this.degreeTb.Size = new System.Drawing.Size(219, 20);
            this.degreeTb.TabIndex = 5;
            this.degreeTb.Text = "Degree";
            this.toolTip1.SetToolTip(this.degreeTb, "Please enter your degree.");
            this.degreeTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNextOnEnter);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.backBtn.Location = new System.Drawing.Point(39, 534);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(252, 52);
            this.backBtn.TabIndex = 26;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.registerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.registerBtn.Location = new System.Drawing.Point(39, 476);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(252, 52);
            this.registerBtn.TabIndex = 25;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // degreePb
            // 
            this.degreePb.Image = global::Smartloop_Feedback.Properties.Resources.degree1;
            this.degreePb.Location = new System.Drawing.Point(39, 316);
            this.degreePb.Name = "degreePb";
            this.degreePb.Size = new System.Drawing.Size(27, 27);
            this.degreePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.degreePb.TabIndex = 24;
            this.degreePb.TabStop = false;
            // 
            // passwordPb
            // 
            this.passwordPb.Image = global::Smartloop_Feedback.Properties.Resources.pass1;
            this.passwordPb.Location = new System.Drawing.Point(39, 272);
            this.passwordPb.Name = "passwordPb";
            this.passwordPb.Size = new System.Drawing.Size(27, 27);
            this.passwordPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPb.TabIndex = 21;
            this.passwordPb.TabStop = false;
            // 
            // studentPb
            // 
            this.studentPb.Image = global::Smartloop_Feedback.Properties.Resources.person1;
            this.studentPb.Location = new System.Drawing.Point(39, 223);
            this.studentPb.Name = "studentPb";
            this.studentPb.Size = new System.Drawing.Size(27, 27);
            this.studentPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.studentPb.TabIndex = 18;
            this.studentPb.TabStop = false;
            // 
            // namePb
            // 
            this.namePb.Image = global::Smartloop_Feedback.Properties.Resources.person1;
            this.namePb.Location = new System.Drawing.Point(41, 142);
            this.namePb.Name = "namePb";
            this.namePb.Size = new System.Drawing.Size(27, 27);
            this.namePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.namePb.TabIndex = 17;
            this.namePb.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-32, -43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // profilePb
            // 
            this.profilePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePb.Location = new System.Drawing.Point(41, 371);
            this.profilePb.Name = "profilePb";
            this.profilePb.Size = new System.Drawing.Size(96, 96);
            this.profilePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePb.TabIndex = 28;
            this.profilePb.TabStop = false;
            // 
            // profileBtn
            // 
            this.profileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.profileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.profileBtn.Location = new System.Drawing.Point(143, 395);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(126, 52);
            this.profileBtn.TabIndex = 29;
            this.profileBtn.Text = "Upload Profile Image";
            this.toolTip1.SetToolTip(this.profileBtn, "Upload your profile image.");
            this.profileBtn.UseVisualStyleBackColor = false;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // emailPb
            // 
            this.emailPb.Image = global::Smartloop_Feedback.Properties.Resources.email1;
            this.emailPb.Location = new System.Drawing.Point(39, 182);
            this.emailPb.Name = "emailPb";
            this.emailPb.Size = new System.Drawing.Size(27, 27);
            this.emailPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.emailPb.TabIndex = 32;
            this.emailPb.TabStop = false;
            // 
            // emailPl
            // 
            this.emailPl.BackColor = System.Drawing.Color.White;
            this.emailPl.Location = new System.Drawing.Point(41, 211);
            this.emailPl.Name = "emailPl";
            this.emailPl.Size = new System.Drawing.Size(250, 1);
            this.emailPl.TabIndex = 31;
            // 
            // emailTb
            // 
            this.emailTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.emailTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.emailTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.emailTb.HideSelection = false;
            this.emailTb.Location = new System.Drawing.Point(72, 192);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(219, 20);
            this.emailTb.TabIndex = 2;
            this.emailTb.Text = "Email";
            this.toolTip1.SetToolTip(this.emailTb, "Please enter your email address.");
            this.emailTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNextOnEnter);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.headerPanel.Controls.Add(this.formTitle);
            this.headerPanel.Controls.Add(this.exitPb);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(314, 40);
            this.headerPanel.TabIndex = 33;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            this.headerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseUp);
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(10, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(72, 21);
            this.formTitle.TabIndex = 7;
            this.formTitle.Text = "Register";
            // 
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exitPb.Location = new System.Drawing.Point(293, 10);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 9;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(314, 608);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.emailPb);
            this.Controls.Add(this.emailPl);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.profilePb);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.degreePb);
            this.Controls.Add(this.degreePl);
            this.Controls.Add(this.degreeTb);
            this.Controls.Add(this.passwordPb);
            this.Controls.Add(this.passwordPl);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.studentPb);
            this.Controls.Add(this.namePb);
            this.Controls.Add(this.studentPl);
            this.Controls.Add(this.studentTb);
            this.Controls.Add(this.namePl);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registerForm";
            ((System.ComponentModel.ISupportInitialize)(this.degreePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailPb)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox studentPb;
        private System.Windows.Forms.PictureBox namePb;
        private System.Windows.Forms.Panel studentPl;
        private System.Windows.Forms.TextBox studentTb;
        private System.Windows.Forms.Panel namePl;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox passwordPb;
        private System.Windows.Forms.Panel passwordPl;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.PictureBox degreePb;
        private System.Windows.Forms.Panel degreePl;
        private System.Windows.Forms.TextBox degreeTb;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.PictureBox profilePb;
        private System.Windows.Forms.Button profileBtn;
        private System.Windows.Forms.PictureBox emailPb;
        private System.Windows.Forms.Panel emailPl;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.PictureBox exitPb;
        private System.Windows.Forms.ToolTip toolTip1;

        // Method to move to the next input field when Enter is pressed
        private void MoveNextOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
