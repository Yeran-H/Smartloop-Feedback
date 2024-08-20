namespace Smartloop_Feedback
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.usernamePl = new System.Windows.Forms.Panel();
            this.passwordPl = new System.Windows.Forms.Panel();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.signBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.passwordPb = new System.Windows.Forms.PictureBox();
            this.usernamePb = new System.Windows.Forms.PictureBox();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.formTitle = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.showPasswordCb = new System.Windows.Forms.CheckBox();
            this.rememberMeCb = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameTb
            // 
            this.usernameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.usernameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.usernameTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.usernameTb.HideSelection = false;
            this.usernameTb.Location = new System.Drawing.Point(71, 184);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(218, 20);
            this.usernameTb.TabIndex = 1;
            this.toolTip1.SetToolTip(this.usernameTb, "Please Enter Student ID");
            this.usernameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameTb_KeyPress);
            // 
            // usernamePl
            // 
            this.usernamePl.BackColor = System.Drawing.Color.White;
            this.usernamePl.Location = new System.Drawing.Point(39, 207);
            this.usernamePl.Name = "usernamePl";
            this.usernamePl.Size = new System.Drawing.Size(250, 1);
            this.usernamePl.TabIndex = 3;
            // 
            // passwordPl
            // 
            this.passwordPl.BackColor = System.Drawing.Color.White;
            this.passwordPl.Location = new System.Drawing.Point(39, 262);
            this.passwordPl.Name = "passwordPl";
            this.passwordPl.Size = new System.Drawing.Size(250, 1);
            this.passwordPl.TabIndex = 6;
            // 
            // passwordTb
            // 
            this.passwordTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.passwordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.passwordTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.passwordTb.HideSelection = false;
            this.passwordTb.Location = new System.Drawing.Point(70, 239);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(219, 20);
            this.passwordTb.TabIndex = 2;
            this.toolTip1.SetToolTip(this.passwordTb, "Please Enter Password");
            // 
            // signBtn
            // 
            this.signBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.signBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signBtn.Enabled = false;
            this.signBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.signBtn.Location = new System.Drawing.Point(37, 340);
            this.signBtn.Name = "signBtn";
            this.signBtn.Size = new System.Drawing.Size(252, 52);
            this.signBtn.TabIndex = 3;
            this.signBtn.Text = "Sign In";
            this.signBtn.UseVisualStyleBackColor = false;
            this.signBtn.Click += new System.EventHandler(this.signBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.registerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.registerBtn.Location = new System.Drawing.Point(37, 398);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(252, 52);
            this.registerBtn.TabIndex = 4;
            this.registerBtn.TabStop = false;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // passwordPb
            // 
            this.passwordPb.Image = global::Smartloop_Feedback.Properties.Resources.pass1;
            this.passwordPb.Location = new System.Drawing.Point(37, 229);
            this.passwordPb.Name = "passwordPb";
            this.passwordPb.Size = new System.Drawing.Size(27, 27);
            this.passwordPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPb.TabIndex = 11;
            this.passwordPb.TabStop = false;
            // 
            // usernamePb
            // 
            this.usernamePb.Image = global::Smartloop_Feedback.Properties.Resources.person1;
            this.usernamePb.Location = new System.Drawing.Point(39, 174);
            this.usernamePb.Name = "usernamePb";
            this.usernamePb.Size = new System.Drawing.Size(27, 27);
            this.usernamePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.usernamePb.TabIndex = 10;
            this.usernamePb.TabStop = false;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Smartloop_Feedback.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(-35, -21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(10, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(53, 21);
            this.formTitle.TabIndex = 7;
            this.formTitle.Text = "Login";
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
            this.headerPanel.TabIndex = 12;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            this.headerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseUp);
            // 
            // showPasswordCb
            // 
            this.showPasswordCb.AutoSize = true;
            this.showPasswordCb.Font = new System.Drawing.Font("Aptos", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPasswordCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.showPasswordCb.Location = new System.Drawing.Point(99, 275);
            this.showPasswordCb.Name = "showPasswordCb";
            this.showPasswordCb.Size = new System.Drawing.Size(137, 23);
            this.showPasswordCb.TabIndex = 13;
            this.showPasswordCb.Text = "Show Password";
            this.toolTip1.SetToolTip(this.showPasswordCb, "Click to View Password");
            this.showPasswordCb.UseVisualStyleBackColor = true;
            this.showPasswordCb.CheckedChanged += new System.EventHandler(this.showPasswordCb_CheckedChanged);
            // 
            // rememberMeCb
            // 
            this.rememberMeCb.AutoSize = true;
            this.rememberMeCb.Font = new System.Drawing.Font("Aptos", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberMeCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.rememberMeCb.Location = new System.Drawing.Point(99, 300);
            this.rememberMeCb.Name = "rememberMeCb";
            this.rememberMeCb.Size = new System.Drawing.Size(126, 23);
            this.rememberMeCb.TabIndex = 14;
            this.rememberMeCb.Text = "Remember Me";
            this.toolTip1.SetToolTip(this.rememberMeCb, "Click to remeber ID and Password");
            this.rememberMeCb.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(314, 495);
            this.Controls.Add(this.rememberMeCb);
            this.Controls.Add(this.showPasswordCb);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.passwordPb);
            this.Controls.Add(this.usernamePb);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.signBtn);
            this.Controls.Add(this.passwordPl);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.usernamePl);
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox usernameTb;
        private System.Windows.Forms.Panel usernamePl;
        private System.Windows.Forms.Panel passwordPl;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Button signBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.PictureBox exitPb;
        private System.Windows.Forms.PictureBox usernamePb;
        private System.Windows.Forms.PictureBox passwordPb;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.CheckBox showPasswordCb;
        private System.Windows.Forms.CheckBox rememberMeCb;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
