namespace Smartloop_Feedback.Coordinator
{
    partial class CoordinatorDash
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
            this.coordinatorBtn = new System.Windows.Forms.Button();
            this.courseDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // coordinatorBtn
            // 
            this.coordinatorBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.coordinatorBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.coordinatorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coordinatorBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.coordinatorBtn.Location = new System.Drawing.Point(252, 401);
            this.coordinatorBtn.Name = "coordinatorBtn";
            this.coordinatorBtn.Size = new System.Drawing.Size(252, 52);
            this.coordinatorBtn.TabIndex = 19;
            this.coordinatorBtn.TabStop = false;
            this.coordinatorBtn.Text = "Add Course";
            this.coordinatorBtn.UseVisualStyleBackColor = false;
            // 
            // courseDgv
            // 
            this.courseDgv.AllowUserToAddRows = false;
            this.courseDgv.AllowUserToDeleteRows = false;
            this.courseDgv.AllowUserToOrderColumns = true;
            this.courseDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.courseDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.courseDgv.Location = new System.Drawing.Point(12, 12);
            this.courseDgv.Name = "courseDgv";
            this.courseDgv.ReadOnly = true;
            this.courseDgv.Size = new System.Drawing.Size(715, 383);
            this.courseDgv.TabIndex = 50;
            // 
            // CoordinatorDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.courseDgv);
            this.Controls.Add(this.coordinatorBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CoordinatorDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoordinatorDash";
            this.Load += new System.EventHandler(this.CoordinatorDash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button coordinatorBtn;
        private System.Windows.Forms.DataGridView courseDgv;
    }
}