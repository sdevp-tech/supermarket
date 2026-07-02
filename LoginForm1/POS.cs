using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class POS : Form
    {
        private List<SaleDetail> currentSale = new List<SaleDetail>();
        private decimal totalAmount = 0m;
        private decimal amountPaid = 0m;
        private decimal changeDue = 0m;
        private bool isPackageMode = false;
        private Label lblCreditInfo;
        private TextBox txtProductName;
        private ListBox lstProductSuggestions;
        private List<ProductMatch> allProducts = new List<ProductMatch>();

        public POS()
        {
            InitializeComponent();

            InitializeProductNameSearch();
            InitializeCreditInfoLabel();
            SetupDataGridView();
            InitializeForm();
            LoadCustomers();
            LoadPaymentMethods();
            LoadAllProducts();

            // Delay first positioning to let WinForms finish layout
            var t = new Timer { Interval = 100 };
            t.Tick += (s, e) =>
            {
                t.Stop();
                PositionLabels();
            };
            t.Start();

            this.HandleCreated += (s, e) => PositionLabels();
            this.Resize += (s, e) => PositionLabels();
        }

        private void InitializeProductNameSearch()
        {
            // create the product-name textbox
            txtProductName = new TextBox
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(256, 39),
                Location = new Point(360, 15)
            };
            txtProductName.TextChanged += txtProductName_TextChanged;
            txtProductName.KeyDown += txtProductName_KeyDown;
            txtProductName.KeyPress += txtProductName_KeyPress;

            // create the suggestions ListBox
            lstProductSuggestions = new ListBox
            {
                Visible = false,
                Font = new Font("Segoe UI", 11F),
                BorderStyle = BorderStyle.FixedSingle,
                Width = txtProductName.Width,
                Height = 150
            };
            lstProductSuggestions.KeyDown += lstProductSuggestions_KeyDown;
            lstProductSuggestions.DoubleClick += lstProductSuggestions_DoubleClick;

            // add them into the header panel (txtBarcode is already there via designer)
            panelHeader.Controls.Add(txtProductName);
            panelHeader.Controls.Add(lstProductSuggestions);
        }

        private void PositionLabels()
        {
            if (txtBarcode == null || txtProductName == null || label7 == null || label8 == null)
                return;

            // align the static labels beside their textboxes
            label8.Location = new Point(
                txtBarcode.Right + 10,
                txtBarcode.Top + (txtBarcode.Height - label8.Height) / 2
            );

            label7.Location = new Point(
                txtProductName.Right + 10,
                txtProductName.Top + (txtProductName.Height - label7.Height) / 2
            );

            // position the dropdown below txtProductName and bring to front
            lstProductSuggestions.Location = new Point(
                txtProductName.Left,
                txtProductName.Bottom + 2
            );
            lstProductSuggestions.BringToFront();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            loadTheme();
            txtBarcode.Focus();
            PositionLabels();
        }

        private void InitializeForm()
        {

            txtAmountPaid.KeyPress += new KeyPressEventHandler(txtAmountPaid_KeyPress);
            txtProductName.KeyPress += new KeyPressEventHandler(txtProductName_KeyPress);
            txtBarcode.KeyPress += new KeyPressEventHandler(txtBarcode_KeyPress);


            
            btnRemoveItem.Click += btnRemoveItem_Click;
            btnVoidSale.Click += btnVoidSale_Click;
            
            btnClose.Click += btnClose_Click;
            chkPackageMode.CheckedChanged += chkPackageMode_CheckedChanged;
            cmbPaymentMethod.SelectedIndexChanged += cmbPaymentMethod_SelectedIndexChanged;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;

            // if user clicks outside, hide suggestions
            panelContainer.Click += (s, e) => lstProductSuggestions.Visible = false;
            panelFooter.Click += (s, e) => lstProductSuggestions.Visible = false;
            dgvSaleItems.Click += (s, e) => lstProductSuggestions.Visible = false;

            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblPackageMode.Text = "وضع التعبئة: وحدة";

            var clock = new Timer { Interval = 1000 };
            clock.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            clock.Start();
        }
        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                decimal paid;
                if (decimal.TryParse(txtAmountPaid.Text, out paid))
                {
                    e.Handled = true;
                    amountPaid = paid;
                    changeDue = amountPaid - totalAmount;
                    lblChange.Text = changeDue.ToString("N2");

                    if (changeDue >= 0)
                    {
                        btnProcessPayment.Enabled = true;
                        btnProcessPayment.Focus();
                    }
                    else
                    {
                        MessageBox.Show("المبلغ المدفوع غير كافي");
                    }
                }
            }}
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            string txt = txtProductName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txt))
            {
                lstProductSuggestions.Visible = false;
                return;
            }

            var matches = allProducts.FindAll(p =>
                p.ProductName.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0);

            if (matches.Count > 0)
            {
                lstProductSuggestions.DataSource = matches;
                lstProductSuggestions.DisplayMember = "ProductName";
                lstProductSuggestions.ValueMember = "ProductID";
                lstProductSuggestions.Visible = true;
                lstProductSuggestions.BringToFront();
                PositionLabels();
            }
            else
            {
                lstProductSuggestions.Visible = false;
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lstProductSuggestions.Visible)
            {
                lstProductSuggestions.SelectedIndex = 0;
                lstProductSuggestions.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstProductSuggestions.Visible && lstProductSuggestions.SelectedItem != null)
                    SelectProductFromList();
                else if (!string.IsNullOrWhiteSpace(txtProductName.Text))
                    AddOrUpdateProductByName(txtProductName.Text.Trim());

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstProductSuggestions.Visible = false;
                txtProductName.Focus();
            }
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
        }

        private void lstProductSuggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstProductSuggestions.SelectedItem != null)
                SelectProductFromList();
            else if (e.KeyCode == Keys.Escape)
            {
                lstProductSuggestions.Visible = false;
                txtProductName.Focus();
            }
        }

        private void lstProductSuggestions_DoubleClick(object sender, EventArgs e)
        {
            if (lstProductSuggestions.SelectedItem != null)
                SelectProductFromList();
        }

        private void SelectProductFromList()
        {
            var pm = (ProductMatch)lstProductSuggestions.SelectedItem;
            AddProductToSale(pm);
            lstProductSuggestions.Visible = false;
            txtProductName.Clear();
            txtProductName.Focus();
        }

        private void LoadAllProducts()
        {
            allProducts.Clear();
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    @"SELECT p.ProductID, p.ProductName, p.SalePrice,
                             i.Quantity AS Stock, p.Unit, p.PackageSize
                      FROM Products p
                      LEFT JOIN Inventory i ON p.ProductID = i.ProductID", conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            allProducts.Add(new ProductMatch
                            {
                                ProductID = rdr.GetInt32(0),
                                ProductName = rdr.GetString(1),
                                SalePrice = rdr.GetDecimal(2),
                                Stock = rdr.IsDBNull(3) ? 0 : rdr.GetInt32(3),
                                Unit = rdr.GetString(4),
                                PackageSize = rdr.GetInt32(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المنتجات: " + ex.Message);
            }
        }

        private bool ConfirmNegativeSale(string name, int req, int avail)
        {
            return MessageBox.Show(
                $"تحذير: الكمية المطلوبة ({req}) من {name} تفوق المخزون ({avail}).\nهل تستمر؟",
                "تحذير الكمية",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) == DialogResult.Yes;
        }

        private void AddOrUpdateProductByName(string productName)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    @"SELECT p.ProductID, p.ProductName, p.SalePrice,
                             i.Quantity AS Stock, p.Unit, p.PackageSize
                      FROM Products p
                      LEFT JOIN Inventory i ON p.ProductID = i.ProductID
                      WHERE p.ProductName LIKE @nm", conn))
                {
                    cmd.Parameters.AddWithValue("@nm", "%" + productName + "%");
                    conn.Open();

                    var matches = new List<ProductMatch>();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            matches.Add(new ProductMatch
                            {
                                ProductID = rdr.GetInt32(0),
                                ProductName = rdr.GetString(1),
                                SalePrice = rdr.GetDecimal(2),
                                Stock = rdr.IsDBNull(3) ? 0 : rdr.GetInt32(3),
                                Unit = rdr.GetString(4),
                                PackageSize = rdr.GetInt32(5)
                            });
                        }
                    }

                    if (matches.Count == 1)
                        AddProductToSale(matches[0]);
                    else if (matches.Count > 1)
                        ShowProductSelectionDialog(matches);
                    else
                        MessageBox.Show("لم يتم العثور على المنتج");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void ShowProductSelectionDialog(List<ProductMatch> products)
        {
            var dlg = new Form
            {
                Text = "اختر المنتج",
                Size = new Size(500, 400),
                StartPosition = FormStartPosition.CenterParent
            };

            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "الاسم",
                DataPropertyName = "ProductName",
                Width = 200
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "السعر",
                DataPropertyName = "SalePrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    FormatProvider = CultureInfo.CurrentCulture
                }
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "المخزون",
                DataPropertyName = "Stock",
                Width = 80
            });
            dgv.DataSource = products;

            var btn = new Button
            {
                Text = "اختر",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btn.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                    dlg.DialogResult = DialogResult.OK;
            };

            dlg.Controls.Add(dgv);
            dlg.Controls.Add(btn);

            if (dlg.ShowDialog() == DialogResult.OK)
                AddProductToSale(products[dgv.SelectedRows[0].Index]);
        }

        private void AddProductToSale(ProductMatch product)
        {
            bool pkg = isPackageMode && product.PackageSize > 1;
            decimal qty = 1m;
            decimal avail = pkg
                ? Math.Floor((decimal)product.Stock / product.PackageSize)
                : product.Stock;

            var existing = currentSale.Find(x =>
                x.ProductID == product.ProductID && x.IsPackage == pkg);

            if (existing != null)
            {
                decimal newQty = existing.Quantity + qty;
                if (newQty > avail && !ConfirmNegativeSale(product.ProductName, (int)newQty, (int)avail))
                    return;
                existing.Quantity = newQty;
                existing.Total = existing.Quantity * existing.UnitPrice;
            }
            else
            {
                if (qty > avail && !ConfirmNegativeSale(product.ProductName, (int)qty, (int)avail))
                    return;

                decimal price = pkg
                    ? product.SalePrice * product.PackageSize
                    : product.SalePrice;

                currentSale.Add(new SaleDetail
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Quantity = qty,
                    UnitPrice = price,
                    Total = price,
                    Unit = pkg ? "حزمة" : product.Unit,
                    PackageSize = product.PackageSize,
                    IsPackage = pkg
                });
            }

            UpdateSaleGrid();
            CalculateTotal();
        }

        private void InitializeCreditInfoLabel()
        {
            lblCreditInfo = new Label
            {
                ForeColor = Color.Red,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Size = new Size(250, 20),
                Visible = false
            };
            this.Controls.Add(lblCreditInfo);
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMethod = cmbPaymentMethod.SelectedItem != null ?
                cmbPaymentMethod.SelectedItem.ToString() : "";
            bool isCreditSale = selectedMethod == "آجل";

            lblCustomer.Visible = isCreditSale;
            cmbCustomer.Visible = isCreditSale;

            if (lblCreditInfo != null)
                lblCreditInfo.Visible = isCreditSale;

            txtAmountPaid.Enabled = !isCreditSale;
            txtAmountPaid.Text = isCreditSale ? "0" : "";
            lblChange.Text = "0.00";

            if (isCreditSale && cmbCustomer.SelectedIndex != -1)
            {
                cmbCustomer_SelectedIndexChanged(null, null);
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != -1 &&
                cmbPaymentMethod.SelectedItem?.ToString() == "آجل")
            {
                UpdateCreditInfo((int)cmbCustomer.SelectedValue);
            }
        }

        private void UpdateCreditInfo(int customerId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT CreditLimit, CurrentBalance FROM Customers WHERE CustomerID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", customerId);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            decimal lim = rdr.GetDecimal(0);
                            decimal bal = rdr.GetDecimal(1);
                            lblCreditInfo.Text = "الرصيد المتاح: " + (lim - bal).ToString("N2");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في جلب رصيد العميل: " + ex.Message);
            }
        }

        private void SetupDataGridView()
        {
            dgvSaleItems.AutoGenerateColumns = false;
            dgvSaleItems.Columns.Clear();

            AddColumn("ProductName", "الاسم", 200);
            AddCurrencyColumn("UnitPrice", "السعر", 100);
            AddColumn("Quantity", "الكمية", 80);
            AddColumn("Unit", "الوحدة", 80);
            AddCurrencyColumn("Total", "المجموع", 120);

            dgvSaleItems.RowHeadersVisible = false;
            dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleItems.CellEndEdit += dgvSaleItems_CellEndEdit;
        }

        private void AddColumn(string name, string header, int width)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width
            };
            dgvSaleItems.Columns.Add(col);
        }

        private void AddCurrencyColumn(string name, string header, int width)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    FormatProvider = CultureInfo.CurrentCulture
                }
            };
            dgvSaleItems.Columns.Add(col);
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var da = new SqlDataAdapter(
                    "SELECT CustomerID, Name FROM Customers ORDER BY Name", conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "Name";
                    cmbCustomer.ValueMember = "CustomerID";
                    cmbCustomer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل العملاء: " + ex.Message);
            }
        }

        private string MapPaymentMethod(string uiMethod)
        {
            if (uiMethod == "نقدي")
                return "Cash";
            if (uiMethod == "بطاقة")
                return "Card";
            if (uiMethod == "محفظة إلكترونية")
                return "EWallet";
            if (uiMethod == "آجل")
                return "Credit";

            return "Cash";
        }

        private void chkPackageMode_CheckedChanged(object sender, EventArgs e)
        {
            isPackageMode = chkPackageMode.Checked;
            lblPackageMode.Text = isPackageMode
                ? "وضع التعبئة: حزمة"
                : "وضع التعبئة: وحدة";
        }
        private void LoadPaymentMethods()
        {
            cmbPaymentMethod.Items.AddRange(new object[] { "نقدي", "بطاقة", "محفظة إلكترونية", "آجل" });
            cmbPaymentMethod.SelectedIndex = 0;
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter &&
                !string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                e.Handled = true;
                AddOrUpdateProductInSale(txtBarcode.Text.Trim());
                txtBarcode.Clear();
                txtBarcode.Focus();
            }
        }

        private void BackupDatabase()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand("EXEC [dbo].[BackupDatabaseNow]", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("تم إنشاء نسخة احتياطية بنجاح.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في النسخ الاحتياطي: " + ex.Message);
            }
        }

        private void AddOrUpdateProductInSale(string barcode)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    @"SELECT p.ProductID, p.ProductName, p.SalePrice,
                             i.Quantity AS Stock, p.Unit, p.PackageSize
                      FROM Products p
                      LEFT JOIN Inventory i ON p.ProductID = i.ProductID
                      WHERE p.Barcode = @bc", conn))
                {
                    cmd.Parameters.AddWithValue("@bc", barcode);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            AddProductToSale(new ProductMatch
                            {
                                ProductID = rdr.GetInt32(0),
                                ProductName = rdr.GetString(1),
                                SalePrice = rdr.GetDecimal(2),
                                Stock = rdr.IsDBNull(3) ? 0 : rdr.GetInt32(3),
                                Unit = rdr.GetString(4),
                                PackageSize = rdr.GetInt32(5)
                            });
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على المنتج بالباركود.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void UpdateSaleGrid()
        {
            dgvSaleItems.DataSource = null;
            dgvSaleItems.DataSource = currentSale;
            dgvSaleItems.Refresh();
        }

        private void CalculateTotal()
        {
            totalAmount = 0m;
            foreach (var x in currentSale)
                totalAmount += x.Total;

            lblTotal.Text = totalAmount.ToString("N2");
            if (amountPaid > 0)
                lblChange.Text = (amountPaid - totalAmount).ToString("N2");
        }

        private void dgvSaleItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSaleItems.Columns[e.ColumnIndex].Name != "Quantity")
                return;

            try
            {
                int row = e.RowIndex;
                decimal newQty = Convert.ToDecimal(
                    dgvSaleItems.Rows[row].Cells["Quantity"].Value);
                var item = currentSale[row];

                int stock = 0;
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT Quantity FROM Inventory WHERE ProductID = @pid", conn))
                {
                    cmd.Parameters.AddWithValue("@pid", item.ProductID);
                    conn.Open();
                    var obj = cmd.ExecuteScalar();
                    stock = obj == null ? 0 : Convert.ToInt32(obj);
                }

                decimal maxAvail = item.IsPackage
                    ? Math.Floor((decimal)stock / item.PackageSize)
                    : stock;

                if (newQty < 0.01m)
                {
                    MessageBox.Show("الكمية يجب ألا تقل عن 0.01");
                    dgvSaleItems.Rows[row].Cells["Quantity"].Value = 1m;
                    newQty = 1m;
                }
                else if (newQty > maxAvail)
                {
                    if (!ConfirmNegativeSale(item.ProductName, (int)newQty, (int)maxAvail))
                    {
                        dgvSaleItems.Rows[row].Cells["Quantity"].Value = maxAvail;
                        newQty = maxAvail;
                    }
                }

                item.Quantity = newQty;
                item.Total = newQty * item.UnitPrice;

                UpdateSaleGrid();
                CalculateTotal();
            }
            catch
            {
                MessageBox.Show("خطأ في تعديل الكمية");
                dgvSaleItems.Rows[e.RowIndex].Cells["Quantity"].Value = 1m;
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvSaleItems.SelectedRows.Count == 0) return;
            int idx = dgvSaleItems.SelectedRows[0].Index;
            currentSale.RemoveAt(idx);
            UpdateSaleGrid();
            CalculateTotal();
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (currentSale.Count == 0)
            {
                MessageBox.Show("لا توجد أصناف في الفاتورة");
                return;
            }

            string paymentMethod = cmbPaymentMethod.SelectedItem != null ?
                cmbPaymentMethod.SelectedItem.ToString() : "";
            bool isCreditSale = paymentMethod == "آجل";

            if (!isCreditSale && amountPaid < totalAmount)
            {
                MessageBox.Show("المبلغ المدفوع غير كافي");
                return;
            }

            if (isCreditSale && cmbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار عميل للبيع الآجل");
                return;
            }

            try
            {
                int? customerId = isCreditSale ? (int?)cmbCustomer.SelectedValue : null;
                string dbPaymentMethod = MapPaymentMethod(paymentMethod);

                if (isCreditSale && !ValidateCreditLimit((int)customerId, totalAmount))
                {
                    return;
                }

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO Sales (SaleDate, UserID, TotalAmount, PaymentMethod, Notes, IsFinalized)
                              VALUES (@SaleDate, @UserID, @TotalAmount, @PaymentMethod, @Notes, 1);
                              SELECT SCOPE_IDENTITY();",
                            conn, transaction);

                        cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@PaymentMethod", dbPaymentMethod);
                        cmd.Parameters.AddWithValue("@Notes", "POS Sale");

                        int saleId = Convert.ToInt32(cmd.ExecuteScalar());
                        int? creditSaleId = null;

                        if (isCreditSale)
                        {
                            DateTime dueDate = DateTime.Now.AddDays(30);

                            cmd = new SqlCommand(
                                @"INSERT INTO CreditSales (CustomerID, SaleDate, TotalAmount, 
                                  PaidAmount, DueDate, IsPaid, SalesHeaderID)
                                  VALUES (@CustomerID, @SaleDate, @TotalAmount, 
                                  0, @DueDate, 0, @SalesHeaderID);
                                  SELECT SCOPE_IDENTITY();",
                                conn, transaction);

                            cmd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmd.Parameters.AddWithValue("@DueDate", dueDate);
                            cmd.Parameters.AddWithValue("@SalesHeaderID", saleId);

                            creditSaleId = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd = new SqlCommand(
                                @"UPDATE Customers 
                                  SET CurrentBalance = CurrentBalance + @Amount
                                  WHERE CustomerID = @CustomerID",
                                conn, transaction);

                            cmd.Parameters.AddWithValue("@Amount", totalAmount);
                            cmd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var item in currentSale)
                        {
                            cmd = new SqlCommand(
                                @"INSERT INTO SaleDetails (SaleID, ProductID, Quantity, 
                                  UnitPrice, IsPackage, CreditSaleID)
                                  VALUES (@SaleID, @ProductID, @Quantity, 
                                  @UnitPrice, @IsPackage, @CreditSaleID)",
                                conn, transaction);

                            cmd.Parameters.AddWithValue("@SaleID", saleId);
                            cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                            cmd.Parameters.AddWithValue("@Quantity", (int)item.Quantity);
                            cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                            cmd.Parameters.AddWithValue("@IsPackage", item.IsPackage);
                            cmd.Parameters.AddWithValue("@CreditSaleID",
                                creditSaleId.HasValue ? (object)creditSaleId.Value : DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                        if (!isCreditSale)
                        {
                            cmd = new SqlCommand(
                                @"INSERT INTO CashBox (TransactionDate, TransactionType, Amount, 
                                  Description, ReferenceID, ReferenceTable, UserID)
                                  VALUES (GETDATE(), 'Sale', @Amount, 
                                  @Description, @ReferenceID, 'Sales', @UserID)",
                                conn, transaction);

                            cmd.Parameters.AddWithValue("@Amount", totalAmount);
                            cmd.Parameters.AddWithValue("@Description", "فاتورة مبيع #" + saleId);
                            cmd.Parameters.AddWithValue("@ReferenceID", saleId);
                            cmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        GenerateReceipt(saleId, isCreditSale);
                        ResetSale();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("خطأ في معالجة البيع: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }
        private void GenerateReceipt(int saleId, bool isCreditSale)
        {
            string receipt = "تمت عملية البيع بنجاح\n" +
                            "رقم الفاتورة: " + saleId + "\n" +
                            "المبلغ الإجمالي: " + totalAmount.ToString("N2") + "\n";

            if (isCreditSale)
            {
                receipt += "نوع البيع: آجل\n" +
                           "العميل: " + cmbCustomer.Text + "\n" +
                           "تاريخ الاستحقاق: " + DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            }
            else
            {
                receipt += "المبلغ المدفوع: " + amountPaid.ToString("N2") + "\n" +
                           "الباقي: " + changeDue.ToString("N2");
            }

            MessageBox.Show(receipt);
        }



        private bool ValidateCreditLimit(int customerId, decimal saleAmount)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT CreditLimit, CurrentBalance FROM Customers WHERE CustomerID = @c", conn))
                {
                    cmd.Parameters.AddWithValue("@c", customerId);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            decimal lim = rdr.GetDecimal(0);
                            decimal bal = rdr.GetDecimal(1);
                            if (bal + saleAmount > lim)
                            {
                                MessageBox.Show(
                                    $"تجاوز حد الائتمان. المتبقي: {(lim - bal).ToString("N2")}");
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في التحقق من الائتمان: " + ex.Message);
                return false;
            }
        }

        private void ResetSale()
        {
            currentSale.Clear();
            totalAmount = amountPaid = changeDue = 0m;
            isPackageMode = false;
            chkPackageMode.Checked = false;

            dgvSaleItems.DataSource = null;
            lblTotal.Text = "0.00";
            txtAmountPaid.Clear();
            lblChange.Text = "0.00";
            cmbCustomer.SelectedIndex = -1;
            cmbPaymentMethod.SelectedIndex = 0;
            lblCreditInfo.Visible = false;

            txtBarcode.Focus();
        }

        private void btnVoidSale_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد إلغاء هذه العملية؟",
                "تأكيد الإلغاء", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetSale();
            }
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            // replace with your actual returns form
            المرجعات re = new المرجعات();
            re.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadTheme()
        {
            // VS2015‐compatible: no pattern matching
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    btn.BackColor = ColorTranslator.FromHtml("#4CAF50");
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#388E3C");
                }
            }

            chkPackageMode.BackColor = ColorTranslator.FromHtml("#E8F5E9");
            chkPackageMode.ForeColor = ColorTranslator.FromHtml("#2E7D32");
        }


        public class SaleDetail
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Total { get; set; }
            public string Unit { get; set; }
            public int PackageSize { get; set; }
            public bool IsPackage { get; set; }
        }

        private class ProductMatch
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal SalePrice { get; set; }
            public int Stock { get; set; }
            public string Unit { get; set; }
            public int PackageSize { get; set; }
            public override string ToString()
            {
                return ProductName;
            }
        }

        private void POS_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Skip backup for admin users
            if (CurrentUser.UserType != "Admin")
            {
                BackupDatabase();
            }
        }
    }
}
