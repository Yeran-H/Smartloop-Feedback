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
            this.assessmentDgv = new System.Windows.Forms.DataGridView();
            this.titleLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assessmentDgv)).BeginInit();
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
            this.tutorialDgv.Location = new System.Drawing.Point(53, 92);
            this.tutorialDgv.Name = "tutorialDgv";
            this.tutorialDgv.ReadOnly = true;
            this.tutorialDgv.Size = new System.Drawing.Size(148, 262);
            this.tutorialDgv.TabIndex = 50;
            this.tutorialDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorialDgv_CellClick);
            // 
            // assessmentDgv
            // 
            this.assessmentDgv.AllowUserToAddRows = false;
            this.assessmentDgv.AllowUserToDeleteRows = false;
            this.assessmentDgv.AllowUserToOrderColumns = true;
            this.assessmentDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.assessmentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assessmentDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.assessmentDgv.Location = new System.Drawing.Point(338, 92);
            this.assessmentDgv.Name = "assessmentDgv";
            this.assessmentDgv.ReadOnly = true;
            this.assessmentDgv.Size = new System.Drawing.Size(400, 262);
            this.assessmentDgv.TabIndex = 51;
            // 
            // titleLb
            // 
            this.titleLb.AutoSize = true;
            this.titleLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.titleLb.Location = new System.Drawing.Point(18, 53);
            this.titleLb.Name = "titleLb";
            this.titleLb.Size = new System.Drawing.Size(217, 36);
            this.titleLb.TabIndex = 52;
            this.titleLb.Text = "Tutorial Classes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(438, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 36);
            this.label1.TabIndex = 53;
            this.label1.Text = "Assessment";
            // 
            // TutorCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLb);
            this.Controls.Add(this.assessmentDgv);
            this.Controls.Add(this.tutorialDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TutorCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TutorCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assessmentDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tutorialDgv;
        private System.Windows.Forms.DataGridView assessmentDgv;
        private System.Windows.Forms.Label titleLb;
        private System.Windows.Forms.Label label1;
    }
}