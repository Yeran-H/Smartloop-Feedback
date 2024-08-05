namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    partial class AIForm
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
            this.AssessmentTextBox = new System.Windows.Forms.TextBox();
            this.RubricTextBox = new System.Windows.Forms.TextBox();
            this.TeacherCommentsTextBox = new System.Windows.Forms.TextBox();
            this.GenerateFeedbackButton = new System.Windows.Forms.Button();
            this.FeedbackTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AssessmentTextBox
            // 
            this.AssessmentTextBox.Location = new System.Drawing.Point(12, 12);
            this.AssessmentTextBox.Multiline = true;
            this.AssessmentTextBox.Name = "AssessmentTextBox";
            this.AssessmentTextBox.Size = new System.Drawing.Size(726, 50);
            this.AssessmentTextBox.TabIndex = 0;
            this.AssessmentTextBox.Text = "Enter assessment here...";
            // 
            // RubricTextBox
            // 
            this.RubricTextBox.Location = new System.Drawing.Point(12, 68);
            this.RubricTextBox.Multiline = true;
            this.RubricTextBox.Name = "RubricTextBox";
            this.RubricTextBox.Size = new System.Drawing.Size(726, 50);
            this.RubricTextBox.TabIndex = 1;
            this.RubricTextBox.Text = "Enter rubric here...";
            // 
            // TeacherCommentsTextBox
            // 
            this.TeacherCommentsTextBox.Location = new System.Drawing.Point(12, 124);
            this.TeacherCommentsTextBox.Multiline = true;
            this.TeacherCommentsTextBox.Name = "TeacherCommentsTextBox";
            this.TeacherCommentsTextBox.Size = new System.Drawing.Size(726, 50);
            this.TeacherCommentsTextBox.TabIndex = 2;
            this.TeacherCommentsTextBox.Text = "Enter teacher comments here...";
            // 
            // GenerateFeedbackButton
            // 
            this.GenerateFeedbackButton.Location = new System.Drawing.Point(12, 180);
            this.GenerateFeedbackButton.Name = "GenerateFeedbackButton";
            this.GenerateFeedbackButton.Size = new System.Drawing.Size(150, 23);
            this.GenerateFeedbackButton.TabIndex = 3;
            this.GenerateFeedbackButton.Text = "Generate Feedback";
            this.GenerateFeedbackButton.UseVisualStyleBackColor = true;
            this.GenerateFeedbackButton.Click += new System.EventHandler(this.GenerateFeedbackButton_Click);
            // 
            // FeedbackTextBox
            // 
            this.FeedbackTextBox.Location = new System.Drawing.Point(12, 209);
            this.FeedbackTextBox.Multiline = true;
            this.FeedbackTextBox.Name = "FeedbackTextBox";
            this.FeedbackTextBox.Size = new System.Drawing.Size(726, 256);
            this.FeedbackTextBox.TabIndex = 4;
            this.FeedbackTextBox.Text = "Feedback will appear here...";
            // 
            // AIForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.FeedbackTextBox);
            this.Controls.Add(this.GenerateFeedbackButton);
            this.Controls.Add(this.TeacherCommentsTextBox);
            this.Controls.Add(this.RubricTextBox);
            this.Controls.Add(this.AssessmentTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AIForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AssessmentTextBox;
        private System.Windows.Forms.TextBox RubricTextBox;
        private System.Windows.Forms.TextBox TeacherCommentsTextBox;
        private System.Windows.Forms.Button GenerateFeedbackButton;
        private System.Windows.Forms.TextBox FeedbackTextBox;
    }
}
