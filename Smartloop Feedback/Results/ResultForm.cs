using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Smartloop_Feedback.Results
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            (resultDgv.DataSource as System.Data.DataTable).DefaultView.RowFilter =
                string.Format("Course LIKE '%{0}%' OR Grade LIKE '%{0}%' OR Score LIKE '%{0}%'", searchTextBox.Text);

        }

        private void resultDgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = resultDgv.Columns[e.ColumnIndex];
            if (resultDgv.SortOrder == System.Windows.Forms.SortOrder.Ascending)
            {
                resultDgv.Sort(column, System.ComponentModel.ListSortDirection.Descending);
            }
            else
            {
                resultDgv.Sort(column, System.ComponentModel.ListSortDirection.Ascending);
            }
        }
    }
}
