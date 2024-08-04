using System.Drawing;
using System.Windows.Forms;

namespace Smartloop_Feedback.Objects
{
    // Custom DataGridView button cell with hover effect
    public class StyledButtonCell : DataGridViewButtonCell
    {
        private bool isHovered = false; // Indicates whether the cell is hovered

        // Event handler for mouse enter
        protected override void OnMouseEnter(int rowIndex)
        {
            base.OnMouseEnter(rowIndex);
            isHovered = true; // Set hovered state to true
            this.DataGridView.InvalidateCell(this); // Redraw the cell
        }

        // Event handler for mouse leave
        protected override void OnMouseLeave(int rowIndex)
        {
            base.OnMouseLeave(rowIndex);
            isHovered = false; // Set hovered state to false
            this.DataGridView.InvalidateCell(this); // Redraw the cell
            this.DataGridView.Cursor = Cursors.Default; // Reset cursor
        }

        // Custom painting for the button cell
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // Set colors based on hover state
            Color backColor = isHovered ? Color.FromArgb(16, 34, 61) : Color.FromArgb(10, 22, 39);
            Color foreColor = isHovered ? Color.FromArgb(254, 0, 57) : Color.FromArgb(193, 193, 193);

            // Draw cell background and text
            graphics.FillRectangle(new SolidBrush(backColor), cellBounds);
            TextRenderer.DrawText(graphics, (string)value, cellStyle.Font, cellBounds, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Event handler for mouse move
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.DataGridView.Cursor = Cursors.Hand; // Change cursor to hand
        }
    }

    // Custom DataGridView cell for displaying progress
    public class DataGridView : DataGridViewTextBoxCell
    {
        public DataGridView()
        {
            this.ValueType = typeof(int); // Set value type to integer
        }

        // Custom painting for the progress cell
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            if (value != null)
            {
                int progressVal = (int)value; // Get progress value
                float percentage = ((float)progressVal / 100.0f); // Calculate percentage
                Brush backBrush = new SolidBrush(cellStyle.BackColor); // Background brush
                Brush foreBrush = new SolidBrush(Color.FromArgb(254, 0, 57)); // Foreground brush

                // Draw background and progress bar
                graphics.FillRectangle(backBrush, cellBounds);
                graphics.FillRectangle(foreBrush, cellBounds.X, cellBounds.Y, (int)(cellBounds.Width * percentage), cellBounds.Height);

                // Draw progress text
                string text = progressVal.ToString() + "%";
                SizeF textSize = graphics.MeasureString(text, cellStyle.Font);
                float textX = cellBounds.X + (cellBounds.Width - textSize.Width) / 2;
                float textY = cellBounds.Y + (cellBounds.Height - textSize.Height) / 2;
                graphics.DrawString(text, cellStyle.Font, Brushes.Black, textX, textY);
            }
        }
    }
}
