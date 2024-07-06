using Smartloop_Feedback.Academic_Portfolio.Add_Form;
using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class AssessmentForm : Form
    {
        public Assessment assessment;
        public MainForm mainForm;

        public AssessmentForm(Assessment assessment, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.assessment = assessment;
        }

        private void AssessmentForm_Load(object sender, EventArgs e)
        {
            markTb.Text = assessment.finalMark.ToString() + "/" + assessment.mark.ToString();
            dateP.Value = assessment.date;
            descriptionRb.Text = assessment.description;
            PopulateCheckListBox();
        }

        private void PopulateCheckListBox()
        {
            checklistCb.Items.Clear();

            foreach(var item in assessment.checkList)
            {
                // Add item to the CheckedListBox
                int index = checklistCb.Items.Add(item.name);

                // Set the checked state based on isChecked property
                checklistCb.SetItemChecked(index, item.isChecked);
            }

            assessment.CalculateStatus();
            progressBar.Value = assessment.status;
        }

        private void canvasBtn_Click(object sender, EventArgs e)
        {
            OpenUrl(assessment.canvasLink);
        }
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the URL: " + ex.Message);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(0);
        }

        private void itemBtn_Click(object sender, EventArgs e)
        {
            using (var addCheckList = new AddCheckListForm()) // Open the add year form
            {
                if (addCheckList.ShowDialog() == DialogResult.OK) // Check if the dialog result is OK
                {
                    string name = addCheckList.name; // Get the new year's name

                    assessment.checkList.Add(new CheckList(name, assessment.studentId, false, assessment.id));
                    
                    PopulateCheckListBox();
                }
            }
        }

        private void checklistCb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            bool isChecked = e.NewValue == CheckState.Checked;
            assessment.checkList[index].UpdateChecked(isChecked);

            assessment.CalculateStatus();
            progressBar.Value = assessment.status;
        }
    }
}
