using Smartloop_Feedback.Objects;
using System.Windows.Forms;
using System;

namespace Smartloop_Feedback.Dashboard
{
    partial class DashboardForm
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
            this.eventDgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.filterCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.courseDgv = new System.Windows.Forms.DataGridView();
            this.filterBtn = new System.Windows.Forms.Button();
            this.fromDp = new Smartloop_Feedback.Objects.DatePicker();
            this.toDp = new Smartloop_Feedback.Objects.DatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datePl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.eventDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // eventDgv
            // 
            this.eventDgv.AllowUserToAddRows = false;
            this.eventDgv.AllowUserToDeleteRows = false;
            this.eventDgv.AllowUserToOrderColumns = true;
            this.eventDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.eventDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDgv.Location = new System.Drawing.Point(371, 118);
            this.eventDgv.Name = "eventDgv";
            this.eventDgv.ReadOnly = true;
            this.eventDgv.Size = new System.Drawing.Size(355, 207);
            this.eventDgv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aptos", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(537, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Filter:";
            // 
            // filterCb
            // 
            this.filterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCb.FormattingEnabled = true;
            this.filterCb.Items.AddRange(new object[] {
            "Year",
            "Semester"});
            this.filterCb.Location = new System.Drawing.Point(591, 91);
            this.filterCb.Name = "filterCb";
            this.filterCb.Size = new System.Drawing.Size(121, 21);
            this.filterCb.TabIndex = 41;
            this.filterCb.SelectedIndexChanged += new System.EventHandler(this.filterCb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.label2.Font = new System.Drawing.Font("Aptos", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(509, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 27);
            this.label2.TabIndex = 46;
            this.label2.Text = "Events";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.label3.Font = new System.Drawing.Font("Aptos", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label3.Location = new System.Drawing.Point(101, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 27);
            this.label3.TabIndex = 53;
            this.label3.Text = "Current Course";
            // 
            // courseDgv
            // 
            this.courseDgv.AllowUserToAddRows = false;
            this.courseDgv.AllowUserToDeleteRows = false;
            this.courseDgv.AllowUserToOrderColumns = true;
            this.courseDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.courseDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDgv.Location = new System.Drawing.Point(10, 118);
            this.courseDgv.Name = "courseDgv";
            this.courseDgv.ReadOnly = true;
            this.courseDgv.Size = new System.Drawing.Size(355, 207);
            this.courseDgv.TabIndex = 47;
            this.courseDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.courseDgv_CellClick);
            // 
            // filterBtn
            // 
            this.filterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.filterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.filterBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.filterBtn.Location = new System.Drawing.Point(479, 413);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(141, 52);
            this.filterBtn.TabIndex = 56;
            this.filterBtn.Text = "Filter";
            this.filterBtn.UseVisualStyleBackColor = false;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // fromDp
            // 
            this.fromDp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.fromDp.BorderSize = 0;
            this.fromDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.fromDp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDp.Location = new System.Drawing.Point(396, 362);
            this.fromDp.MinimumSize = new System.Drawing.Size(4, 35);
            this.fromDp.Name = "fromDp";
            this.fromDp.Size = new System.Drawing.Size(130, 35);
            this.fromDp.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.fromDp.TabIndex = 57;
            this.fromDp.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            // 
            // toDp
            // 
            this.toDp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.toDp.BorderSize = 0;
            this.toDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.toDp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDp.Location = new System.Drawing.Point(582, 362);
            this.toDp.MinimumSize = new System.Drawing.Size(4, 35);
            this.toDp.Name = "toDp";
            this.toDp.Size = new System.Drawing.Size(130, 35);
            this.toDp.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.toDp.TabIndex = 58;
            this.toDp.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.label4.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label4.Location = new System.Drawing.Point(621, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.label5.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label5.Location = new System.Drawing.Point(430, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 60;
            this.label5.Text = "From";
            // 
            // datePl
            // 
            this.datePl.BackColor = System.Drawing.Color.White;
            this.datePl.Location = new System.Drawing.Point(396, 403);
            this.datePl.Name = "datePl";
            this.datePl.Size = new System.Drawing.Size(120, 1);
            this.datePl.TabIndex = 61;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(586, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 1);
            this.panel1.TabIndex = 62;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datePl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toDp);
            this.Controls.Add(this.fromDp);
            this.Controls.Add(this.filterBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.courseDgv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterCb);
            this.Controls.Add(this.eventDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView eventDgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox filterCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView courseDgv;
        private Button filterBtn;
        private DatePicker fromDp;
        private DatePicker toDp;
        private Label label4;
        private Label label5;
        private Panel datePl;
        private Panel panel1;
    }
}
