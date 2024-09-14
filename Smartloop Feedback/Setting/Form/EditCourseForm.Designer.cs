namespace Smartloop_Feedback.Setting
{
    partial class EditCourseForm
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
            this.components = new System.ComponentModel.Container();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tutorialDgv = new System.Windows.Forms.DataGridView();
            this.passwordPb = new System.Windows.Forms.PictureBox();
            this.passwordPl = new System.Windows.Forms.Panel();
            this.searchTb = new System.Windows.Forms.TextBox();
            this.courseDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.deleteBtn.Location = new System.Drawing.Point(506, 322);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(211, 55);
            this.deleteBtn.TabIndex = 30;
            this.deleteBtn.Text = "Delete Course";
            this.toolTip1.SetToolTip(this.deleteBtn, "Click to Delete Course");
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.Enabled = false;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.updateBtn.Location = new System.Drawing.Point(289, 322);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(211, 55);
            this.updateBtn.TabIndex = 29;
            this.updateBtn.Text = "Change Tutorial Class";
            this.toolTip1.SetToolTip(this.updateBtn, "Click to Update Course");
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(77, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 36);
            this.label1.TabIndex = 73;
            this.label1.Text = "Tutorial";
            // 
            // tutorialDgv
            // 
            this.tutorialDgv.AllowUserToAddRows = false;
            this.tutorialDgv.AllowUserToDeleteRows = false;
            this.tutorialDgv.AllowUserToOrderColumns = true;
            this.tutorialDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tutorialDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tutorialDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tutorialDgv.Location = new System.Drawing.Point(12, 280);
            this.tutorialDgv.Name = "tutorialDgv";
            this.tutorialDgv.ReadOnly = true;
            this.tutorialDgv.Size = new System.Drawing.Size(259, 153);
            this.tutorialDgv.TabIndex = 71;
            // 
            // passwordPb
            // 
            this.passwordPb.Image = global::Smartloop_Feedback.Properties.Resources.search;
            this.passwordPb.Location = new System.Drawing.Point(236, 17);
            this.passwordPb.Name = "passwordPb";
            this.passwordPb.Size = new System.Drawing.Size(27, 27);
            this.passwordPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPb.TabIndex = 70;
            this.passwordPb.TabStop = false;
            // 
            // passwordPl
            // 
            this.passwordPl.BackColor = System.Drawing.Color.White;
            this.passwordPl.Location = new System.Drawing.Point(238, 50);
            this.passwordPl.Name = "passwordPl";
            this.passwordPl.Size = new System.Drawing.Size(250, 1);
            this.passwordPl.TabIndex = 69;
            // 
            // searchTb
            // 
            this.searchTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.searchTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.searchTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.searchTb.HideSelection = false;
            this.searchTb.Location = new System.Drawing.Point(269, 27);
            this.searchTb.Name = "searchTb";
            this.searchTb.Size = new System.Drawing.Size(219, 20);
            this.searchTb.TabIndex = 68;
            this.searchTb.Text = "Search Course";
            this.searchTb.TextChanged += new System.EventHandler(this.searchTb_TextChanged);
            this.searchTb.Enter += new System.EventHandler(this.searchTb_Enter);
            // 
            // courseDgv
            // 
            this.courseDgv.AllowUserToAddRows = false;
            this.courseDgv.AllowUserToDeleteRows = false;
            this.courseDgv.AllowUserToOrderColumns = true;
            this.courseDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.courseDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.courseDgv.Location = new System.Drawing.Point(196, 53);
            this.courseDgv.Name = "courseDgv";
            this.courseDgv.ReadOnly = true;
            this.courseDgv.Size = new System.Drawing.Size(347, 170);
            this.courseDgv.TabIndex = 67;
            this.courseDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.courseDgv_CellContentClick);
            // 
            // EditCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tutorialDgv);
            this.Controls.Add(this.passwordPb);
            this.Controls.Add(this.passwordPl);
            this.Controls.Add(this.searchTb);
            this.Controls.Add(this.courseDgv);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditCourseForm";
            this.Load += new System.EventHandler(this.EditCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tutorialDgv;
        private System.Windows.Forms.PictureBox passwordPb;
        private System.Windows.Forms.Panel passwordPl;
        private System.Windows.Forms.TextBox searchTb;
        private System.Windows.Forms.DataGridView courseDgv;
    }
}