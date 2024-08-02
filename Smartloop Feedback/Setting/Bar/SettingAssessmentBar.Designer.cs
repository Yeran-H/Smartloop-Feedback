namespace Smartloop_Feedback.Setting.Bar
{
    partial class SettingAssessmentBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingAssessmentBar));
            this.backBtn = new System.Windows.Forms.Button();
            this.secondBtn = new System.Windows.Forms.Button();
            this.navPl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.backBtn.Image = global::Smartloop_Feedback.Properties.Resources.back;
            this.backBtn.Location = new System.Drawing.Point(0, 0);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(170, 42);
            this.backBtn.TabIndex = 16;
            this.backBtn.Text = "Back";
            this.backBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            this.backBtn.Leave += new System.EventHandler(this.ResetButtonColor);
            // 
            // secondBtn
            // 
            this.secondBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.secondBtn.FlatAppearance.BorderSize = 0;
            this.secondBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secondBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.secondBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.secondBtn.Image = ((System.Drawing.Image)(resources.GetObject("secondBtn.Image")));
            this.secondBtn.Location = new System.Drawing.Point(0, 42);
            this.secondBtn.Name = "secondBtn";
            this.secondBtn.Size = new System.Drawing.Size(170, 42);
            this.secondBtn.TabIndex = 19;
            this.secondBtn.Text = "heloo";
            this.secondBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.secondBtn.UseVisualStyleBackColor = true;
            this.secondBtn.Visible = false;
            // 
            // navPl
            // 
            this.navPl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.navPl.Location = new System.Drawing.Point(0, 0);
            this.navPl.Name = "navPl";
            this.navPl.Size = new System.Drawing.Size(3, 100);
            this.navPl.TabIndex = 20;
            // 
            // SettingAssessmentBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(170, 105);
            this.Controls.Add(this.navPl);
            this.Controls.Add(this.secondBtn);
            this.Controls.Add(this.backBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingAssessmentBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingAssessmentBar";
            this.Load += new System.EventHandler(this.SettingAssessmentBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button secondBtn;
        private System.Windows.Forms.Panel navPl;
    }
}