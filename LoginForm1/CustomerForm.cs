using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
            SetupDataGridView();
            SetArabicLanguage();
        }

        private void SetArabicLanguage()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            lblTitle.Text = "إدارة العملاء";
            grpCustomerInfo.Text = "بيانات العميل";
            lblName.Text = "الاسم:";
            lblPhone.Text = "الهاتف:";
            lblAddress.Text = "العنوان:";
            lblCreditLimit.Text = "حد الائتمان:";
            lblBalance.Text = "الرصيد الحالي:";
            btnAdd.Text = "إضافة";
            btnUpdate.Text = "تحديث";
            btnDelete.Text = "حذف";
            btnClear.Text = "مسح";
        }

        private void SetupDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            AddColumn("CustomerID", "رقم العميل", 100);
            AddColumn("Name", "الاسم", 200);
            AddColumn("Phone", "الهاتف", 150);
            AddColumn("Address", "العنوان", 250);
            AddCurrencyColumn("CreditLimit", "حد الائتمان", 120);
            AddCurrencyColumn("CurrentBalance", "الرصيد", 120);
        }

        private void AddColumn(string name, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = header;
            col.DataPropertyName = name;
            col.Width = width;
            dgvCustomers.Columns.Add(col);
        }

        private void AddCurrencyColumn(string name, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = header;
            col.DataPropertyName = name;
            col.DefaultCellStyle.Format = "N2";
            col.Width = width;
            dgvCustomers.Columns.Add(col);
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT CustomerID, Name, Phone, Address, CreditLimit, CurrentBalance FROM Customers",
                        conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCustomers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل العملاء: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم العميل");
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Customers (Name, Phone, Address, CreditLimit, CurrentBalance) " +
                        "VALUES (@Name, @Phone, @Address, @CreditLimit, @CurrentBalance)",
                        conn);

                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", decimal.Parse(txtCreditLimit.Text));
                    cmd.Parameters.AddWithValue("@CurrentBalance", decimal.Parse(txtBalance.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("تمت إضافة العميل بنجاح");
                    LoadCustomers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في إضافة العميل: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("الرجاء تحديد عميل للتحديث");
                return;
            }

            try
            {
                int customerId = (int)dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Customers SET Name = @Name, Phone = @Phone, Address = @Address, " +
                        "CreditLimit = @CreditLimit, CurrentBalance = @CurrentBalance " +
                        "WHERE CustomerID = @CustomerID",
                        conn);

                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", decimal.Parse(txtCreditLimit.Text));
                    cmd.Parameters.AddWithValue("@CurrentBalance", decimal.Parse(txtBalance.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("تم تحديث بيانات العميل بنجاح");
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحديث العميل: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("الرجاء تحديد عميل للحذف");
                return;
            }

            if (MessageBox.Show("هل أنت متأكد من حذف العميل المحدد؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int customerId = (int)dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value;

                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM Customers WHERE CustomerID = @CustomerID",
                            conn);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("تم حذف العميل بنجاح");
                        LoadCustomers();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في حذف العميل: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCreditLimit.Text = "0";
            txtBalance.Text = "0";
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtCreditLimit.Text = row.Cells["CreditLimit"].Value.ToString();
                txtBalance.Text = row.Cells["CurrentBalance"].Value.ToString();
            }
        }

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


    }
}