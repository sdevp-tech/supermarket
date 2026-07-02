using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class frmInventoryMain : Form
    {
        private Form currentChildForm;
        private Button currentButton;

        public frmInventoryMain()
        {
            InitializeComponent();
            OpenChildForm(new المخزان()); // Open default form
            HighlightButton(btnInventory);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Hide();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void HighlightButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(40, 40, 55);
                currentButton.ForeColor = Color.Gainsboro;
            }

            currentButton = btn;
            currentButton.BackColor = Color.FromArgb(0, 122, 204);
            currentButton.ForeColor = Color.White;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new المخزان());
            HighlightButton((Button)sender);
        }

        private void btnExpiry_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmExpiryDashboard());
            HighlightButton((Button)sender);
        }

        private void btnBatches_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInventoryBatches());
            HighlightButton((Button)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BarcodeLabelGenerator());
            HighlightButton((Button)sender);
        }
    }
}