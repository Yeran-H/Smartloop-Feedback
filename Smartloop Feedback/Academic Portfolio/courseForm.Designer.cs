namespace Smartloop_Feedback.Forms
{
    partial class CourseForm
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentPl = new System.Windows.Forms.Panel();
            this.currentTb = new System.Windows.Forms.TextBox();
            this.cPl = new System.Windows.Forms.Panel();
            this.cTb = new System.Windows.Forms.TextBox();
            this.dPl = new System.Windows.Forms.Panel();
            this.dTb = new System.Windows.Forms.TextBox();
            this.hdPl = new System.Windows.Forms.Panel();
            this.hdTb = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.canvasBtn = new System.Windows.Forms.Button();
            this.handbookBtn = new System.Windows.Forms.Button();
            this.eventBtn = new System.Windows.Forms.Button();
            this.eventDgv = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.assessmentDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.eventDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assessmentDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLb
            // 
            this.titleLb.AutoSize = true;
            this.titleLb.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.titleLb.Location = new System.Drawing.Point(81, 70);
            this.titleLb.Name = "titleLb";
            this.titleLb.Size = new System.Drawing.Size(156, 36);
            this.titleLb.TabIndex = 2;
            this.titleLb.Text = "Asessment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(496, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Marks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(418, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 38);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mark needed\r\n for C";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(525, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 38);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mark needed\r\n for D";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Aptos", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label4.Location = new System.Drawing.Point(642, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 38);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mark needed\r\n for HD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentPl
            // 
            this.currentPl.BackColor = System.Drawing.Color.White;
            this.currentPl.Location = new System.Drawing.Point(492, 77);
            this.currentPl.Name = "currentPl";
            this.currentPl.Size = new System.Drawing.Size(200, 1);
            this.currentPl.TabIndex = 16;
            // 
            // currentTb
            // 
            this.currentTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.currentTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.currentTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.currentTb.HideSelection = false;
            this.currentTb.Location = new System.Drawing.Point(492, 55);
            this.currentTb.Name = "currentTb";
            this.currentTb.ReadOnly = true;
            this.currentTb.Size = new System.Drawing.Size(200, 20);
            this.currentTb.TabIndex = 15;
            this.currentTb.TabStop = false;
            this.toolTip1.SetToolTip(this.currentTb, "Total Current Marks for Course");
            // 
            // cPl
            // 
            this.cPl.BackColor = System.Drawing.Color.White;
            this.cPl.Location = new System.Drawing.Point(417, 172);
            this.cPl.Name = "cPl";
            this.cPl.Size = new System.Drawing.Size(100, 1);
            this.cPl.TabIndex = 18;
            // 
            // cTb
            // 
            this.cTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.cTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.cTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.cTb.HideSelection = false;
            this.cTb.Location = new System.Drawing.Point(417, 150);
            this.cTb.Name = "cTb";
            this.cTb.ReadOnly = true;
            this.cTb.Size = new System.Drawing.Size(100, 20);
            this.cTb.TabIndex = 17;
            this.cTb.TabStop = false;
            this.toolTip1.SetToolTip(this.cTb, "Marks needed for Credit");
            // 
            // dPl
            // 
            this.dPl.BackColor = System.Drawing.Color.White;
            this.dPl.Location = new System.Drawing.Point(529, 172);
            this.dPl.Name = "dPl";
            this.dPl.Size = new System.Drawing.Size(100, 1);
            this.dPl.TabIndex = 20;
            // 
            // dTb
            // 
            this.dTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.dTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.dTb.HideSelection = false;
            this.dTb.Location = new System.Drawing.Point(529, 150);
            this.dTb.Name = "dTb";
            this.dTb.ReadOnly = true;
            this.dTb.Size = new System.Drawing.Size(100, 20);
            this.dTb.TabIndex = 19;
            this.dTb.TabStop = false;
            this.toolTip1.SetToolTip(this.dTb, "Marks needed for Distinction");
            // 
            // hdPl
            // 
            this.hdPl.BackColor = System.Drawing.Color.White;
            this.hdPl.Location = new System.Drawing.Point(646, 172);
            this.hdPl.Name = "hdPl";
            this.hdPl.Size = new System.Drawing.Size(100, 1);
            this.hdPl.TabIndex = 20;
            // 
            // hdTb
            // 
            this.hdTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.hdTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hdTb.Font = new System.Drawing.Font("Aptos", 12F);
            this.hdTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.hdTb.HideSelection = false;
            this.hdTb.Location = new System.Drawing.Point(646, 150);
            this.hdTb.Name = "hdTb";
            this.hdTb.ReadOnly = true;
            this.hdTb.Size = new System.Drawing.Size(100, 20);
            this.hdTb.TabIndex = 19;
            this.hdTb.TabStop = false;
            this.toolTip1.SetToolTip(this.hdTb, "Marks needed for High Distinction");
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.addBtn.Location = new System.Drawing.Point(68, 388);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(252, 52);
            this.addBtn.TabIndex = 21;
            this.addBtn.Text = "Add Assessment";
            this.toolTip1.SetToolTip(this.addBtn, "Click to Add Assessment");
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // canvasBtn
            // 
            this.canvasBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.canvasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canvasBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvasBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.canvasBtn.Location = new System.Drawing.Point(445, 193);
            this.canvasBtn.Name = "canvasBtn";
            this.canvasBtn.Size = new System.Drawing.Size(135, 52);
            this.canvasBtn.TabIndex = 22;
            this.canvasBtn.Text = "Canvas";
            this.toolTip1.SetToolTip(this.canvasBtn, "Click to go Canvas Page");
            this.canvasBtn.UseVisualStyleBackColor = false;
            this.canvasBtn.Click += new System.EventHandler(this.canvasBtn_Click);
            // 
            // handbookBtn
            // 
            this.handbookBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.handbookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handbookBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handbookBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.handbookBtn.Location = new System.Drawing.Point(586, 193);
            this.handbookBtn.Name = "handbookBtn";
            this.handbookBtn.Size = new System.Drawing.Size(135, 52);
            this.handbookBtn.TabIndex = 24;
            this.handbookBtn.Text = "UTS Handbook";
            this.toolTip1.SetToolTip(this.handbookBtn, "Click to view Handbook");
            this.handbookBtn.UseVisualStyleBackColor = false;
            this.handbookBtn.Click += new System.EventHandler(this.handbookBtn_Click);
            // 
            // eventBtn
            // 
            this.eventBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.eventBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.eventBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.eventBtn.Location = new System.Drawing.Point(511, 421);
            this.eventBtn.Name = "eventBtn";
            this.eventBtn.Size = new System.Drawing.Size(141, 52);
            this.eventBtn.TabIndex = 40;
            this.eventBtn.Text = "Add Event";
            this.toolTip1.SetToolTip(this.eventBtn, "Click to Add Event");
            this.eventBtn.UseVisualStyleBackColor = false;
            this.eventBtn.Click += new System.EventHandler(this.eventBtn_Click);
            // 
            // eventDgv
            // 
            this.eventDgv.AllowUserToAddRows = false;
            this.eventDgv.AllowUserToDeleteRows = false;
            this.eventDgv.AllowUserToOrderColumns = true;
            this.eventDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.eventDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDgv.Location = new System.Drawing.Point(445, 251);
            this.eventDgv.Name = "eventDgv";
            this.eventDgv.ReadOnly = true;
            this.eventDgv.Size = new System.Drawing.Size(276, 164);
            this.eventDgv.TabIndex = 48;
            this.toolTip1.SetToolTip(this.eventDgv, "Click on Name to Edit Event");
            this.eventDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventDgv_CellClick);
            // 
            // assessmentDgv
            // 
            this.assessmentDgv.AllowUserToAddRows = false;
            this.assessmentDgv.AllowUserToDeleteRows = false;
            this.assessmentDgv.AllowUserToOrderColumns = true;
            this.assessmentDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.assessmentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assessmentDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.assessmentDgv.Location = new System.Drawing.Point(12, 109);
            this.assessmentDgv.Name = "assessmentDgv";
            this.assessmentDgv.ReadOnly = true;
            this.assessmentDgv.Size = new System.Drawing.Size(400, 262);
            this.assessmentDgv.TabIndex = 49;
            this.toolTip1.SetToolTip(this.assessmentDgv, "Click on Name to Edit Assessment");
            this.assessmentDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assessmentDgv_CellClick);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.assessmentDgv);
            this.Controls.Add(this.eventDgv);
            this.Controls.Add(this.eventBtn);
            this.Controls.Add(this.handbookBtn);
            this.Controls.Add(this.canvasBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.hdPl);
            this.Controls.Add(this.hdTb);
            this.Controls.Add(this.dPl);
            this.Controls.Add(this.dTb);
            this.Controls.Add(this.cPl);
            this.Controls.Add(this.cTb);
            this.Controls.Add(this.currentPl);
            this.Controls.Add(this.currentTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "courseForm";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assessmentDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label titleLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel currentPl;
        private System.Windows.Forms.TextBox currentTb;
        private System.Windows.Forms.Panel cPl;
        private System.Windows.Forms.TextBox cTb;
        private System.Windows.Forms.Panel dPl;
        private System.Windows.Forms.TextBox dTb;
        private System.Windows.Forms.Panel hdPl;
        private System.Windows.Forms.TextBox hdTb;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button canvasBtn;
        private System.Windows.Forms.Button handbookBtn;
        private System.Windows.Forms.Button eventBtn;
        private System.Windows.Forms.DataGridView eventDgv;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView assessmentDgv;
    }
}