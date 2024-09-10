namespace Smartloop_Feedback
{
    partial class AcademicCourseBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcademicCourseBar));
            this.oneBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.navPl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // oneBtn
            // 
            this.oneBtn.FlatAppearance.BorderSize = 0;
            this.oneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oneBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.oneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.oneBtn.Image = ((System.Drawing.Image)(resources.GetObject("oneBtn.Image")));
            this.oneBtn.Location = new System.Drawing.Point(0, 90);
            this.oneBtn.Name = "oneBtn";
            this.oneBtn.Size = new System.Drawing.Size(186, 42);
            this.oneBtn.TabIndex = 9;
            this.oneBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.oneBtn.UseVisualStyleBackColor = true;
            this.oneBtn.Visible = false;
            this.oneBtn.Click += new System.EventHandler(this.CourseBtn_Click);
            this.oneBtn.Leave += new System.EventHandler(this.ResetButtonColor);
            // 
            // addBtn
            // 
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.addBtn.Image = global::Smartloop_Feedback.Properties.Resources.add;
            this.addBtn.Location = new System.Drawing.Point(0, 42);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(186, 42);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add";
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
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
            this.backBtn.Size = new System.Drawing.Size(186, 42);
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Back";
            this.backBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // navPl
            // 
            this.navPl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.navPl.Location = new System.Drawing.Point(12, 0);
            this.navPl.Name = "navPl";
            this.navPl.Size = new System.Drawing.Size(1, 248);
            this.navPl.TabIndex = 14;
            // 
            // AcademicCourseBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(186, 137);
            this.Controls.Add(this.navPl);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.oneBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AcademicCourseBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "academicSubjectBar";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button oneBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel navPl;
    }
}