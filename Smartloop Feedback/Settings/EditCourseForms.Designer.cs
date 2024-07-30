namespace Smartloop_Feedback.Settings
{
    partial class EditCourseForms
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
            this.courseTab = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // courseTab
            // 
            this.courseTab.Location = new System.Drawing.Point(0, 0);
            this.courseTab.Margin = new System.Windows.Forms.Padding(0);
            this.courseTab.Name = "courseTab";
            this.courseTab.Padding = new System.Drawing.Point(0, 0);
            this.courseTab.SelectedIndex = 0;
            this.courseTab.Size = new System.Drawing.Size(734, 424);
            this.courseTab.TabIndex = 0;
            // 
            // EditCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(734, 424);
            this.Controls.Add(this.courseTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditCourse";
            this.Load += new System.EventHandler(this.EditCourseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl courseTab;
    }
}