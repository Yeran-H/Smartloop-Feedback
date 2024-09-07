using Smartloop_Feedback.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Coordinator
{
    public partial class CoordinatorMain : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHieghtEllipse
        );

        // Fields to track dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public CoordinatorMain()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            navPl.Height = dashboardBtn.Height;
            navPl.Top = dashboardBtn.Top;
            navPl.Left = dashboardBtn.Left;
            dashboardBtn.BackColor = Color.FromArgb(16, 34, 61);
            MainPannel(0);
        }

        public void MainPannel(int num)
        {
            switch (num)
            {
                case 0:
                    titleLb.Text = "Dashboard";
                    this.formLoaderPl.Controls.Clear();

                    DashboardForm dashboard = new DashboardForm(coordinator, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    dashboard.FormBorderStyle = FormBorderStyle.None;
                    this.formLoaderPl.Controls.Add(dashboard);
                    dashboard.Show();
                    break;
            }

        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
