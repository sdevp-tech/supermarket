using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class SupplierPaymentsForm : Form
    {
        private SqlConnection conn;
        private DataTable purchasesTable;

        public SupplierPaymentsForm()
        {
            InitializeComponent();
            conn = DatabaseHelper.GetConnection();
        }

        private void LoadCreditPurchases()
        {
            try
            {
                conn.Open();
                string query = @"SELECT p.PurchaseID, s.SupplierName, p.Total, p.PaidAmount, 
                                        (p.Total - p.PaidAmount) AS Balance, p.DueDate
                                 FROM Purchases p
                                 INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
                                 WHERE p.IsCredit = 1 AND p.Total > p.PaidAmount";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                purchasesTable = new DataTable();
                da.Fill(purchasesTable);

                dgvPurchases.DataSource = purchasesTable;
                dgvPurchases.Columns["PurchaseID"].HeaderText = "الرقم";
                dgvPurchases.Columns["SupplierName"].HeaderText = "المورد";
                dgvPurchases.Columns["Total"].HeaderText = "اجمالي الكمية";
                dgvPurchases.Columns["PaidAmount"].HeaderText = "كمية الدفع";
                dgvPurchases.Columns["Balance"].HeaderText = "الباقي";
                dgvPurchases.Columns["DueDate"].HeaderText = "تاريخ الاستحقاق";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading credit purchases: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void SupplierPayments_Load(object sender, EventArgs e)
        {
            LoadCreditPurchases();
            dtpDate.Value = DateTime.Today;
        }

        private void dgvPurchases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPurchases.SelectedRows[0];
                txtPurchaseID.Text = row.Cells["PurchaseID"].Value.ToString();
                txtSupplier.Text = row.Cells["SupplierName"].Value.ToString();
                txtTotal.Text = Convert.ToDecimal(row.Cells["Total"].Value).ToString("N2");
                txtPaid.Text = Convert.ToDecimal(row.Cells["PaidAmount"].Value).ToString("N2");

                decimal balance = Convert.ToDecimal(row.Cells["Balance"].Value);
                txtBalance.Text = balance.ToString("N2");
                txtAmount.Text = balance.ToString("N2"); // Default to full balance

                gbPayment.Enabled = true;
            }
            else
            {
                gbPayment.Enabled = false;
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase first.");
                return;
            }
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid payment amount.");
                return;
            }

            int purchaseID = Convert.ToInt32(txtPurchaseID.Text);
            decimal balance = Convert.ToDecimal(txtBalance.Text);

            if (amount > balance)
            {
                MessageBox.Show("Payment amount cannot exceed the balance due.");
                return;
            }

            try
            {
                // Use a new connection for the payment transaction
                using (SqlConnection paymentConn = DatabaseHelper.GetConnection())
                {
                    paymentConn.Open();
                    using (SqlTransaction transaction = paymentConn.BeginTransaction())
                    {
                        try
                        {
                            // Record payment
                            string paymentQuery = @"INSERT INTO SupplierPayments 
                                           (PurchaseID, PaymentDate, Amount, PaymentMethod, Notes)
                                           VALUES (@PurchaseID, @Date, @Amount, @Method, @Notes)";

                            SqlCommand cmd = new SqlCommand(paymentQuery, paymentConn, transaction);
                            cmd.Parameters.AddWithValue("@PurchaseID", purchaseID);
                            cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@Method", cmbMethod.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                            cmd.ExecuteNonQuery();

                            // Update purchase paid amount


                            transaction.Commit();
                            MessageBox.Show("Payment recorded successfully!");

                            // Refresh data using a new connection
                            LoadCreditPurchases();
                            ClearForm();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error recording payment: " + ex.Message);
                        }
                    }
                } // paymentConn is automatically closed here
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtPurchaseID.Clear();
            txtSupplier.Clear();
            txtTotal.Clear();
            txtPaid.Clear();
            txtBalance.Clear();
            txtAmount.Clear();
            txtNotes.Clear();
            cmbMethod.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
        }

        private void gbPayment_Enter(object sender, EventArgs e)
        {

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCreditPurchases();

        }
    }
}