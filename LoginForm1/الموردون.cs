using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace LoginForm1
{
    public partial class الموردون : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataTable suppliersTable;
        private bool isEditMode = false;

        public الموردون()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadSuppliers();
            SetupDataGridView();
        }

        private void InitializeDatabaseConnection()
        {
            conn = DatabaseHelper.GetConnection();
        }

        private void SetupDataGridView()
        {
            dgvSuppliers.AutoGenerateColumns = false;
            dgvSuppliers.Columns.Clear();

            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SupplierName",
                HeaderText = "اسم المورد",
                Name = "colName",
                Width = 150
            });

            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "العنوان",
                Name = "colAddress",
                Width = 200
            });

            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "رقم التلفون",
                Name = "colPhone",
                Width = 100
            });

            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "البريد الاكتروني",
                Name = "colEmail",
                Width = 150
            });
        }

        private void LoadSuppliers()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Suppliers", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                suppliersTable = new DataTable();
                adapter.Fill(suppliersTable);
                dgvSuppliers.DataSource = suppliersTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditMode = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    DataRow row;
                    if (isEditMode)
                    {
                        row = ((DataRowView)dgvSuppliers.CurrentRow.DataBoundItem).Row;
                    }
                    else
                    {
                        row = suppliersTable.NewRow();
                    }

                    row["SupplierName"] = txtName.Text;
                    row["Address"] = txtAddress.Text;
                    row["Phone"] = txtPhone.Text;
                    row["Email"] = txtEmail.Text;

                    if (!isEditMode) suppliersTable.Rows.Add(row);

                    adapter.Update(suppliersTable);
                    LoadSuppliers();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving supplier: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete this supplier?", "Confirm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        dgvSuppliers.Rows.RemoveAt(dgvSuppliers.CurrentRow.Index);
                        adapter.Update(suppliersTable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting supplier: " + ex.Message);
                    }
                }
            }
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtAddress.Text = row.Cells["colAddress"].Value.ToString();
                txtPhone.Text = row.Cells["colPhone"].Value.ToString();
                txtEmail.Text = row.Cells["colEmail"].Value.ToString();
                isEditMode = true;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Supplier name is required!");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            isEditMode = false;
        }

    }
}