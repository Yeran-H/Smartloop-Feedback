using Smartloop_Feedback.Coordinator;
using Smartloop_Feedback.Objects;
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

namespace Smartloop_Feedback.Coordinator_Folder
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

        private Smartloop_Feedback.Objects.Coordinator coordinator;
        public int[] position;

        public CoordinatorMain(Smartloop_Feedback.Objects.Coordinator coordinator)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            navPl.Height = dashboardBtn.Height;
            navPl.Top = dashboardBtn.Top;
            navPl.Left = dashboardBtn.Left;
            dashboardBtn.BackColor = Color.FromArgb(16, 34, 61);

            this.coordinator = coordinator;
            position = new int[5];
            MainPannel(0);
        }

        public void MainPannel(int num)
        {
            switch (num)
            {
                case 0:
                    titleLb.Text = "Dashboard";
                    this.formLoaderPl.Controls.Clear();

                    CoordinatorDash dashboard = new CoordinatorDash(coordinator, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    dashboard.FormBorderStyle = FormBorderStyle.None;
                    this.formLoaderPl.Controls.Add(dashboard);
                    dashboard.Show();
                    break;
                case 1:
                    titleLb.Text = coordinator.CourseList[position[0]].Name;
                    this.formLoaderPl.Controls.Clear();

                    CoordinatorCourse course = new CoordinatorCourse(coordinator.CourseList[position[0]], this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    course.FormBorderStyle = FormBorderStyle.None;
                    this.formLoaderPl.Controls.Add(course);
                    course.Show();
                    break;
            }

        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            navPl.Height = dashboardBtn.Height;
            navPl.Top = dashboardBtn.Top;
            navPl.Left = dashboardBtn.Left;
            dashboardBtn.BackColor = Color.FromArgb(16, 34, 61);

            MainPannel(0);
        }

        private void centrePannel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void centrePannel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void centrePannel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
