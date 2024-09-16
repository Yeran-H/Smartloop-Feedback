namespace Smartloop_Feedback.Academic_Portfolio
{
    partial class TutorialClassForm
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
            this.tutorialLb = new System.Windows.Forms.Label();
            this.studentDgv = new System.Windows.Forms.DataGridView();
            this.assessmentCb = new System.Windows.Forms.CheckedListBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.feedbackRb = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tutorialLb
            // 
            this.tutorialLb.AutoSize = true;
            this.tutorialLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutorialLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.tutorialLb.Location = new System.Drawing.Point(129, 29);
            this.tutorialLb.Name = "tutorialLb";
            this.tutorialLb.Size = new System.Drawing.Size(310, 36);
            this.tutorialLb.TabIndex = 55;
            this.tutorialLb.Text = "Tutorial XX Student List";
            // 
            // studentDgv
            // 
            this.studentDgv.AllowUserToAddRows = false;
            this.studentDgv.AllowUserToDeleteRows = false;
            this.studentDgv.AllowUserToOrderColumns = true;
            this.studentDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.studentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.studentDgv.Location = new System.Drawing.Point(12, 68);
            this.studentDgv.Name = "studentDgv";
            this.studentDgv.ReadOnly = true;
            this.studentDgv.Size = new System.Drawing.Size(540, 225);
            this.studentDgv.TabIndex = 54;
            this.studentDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentDgv_CellClick);
            // 
            // assessmentCb
            // 
            this.assessmentCb.FormattingEnabled = true;
            this.assessmentCb.Location = new System.Drawing.Point(579, 73);
            this.assessmentCb.Name = "assessmentCb";
            this.assessmentCb.Size = new System.Drawing.Size(149, 214);
            this.assessmentCb.TabIndex = 57;
            // 
            // generateBtn
            // 
            this.generateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.generateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.generateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.generateBtn.Location = new System.Drawing.Point(582, 293);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(141, 52);
            this.generateBtn.TabIndex = 58;
            this.generateBtn.Text = "Generate Feeback";
            this.generateBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(12, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 36);
            this.label1.TabIndex = 60;
            this.label1.Text = "General Feeback";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(341, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 36);
            this.label2.TabIndex = 61;
            this.label2.Text = "Improvements";
            // 
            // feedbackRb
            // 
            this.feedbackRb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.feedbackRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackRb.Font = new System.Drawing.Font("Aptos", 12F);
            this.feedbackRb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.feedbackRb.Location = new System.Drawing.Point(18, 348);
            this.feedbackRb.Name = "feedbackRb";
            this.feedbackRb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.feedbackRb.Size = new System.Drawing.Size(240, 117);
            this.feedbackRb.TabIndex = 62;
            this.feedbackRb.Text = "Feedback";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Aptos", 12F);
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.richTextBox1.Location = new System.Drawing.Point(312, 348);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(240, 117);
            this.richTextBox1.TabIndex = 63;
            this.richTextBox1.Text = "Feedback";
            // 
            // TutorialClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.feedbackRb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.assessmentCb);
            this.Controls.Add(this.tutorialLb);
            this.Controls.Add(this.studentDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TutorialClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TutorialClassForm";
            ((System.ComponentModel.ISupportInitialize)(this.studentDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tutorialLb;
        private System.Windows.Forms.DataGridView studentDgv;
        private System.Windows.Forms.CheckedListBox assessmentCb;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox feedbackRb;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}