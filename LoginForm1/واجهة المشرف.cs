using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm1
{
    public partial class واجهة_المشرف : Form
    {
        private Button currentButton;
        private Form activeForm;
        private Color activeColor = Color.FromArgb(0, 122, 204);
        private Color menuColor = Color.FromArgb(40, 40, 55);
        private List<Button> menuButtons = new List<Button>();

        public واجهة_المشرف()
        {
            InitializeComponent();
            CustomizeUI();
            lblTitle.Text = "الرئيسية";
        }

        private void CustomizeUI()
        {
            // Modern styling
            this.BackColor = Color.FromArgb(32, 32, 45);
            panelMenu.BackColor = menuColor;
            panelLogo.BackColor = Color.FromArgb(30, 30, 45);
            panelTitleBar.BackColor = activeColor;
            panelDesktopPanel.BackColor = Color.FromArgb(45, 45, 60);

            // Configure scrollable panel
            scrollPanel.BackColor = menuColor;

            // Add all buttons to list
            menuButtons.AddRange(new Button[] {
                button1, button9, button2, button4, button5, button6, button7,
                button8, button3, button10, button12, button13, button14,
                button15, button16, button11
            });

            // Position buttons vertically
            PositionMenuButtons();
        }

        private void PositionMenuButtons()
        {
            int yPos = 10;
            foreach (Button btn in menuButtons)
            {
                // Configure button appearance
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = menuColor;
                btn.ForeColor = Color.Gainsboro;
                btn.Font = new Font("Tahoma", 10, FontStyle.Bold);
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.TextAlign = ContentAlignment.MiddleLeft;

                // Set button position and size
                btn.Location = new Point(10, yPos);
                btn.Size = new Size(scrollPanel.Width - 30, 60);

                // Add to scroll panel
                scrollPanel.Controls.Add(btn);

                // Increment Y position
                yPos += 65;
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null && currentButton != (Button)btnSender)
            {
                DisableButtons();
                currentButton = (Button)btnSender;
                currentButton.BackColor = activeColor;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new Font("Tahoma", 10.5F, FontStyle.Bold);
                panelTitleBar.BackColor = activeColor;
                panelLogo.BackColor = Color.FromArgb(0, 92, 174);
            }
        }

        private void DisableButtons()
        {
            foreach (Button btn in menuButtons)
            {
                btn.BackColor = menuColor;
                btn.ForeColor = Color.Gainsboro;
                btn.Font = new Font("Tahoma", 10, FontStyle.Bold);
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktopPanel.Controls.Add(childForm);
            panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        // Traditional button click handlers
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.ProductForm(), sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.POS(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.PurchaseForm(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.CustomerForm(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.تقارير_المبيعات(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.الفئات(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.الموردون(), sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.UserManagementForm(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.IncomeCalculatorForm(), sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.DatabaseSettingsForm(), sender);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.CreditPaymentsForm(), sender);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.SupplierPaymentsForm(), sender);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.ExpensesForm(), sender);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.CashBoxForm(), sender);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.frmReports(), sender);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm1.frmInventoryMain(), sender);


        }

        private void واجهة_المشرف_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackupDatabase();
        }

        private void BackupDatabase()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("EXEC [dbo].[BackupDatabaseNow]", conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("تم إنشاء نسخة احتياطية بنجاح!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل النسخ الاحتياطي: " + ex.Message);
            }
        }

        // Add this empty method to satisfy the designer
        private void واجهة_المشرف_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }
    }
}