using Smartloop_Feedback.Coordinator_Folder;
using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback.Coordinator
{
    public partial class CoordinatorDash : Form
    {
        private Smartloop_Feedback.Objects.Coordinator coordinator;
        private CoordinatorMain mainForm;

        public CoordinatorDash(Smartloop_Feedback.Objects.Coordinator coordinator, CoordinatorMain mainForm)
        {
            InitializeComponent();
            this.coordinator = coordinator;
            this.mainForm = mainForm;
        }

        private void CoordinatorDash_Load(object sender, EventArgs e)
        {

        }
    }
}
