using System.Windows.Forms;

namespace Smartloop_Feedback.Dashboard
{
    partial class DashboardForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.eventDgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.filterCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.courseDgv = new System.Windows.Forms.DataGridView();
            this.toggleViewBtn = new System.Windows.Forms.Button();
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
            this.eventDgv.Location = new System.Drawing.Point(371, 141);
            this.eventDgv.Name = "eventDgv";
            this.eventDgv.ReadOnly = true;
            this.eventDgv.Size = new System.Drawing.Size(355, 333);
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
            // toggleViewBtn
            // 
            this.toggleViewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.toggleViewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleViewBtn.Font = new System.Drawing.Font("Aptos Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.toggleViewBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.toggleViewBtn.Location = new System.Drawing.Point(390, 80);
            this.toggleViewBtn.Name = "toggleViewBtn";
            this.toggleViewBtn.Size = new System.Drawing.Size(141, 52);
            this.toggleViewBtn.TabIndex = 56;
            this.toggleViewBtn.Text = "Toggle to Hourly View";
            this.toggleViewBtn.UseVisualStyleBackColor = false;
            this.toggleViewBtn.Click += new System.EventHandler(this.toggleViewBtn_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(750, 477);
            this.Controls.Add(this.toggleViewBtn);
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
        private Button toggleViewBtn;
    }
}
