using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class CreditPaymentsForm : Form
    {
        private DataTable customersTable = new DataTable();
        private DataTable creditSalesTable = new DataTable();
        private int currentCustomerId = 0;
        private int currentSaleId = 0;
        private decimal currentBalance = 0;

        public CreditPaymentsForm()
        {
            InitializeComponent();
            dtpPaymentDate.Value = DateTime.Now;
            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void CreditPaymentsForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            EnablePaymentSection(false);
        }

        private void LoadCustomers()
        {
            try
            {
                customersTable.Rows.Clear();
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"SELECT CustomerID, Name, Phone, CurrentBalance 
                                     FROM Customers 
                                     WHERE CurrentBalance > 0
                                     ORDER BY Name";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(customersTable);

                    dgvCustomers.DataSource = customersTable;
                    FormatCustomersGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatCustomersGrid()
        {
            dgvCustomers.Columns["CustomerID"].Visible = true;
            dgvCustomers.Columns["Name"].HeaderText = "اسم العميل";
            dgvCustomers.Columns["Name"].Width = 150;
            dgvCustomers.Columns["Phone"].HeaderText = "الهاتف";
            dgvCustomers.Columns["Phone"].Width = 100;
            dgvCustomers.Columns["CurrentBalance"].HeaderText = "الدين الحالي";
            dgvCustomers.Columns["CurrentBalance"].Width = 100;
            dgvCustomers.Columns["CurrentBalance"].DefaultCellStyle.Format = "N2";
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                currentCustomerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                currentBalance = Convert.ToDecimal(dgvCustomers.SelectedRows[0].Cells["CurrentBalance"].Value);
                lblCustomerInfo.Text = "" + (dgvCustomers.SelectedRows[0].Cells["Name"].Value) + " - الدين: " + (currentBalance);
                LoadCreditSales(currentCustomerId);
            }
        }

        // Updated LoadCreditSales method
        private void LoadCreditSales(int customerId)
        {
            try
            {
                creditSalesTable.Rows.Clear();
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT 
                    cs.SaleID AS SaleID,
                    FORMAT(cs.SaleDate, 'dd/MM/yyyy HH:mm') AS SaleDate,
                    p.ProductName AS ProductName,
                    sd.Quantity AS Quantity,
                    CASE 
                        WHEN sd.IsPackage = 1 THEN 'باكدج'
                        ELSE 'قطعة'
                    END AS SaleType,
                    sd.UnitPrice AS UnitPrice,
                    (sd.Quantity * sd.UnitPrice) AS ProductTotal,
                    FORMAT(cs.DueDate, 'dd/MM/yyyy') AS DueDate,
                    cs.TotalAmount AS TotalAmount,
                    cs.PaidAmount AS PaidAmount,
                    (cs.TotalAmount - cs.PaidAmount) AS Balance,
                    CASE 
                        WHEN cs.IsPaid = 1 THEN 'مدفوعة'
                        WHEN GETDATE() > cs.DueDate THEN 'متأخرة'
                        ELSE 'غير مدفوعة'
                    END AS InvoiceStatus,
                    DATEDIFF(DAY, GETDATE(), cs.DueDate) AS DaysRemaining
                FROM CreditSales cs
                JOIN SaleDetails sd ON cs.SaleID = sd.CreditSaleID
                JOIN Products p ON sd.ProductID = p.ProductID
                WHERE cs.CustomerID = @CustomerId 
                AND (cs.PaidAmount < cs.TotalAmount OR cs.IsPaid = 0)
                ORDER BY cs.DueDate, cs.SaleID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(creditSalesTable);

                    dgvCreditSales.DataSource = creditSalesTable;
                    FormatCreditSalesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading credit sales: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Updated FormatCreditSalesGrid method
        // Updated FormatCreditSalesGrid method
        private void FormatCreditSalesGrid()
        {
            // Set grid selection properties
            dgvCreditSales.MultiSelect = false;
            dgvCreditSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Set column display order
            string[] columnOrder = {
        "SaleID", "SaleDate", "DueDate", "DaysRemaining",
        "ProductName", "Quantity", "SaleType", "UnitPrice", "ProductTotal",
        "TotalAmount", "PaidAmount", "Balance", "InvoiceStatus"
    };

            for (int i = 0; i < columnOrder.Length; i++)
            {
                if (dgvCreditSales.Columns.Contains(columnOrder[i]))
                {
                    dgvCreditSales.Columns[columnOrder[i]].DisplayIndex = i;
                }
            }

            // Configure individual columns
            dgvCreditSales.Columns["SaleID"].HeaderText = "رقم الفاتورة";
            dgvCreditSales.Columns["SaleID"].Width = 80;
            dgvCreditSales.Columns["SaleID"].Frozen = true;  // Keep visible when scrolling

            dgvCreditSales.Columns["SaleDate"].HeaderText = "تاريخ الفاتورة";
            dgvCreditSales.Columns["SaleDate"].Width = 120;

            dgvCreditSales.Columns["DueDate"].HeaderText = "تاريخ الاستحقاق";
            dgvCreditSales.Columns["DueDate"].Width = 100;

            dgvCreditSales.Columns["DaysRemaining"].HeaderText = "الأيام المتبقية";
            dgvCreditSales.Columns["DaysRemaining"].Width = 100;


            dgvCreditSales.Columns["ProductName"].HeaderText = "اسم المنتج";
            dgvCreditSales.Columns["ProductName"].Width = 150;


            dgvCreditSales.Columns["Quantity"].HeaderText = "الكمية";
            dgvCreditSales.Columns["Quantity"].Width = 60;


            dgvCreditSales.Columns["SaleType"].HeaderText = "نوع البيع";
            dgvCreditSales.Columns["SaleType"].Width = 80;

            dgvCreditSales.Columns["UnitPrice"].HeaderText = "سعر الوحدة";
            dgvCreditSales.Columns["UnitPrice"].Width = 90;


            dgvCreditSales.Columns["ProductTotal"].HeaderText = "المجموع";
            dgvCreditSales.Columns["ProductTotal"].Width = 90;


            dgvCreditSales.Columns["TotalAmount"].HeaderText = "الإجمالي";
            dgvCreditSales.Columns["TotalAmount"].Width = 100;


            dgvCreditSales.Columns["PaidAmount"].HeaderText = "المدفوع";
            dgvCreditSales.Columns["PaidAmount"].Width = 100;


            dgvCreditSales.Columns["Balance"].HeaderText = "المتبقي";
            dgvCreditSales.Columns["Balance"].Width = 100;


            dgvCreditSales.Columns["InvoiceStatus"].HeaderText = "الحالة";
            dgvCreditSales.Columns["InvoiceStatus"].Width = 100;

            // Additional UI improvements
            dgvCreditSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCreditSales.AllowUserToResizeColumns = true;
            dgvCreditSales.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
        }

        private void dgvCreditSales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCreditSales.SelectedRows.Count > 0)
            {
                currentSaleId = Convert.ToInt32(dgvCreditSales.SelectedRows[0].Cells["SaleID"].Value);
                decimal balance = Convert.ToDecimal(dgvCreditSales.SelectedRows[0].Cells["Balance"].Value);
                txtAmount.Maximum = balance;
                txtAmount.Value = balance;
                EnablePaymentSection(true);
            }
            else
            {
                EnablePaymentSection(false);
            }
        }

        private void EnablePaymentSection(bool enable)
        {
            dtpPaymentDate.Enabled = enable;
            txtAmount.Enabled = enable;
            cmbPaymentMethod.Enabled = enable;
            txtNotes.Enabled = enable;
            btnSavePayment.Enabled = enable;
        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            if (txtAmount.Value <= 0)
            {
                MessageBox.Show("المبلغ يجب أن يكون أكبر من الصفر", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert payment record
                    SqlCommand cmdPayment = new SqlCommand(
                        @"INSERT INTO CreditPayments (SaleID, PaymentDate, Amount, PaymentMethod, Notes)
                          VALUES (@SaleID, @PaymentDate, @Amount, @PaymentMethod, @Notes);
                          SELECT SCOPE_IDENTITY();",
                        conn, transaction);

                    cmdPayment.Parameters.AddWithValue("@SaleID", currentSaleId);
                    cmdPayment.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                    cmdPayment.Parameters.AddWithValue("@Amount", txtAmount.Value);
                    cmdPayment.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.SelectedItem.ToString());
                    cmdPayment.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());

                    int paymentId = Convert.ToInt32(cmdPayment.ExecuteScalar());

                    // 2. Update credit sale
                    SqlCommand cmdSale = new SqlCommand(
                        @"UPDATE CreditSales 
                          SET PaidAmount = PaidAmount + @Amount,
                              IsPaid = CASE WHEN (PaidAmount + @Amount) >= TotalAmount THEN 1 ELSE 0 END
                          WHERE SaleID = @SaleID",
                        conn, transaction);

                    cmdSale.Parameters.AddWithValue("@Amount", txtAmount.Value);
                    cmdSale.Parameters.AddWithValue("@SaleID", currentSaleId);
                    cmdSale.ExecuteNonQuery();

                    // 3. Update customer balance
                    SqlCommand cmdCustomer = new SqlCommand(
                        @"UPDATE Customers 
                          SET CurrentBalance = CurrentBalance - @Amount
                          WHERE CustomerID = @CustomerID",
                        conn, transaction);

                    cmdCustomer.Parameters.AddWithValue("@Amount", txtAmount.Value);
                    cmdCustomer.Parameters.AddWithValue("@CustomerID", currentCustomerId);
                    cmdCustomer.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("تم حفظ الدفعة بنجاح", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh data
                    LoadCustomers();
                    LoadCreditSales(currentCustomerId);
                    ResetPaymentForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("حدث خطأ أثناء حفظ الدفعة: " + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetPaymentForm()
        {
            txtAmount.Value = 0;
            txtNotes.Clear();
            cmbPaymentMethod.SelectedIndex = 0;
            EnablePaymentSection(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            creditSalesTable.Rows.Clear();
            ResetPaymentForm();
            lblCustomerInfo.Text = "حدد عميلاً لعرض تفاصيل الدين";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}