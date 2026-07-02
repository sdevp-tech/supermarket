using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LoginForm1
{
    public partial class الزبائن : Form
    {
        public الزبائن()
        {
            InitializeComponent();
            InitializeCustomersForm();
        }

        private void InitializeCustomersForm()
        {
            this.Text = "Customer Management";
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;

            StyleDataGridView(dgvCustomers);
            LoadCustomers();
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(62, 62, 66);
        }

        private void LoadCustomers()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT CustomerID, CustomerName, Phone, Address, CreditLimit, Balance, IsActive FROM Customers";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCustomers.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Customer name is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"INSERT INTO Customers 
                                    (CustomerName, Phone, Address, CreditLimit, Balance, IsActive)
                                    VALUES (@CustomerName, @Phone, @Address, @CreditLimit, @Balance, @IsActive)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", numCreditLimit.Value);
                    cmd.Parameters.AddWithValue("@Balance", numBalance.Value);
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer added successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            numCreditLimit.Value = 0;
            numBalance.Value = 0;
            chkActive.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                numCreditLimit.Value = Convert.ToDecimal(row.Cells["CreditLimit"].Value);
                numBalance.Value = Convert.ToDecimal(row.Cells["Balance"].Value);
                chkActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"UPDATE Customers SET 
                                    CustomerName = @CustomerName,
                                    Phone = @Phone,
                                    Address = @Address,
                                    CreditLimit = @CreditLimit,
                                    Balance = @Balance,
                                    IsActive = @IsActive
                                    WHERE CustomerID = @CustomerID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", numCreditLimit.Value);
                    cmd.Parameters.AddWithValue("@Balance", numBalance.Value);
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked);
                    cmd.Parameters.AddWithValue("@CustomerID",
                        dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer updated successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
