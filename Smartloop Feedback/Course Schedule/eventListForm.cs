﻿using Smartloop_Feedback.Objects;
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

namespace Smartloop_Feedback.Forms
{
    public partial class EventListForm : Form
    {
        public Event selectedEvent { get; private set; }
        public bool IsEdit { get; private set; }
        public bool IsDelete { get; private set; }

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

        public EventListForm(List<Event> eventList)
        {
            InitializeComponent();
            eventLst.DataSource = eventList;
            eventLst.DisplayMember = "Name";
            formTitle.Text = eventList[0].Date.ToString("dd MMMM yyyy");
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (eventLst.SelectedItem != null)
            {
                selectedEvent = (Event)eventLst.SelectedItem;
                IsEdit = true;
                IsDelete = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (eventLst.SelectedItem != null)
            {
                selectedEvent = (Event)eventLst.SelectedItem;
                IsEdit = false;
                IsDelete = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
