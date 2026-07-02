using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class ProductForm : Form
    {
        private DataTable productsTable = new DataTable();
        private bool isEditMode = false;
        private int currentProductId = 0;

        public ProductForm()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadCategories();
            LoadProducts();
            ConfigureInputHandling();
            EnableForm(false);
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            // Add hidden ProductID column
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "ProductID";
            colId.DataPropertyName = "ProductID";
            colId.HeaderText = "الرقم";
            colId.Visible = false;
            dgvProducts.Columns.Add(colId);

            // Add visible columns (modified for your schema)
            AddColumn("ProductName", "اسم المنتج", 150);
            AddColumn("Barcode", "باركود", 120);
            AddColumn("CategoryName", "الفئة", 120);
            AddCurrencyColumn("PurchasePrice", "سعر الشراء", 100);
            AddCurrencyColumn("SalePrice", "سعر البيع", 100);
            AddColumn("Unit", "Unit", 80);
            AddColumn("ReorderLevel", "مستوى الطلب", 90);
            AddColumn("PackageSize", "حجم الباكج", 80);

            // Styling
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void AddColumn(string name, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = name;
            col.HeaderText = header;
            col.Width = width;
            dgvProducts.Columns.Add(col);
        }

        private void AddCurrencyColumn(string name, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = name;
            col.HeaderText = header;
            col.Width = width;
            col.DefaultCellStyle.Format = "N2";
            dgvProducts.Columns.Add(col);
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName",
                        conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dgvProducts.SuspendLayout();
                productsTable.Clear();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        @"SELECT p.ProductID, p.ProductName, p.Barcode, c.CategoryName,
                 p.PurchasePrice, p.SalePrice, p.Unit, p.ReorderLevel, p.PackageSize
                 FROM Products p
                 JOIN Categories c ON p.CategoryID = c.CategoryID
                 ORDER BY p.ProductName",
                        conn);
                    da.Fill(productsTable);

                    dgvProducts.DataSource = productsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvProducts.ResumeLayout();
                Cursor.Current = Cursors.Default;
            }
        }

        private void ConfigureInputHandling()
        {
            txtPurchasePrice.KeyPress += NumericTextBox_KeyPress;
            txtSalePrice.KeyPress += NumericTextBox_KeyPress;
            txtReorderLevel.KeyPress += IntegerTextBox_KeyPress;
            txtPackageSize.KeyPress += IntegerTextBox_KeyPress;
        }

        private void EnableForm(bool enable)
        {
            txtName.Enabled = enable;
            txtBarcode.Enabled = enable;
            cmbCategory.Enabled = enable;
            txtPurchasePrice.Enabled = enable;
            txtSalePrice.Enabled = enable;
            txtUnit.Enabled = enable;
            txtReorderLevel.Enabled = enable;
            txtPackageSize.Enabled = enable;

            btnSave.Enabled = enable;
            btnNew.Enabled = !enable;
            btnEdit.Enabled = !enable && dgvProducts.SelectedRows.Count > 0;
            btnDelete.Enabled = !enable && dgvProducts.SelectedRows.Count > 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditMode = false;
            EnableForm(true);
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView row = (DataRowView)dgvProducts.SelectedRows[0].DataBoundItem;
            PopulateFields(row);

            EnableForm(true);
            isEditMode = true;
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveProduct();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product name is required!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Barcode is required!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarcode.Focus();
                return false;
            }

            decimal purchasePrice, salePrice;
            int reorderLevel, packageSize;

            if (!decimal.TryParse(txtPurchasePrice.Text, NumberStyles.Currency,
                CultureInfo.InvariantCulture, out purchasePrice))
            {
                MessageBox.Show("Invalid purchase price!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurchasePrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalePrice.Text, NumberStyles.Currency,
                CultureInfo.InvariantCulture, out salePrice))
            {
                MessageBox.Show("Invalid sale price!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalePrice.Focus();
                return false;
            }

            if (!int.TryParse(txtReorderLevel.Text, out reorderLevel))
            {
                MessageBox.Show("Reorder level must be an integer!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReorderLevel.Focus();
                return false;
            }

            if (!int.TryParse(txtPackageSize.Text, out packageSize) || packageSize < 1)
            {
                MessageBox.Show("Package size must be an integer greater than 0!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPackageSize.Focus();
                return false;
            }

            if (salePrice < purchasePrice)
            {
                MessageBox.Show("Sale price cannot be less than purchase price!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalePrice.Focus();
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);

            var confirmResult = MessageBox.Show("Are you sure you want to delete this product?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                SqlCommand cmdDeleteInventory = new SqlCommand(
                                    "DELETE FROM Inventory WHERE ProductID = @ID",
                                    conn, transaction);
                                cmdDeleteInventory.Parameters.AddWithValue("@ID", productId);
                                cmdDeleteInventory.ExecuteNonQuery();

                                SqlCommand cmdDeleteProduct = new SqlCommand(
                                    "DELETE FROM Products WHERE ProductID = @ID",
                                    conn, transaction);
                                cmdDeleteProduct.Parameters.AddWithValue("@ID", productId);

                                int rowsAffected = cmdDeleteProduct.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Product deleted successfully", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadProducts();
                                    ClearFields();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Product not found", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (SqlException sqlEx)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Cannot delete product because it's referenced in other records" + sqlEx.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error while deleting: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database connection error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                DataRowView row = (DataRowView)dgvProducts.Rows[e.RowIndex].DataBoundItem;
                PopulateFields(row);
            }
        }

        private void PopulateFields(DataRowView row)
        {
            if (row != null)
            {
                currentProductId = Convert.ToInt32(row["ProductID"]);
                txtName.Text = row["ProductName"].ToString();
                txtBarcode.Text = row["Barcode"].ToString();

                try
                {
                    cmbCategory.SelectedValue = GetCategoryID(row["CategoryName"].ToString());
                }
                catch
                {
                    if (cmbCategory.Items.Count > 0)
                        cmbCategory.SelectedIndex = 0;
                }

                txtPurchasePrice.Text = Convert.ToDecimal(row["PurchasePrice"]).ToString("N2");
                txtSalePrice.Text = Convert.ToDecimal(row["SalePrice"]).ToString("N2");
                txtUnit.Text = row["Unit"].ToString();
                txtReorderLevel.Text = row["ReorderLevel"].ToString();
                txtPackageSize.Text = row["PackageSize"].ToString();
            }
        }

        private int GetCategoryID(string categoryName)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT CategoryID FROM Categories WHERE CategoryName = @Name",
                    conn);
                cmd.Parameters.AddWithValue("@Name", categoryName);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void ClearFields()
        {
            currentProductId = 0;
            txtName.Clear();
            txtBarcode.Clear();
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
            txtPurchasePrice.Clear();
            txtSalePrice.Clear();
            txtUnit.Clear();
            txtReorderLevel.Clear();
            txtPackageSize.Clear();
            isEditMode = false;
            EnableForm(false);
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar))
            {
                bool isDecimalSeparator = e.KeyChar == '.' || e.KeyChar == ',';
                bool hasDecimal = textBox.Text.Contains(".") || textBox.Text.Contains(",");

                if (!(char.IsDigit(e.KeyChar) || (isDecimalSeparator && !hasDecimal)))
                {
                    e.Handled = true;
                }

                if (isDecimalSeparator)
                {
                    e.KeyChar = '.';
                }
            }
        }

        private void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaveProduct()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        isEditMode ?
                        @"UPDATE Products SET
                    ProductName = @Name,
                    Barcode = @Barcode,
                    CategoryID = @CategoryID,
                    PurchasePrice = @PurchasePrice,
                    SalePrice = @SalePrice,
                    Unit = @Unit,
                    ReorderLevel = @ReorderLevel,
                    PackageSize = @PackageSize
                  WHERE ProductID = @ID" :
                        @"INSERT INTO Products (
                    ProductName, Barcode, CategoryID,
                    PurchasePrice, SalePrice, Unit,
                    ReorderLevel, PackageSize
                  ) VALUES (
                    @Name, @Barcode, @CategoryID,
                    @PurchasePrice, @SalePrice, @Unit,
                    @ReorderLevel, @PackageSize
                  )",
                        conn);

                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@CategoryID", cmbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@PurchasePrice", decimal.Parse(txtPurchasePrice.Text));
                    cmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                    cmd.Parameters.AddWithValue("@Unit", txtUnit.Text.Trim());
                    cmd.Parameters.AddWithValue("@ReorderLevel", int.Parse(txtReorderLevel.Text));
                    cmd.Parameters.AddWithValue("@PackageSize", int.Parse(txtPackageSize.Text));

                    if (isEditMode)
                    {
                        cmd.Parameters.AddWithValue("@ID", currentProductId);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Changes saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProducts();
                    ClearFields();
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        MessageBox.Show("This barcode already exists!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + sqlEx.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string searchTerm = txtSearch.Text.Trim();
                    string query = @"SELECT p.ProductID, p.ProductName, p.Barcode, c.CategoryName, 
                                    p.PurchasePrice, p.SalePrice, p.Unit, p.ReorderLevel, p.PackageSize
                                    FROM Products p
                                    JOIN Categories c ON p.CategoryID = c.CategoryID
                                    WHERE p.ProductName LIKE '%' + @SearchTerm + '%' 
                                    OR p.Barcode LIKE '%' + @SearchTerm + '%'";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvProducts.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
} 