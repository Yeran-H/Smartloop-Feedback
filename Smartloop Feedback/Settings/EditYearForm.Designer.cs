namespace Smartloop_Feedback.Settings
{
    partial class EditYearForm
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
            this.yearTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addSemsterBtn = new System.Windows.Forms.Button();
            this.semesterCb = new System.Windows.Forms.CheckedListBox();
            this.deleteSemesterBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.yearTb = new System.Windows.Forms.TextBox();
            this.yearPl = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.yearTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yearTab
            // 
            this.yearTab.Controls.Add(this.tabPage1);
            this.yearTab.Location = new System.Drawing.Point(0, 0);
            this.yearTab.Name = "yearTab";
            this.yearTab.SelectedIndex = 0;
            this.yearTab.Size = new System.Drawing.Size(742, 450);
            this.yearTab.TabIndex = 0;
            this.yearTab.SelectedIndexChanged += new System.EventHandler(this.yearTab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.addSemsterBtn);
            this.panel2.Controls.Add(this.semesterCb);
            this.panel2.Controls.Add(this.deleteSemesterBtn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(412, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 384);
            this.panel2.TabIndex = 19;
            // 
            // addSemsterBtn
            // 
            this.addSemsterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.addSemsterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addSemsterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSemsterBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSemsterBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.addSemsterBtn.Location = new System.Drawing.Point(23, 191);
            this.addSemsterBtn.Name = "addSemsterBtn";
            this.addSemsterBtn.Size = new System.Drawing.Size(211, 55);
            this.addSemsterBtn.TabIndex = 18;
            this.addSemsterBtn.Text = "Add";
            this.addSemsterBtn.UseVisualStyleBackColor = false;
            this.addSemsterBtn.Click += new System.EventHandler(this.addSemsterBtn_Click);
            // 
            // semesterCb
            // 
            this.semesterCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.semesterCb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.semesterCb.Font = new System.Drawing.Font("Aptos", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.semesterCb.FormattingEnabled = true;
            this.semesterCb.Items.AddRange(new object[] {
            "Summer",
            "Autumn",
            "Winter",
            "Spring"});
            this.semesterCb.Location = new System.Drawing.Point(52, 71);
            this.semesterCb.Name = "semesterCb";
            this.semesterCb.Size = new System.Drawing.Size(146, 104);
            this.semesterCb.TabIndex = 17;
            // 
            // deleteSemesterBtn
            // 
            this.deleteSemesterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.deleteSemesterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteSemesterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSemesterBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSemesterBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.deleteSemesterBtn.Location = new System.Drawing.Point(23, 261);
            this.deleteSemesterBtn.Name = "deleteSemesterBtn";
            this.deleteSemesterBtn.Size = new System.Drawing.Size(211, 55);
            this.deleteSemesterBtn.TabIndex = 13;
            this.deleteSemesterBtn.Text = "Delete";
            this.deleteSemesterBtn.UseVisualStyleBackColor = false;
            this.deleteSemesterBtn.Click += new System.EventHandler(this.deleteSemesterBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 36);
            this.label1.TabIndex = 16;
            this.label1.Text = "Semester";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.yearTb);
            this.panel1.Controls.Add(this.yearPl);
            this.panel1.Controls.Add(this.deleteBtn);
            this.panel1.Controls.Add(this.updateBtn);
            this.panel1.Location = new System.Drawing.Point(84, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 384);
            this.panel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(90, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 36);
            this.label2.TabIndex = 17;
            this.label2.Text = "Year";
            // 
            // yearTb
            // 
            this.yearTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.yearTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.yearTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.yearTb.HideSelection = false;
            this.yearTb.Location = new System.Drawing.Point(21, 80);
            this.yearTb.Name = "yearTb";
            this.yearTb.Size = new System.Drawing.Size(206, 20);
            this.yearTb.TabIndex = 11;
            this.yearTb.TabStop = false;
            this.yearTb.Text = "Eg. 2024";
            // 
            // yearPl
            // 
            this.yearPl.BackColor = System.Drawing.Color.White;
            this.yearPl.Location = new System.Drawing.Point(21, 102);
            this.yearPl.Name = "yearPl";
            this.yearPl.Size = new System.Drawing.Size(206, 1);
            this.yearPl.TabIndex = 12;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.deleteBtn.Location = new System.Drawing.Point(16, 261);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(211, 55);
            this.deleteBtn.TabIndex = 14;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.updateBtn.Location = new System.Drawing.Point(16, 191);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(211, 55);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // EditYearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(742, 450);
            this.Controls.Add(this.yearTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditYearForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditYear";
            this.Load += new System.EventHandler(this.EditYearForm_Load);
            this.yearTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl yearTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel yearPl;
        private System.Windows.Forms.TextBox yearTb;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button deleteSemesterBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addSemsterBtn;
        private System.Windows.Forms.CheckedListBox semesterCb;
    }
}