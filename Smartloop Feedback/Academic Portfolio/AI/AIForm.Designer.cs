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
            this.loadAssessmentBtn = new System.Windows.Forms.Button();
            this.teacherRb = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.titlePl = new System.Windows.Forms.Panel();
            this.fileTb = new System.Windows.Forms.TextBox();
            this.feedbackBtn = new System.Windows.Forms.Button();
            this.feedbackRb = new System.Windows.Forms.RichTextBox();
            this.previousCb = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.noteRb = new System.Windows.Forms.RichTextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadAssessmentBtn
            // 
            this.loadAssessmentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.loadAssessmentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadAssessmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadAssessmentBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.loadAssessmentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.loadAssessmentBtn.Location = new System.Drawing.Point(311, 104);
            this.loadAssessmentBtn.Name = "loadAssessmentBtn";
            this.loadAssessmentBtn.Size = new System.Drawing.Size(141, 52);
            this.loadAssessmentBtn.TabIndex = 40;
            this.loadAssessmentBtn.Text = "Load Assessment";
            this.loadAssessmentBtn.UseVisualStyleBackColor = false;
            this.loadAssessmentBtn.Click += new System.EventHandler(this.loadAssessmentBtn_Click);
            // 
            // teacherRb
            // 
            this.teacherRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.teacherRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.teacherRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.teacherRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.teacherRb.Location = new System.Drawing.Point(12, 12);
            this.teacherRb.Name = "teacherRb";
            this.teacherRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.teacherRb.Size = new System.Drawing.Size(217, 161);
            this.teacherRb.TabIndex = 39;
            this.teacherRb.Text = "Teacher Feedback";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(269, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "File";
            // 
            // titlePl
            // 
            this.titlePl.BackColor = System.Drawing.Color.White;
            this.titlePl.Location = new System.Drawing.Point(273, 83);
            this.titlePl.Name = "titlePl";
            this.titlePl.Size = new System.Drawing.Size(200, 1);
            this.titlePl.TabIndex = 43;
            // 
            // fileTb
            // 
            this.fileTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.fileTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.fileTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.fileTb.HideSelection = false;
            this.fileTb.Location = new System.Drawing.Point(307, 60);
            this.fileTb.Name = "fileTb";
            this.fileTb.Size = new System.Drawing.Size(166, 20);
            this.fileTb.TabIndex = 42;
            this.fileTb.TabStop = false;
            // 
            // feedbackBtn
            // 
            this.feedbackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.feedbackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.feedbackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feedbackBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.feedbackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.feedbackBtn.Location = new System.Drawing.Point(258, 337);
            this.feedbackBtn.Name = "feedbackBtn";
            this.feedbackBtn.Size = new System.Drawing.Size(214, 52);
            this.feedbackBtn.TabIndex = 45;
            this.feedbackBtn.Text = "Run Feedback";
            this.feedbackBtn.UseVisualStyleBackColor = false;
            this.feedbackBtn.Click += new System.EventHandler(this.feedbackBtn_Click);
            // 
            // feedbackRb
            // 
            this.feedbackRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.feedbackRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.feedbackRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.feedbackRb.Location = new System.Drawing.Point(490, 12);
            this.feedbackRb.Name = "feedbackRb";
            this.feedbackRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.feedbackRb.Size = new System.Drawing.Size(248, 453);
            this.feedbackRb.TabIndex = 46;
            this.feedbackRb.Text = "";
            // 
            // previousCb
            // 
            this.previousCb.FormattingEnabled = true;
            this.previousCb.Location = new System.Drawing.Point(284, 218);
            this.previousCb.Name = "previousCb";
            this.previousCb.Size = new System.Drawing.Size(168, 94);
            this.previousCb.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Aptos", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(262, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 24);
            this.label3.TabIndex = 51;
            this.label3.Text = "Add Previous Attempts";
            // 
            // noteRb
            // 
            this.noteRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.noteRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noteRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.noteRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.noteRb.Location = new System.Drawing.Point(12, 205);
            this.noteRb.Name = "noteRb";
            this.noteRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.noteRb.Size = new System.Drawing.Size(217, 149);
            this.noteRb.TabIndex = 52;
            this.noteRb.Text = "Notes";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.backBtn.Location = new System.Drawing.Point(13, 413);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(141, 52);
            this.backBtn.TabIndex = 57;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // AIForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.noteRb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.previousCb);
            this.Controls.Add(this.feedbackRb);
            this.Controls.Add(this.feedbackBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titlePl);
            this.Controls.Add(this.fileTb);
            this.Controls.Add(this.loadAssessmentBtn);
            this.Controls.Add(this.teacherRb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AIForm";
            this.Load += new System.EventHandler(this.AIForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadAssessmentBtn;
        private System.Windows.Forms.RichTextBox teacherRb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel titlePl;
        private System.Windows.Forms.TextBox fileTb;
        private System.Windows.Forms.Button feedbackBtn;
        private System.Windows.Forms.RichTextBox feedbackRb;
        private System.Windows.Forms.CheckedListBox previousCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox noteRb;
        private System.Windows.Forms.Button backBtn;
    }
}
