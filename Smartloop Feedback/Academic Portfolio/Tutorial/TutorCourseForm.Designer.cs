namespace Smartloop_Feedback.Academic_Portfolio
{
    partial class TutorCourseForm
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
            this.tutorialDgv = new System.Windows.Forms.DataGridView();
            this.titleLb = new System.Windows.Forms.Label();
            this.tutorialLb = new System.Windows.Forms.Label();
            this.studentDgv = new System.Windows.Forms.DataGridView();
            this.feedbackRb = new System.Windows.Forms.RichTextBox();
            this.feedbackLb = new System.Windows.Forms.Label();
            this.assessmentCb = new System.Windows.Forms.CheckedListBox();
            this.feedbackCb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tutorialDgv
            // 
            this.tutorialDgv.AllowUserToAddRows = false;
            this.tutorialDgv.AllowUserToDeleteRows = false;
            this.tutorialDgv.AllowUserToOrderColumns = true;
            this.tutorialDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tutorialDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tutorialDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tutorialDgv.Location = new System.Drawing.Point(35, 92);
            this.tutorialDgv.Name = "tutorialDgv";
            this.tutorialDgv.ReadOnly = true;
            this.tutorialDgv.Size = new System.Drawing.Size(123, 262);
            this.tutorialDgv.TabIndex = 50;
            this.tutorialDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorialDgv_CellClick);
            // 
            // titleLb
            // 
            this.titleLb.AutoSize = true;
            this.titleLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.titleLb.Location = new System.Drawing.Point(3, 53);
            this.titleLb.Name = "titleLb";
            this.titleLb.Size = new System.Drawing.Size(217, 36);
            this.titleLb.TabIndex = 52;
            this.titleLb.Text = "Tutorial Classes";
            // 
            // tutorialLb
            // 
            this.tutorialLb.AutoSize = true;
            this.tutorialLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutorialLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.tutorialLb.Location = new System.Drawing.Point(320, 53);
            this.tutorialLb.Name = "tutorialLb";
            this.tutorialLb.Size = new System.Drawing.Size(310, 36);
            this.tutorialLb.TabIndex = 57;
            this.tutorialLb.Text = "Tutorial XX Student List";
            this.tutorialLb.Visible = false;
            // 
            // studentDgv
            // 
            this.studentDgv.AllowUserToAddRows = false;
            this.studentDgv.AllowUserToDeleteRows = false;
            this.studentDgv.AllowUserToOrderColumns = true;
            this.studentDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.studentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.studentDgv.Location = new System.Drawing.Point(251, 92);
            this.studentDgv.Name = "studentDgv";
            this.studentDgv.ReadOnly = true;
            this.studentDgv.Size = new System.Drawing.Size(458, 137);
            this.studentDgv.TabIndex = 56;
            this.studentDgv.Visible = false;
            this.studentDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentDgv_CellClick);
            // 
            // feedbackRb
            // 
            this.feedbackRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.feedbackRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.feedbackRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.feedbackRb.Location = new System.Drawing.Point(428, 322);
            this.feedbackRb.Name = "feedbackRb";
            this.feedbackRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.feedbackRb.Size = new System.Drawing.Size(310, 117);
            this.feedbackRb.TabIndex = 66;
            this.feedbackRb.Text = "";
            this.feedbackRb.Visible = false;
            // 
            // feedbackLb
            // 
            this.feedbackLb.AutoSize = true;
            this.feedbackLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.feedbackLb.Location = new System.Drawing.Point(465, 256);
            this.feedbackLb.Name = "feedbackLb";
            this.feedbackLb.Size = new System.Drawing.Size(229, 36);
            this.feedbackLb.TabIndex = 64;
            this.feedbackLb.Text = "General Feeback";
            this.feedbackLb.Visible = false;
            // 
            // assessmentCb
            // 
            this.assessmentCb.FormattingEnabled = true;
            this.assessmentCb.Location = new System.Drawing.Point(175, 282);
            this.assessmentCb.Name = "assessmentCb";
            this.assessmentCb.Size = new System.Drawing.Size(247, 169);
            this.assessmentCb.TabIndex = 67;
            this.assessmentCb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.assessmentCb_ItemCheck);
            // 
            // feedbackCb
            // 
            this.feedbackCb.FormattingEnabled = true;
            this.feedbackCb.Location = new System.Drawing.Point(471, 295);
            this.feedbackCb.Name = "feedbackCb";
            this.feedbackCb.Size = new System.Drawing.Size(223, 21);
            this.feedbackCb.TabIndex = 68;
            this.feedbackCb.SelectedIndexChanged += new System.EventHandler(this.feedbackCb_SelectedIndexChanged);
            // 
            // TutorCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.feedbackCb);
            this.Controls.Add(this.assessmentCb);
            this.Controls.Add(this.feedbackRb);
            this.Controls.Add(this.feedbackLb);
            this.Controls.Add(this.tutorialLb);
            this.Controls.Add(this.studentDgv);
            this.Controls.Add(this.titleLb);
            this.Controls.Add(this.tutorialDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TutorCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TutorCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tutorialDgv;
        private System.Windows.Forms.Label titleLb;
        private System.Windows.Forms.Label tutorialLb;
        private System.Windows.Forms.DataGridView studentDgv;
        private System.Windows.Forms.RichTextBox feedbackRb;
        private System.Windows.Forms.Label feedbackLb;
        private System.Windows.Forms.CheckedListBox assessmentCb;
        private System.Windows.Forms.ComboBox feedbackCb;
    }
}