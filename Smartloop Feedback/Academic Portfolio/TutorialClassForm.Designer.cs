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
            this.generalTb = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tutorialLb
            // 
            this.tutorialLb.AutoSize = true;
            this.tutorialLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutorialLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.tutorialLb.Location = new System.Drawing.Point(304, 29);
            this.tutorialLb.Name = "tutorialLb";
            this.tutorialLb.Size = new System.Drawing.Size(169, 36);
            this.tutorialLb.TabIndex = 55;
            this.tutorialLb.Text = "Assessment";
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
            this.studentDgv.Size = new System.Drawing.Size(776, 225);
            this.studentDgv.TabIndex = 54;
            this.studentDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentDgv_CellClick);
            // 
            // generalTb
            // 
            this.generalTb.Location = new System.Drawing.Point(61, 313);
            this.generalTb.Name = "generalTb";
            this.generalTb.Size = new System.Drawing.Size(669, 110);
            this.generalTb.TabIndex = 56;
            this.generalTb.Text = "";
            // 
            // TutorialClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.generalTb);
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
        private System.Windows.Forms.RichTextBox generalTb;
    }
}