using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public partial class academicYearBar : Form
    {
        private mainForm mainForm;
        private int buttonCount = 0;
        Button[] buttons = new Button[5];

        public academicYearBar(mainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            oneBtn.Dock = DockStyle.None;
            oneBtn.Visible = false;
            secondBtn.Dock = DockStyle.None;
            secondBtn.Visible = false;
            thirdBtn.Dock = DockStyle.None;
            thirdBtn.Visible = false;
            fourthBtn.Dock = DockStyle.None;
            fourthBtn.Visible = false;
            fifthBtn.Dock = DockStyle.None;
            fifthBtn.Visible = false;

            addBtn.Visible = true;
            addBtn.Dock = DockStyle.Top;

            buttonCount = 0;

            mainForm.removePannel();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var addYearForm = new addYearForm())
            {
                if(addYearForm.ShowDialog() == DialogResult.OK)
                {
                    string yearName = addYearForm.yearName;

                    if (buttonCount < 5)
                    {
                        buttonCount++;
                        Button btn = null;
                        switch (buttonCount)
                        {
                            case 1:
                                btn = oneBtn;
                                break;
                            case 2:
                                btn = secondBtn;
                                break;
                            case 3:
                                btn = thirdBtn;
                                break;
                            case 4:
                                btn = fourthBtn;
                                break;
                            case 5:
                                btn = fifthBtn;
                                addBtn.Visible = false;
                                break;
                        }

                        if (btn != null)
                        {
                            btn.Visible = true;
                            btn.Text = yearName;
                            buttons[buttonCount - 1] = btn;
                            UpdatePanel();
                        }
                    }
                }
            }
        }

        private void UpdatePanel()
        {
            for (int i = 0; i < buttonCount; i++)
            {
                Controls.Remove(buttons[i]);
            }

            if (buttonCount < 5)
            {
                Controls.Remove(addBtn);
            }
            Controls.Remove(backBtn);

            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Controls.Add(buttons[i]);
                buttons[i].Dock = DockStyle.Top;
            }

            if (buttonCount < 5)
            {
                Controls.Add(addBtn);
                addBtn.Dock = DockStyle.Top;
            }
            Controls.Add(backBtn);
            backBtn.Dock = DockStyle.Top;
        }
    }
}
