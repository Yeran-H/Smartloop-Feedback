namespace Smartloop_Feedback.Settings
{
    partial class SettingForm
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
            this.settingsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.emailPb = new System.Windows.Forms.PictureBox();
            this.emailPl = new System.Windows.Forms.Panel();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.profileBtn = new System.Windows.Forms.Button();
            this.profilePb = new System.Windows.Forms.PictureBox();
            this.degreePb = new System.Windows.Forms.PictureBox();
            this.degreePl = new System.Windows.Forms.Panel();
            this.degreeTb = new System.Windows.Forms.TextBox();
            this.passwordPb = new System.Windows.Forms.PictureBox();
            this.passwordPl = new System.Windows.Forms.Panel();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.namePb = new System.Windows.Forms.PictureBox();
            this.namePl = new System.Windows.Forms.Panel();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.settingsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePb)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.tabPage1);
            this.settingsTab.Controls.Add(this.tabPage2);
            this.settingsTab.Controls.Add(this.tabPage5);
            this.settingsTab.Font = new System.Drawing.Font("Aptos", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsTab.Location = new System.Drawing.Point(0, 0);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(0);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Drawing.Point(0, 0);
            this.settingsTab.SelectedIndex = 0;
            this.settingsTab.Size = new System.Drawing.Size(750, 477);
            this.settingsTab.TabIndex = 0;
            this.settingsTab.SelectedIndexChanged += new System.EventHandler(this.settingsTab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tabPage1.Controls.Add(this.deleteBtn);
            this.tabPage1.Controls.Add(this.updateBtn);
            this.tabPage1.Controls.Add(this.emailPb);
            this.tabPage1.Controls.Add(this.emailPl);
            this.tabPage1.Controls.Add(this.emailTb);
            this.tabPage1.Controls.Add(this.profileBtn);
            this.tabPage1.Controls.Add(this.profilePb);
            this.tabPage1.Controls.Add(this.degreePb);
            this.tabPage1.Controls.Add(this.degreePl);
            this.tabPage1.Controls.Add(this.degreeTb);
            this.tabPage1.Controls.Add(this.passwordPb);
            this.tabPage1.Controls.Add(this.passwordPl);
            this.tabPage1.Controls.Add(this.passwordTb);
            this.tabPage1.Controls.Add(this.namePb);
            this.tabPage1.Controls.Add(this.namePl);
            this.tabPage1.Controls.Add(this.nameTb);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Account";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Year";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(742, 450);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Assessment";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // emailPb
            // 
            this.emailPb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.emailPb.Image = global::Smartloop_Feedback.Properties.Resources.email1;
            this.emailPb.Location = new System.Drawing.Point(251, 75);
            this.emailPb.Name = "emailPb";
            this.emailPb.Size = new System.Drawing.Size(27, 27);
            this.emailPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.emailPb.TabIndex = 50;
            this.emailPb.TabStop = false;
            // 
            // emailPl
            // 
            this.emailPl.BackColor = System.Drawing.Color.White;
            this.emailPl.Location = new System.Drawing.Point(253, 104);
            this.emailPl.Name = "emailPl";
            this.emailPl.Size = new System.Drawing.Size(250, 1);
            this.emailPl.TabIndex = 49;
            // 
            // emailTb
            // 
            this.emailTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.emailTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.emailTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.emailTb.HideSelection = false;
            this.emailTb.Location = new System.Drawing.Point(284, 85);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(219, 20);
            this.emailTb.TabIndex = 34;
            this.emailTb.Text = "Email";
            // 
            // profileBtn
            // 
            this.profileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.profileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.profileBtn.Location = new System.Drawing.Point(355, 243);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(126, 52);
            this.profileBtn.TabIndex = 48;
            this.profileBtn.Text = "Upload Profile Image";
            this.profileBtn.UseVisualStyleBackColor = false;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // profilePb
            // 
            this.profilePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePb.Location = new System.Drawing.Point(253, 219);
            this.profilePb.Name = "profilePb";
            this.profilePb.Size = new System.Drawing.Size(96, 96);
            this.profilePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePb.TabIndex = 47;
            this.profilePb.TabStop = false;
            // 
            // degreePb
            // 
            this.degreePb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.degreePb.Image = global::Smartloop_Feedback.Properties.Resources.degree1;
            this.degreePb.Location = new System.Drawing.Point(251, 164);
            this.degreePb.Name = "degreePb";
            this.degreePb.Size = new System.Drawing.Size(27, 27);
            this.degreePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.degreePb.TabIndex = 46;
            this.degreePb.TabStop = false;
            // 
            // degreePl
            // 
            this.degreePl.BackColor = System.Drawing.Color.White;
            this.degreePl.Location = new System.Drawing.Point(253, 197);
            this.degreePl.Name = "degreePl";
            this.degreePl.Size = new System.Drawing.Size(250, 1);
            this.degreePl.TabIndex = 45;
            // 
            // degreeTb
            // 
            this.degreeTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.degreeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.degreeTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.degreeTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.degreeTb.HideSelection = false;
            this.degreeTb.Location = new System.Drawing.Point(284, 174);
            this.degreeTb.Name = "degreeTb";
            this.degreeTb.Size = new System.Drawing.Size(219, 20);
            this.degreeTb.TabIndex = 37;
            this.degreeTb.Text = "Degree";
            // 
            // passwordPb
            // 
            this.passwordPb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.passwordPb.Image = global::Smartloop_Feedback.Properties.Resources.pass1;
            this.passwordPb.Location = new System.Drawing.Point(251, 120);
            this.passwordPb.Name = "passwordPb";
            this.passwordPb.Size = new System.Drawing.Size(27, 27);
            this.passwordPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPb.TabIndex = 44;
            this.passwordPb.TabStop = false;
            // 
            // passwordPl
            // 
            this.passwordPl.BackColor = System.Drawing.Color.White;
            this.passwordPl.Location = new System.Drawing.Point(253, 153);
            this.passwordPl.Name = "passwordPl";
            this.passwordPl.Size = new System.Drawing.Size(250, 1);
            this.passwordPl.TabIndex = 43;
            // 
            // passwordTb
            // 
            this.passwordTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.passwordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.passwordTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.passwordTb.HideSelection = false;
            this.passwordTb.Location = new System.Drawing.Point(284, 130);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(219, 20);
            this.passwordTb.TabIndex = 36;
            this.passwordTb.Text = "Password";
            // 
            // namePb
            // 
            this.namePb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.namePb.Image = global::Smartloop_Feedback.Properties.Resources.person1;
            this.namePb.Location = new System.Drawing.Point(253, 35);
            this.namePb.Name = "namePb";
            this.namePb.Size = new System.Drawing.Size(27, 27);
            this.namePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.namePb.TabIndex = 41;
            this.namePb.TabStop = false;
            // 
            // namePl
            // 
            this.namePl.BackColor = System.Drawing.Color.White;
            this.namePl.Location = new System.Drawing.Point(253, 68);
            this.namePl.Name = "namePl";
            this.namePl.Size = new System.Drawing.Size(250, 1);
            this.namePl.TabIndex = 39;
            // 
            // nameTb
            // 
            this.nameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.nameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.nameTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.nameTb.HideSelection = false;
            this.nameTb.Location = new System.Drawing.Point(284, 46);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(219, 20);
            this.nameTb.TabIndex = 33;
            this.nameTb.Text = "Name";
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.deleteBtn.Location = new System.Drawing.Point(97, 371);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(252, 52);
            this.deleteBtn.TabIndex = 52;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.updateBtn.Location = new System.Drawing.Point(355, 371);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(252, 52);
            this.updateBtn.TabIndex = 51;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.settingsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.settingsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox emailPb;
        private System.Windows.Forms.Panel emailPl;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Button profileBtn;
        private System.Windows.Forms.PictureBox profilePb;
        private System.Windows.Forms.PictureBox degreePb;
        private System.Windows.Forms.Panel degreePl;
        private System.Windows.Forms.TextBox degreeTb;
        private System.Windows.Forms.PictureBox passwordPb;
        private System.Windows.Forms.Panel passwordPl;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.PictureBox namePb;
        private System.Windows.Forms.Panel namePl;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
    }
}