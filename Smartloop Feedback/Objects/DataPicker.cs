using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Smartloop_Feedback.Objects
{
    public class DatePicker : DateTimePicker
    {
        // Fields
        private Color skinColor = Color.FromArgb(16, 34, 61);
        private Color textColor = Color.FromArgb(193, 193, 193);
        private Color borderColor = Color.FromArgb(254, 0, 57);
        private int borderSize = 0;
        private bool droppedDown = false;
        private Image calendarIcon = Properties.Resources.calendar;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        // Properties
        public Color SkinColor
        {
            get => skinColor;
            set
            {
                skinColor = value;
                calendarIcon = Properties.Resources.calendar;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        // Constructor
        public DatePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 35);
            Font = new Font(Font.Name, 9.5F);
        }

        // Overridden methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true; // Disable typing in the DatePicker
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, Width - 0.5F, Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;

                // Draw surface
                graphics.FillRectangle(skinBrush, clientArea);
                // Draw text
                graphics.DrawString("   " + Text, Font, textBrush, clientArea, textFormat);
                // Draw open calendar icon highlight
                if (droppedDown) graphics.FillRectangle(openIconBrush, iconArea);
                // Draw border
                if (borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);

                // Calculate the rectangle to fit the calendar icon within the icon button area
                float iconX = Width - calendarIconWidth;
                float iconY = (Height - calendarIcon.Height) / 2;
                RectangleF iconRectangle = new RectangleF(iconX, iconY, calendarIconWidth - 9, Height - iconY * 2);

                // Draw icon
                graphics.DrawImage(calendarIcon, iconRectangle);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(Width - iconWidth, 0, iconWidth, Height);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = iconButtonArea.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        // Private methods
        private int GetIconButtonWidth()
        {
            int textWidth = TextRenderer.MeasureText(Text, Font).Width;
            return textWidth <= Width - (calendarIconWidth + 20) ? calendarIconWidth : arrowIconWidth;
        }
    }
}
