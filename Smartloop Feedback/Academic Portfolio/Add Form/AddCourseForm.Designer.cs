namespace Smartloop_Feedback.Academic_Portfolio.Add_Form
{
    partial class AddCourseForm
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
            this.courseDgv = new System.Windows.Forms.DataGridView();
            this.passwordPb = new System.Windows.Forms.PictureBox();
            this.passwordPl = new System.Windows.Forms.Panel();
            this.searchTb = new System.Windows.Forms.TextBox();
            this.tutorialDgv = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.formTitle = new System.Windows.Forms.Label();
            this.exitPb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).BeginInit();
            this.SuspendLayout();
            // 
            // courseDgv
            // 
            this.courseDgv.AllowUserToAddRows = false;
            this.courseDgv.AllowUserToDeleteRows = false;
            this.courseDgv.AllowUserToOrderColumns = true;
            this.courseDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.courseDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.courseDgv.Location = new System.Drawing.Point(38, 98);
            this.courseDgv.Name = "courseDgv";
            this.courseDgv.ReadOnly = true;
            this.courseDgv.Size = new System.Drawing.Size(347, 170);
            this.courseDgv.TabIndex = 59;
            this.courseDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.courseDgv_CellClick);
            // 
            // passwordPb
            // 
            this.passwordPb.Image = global::Smartloop_Feedback.Properties.Resources.search;
            this.passwordPb.Location = new System.Drawing.Point(54, 47);
            this.passwordPb.Name = "passwordPb";
            this.passwordPb.Size = new System.Drawing.Size(27, 27);
            this.passwordPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPb.TabIndex = 62;
            this.passwordPb.TabStop = false;
            // 
            // passwordPl
            // 
            this.passwordPl.BackColor = System.Drawing.Color.White;
            this.passwordPl.Location = new System.Drawing.Point(56, 80);
            this.passwordPl.Name = "passwordPl";
            this.passwordPl.Size = new System.Drawing.Size(250, 1);
            this.passwordPl.TabIndex = 61;
            // 
            // searchTb
            // 
            this.searchTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.searchTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.searchTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.searchTb.HideSelection = false;
            this.searchTb.Location = new System.Drawing.Point(87, 57);
            this.searchTb.Name = "searchTb";
            this.searchTb.Size = new System.Drawing.Size(219, 20);
            this.searchTb.TabIndex = 60;
            this.searchTb.Text = "Search Course";
            this.searchTb.TextChanged += new System.EventHandler(this.searchTb_TextChanged);
            this.searchTb.Enter += new System.EventHandler(this.searchTb_Enter);
            // 
            // tutorialDgv
            // 
            this.tutorialDgv.AllowUserToAddRows = false;
            this.tutorialDgv.AllowUserToDeleteRows = false;
            this.tutorialDgv.AllowUserToOrderColumns = true;
            this.tutorialDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.tutorialDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tutorialDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tutorialDgv.Location = new System.Drawing.Point(14, 314);
            this.tutorialDgv.Name = "tutorialDgv";
            this.tutorialDgv.ReadOnly = true;
            this.tutorialDgv.Size = new System.Drawing.Size(213, 153);
            this.tutorialDgv.TabIndex = 63;
            this.tutorialDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorialDgv_CellContentClick);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.addBtn.Location = new System.Drawing.Point(242, 391);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(152, 52);
            this.addBtn.TabIndex = 64;
            this.addBtn.Text = "Add Course";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.headerPanel.Controls.Add(this.formTitle);
            this.headerPanel.Controls.Add(this.exitPb);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(397, 40);
            this.headerPanel.TabIndex = 65;
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(10, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(193, 21);
            this.formTitle.TabIndex = 7;
            this.formTitle.Text = "Add Course and Tutorial";
            // 
            // exitPb
            // 
            this.exitPb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPb.Image = global::Smartloop_Feedback.Properties.Resources.close;
            this.exitPb.Location = new System.Drawing.Point(364, 10);
            this.exitPb.Name = "exitPb";
            this.exitPb.Size = new System.Drawing.Size(21, 21);
            this.exitPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPb.TabIndex = 9;
            this.exitPb.TabStop = false;
            this.exitPb.Click += new System.EventHandler(this.exitPb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(31, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 36);
            this.label1.TabIndex = 66;
            this.label1.Text = "Add Tutorial";
            // 
            // AddCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(397, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.tutorialDgv);
            this.Controls.Add(this.passwordPb);
            this.Controls.Add(this.passwordPl);
            this.Controls.Add(this.searchTb);
            this.Controls.Add(this.courseDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCourseForm";
            this.Load += new System.EventHandler(this.AddCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorialDgv)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView courseDgv;
        private System.Windows.Forms.PictureBox passwordPb;
        private System.Windows.Forms.Panel passwordPl;
        private System.Windows.Forms.TextBox searchTb;
        private System.Windows.Forms.DataGridView tutorialDgv;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.PictureBox exitPb;
        private System.Windows.Forms.Label label1;
    }
}