namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    partial class PdfReadeerForm
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

        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtRubric = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblRubric = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.txtTips = new System.Windows.Forms.TextBox();
            this.txtUserQuestion = new System.Windows.Forms.TextBox();
            this.txtAIResponse = new System.Windows.Forms.TextBox();
            this.btnSendQuestion = new System.Windows.Forms.Button();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.lblUserQuestion = new System.Windows.Forms.Label();
            this.lblAIResponse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(93, 14);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(379, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(478, 12);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFile.TabIndex = 2;
            this.btnUploadFile.Text = "Upload File";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(93, 50);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(379, 60);
            this.txtComments.TabIndex = 3;
            // 
            // txtRubric
            // 
            this.txtRubric.Location = new System.Drawing.Point(93, 130);
            this.txtRubric.Multiline = true;
            this.txtRubric.Name = "txtRubric";
            this.txtRubric.Size = new System.Drawing.Size(379, 60);
            this.txtRubric.TabIndex = 4;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(12, 53);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(56, 13);
            this.lblComments.TabIndex = 5;
            this.lblComments.Text = "Comments";
            // 
            // lblRubric
            // 
            this.lblRubric.AutoSize = true;
            this.lblRubric.Location = new System.Drawing.Point(12, 133);
            this.lblRubric.Name = "lblRubric";
            this.lblRubric.Size = new System.Drawing.Size(37, 13);
            this.lblRubric.TabIndex = 6;
            this.lblRubric.Text = "Rubric";
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(93, 210);
            this.txtGrade.Multiline = true;
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(379, 40);
            this.txtGrade.TabIndex = 7;
            // 
            // txtFeedback
            // 
            this.txtFeedback.Location = new System.Drawing.Point(93, 270);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(379, 60);
            this.txtFeedback.TabIndex = 8;
            // 
            // txtTips
            // 
            this.txtTips.Location = new System.Drawing.Point(93, 350);
            this.txtTips.Multiline = true;
            this.txtTips.Name = "txtTips";
            this.txtTips.Size = new System.Drawing.Size(379, 60);
            this.txtTips.TabIndex = 9;
            // 
            // txtUserQuestion
            // 
            this.txtUserQuestion.Location = new System.Drawing.Point(93, 430);
            this.txtUserQuestion.Multiline = true;
            this.txtUserQuestion.Name = "txtUserQuestion";
            this.txtUserQuestion.Size = new System.Drawing.Size(379, 40);
            this.txtUserQuestion.TabIndex = 10;
            // 
            // txtAIResponse
            // 
            this.txtAIResponse.Location = new System.Drawing.Point(93, 490);
            this.txtAIResponse.Multiline = true;
            this.txtAIResponse.Name = "txtAIResponse";
            this.txtAIResponse.Size = new System.Drawing.Size(379, 60);
            this.txtAIResponse.TabIndex = 11;
            // 
            // btnSendQuestion
            // 
            this.btnSendQuestion.Location = new System.Drawing.Point(478, 430);
            this.btnSendQuestion.Name = "btnSendQuestion";
            this.btnSendQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnSendQuestion.TabIndex = 12;
            this.btnSendQuestion.Text = "Send";
            this.btnSendQuestion.UseVisualStyleBackColor = true;
            this.btnSendQuestion.Click += new System.EventHandler(this.btnSendQuestion_Click);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(12, 213);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 13;
            this.lblGrade.Text = "Grade";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(12, 273);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(55, 13);
            this.lblFeedback.TabIndex = 14;
            this.lblFeedback.Text = "Feedback";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Location = new System.Drawing.Point(12, 353);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(26, 13);
            this.lblTips.TabIndex = 15;
            this.lblTips.Text = "Tips";
            // 
            // lblUserQuestion
            // 
            this.lblUserQuestion.AutoSize = true;
            this.lblUserQuestion.Location = new System.Drawing.Point(12, 433);
            this.lblUserQuestion.Name = "lblUserQuestion";
            this.lblUserQuestion.Size = new System.Drawing.Size(75, 13);
            this.lblUserQuestion.TabIndex = 16;
            this.lblUserQuestion.Text = "Your Question";
            // 
            // lblAIResponse
            // 
            this.lblAIResponse.AutoSize = true;
            this.lblAIResponse.Location = new System.Drawing.Point(12, 493);
            this.lblAIResponse.Name = "lblAIResponse";
            this.lblAIResponse.Size = new System.Drawing.Size(70, 13);
            this.lblAIResponse.TabIndex = 17;
            this.lblAIResponse.Text = "AI Response";
            // 
            // PdfReadeerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 570);
            this.Controls.Add(this.lblAIResponse);
            this.Controls.Add(this.lblUserQuestion);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.btnSendQuestion);
            this.Controls.Add(this.txtAIResponse);
            this.Controls.Add(this.txtUserQuestion);
            this.Controls.Add(this.txtTips);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.lblRubric);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.txtRubric);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "PdfReadeerForm";
            this.Text = "PdfReadeerForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtRubric;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblRubric;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.TextBox txtTips;
        private System.Windows.Forms.TextBox txtUserQuestion;
        private System.Windows.Forms.TextBox txtAIResponse;
        private System.Windows.Forms.Button btnSendQuestion;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Label lblUserQuestion;
        private System.Windows.Forms.Label lblAIResponse;
    }
}
