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

namespace Smartloop_Feedback.Forms
{
    public partial class AddEventForm : Form
    {
        public Event newEvent;
        public List<string> courseList;
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

        public AddEventForm(List<string> courseList, Event selectedEvent)
        {
            InitializeComponent();
            this.courseList = courseList;
            this.newEvent = selectedEvent;
            FillCategory();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (newEvent != null)
            {
                eventTb.Text = newEvent.name;
                dateDp.Value = newEvent.date;
                categoryCb.SelectedItem = newEvent.category;
                colourBtn.BackColor = Color.FromArgb(newEvent.color);
            }
        }

        private void FillCategory()
        {
            categoryCb.Items.Add("None");

            foreach(var item in courseList)
            {
                categoryCb.Items.Add(item);
            }

            categoryCb.SelectedIndex = 0;
        }

        private void eventTb_Click(object sender, EventArgs e)
        {
            eventTb.Clear();
        }

        private void colourBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colourBtn.BackColor = colorDialog.Color;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(newEvent != null)
            {
                newEvent.name = eventTb.Text;
                newEvent.date = dateDp.Value;
                newEvent.category = categoryCb.SelectedItem?.ToString();
                newEvent.color = colourBtn.BackColor.ToArgb(); 
            }
            else
            {

                newEvent = new Event(eventTb.Text, dateDp.Value, categoryCb.SelectedItem?.ToString(), colourBtn.BackColor.ToArgb());
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void exitPb_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
