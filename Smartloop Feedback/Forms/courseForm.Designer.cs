namespace Smartloop_Feedback.Forms
{
    partial class courseForm
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
            this.assessmentLv = new System.Windows.Forms.ListView();
            this.nameCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.markCh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.SuspendLayout();
            // 
            // assessmentLv
            // 
            this.assessmentLv.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.assessmentLv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.assessmentLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCh,
            this.typeCh,
            this.dateCh,
            this.statusCh,
            this.markCh});
            this.assessmentLv.Font = new System.Drawing.Font("Aptos", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assessmentLv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.assessmentLv.FullRowSelect = true;
            this.assessmentLv.GridLines = true;
            this.assessmentLv.HideSelection = false;
            this.assessmentLv.HotTracking = true;
            this.assessmentLv.HoverSelection = true;
            this.assessmentLv.Location = new System.Drawing.Point(12, 109);
            this.assessmentLv.MultiSelect = false;
            this.assessmentLv.Name = "assessmentLv";
            this.assessmentLv.OwnerDraw = true;
            this.assessmentLv.Size = new System.Drawing.Size(352, 264);
            this.assessmentLv.TabIndex = 1;
            this.assessmentLv.UseCompatibleStateImageBehavior = false;
            this.assessmentLv.View = System.Windows.Forms.View.Details;
            this.assessmentLv.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.assessmentLv_DrawColumnHeader);
            this.assessmentLv.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.assessmentLv_DrawSubItem);
            this.assessmentLv.ItemActivate += new System.EventHandler(this.assessmentLv_ItemActivate);
            // 
            // nameCh
            // 
            this.nameCh.Text = "Name";
            this.nameCh.Width = 73;
            // 
            // typeCh
            // 
            this.typeCh.Text = "Type";
            this.typeCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateCh
            // 
            this.dateCh.Text = "Date";
            this.dateCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusCh
            // 
            this.statusCh.Text = "Status";
            // 
            // markCh
            // 
            this.markCh.Text = "Mark";
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
            this.label1.Location = new System.Drawing.Point(477, 94);
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
            this.label2.Location = new System.Drawing.Point(399, 187);
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
            this.label3.Location = new System.Drawing.Point(506, 187);
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
            this.label4.Location = new System.Drawing.Point(623, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 38);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mark needed\r\n for HD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentPl
            // 
            this.currentPl.BackColor = System.Drawing.Color.White;
            this.currentPl.Location = new System.Drawing.Point(473, 155);
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
            this.currentTb.Location = new System.Drawing.Point(473, 133);
            this.currentTb.Name = "currentTb";
            this.currentTb.ReadOnly = true;
            this.currentTb.Size = new System.Drawing.Size(200, 20);
            this.currentTb.TabIndex = 15;
            this.currentTb.TabStop = false;
            // 
            // cPl
            // 
            this.cPl.BackColor = System.Drawing.Color.White;
            this.cPl.Location = new System.Drawing.Point(398, 250);
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
            this.cTb.Location = new System.Drawing.Point(398, 228);
            this.cTb.Name = "cTb";
            this.cTb.ReadOnly = true;
            this.cTb.Size = new System.Drawing.Size(100, 20);
            this.cTb.TabIndex = 17;
            this.cTb.TabStop = false;
            // 
            // dPl
            // 
            this.dPl.BackColor = System.Drawing.Color.White;
            this.dPl.Location = new System.Drawing.Point(510, 250);
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
            this.dTb.Location = new System.Drawing.Point(510, 228);
            this.dTb.Name = "dTb";
            this.dTb.ReadOnly = true;
            this.dTb.Size = new System.Drawing.Size(100, 20);
            this.dTb.TabIndex = 19;
            this.dTb.TabStop = false;
            // 
            // hdPl
            // 
            this.hdPl.BackColor = System.Drawing.Color.White;
            this.hdPl.Location = new System.Drawing.Point(627, 250);
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
            this.hdTb.Location = new System.Drawing.Point(627, 228);
            this.hdTb.Name = "hdTb";
            this.hdTb.ReadOnly = true;
            this.hdTb.Size = new System.Drawing.Size(100, 20);
            this.hdTb.TabIndex = 19;
            this.hdTb.TabStop = false;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.addBtn.Location = new System.Drawing.Point(61, 379);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(252, 52);
            this.addBtn.TabIndex = 21;
            this.addBtn.Text = "Add Assessment";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // canvasBtn
            // 
            this.canvasBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.canvasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canvasBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvasBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.canvasBtn.Location = new System.Drawing.Point(431, 301);
            this.canvasBtn.Name = "canvasBtn";
            this.canvasBtn.Size = new System.Drawing.Size(135, 52);
            this.canvasBtn.TabIndex = 22;
            this.canvasBtn.Text = "Canvas";
            this.canvasBtn.UseVisualStyleBackColor = false;
            this.canvasBtn.Click += new System.EventHandler(this.canvasBtn_Click);
            // 
            // handbookBtn
            // 
            this.handbookBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.handbookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handbookBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handbookBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.handbookBtn.Location = new System.Drawing.Point(572, 301);
            this.handbookBtn.Name = "handbookBtn";
            this.handbookBtn.Size = new System.Drawing.Size(135, 52);
            this.handbookBtn.TabIndex = 24;
            this.handbookBtn.Text = "UTS Handbook";
            this.handbookBtn.UseVisualStyleBackColor = false;
            this.handbookBtn.Click += new System.EventHandler(this.handbookBtn_Click);
            // 
            // courseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(746, 477);
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
            this.Controls.Add(this.assessmentLv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "courseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "courseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView assessmentLv;
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
        private System.Windows.Forms.ColumnHeader nameCh;
        private System.Windows.Forms.ColumnHeader typeCh;
        private System.Windows.Forms.ColumnHeader dateCh;
        private System.Windows.Forms.ColumnHeader statusCh;
        private System.Windows.Forms.ColumnHeader markCh;
    }
}