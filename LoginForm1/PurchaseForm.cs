using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class PurchaseForm : Form
    {
        private DataTable purchasesTable = new DataTable();
        private bool isEditMode = false;
        private int currentPurchaseId = 0;
        private bool isFormEnabled = false; // Track form state

        public PurchaseForm()
        {
            InitializeComponent();
            LoadSuppliers();
            LoadProducts();
            LoadUsers();
            ConfigureInputHandling();
            SetupDataGridView();
            EnableForm(false); // Start in view mode
            LoadPurchases();
            txtBarcode.KeyPress += TxtBarcode_KeyPress;

            // Handle grid selection changes
            dgvPurchases.SelectionChanged += DgvPurchases_SelectionChanged;
        }

        #region Setup Controls
        private void ConfigureInputHandling()
        {
            txtUnitPrice.KeyPress += NumericTextBox_KeyPress;
            txtPackagePrice.KeyPress += NumericTextBox_KeyPress;
            txtPaidAmount.KeyPress += NumericTextBox_KeyPress;
            txtQuantity.KeyPress += IntegerTextBox_KeyPress;
        }

        private void SetupDataGridView()
        {
            dgvPurchases.AutoGenerateColumns = false;
            dgvPurchases.Columns.Clear();

            // Add columns to DataGridView
            dgvPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PurchaseID",
                DataPropertyName = "PurchaseID",
                HeaderText = "معرف الشراء",
                Visible = false
            });

            AddColumn("PurchaseDate", "التاريخ", 120);
            AddColumn("ProductName", "المنتج", 150);
            AddColumn("SupplierName", "المورد", 150);
            AddColumn("Quantity", "الكمية", 70);
            AddCurrencyColumn("UnitPrice", "سعر الوحدة", 90);
            AddColumn("IsPackage", "عبوة", 50, "هل هي عبوة؟");
            AddCurrencyColumn("PackagePrice", "سعر العبوة", 90);
            AddCurrencyColumn("Total", "الإجمالي", 90);
            AddColumn("IsCredit", "آجل", 50, "شراء آجل");
            AddColumn("DueDate", "تاريخ الاستحقاق", 100);
            AddCurrencyColumn("PaidAmount", "المدفوع", 90);
            AddColumn("Notes", "ملاحظات", 150);
            AddColumn("UserName", "المستخدم", 100);
            AddColumn("BatchNumber", "رقم الدفعة", 100);
            AddColumn("ExpiryDate", "تاريخ الانتهاء", 100);
        }

        private void AddColumn(string prop, string header, int width, string tooltip = null)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = prop,
                DataPropertyName = prop,
                HeaderText = header,
                Width = width
            };

            if (tooltip != null)
                col.ToolTipText = tooltip;

            dgvPurchases.Columns.Add(col);
        }

        private void AddCurrencyColumn(string prop, string header, int width)
        {
            dgvPurchases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = prop,
                DataPropertyName = prop,
                HeaderText = header,
                Width = width,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
        }
        #endregion

        #region Data Loading
        private void LoadSuppliers()
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var da = new SqlDataAdapter(
                "SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cmbSupplier.DataSource = dt;
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierID";
            }
        }

        private void LoadProducts()
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var da = new SqlDataAdapter(
                "SELECT ProductID, ProductName, Barcode FROM Products ORDER BY ProductName", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cmbProduct.DataSource = dt;
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductID";
            }
        }

        private void LoadUsers()
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var da = new SqlDataAdapter(
                "SELECT UserID, Username FROM Users ORDER BY Username", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cmbUser.DataSource = dt;
                cmbUser.DisplayMember = "Username";
                cmbUser.ValueMember = "UserID";
            }
        }

        private void LoadPurchases()
        {
            purchasesTable.Clear();
            const string sql = @"
SELECT 
    p.PurchaseID, 
    FORMAT(p.PurchaseDate, 'dd/MM/yyyy') AS 'PurchaseDate',
    pr.ProductName, 
    s.SupplierName,
    p.Quantity, 
    p.UnitPrice, 
    p.IsPackage, 
    p.PackagePrice, 
    p.Total,
    p.IsCredit, 
    FORMAT(p.DueDate, 'dd/MM/yyyy') AS 'DueDate',
    p.PaidAmount, 
    p.Notes, 
    u.Username AS UserName,
    p.BatchNumber, 
    FORMAT(p.ExpiryDate, 'dd/MM/yyyy') AS 'ExpiryDate'
FROM Purchases p
JOIN Products pr ON pr.ProductID = p.ProductID
JOIN Suppliers s ON s.SupplierID = p.SupplierID
JOIN Users u ON u.UserID = p.UserID
ORDER BY p.PurchaseDate DESC";

            using (var conn = DatabaseHelper.GetConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(purchasesTable);
                dgvPurchases.DataSource = purchasesTable;
            }
        }
        #endregion

        #region Save/Update
        private void SavePurchase()
        {
            if (!ValidateInputs()) return;

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = isEditMode
                    ? @"UPDATE Purchases SET
                          PurchaseDate=@Date,ProductID=@ProductID,SupplierID=@SupplierID,
                          Quantity=@Quantity,UnitPrice=@UnitPrice,IsPackage=@IsPackage,
                          PackagePrice=@PackagePrice,Notes=@Notes,UserID=@UserID,
                          IsCredit=@IsCredit,DueDate=@DueDate,PaidAmount=@PaidAmount,
                          BatchNumber=@BatchNumber,ExpiryDate=@ExpiryDate
                        WHERE PurchaseID=@ID"
                    : @"INSERT INTO Purchases (
                          PurchaseDate,ProductID,SupplierID,
                          Quantity,UnitPrice,IsPackage,
                          PackagePrice,Notes,UserID,
                          IsCredit,DueDate,PaidAmount,
                          BatchNumber,ExpiryDate
                        ) VALUES (
                          @Date,@ProductID,@SupplierID,
                          @Quantity,@UnitPrice,@IsPackage,
                          @PackagePrice,@Notes,@UserID,
                          @IsCredit,@DueDate,@PaidAmount,
                          @BatchNumber,@ExpiryDate
                        )";

                cmd.Parameters.AddWithValue("@Date", dtpPurchaseDate.Value);
                cmd.Parameters.AddWithValue("@ProductID", cmbProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@SupplierID", cmbSupplier.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@IsPackage", chkIsPackage.Checked);

                if (chkIsPackage.Checked)
                {
                    var pp = decimal.Parse(txtPackagePrice.Text, CultureInfo.InvariantCulture);
                    cmd.Parameters.AddWithValue("@PackagePrice", pp);
                    cmd.Parameters.AddWithValue("@UnitPrice", 0m);
                }
                else
                {
                    var up = decimal.Parse(txtUnitPrice.Text, CultureInfo.InvariantCulture);
                    cmd.Parameters.AddWithValue("@UnitPrice", up);
                    cmd.Parameters.AddWithValue("@PackagePrice", 0m);
                }

                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
                cmd.Parameters.AddWithValue("@UserID", cmbUser.SelectedValue);
                cmd.Parameters.AddWithValue("@IsCredit", chkIsCredit.Checked);

                if (chkIsCredit.Checked)
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                else
                    cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@PaidAmount", decimal.Parse(txtPaidAmount.Text, CultureInfo.InvariantCulture));

                if (!string.IsNullOrWhiteSpace(txtBatchNumber.Text))
                    cmd.Parameters.AddWithValue("@BatchNumber", txtBatchNumber.Text.Trim());
                else
                    cmd.Parameters.AddWithValue("@BatchNumber", DBNull.Value);

                cmd.Parameters.AddWithValue("@ExpiryDate", dtpExpiryDate.Value.Date);

                if (isEditMode)
                    cmd.Parameters.AddWithValue("@ID", currentPurchaseId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("تم حفظ عملية الشراء بنجاح", "نجاح",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadPurchases();
            ClearFields();
        }
        #endregion

        #region Form State Management
        private void ClearFields()
        {
            currentPurchaseId = 0;
            dtpPurchaseDate.Value = DateTime.Today;
            if (cmbProduct.Items.Count > 0) cmbProduct.SelectedIndex = 0;
            if (cmbSupplier.Items.Count > 0) cmbSupplier.SelectedIndex = 0;
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            chkIsPackage.Checked = false;
            txtPackagePrice.Text = "";
            txtNotes.Text = "";
            if (cmbUser.Items.Count > 0) cmbUser.SelectedIndex = 0;
            chkIsCredit.Checked = false;
            dtpDueDate.Value = DateTime.Today;
            txtPaidAmount.Text = "0.00";
            txtBatchNumber.Text = "";
            dtpExpiryDate.Value = DateTime.Today;
            txtBarcode.Text = "";
            isEditMode = false;
            EnableForm(false);
        }

        private void EnableForm(bool enable)
        {
            isFormEnabled = enable;

            // Enable/disable form controls
            dtpPurchaseDate.Enabled = enable;
            cmbProduct.Enabled = enable;
            cmbSupplier.Enabled = enable;
            txtQuantity.Enabled = enable;
            txtUnitPrice.Enabled = enable && !chkIsPackage.Checked;
            txtPackagePrice.Enabled = enable && chkIsPackage.Checked;
            txtNotes.Enabled = enable;
            cmbUser.Enabled = enable;
            chkIsPackage.Enabled = enable;
            chkIsCredit.Enabled = enable;
            txtBatchNumber.Enabled = enable;
            dtpExpiryDate.Enabled = enable;
            txtBarcode.Enabled = enable;

            // Update credit controls
            UpdateCreditControlsState();

            // Update button states
            UpdateButtonStates();
        }

        private void UpdateCreditControlsState()
        {
            bool creditEnabled = isFormEnabled && chkIsCredit.Checked;

            lblDueDate.Visible = chkIsCredit.Checked;
            dtpDueDate.Visible = chkIsCredit.Checked;
            lblPaidAmount.Visible = chkIsCredit.Checked;
            txtPaidAmount.Visible = chkIsCredit.Checked;

            dtpDueDate.Enabled = creditEnabled;
            txtPaidAmount.Enabled = creditEnabled;
        }

        private void UpdateButtonStates()
        {
            btnNew.Enabled = !isFormEnabled;
            btnEdit.Enabled = !isFormEnabled && dgvPurchases.SelectedRows.Count > 0;
            btnSave.Enabled = isFormEnabled;
            btnDelete.Enabled = !isFormEnabled && dgvPurchases.SelectedRows.Count > 0;
            btnSearch.Enabled = !isFormEnabled;
        }
        #endregion

        #region Validation
        private bool ValidateInputs()
        {
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("الرجاء اختيار منتج", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return false;
            }

            if (cmbSupplier.SelectedValue == null)
            {
                MessageBox.Show("الرجاء اختيار مورد", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }

            int qty;
            if (!int.TryParse(txtQuantity.Text, out qty) || qty <= 0)
            {
                MessageBox.Show("يجب أن تكون الكمية عدد صحيح موجب", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            if (chkIsPackage.Checked)
            {
                decimal pp;
                if (!decimal.TryParse(txtPackagePrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pp)
                    || pp <= 0)
                {
                    MessageBox.Show("يجب أن يكون سعر العبوة رقم موجب", "تحذير",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPackagePrice.Focus();
                    return false;
                }
            }
            else
            {
                decimal up;
                if (!decimal.TryParse(txtUnitPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out up)
                    || up <= 0)
                {
                    MessageBox.Show("يجب أن يكون سعر الوحدة رقم موجب", "تحذير",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitPrice.Focus();
                    return false;
                }
            }

            if (chkIsCredit.Checked)
            {
                decimal paid;
                if (!decimal.TryParse(txtPaidAmount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out paid)
                    || paid < 0)
                {
                    MessageBox.Show("يجب أن يكون المبلغ المدفوع رقم غير سالب", "تحذير",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaidAmount.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Lookup Methods
        private int GetProductID(string name)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT ProductID FROM Products WHERE ProductName = @n", conn))
            {
                cmd.Parameters.AddWithValue("@n", name);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetSupplierID(string name)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT SupplierID FROM Suppliers WHERE SupplierName = @n", conn))
            {
                cmd.Parameters.AddWithValue("@n", name);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetUserID(string name)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT UserID FROM Users WHERE Username = @n", conn))
            {
                cmd.Parameters.AddWithValue("@n", name);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        #endregion

        #region Barcode Handling
        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchByBarcode();
                e.Handled = true;
            }
        }

        private void btnSearchByBarcode_Click(object sender, EventArgs e)
        {
            SearchByBarcode();
        }

        private void SearchByBarcode()
        {
            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("الرجاء إدخال باركود المنتج", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT ProductID, ProductName FROM Products WHERE Barcode = @barcode", conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int productId = reader.GetInt32(0);
                            string productName = reader.GetString(1);

                            foreach (DataRowView item in cmbProduct.Items)
                            {
                                if (Convert.ToInt32(item["ProductID"]) == productId)
                                {
                                    cmbProduct.SelectedItem = item;
                                    break;
                                }
                            }

                            txtQuantity.Enabled = true;
                            txtQuantity.Focus();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على منتج بهذا الباركود", "تحذير",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtBarcode.SelectAll();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في البحث عن الباركود: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditMode = false;
            EnableForm(true);
            dtpPurchaseDate.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count == 0) return;
            isEditMode = true;
            EnableForm(true);
            dtpPurchaseDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePurchase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvPurchases.SelectedRows[0].Cells["PurchaseID"].Value);
            if (MessageBox.Show("هل تريد حذف عملية الشراء هذه؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Purchases WHERE PurchaseID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadPurchases();
                ClearFields();
            }
        }

        private void DgvPurchases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dgvPurchases.SelectedRows[0].DataBoundItem;
                PopulateFields(row);
            }
            UpdateButtonStates();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim();
            const string sql = @"
SELECT 
    p.PurchaseID, 
    FORMAT(p.PurchaseDate, 'dd/MM/yyyy') AS 'PurchaseDate',
    pr.ProductName, 
    s.SupplierName,
    p.Quantity, 
    p.UnitPrice, 
    p.IsPackage, 
    p.PackagePrice, 
    p.Total,
    p.IsCredit, 
    FORMAT(p.DueDate, 'dd/MM/yyyy') AS 'DueDate',
    p.PaidAmount, 
    p.Notes, 
    u.Username AS UserName,
    p.BatchNumber, 
    FORMAT(p.ExpiryDate, 'dd/MM/yyyy') AS 'ExpiryDate'
FROM Purchases p
JOIN Products pr ON pr.ProductID = p.ProductID
JOIN Suppliers s ON s.SupplierID = p.SupplierID
JOIN Users u ON u.UserID = p.UserID
WHERE pr.ProductName LIKE '%' + @term + '%'
   OR s.SupplierName LIKE '%' + @term + '%'
   OR p.Notes LIKE '%' + @term + '%'
ORDER BY p.PurchaseDate DESC";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@term", term);
                var dt = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                dgvPurchases.DataSource = dt;
            }
        }

        private void chkIsPackage_CheckedChanged(object sender, EventArgs e)
        {
            txtPackagePrice.Enabled = isFormEnabled && chkIsPackage.Checked;
            txtUnitPrice.Enabled = isFormEnabled && !chkIsPackage.Checked;
            if (chkIsPackage.Checked) txtUnitPrice.Clear();
            else txtPackagePrice.Clear();
        }

        private void chkIsCredit_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCreditControlsState();
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tb.Text.Contains("."))
                e.Handled = true;
        }

        private void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region Field Population
        private void PopulateFields(DataRowView row)
        {
            try
            {
                currentPurchaseId = Convert.ToInt32(row["PurchaseID"]);
                dtpPurchaseDate.Value = Convert.ToDateTime(row["PurchaseDate"]);

                int productId = GetProductID(row["ProductName"].ToString());
                foreach (DataRowView item in cmbProduct.Items)
                {
                    if (Convert.ToInt32(item["ProductID"]) == productId)
                    {
                        cmbProduct.SelectedItem = item;
                        break;
                    }
                }

                int supplierId = GetSupplierID(row["SupplierName"].ToString());
                foreach (DataRowView item in cmbSupplier.Items)
                {
                    if (Convert.ToInt32(item["SupplierID"]) == supplierId)
                    {
                        cmbSupplier.SelectedItem = item;
                        break;
                    }
                }

                txtQuantity.Text = row["Quantity"].ToString();
                chkIsPackage.Checked = Convert.ToBoolean(row["IsPackage"]);

                if (chkIsPackage.Checked)
                {
                    txtPackagePrice.Text = Convert.ToDecimal(row["PackagePrice"]).ToString("N2");
                    txtUnitPrice.Text = "";
                }
                else
                {
                    txtUnitPrice.Text = Convert.ToDecimal(row["UnitPrice"]).ToString("N2");
                    txtPackagePrice.Text = "";
                }

                txtNotes.Text = row["Notes"].ToString();

                int userId = GetUserID(row["UserName"].ToString());
                foreach (DataRowView item in cmbUser.Items)
                {
                    if (Convert.ToInt32(item["UserID"]) == userId)
                    {
                        cmbUser.SelectedItem = item;
                        break;
                    }
                }

                chkIsCredit.Checked = Convert.ToBoolean(row["IsCredit"]);

                if (row["DueDate"] != DBNull.Value)
                    dtpDueDate.Value = Convert.ToDateTime(row["DueDate"]);

                txtPaidAmount.Text = row["PaidAmount"] == DBNull.Value
                    ? "0.00"
                    : Convert.ToDecimal(row["PaidAmount"]).ToString("N2");

                txtBatchNumber.Text = row["BatchNumber"] == DBNull.Value
                    ? ""
                    : row["BatchNumber"].ToString();

                if (row["ExpiryDate"] != DBNull.Value)
                    dtpExpiryDate.Value = Convert.ToDateTime(row["ExpiryDate"]);

                txtBarcode.Text = "";
                UpdateCreditControlsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}