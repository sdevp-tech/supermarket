using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace LoginForm1
{
    public partial class frmReports : Form
    {
        private string connectionString = "Server=.;Database=mini_supermarket;Integrated Security=True;";
        private Dictionary<TabPage, System.Windows.Forms.TextBox> filterTextBoxes = new Dictionary<TabPage, System.Windows.Forms.TextBox>();
        private Dictionary<TabPage, DateTimePicker> startDatePickers = new Dictionary<TabPage, DateTimePicker>();
        private Dictionary<TabPage, DateTimePicker> endDatePickers = new Dictionary<TabPage, DateTimePicker>();

        public frmReports()
        {
            InitializeComponent();
            InitializeReportTabs();
            this.Text = "نظام التقارير - السوبر ماركت المصغر";
        }

        private void InitializeReportTabs()
        {
            tabControl.TabPages.Clear();

            // Add report tabs
            string[] reportTabs = {
                "ديون الزبائن", "ديون الموردين", "المشتريات", "المبيعات",
                "الربح", "المصروفات", "الصندوق", "تقرير شامل"
            };

            foreach (string tabName in reportTabs)
            {
                AddTabPage(tabName);
            }

            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            LoadReportData(tabControl.SelectedTab);
        }

        private void AddTabPage(string title)
        {
            TabPage tab = new TabPage(title);
            tabControl.TabPages.Add(tab);

            // DataGridView
            DataGridView dgv = new DataGridView
            {
                Name = "dgv" + title.Replace(" ", ""),
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };
            tab.Controls.Add(dgv);

            // Button panel - will contain both buttons and filter controls
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.LightGray
            };
            tab.Controls.Add(buttonPanel);

            // Position variables for controls
            int leftPosition = 20;

            // Export button
            System.Windows.Forms.Button btnExport = new System.Windows.Forms.Button
            {
                Text = "تصدير لإكسل",
                Size = new Size(100, 35),
                Location = new System.Drawing.Point(leftPosition, 8),
                Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Name = "btnExport" + title.Replace(" ", "")
            };
            btnExport.Click += btnExport_Click;
            buttonPanel.Controls.Add(btnExport);
            leftPosition += btnExport.Width + 10;

            // Refresh button
            System.Windows.Forms.Button btnRefresh = new System.Windows.Forms.Button
            {
                Text = "تحديث البيانات",
                Size = new Size(100, 35),
                Location = new System.Drawing.Point(leftPosition, 8),
                Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                Name = "btnRefresh" + title.Replace(" ", "")
            };
            btnRefresh.Click += (s, e) => LoadReportData(tab);
            buttonPanel.Controls.Add(btnRefresh);
            leftPosition += btnRefresh.Width + 20;

            // Add filter controls to specific reports
            if (title != "تقرير شامل" && title != "الربح" && title != "المصروفات" && title != "الصندوق")
            {
                // Filter label
                System.Windows.Forms.Label lblFilter = new System.Windows.Forms.Label
                {
                    Text = "بحث حسب الاسم:",
                    Location = new System.Drawing.Point(leftPosition, 15),
                    AutoSize = true,
                    Name = "lblFilter" + title.Replace(" ", "")
                };
                buttonPanel.Controls.Add(lblFilter);
                leftPosition += lblFilter.Width + 5;

                // Filter textbox
                System.Windows.Forms.TextBox txtFilter = new System.Windows.Forms.TextBox
                {
                    Location = new System.Drawing.Point(leftPosition, 10),
                    Width = 200,
                    Name = "txtFilter" + title.Replace(" ", "")
                };
                buttonPanel.Controls.Add(txtFilter);
                filterTextBoxes.Add(tab, txtFilter);
                leftPosition += txtFilter.Width + 5;

                // Filter button
                System.Windows.Forms.Button btnFilter = new System.Windows.Forms.Button
                {
                    Text = "بحث",
                    Location = new System.Drawing.Point(leftPosition, 10),
                    Size = new Size(80, 25),
                    Name = "btnFilter" + title.Replace(" ", "")
                };
                btnFilter.Click += (s, e) => LoadReportData(tab);
                buttonPanel.Controls.Add(btnFilter);
            }

            // Add date filters only for comprehensive report
            if (title == "تقرير شامل")
            {
                int rightPosition = buttonPanel.Width - 20;

                // End Date Picker
                DateTimePicker dtpEndDate = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    Location = new System.Drawing.Point(rightPosition - 100, 12),
                    Size = new Size(120, 25),
                    Name = "dtpEndDate"
                };
                buttonPanel.Controls.Add(dtpEndDate);
                rightPosition -= dtpEndDate.Width + 10;

                // End Date Label
                System.Windows.Forms.Label lblEndDate = new System.Windows.Forms.Label
                {
                    Text = ":إلى تاريخ",
                    Location = new System.Drawing.Point(rightPosition - 40, 15),
                    AutoSize = true
                };
                buttonPanel.Controls.Add(lblEndDate);
                rightPosition -= lblEndDate.Width + 5;

                // Start Date Picker
                DateTimePicker dtpStartDate = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    Location = new System.Drawing.Point(rightPosition - 100, 12),
                    Size = new Size(120, 25),
                    Name = "dtpStartDate"
                };
                buttonPanel.Controls.Add(dtpStartDate);
                rightPosition -= dtpStartDate.Width + 10;

                // Start Date Label
                System.Windows.Forms.Label lblStartDate = new System.Windows.Forms.Label
                {
                    Text = ":من تاريخ",
                    Location = new System.Drawing.Point(rightPosition - 60, 15),
                    AutoSize = true
                };
                buttonPanel.Controls.Add(lblStartDate);
                rightPosition -= lblStartDate.Width + 15;

                // Filter Button
                System.Windows.Forms.Button btnDateFilter = new System.Windows.Forms.Button
                {
                    Text = "تطبيق التاريخ",
                    Size = new Size(120, 30),
                    Location = new System.Drawing.Point(rightPosition - 120, 8),
                    BackColor = Color.Teal,
                    ForeColor = Color.White
                };
                btnDateFilter.Click += (s, e) => LoadReportData(tab);
                buttonPanel.Controls.Add(btnDateFilter);

                // Store references to date pickers
                startDatePickers.Add(tab, dtpStartDate);
                endDatePickers.Add(tab, dtpEndDate);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData(tabControl.SelectedTab);
        }

        private void LoadReportData(TabPage tab)
        {
            DataGridView dgv = FindDgvInTab(tab);
            if (dgv == null) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string filter = filterTextBoxes.ContainsKey(tab) ?
                                    filterTextBoxes[tab].Text.Trim() :
                                    string.Empty;

                    DateTime? startDate = null;
                    DateTime? endDate = null;

                    // Get date values for comprehensive report
                    if (tab.Text == "تقرير شامل" &&
                        startDatePickers.ContainsKey(tab) &&
                        endDatePickers.ContainsKey(tab))
                    {
                        startDate = startDatePickers[tab].Value.Date;
                        endDate = endDatePickers[tab].Value.Date.AddDays(1); // Include entire day
                    }

                    string query = GetReportQuery(tab.Text, filter, startDate, endDate);
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add date parameters if they exist
                    if (startDate != null)
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                    }
                    if (endDate != null)
                    {
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);

                    // For comprehensive report, add additional financial summaries
                    if (tab.Text == "تقرير شامل")
                    {
                        dgv.DataSource = dt;
                        AddSummaryToComprehensiveReport(dt);
                        FormatComprehensiveReport(dgv);
                    }
                    else
                    {
                        dgv.DataSource = dt;
                        FormatDataGridView(dgv, tab.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة لحساب إجمالي الربح
        private decimal CalculateTotalProfit(DateTime? startDate = null, DateTime? endDate = null)
        {
            decimal totalProfit = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    SUM(
                        (sd.Quantity - ISNULL(returned.ReturnedQty, 0)) * sd.UnitPrice 
                        - 
                        (sd.Quantity - ISNULL(returned.ReturnedQty, 0)) 
                        * 
                        CASE 
                            WHEN sd.IsPackage = 1 THEN p.PackageSize * p.PurchasePrice 
                            ELSE p.PurchasePrice 
                        END
                    ) AS TotalProfit
                FROM SaleDetails sd
                INNER JOIN Sales s ON sd.SaleID = s.SaleID
                INNER JOIN Products p ON sd.ProductID = p.ProductID
                LEFT JOIN (
                    SELECT 
                        r.SaleID, 
                        r.ProductID, 
                        SUM(r.Quantity) AS ReturnedQty
                    FROM Returns r
                    GROUP BY r.SaleID, r.ProductID
                ) returned ON sd.SaleID = returned.SaleID AND sd.ProductID = returned.ProductID
                WHERE s.IsFinalized = 1";

                    // Add date filtering if provided
                    if (startDate != null)
                    {
                        query += " AND s.SaleDate >= @startDate";
                    }
                    if (endDate != null)
                    {
                        query += " AND s.SaleDate < @endDate";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (startDate != null)
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                    }
                    if (endDate != null)
                    {
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                    }

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalProfit = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في حساب الربح الإجمالي: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totalProfit;
        }

        private void AddSummaryToComprehensiveReport(System.Data.DataTable dt)
        {
            decimal cashSales = 0;
            decimal cardSales = 0;
            decimal ewalletSales = 0;
            decimal creditSales = 0;
            decimal cashPurchases = 0;
            decimal creditPurchases = 0;
            decimal expenses = 0;

            // Extract values from the report
            foreach (DataRow row in dt.Rows)
            {
                string item = row["البند"].ToString();
                decimal amount = Convert.ToDecimal(row["الإجمالي"]);

                if (item == "مبيعات نقدية") cashSales = amount;
                else if (item == "مبيعات بطاقة") cardSales = amount;
                else if (item == "مبيعات محفظة إلكترونية") ewalletSales = amount;
                else if (item == "مبيعات آجلة") creditSales = amount;
                else if (item == "مشتريات نقدية") cashPurchases = amount;
                else if (item == "مشتريات آجلة") creditPurchases = amount;
                else if (item == "المصروفات") expenses = amount;
            }

            // Calculate totals
            decimal totalSales = cashSales + cardSales + ewalletSales + creditSales;
            decimal totalPurchases = cashPurchases + creditPurchases;

            // Calculate total profit
            DateTime? startDate = null;
            DateTime? endDate = null;
            TabPage tab = tabControl.SelectedTab;

            if (tab.Text == "تقرير شامل" &&
                startDatePickers.ContainsKey(tab) &&
                endDatePickers.ContainsKey(tab))
            {
                startDate = startDatePickers[tab].Value.Date;
                endDate = endDatePickers[tab].Value.Date.AddDays(1);
            }

            decimal totalProfit = CalculateTotalProfit(startDate, endDate);

            // Calculate net profit (total profit - total expenses)
            decimal netProfit = totalProfit - expenses;

            // Add summary rows
            DataRow totalSalesRow = dt.NewRow();
            totalSalesRow["البند"] = "إجمالي المبيعات";
            totalSalesRow["الإجمالي"] = totalSales;
            dt.Rows.InsertAt(totalSalesRow, 0);

            DataRow totalPurchasesRow = dt.NewRow();
            totalPurchasesRow["البند"] = "إجمالي المشتريات";
            totalPurchasesRow["الإجمالي"] = totalPurchases;
            dt.Rows.InsertAt(totalPurchasesRow, 5); // After sales items

            DataRow totalProfitRow = dt.NewRow();
            totalProfitRow["البند"] = "إجمالي الربح";
            totalProfitRow["الإجمالي"] = totalProfit;
            dt.Rows.Add(totalProfitRow);

            DataRow netProfitRow = dt.NewRow();
            netProfitRow["البند"] = "صافي الربح";
            netProfitRow["الإجمالي"] = netProfit;
            dt.Rows.Add(netProfitRow);
        }

        private void FormatComprehensiveReport(DataGridView dgv)
        {
            dgv.Columns["البند"].Width = 250;
            dgv.Columns["الإجمالي"].Width = 150;
            dgv.Columns["الإجمالي"].DefaultCellStyle.Format = "N2";
            dgv.Columns["الإجمالي"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Style important rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["البند"].Value != null)
                {
                    string item = row.Cells["البند"].Value.ToString();

                    if (item == "إجمالي المبيعات" ||
                        item == "إجمالي المشتريات" ||
                        item == "إجمالي الربح" ||
                        item == "صافي الربح")
                    {
                        row.DefaultCellStyle.Font = new System.Drawing.Font(dgv.Font, FontStyle.Bold);
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }

                    if (item == "إجمالي الربح" || item == "صافي الربح")
                    {
                        decimal profit = Convert.ToDecimal(row.Cells["الإجمالي"].Value);
                        row.DefaultCellStyle.BackColor = profit >= 0 ? Color.LightGreen : Color.LightCoral;
                    }
                }
            }
        }

        private string GetReportQuery(string reportName, string filter = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            string filterClause = "";
            if (!string.IsNullOrEmpty(filter))
            {
                // Safe SQL filtering
                filter = filter.Replace("'", "''");

                if (reportName == "ديون الزبائن")
                {
                    filterClause = string.Format(" AND (c.Name LIKE '%{0}%' OR p.ProductName LIKE '%{0}%')", filter);
                }
                else if (reportName == "ديون الموردين")
                {
                    filterClause = string.Format(" AND (s.SupplierName LIKE '%{0}%' OR pr.ProductName LIKE '%{0}%')", filter);
                }
                else if (reportName == "المشتريات")
                {
                    filterClause = string.Format(" AND (pr.ProductName LIKE '%{0}%' OR s.SupplierName LIKE '%{0}%')", filter);
                }
                else if (reportName == "المبيعات")
                {
                    filterClause = string.Format(" AND (pr.ProductName LIKE '%{0}%' OR u.Username LIKE '%{0}%')", filter);
                }
            }

            // Date filtering clauses
            string salesDateFilter = "";
            string purchasesDateFilter = "";
            string expensesDateFilter = "";
            string creditSalesDateFilter = "";

            if (startDate != null)
            {
                salesDateFilter = $" AND s.SaleDate >= @startDate";
                purchasesDateFilter = $" AND p.PurchaseDate >= @startDate";
                expensesDateFilter = $" AND e.ExpenseDate >= @startDate";
                creditSalesDateFilter = $" AND s.SaleDate >= @startDate";
            }
            if (endDate != null)
            {
                salesDateFilter += $" AND s.SaleDate < @endDate";
                purchasesDateFilter += $" AND p.PurchaseDate < @endDate";
                expensesDateFilter += $" AND e.ExpenseDate < @endDate";
                creditSalesDateFilter += $" AND s.SaleDate < @endDate";
            }

            switch (reportName)
            {
                case "ديون الزبائن":
                    return @"SELECT 
    c.CustomerID AS [رقم الزبون],
    c.Name AS [اسم الزبون],
    c.Phone AS [هاتف],
    c.CreditLimit AS [حد الائتمان],
    c.CurrentBalance AS [رصيد حالى],
    cs.SaleID AS [رقم الفاتورة الآجلة],
    s.SaleID AS [رقم الفاتورة],
    FORMAT(s.SaleDate, 'dd/MM/yyyy HH:mm') AS [تاريخ الفاتورة],
    p.ProductName AS [اسم المنتج],
    sd.Quantity AS [الكمية],
    sd.IsPackage AS [باكت],
    CASE 
        WHEN sd.IsPackage = 1 THEN 'باكدج (' + CAST(p.PackageSize AS NVARCHAR) + ' قطعة)'
        ELSE 'قطعة'
    END AS [نوع الوحدة],
    cs.TotalAmount AS [المبلغ الإجمالى],
    cs.PaidAmount AS [المبلغ المدفوع],
    (cs.TotalAmount - cs.PaidAmount) AS [المبلغ المتبقى],
    cp.PaymentDate AS [تاريخ الدفع],
    COALESCE(cp.Amount, 0) AS [مبلغ الدفع]
FROM Customers c
JOIN CreditSales cs ON c.CustomerID = cs.CustomerID
JOIN Sales s ON cs.SalesHeaderID = s.SaleID
JOIN SaleDetails sd ON s.SaleID = sd.SaleID
JOIN Products p ON sd.ProductID = p.ProductID
LEFT JOIN CreditPayments cp ON cs.SaleID = cp.SaleID
WHERE cs.TotalAmount > cs.PaidAmount"
 + filterClause + @"
ORDER BY s.SaleDate DESC;";

                case "ديون الموردين":
                    return @"SELECT 
    s.SupplierID AS [رقم المورد],
    s.SupplierName AS [اسم المورد],
    s.CreditLimit AS [حد الائتمان],
    p.PurchaseID AS [رقم الشراء],
    pr.ProductName AS [اسم المنتج],
    p.Quantity AS [الكمية],
    p.IsPackage AS [باكت],
    FORMAT(p.PurchaseDate, 'dd/MM/yyyy HH:mm') AS [تاريخ الشراء],
    p.Total AS [المبلغ الإجمالى],
    p.PaidAmount AS [المبلغ المدفوع],
    (p.Total - p.PaidAmount) AS [المبلغ المتبقى],
    FORMAT(sp.PaymentDate, 'dd/MM/yyyy') AS [تاريخ الدفع],
    sp.Amount AS [مبلغ الدفع],
    CASE 
        WHEN p.IsPackage = 1 THEN 'عبوة (' + CAST(pr.PackageSize AS NVARCHAR) + ' قطعة)'
        ELSE 'قطعة'
    END AS [نوع الوحدة],
    CASE 
        WHEN p.IsPackage = 1 THEN p.Quantity * pr.PackageSize 
        ELSE p.Quantity 
    END AS [القطع الفعلية]
FROM Suppliers s
JOIN Purchases p ON s.SupplierID = p.SupplierID
JOIN Products pr ON p.ProductID = pr.ProductID
LEFT JOIN SupplierPayments sp ON p.PurchaseID = sp.PurchaseID
WHERE p.IsCredit = 1 AND p.Total > p.PaidAmount"
 + filterClause + @"
ORDER BY p.PurchaseDate DESC;";

                case "المشتريات":
                    return @"SELECT 
    p.PurchaseID AS [رقم الشراء],
    FORMAT(p.PurchaseDate, 'dd/MM/yyyy HH:mm') AS [تاريخ الشراء],
    pr.ProductName AS [اسم المنتج],
    s.SupplierName AS [المورد],
    p.Quantity AS [الكمية],
    CASE 
        WHEN p.IsPackage = 1 THEN 'عبوة (' + CAST(pr.PackageSize AS NVARCHAR) + ' قطعة)'
        ELSE 'قطعة'
    END AS [نوع الوحدة],
    CASE 
        WHEN p.IsPackage = 1 THEN p.PackagePrice 
        ELSE p.UnitPrice 
    END AS [سعر الوحدة المشتراة],
    p.UnitPrice AS [سعر القطعة الواحدة],
    p.PackagePrice AS [سعر العبوة الكاملة],
    p.Total AS [الإجمالي],
    CASE 
        WHEN p.IsCredit = 1 THEN 'آجل'
        ELSE 'نقدي'
    END AS [طريقة الدفع],
    (p.Total - p.PaidAmount) AS [المتبقي للدفع],
    CASE 
        WHEN p.IsCredit = 1 THEN FORMAT(p.DueDate, 'dd/MM/yyyy')
        ELSE '--'
    END AS [تاريخ الاستحقاق]
FROM Purchases p
JOIN Products pr ON p.ProductID = pr.ProductID
JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE 1=1"
 + filterClause + @"
ORDER BY p.PurchaseDate DESC;";

                case "المبيعات":
                    return @"SELECT 
    s.SaleID AS [رقم الفاتورة],
    s.SaleDate AS [تاريخ البيع],
    u.Username AS [اسم المستخدم],
    pr.ProductName AS [اسم المنتج],
    sd.Quantity AS [الكمية],
    CASE WHEN sd.IsPackage = 1 THEN 'عبوة' ELSE 'قطعة' END AS [نوع الوحدة],
    sd.UnitPrice AS [سعر الوحدة],
    sd.Total AS [الإجمالي],
    CASE 
        WHEN s.PaymentMethod = 'Credit' THEN 'اجل' 
        WHEN s.PaymentMethod = 'EWallet' THEN 'محفظة الاكتروني' 
        WHEN s.PaymentMethod = 'Card' THEN 'بطاقة' 
        WHEN s.PaymentMethod = 'Cash' THEN 'كاش' 
        ELSE s.PaymentMethod
    END AS [طريقة الدفع],
    CASE 
        WHEN EXISTS (SELECT 1 FROM Returns r 
                     WHERE r.SaleID = s.SaleID AND r.ProductID = pr.ProductID) 
        THEN 'مرتجع' 
        ELSE 'غير مرتجع' 
    END AS [حالة المرتجع]
FROM Sales s
JOIN SaleDetails sd ON s.SaleID = sd.SaleID
JOIN Products pr ON sd.ProductID = pr.ProductID
JOIN Users u ON s.UserID = u.UserID
WHERE s.IsFinalized = 1"
 + filterClause;

                case "الربح":
                    return @"WITH AvgCost AS (
    SELECT ProductID, AVG(UnitPrice) AS AvgPurchasePrice
    FROM Purchases
    GROUP BY ProductID
)
SELECT
    pr.ProductName AS [اسم المنتج],
    SUM(CASE 
            WHEN sd.IsPackage = 1 THEN sd.Quantity * pr.PackageSize 
            ELSE sd.Quantity 
        END) AS [الكمية المباعة],
    ac.AvgPurchasePrice AS [متوسط سعر الشراء],
    AVG(sd.UnitPrice) AS [متوسط سعر البيع],
    SUM(sd.Total) AS [الإيرادات],
    SUM(CASE 
            WHEN sd.IsPackage = 1 THEN sd.Quantity * pr.PackageSize * ac.AvgPurchasePrice
            ELSE sd.Quantity * ac.AvgPurchasePrice
        END) AS [تكلفة البضاعة المباعة],
    SUM(sd.Total) - SUM(CASE 
            WHEN sd.IsPackage = 1 THEN sd.Quantity * pr.PackageSize * ac.AvgPurchasePrice
            ELSE sd.Quantity * ac.AvgPurchasePrice
        END) AS [الربح]
FROM SaleDetails sd
JOIN Products pr ON sd.ProductID = pr.ProductID
JOIN AvgCost ac ON pr.ProductID = ac.ProductID
GROUP BY pr.ProductName, ac.AvgPurchasePrice";

                case "المصروفات":
                    return @"SELECT 
    ExpenseDate AS [تاريخ المصروف],
    Amount AS [المبلغ],
    Description AS [الوصف],
    Category AS [الفئة],
    PaymentMethod AS [طريقة الدفع],
    Notes AS [ملاحظات]
FROM Expenses";

                case "الصندوق":
                    return @"SELECT 
    TransactionDate AS [تاريخ الحركة],
    TransactionType AS [نوع الحركة],
    Description AS [الوصف],
    Amount AS [المبلغ],
    (SELECT SUM(Amount) 
     FROM CashBox b 
     WHERE b.TransactionID <= a.TransactionID) AS [الرصيد التراكمي]
FROM CashBox a
ORDER BY TransactionDate DESC";

                case "تقرير شامل":
                    return $@"-- المبيعات النقدية
SELECT 'مبيعات نقدية' AS [البند], COALESCE(SUM(s.TotalAmount), 0) AS [الإجمالي] 
FROM Sales s WHERE PaymentMethod = 'Cash' {salesDateFilter}
UNION ALL
-- مبيعات بطاقة
SELECT 'مبيعات بطاقة', COALESCE(SUM(s.TotalAmount), 0)
FROM Sales s WHERE PaymentMethod = 'Card' {salesDateFilter}
UNION ALL
-- مبيعات محفظة إلكترونية
SELECT 'مبيعات محفظة إلكترونية', COALESCE(SUM(s.TotalAmount), 0)
FROM Sales s WHERE PaymentMethod = 'EWallet' {salesDateFilter}
UNION ALL
-- المبيعات الآجلة (المتبقي فقط)
SELECT 'مبيعات آجلة', COALESCE(SUM(cs.TotalAmount - cs.PaidAmount), 0)
FROM CreditSales cs
JOIN Sales s ON cs.SalesHeaderID = s.SaleID
WHERE (cs.PaidAmount < cs.TotalAmount OR cs.IsPaid = 0) {creditSalesDateFilter}
UNION ALL
-- المشتريات النقدية
SELECT 'مشتريات نقدية', COALESCE(SUM(p.Total), 0) 
FROM Purchases p 
WHERE p.IsCredit = 0 {purchasesDateFilter}
UNION ALL
-- المشتريات الآجلة
SELECT 'مشتريات آجلة', COALESCE(SUM(p.Total - p.PaidAmount), 0) 
FROM Purchases p 
WHERE p.IsCredit = 1 {purchasesDateFilter}
UNION ALL
-- المصروفات
SELECT 'المصروفات', COALESCE(SUM(e.Amount), 0) 
FROM Expenses e 
WHERE 1=1 {expensesDateFilter}";

                default:
                    return "SELECT 'لا يوجد بيانات' AS [الرسالة]";
            }
        }

        private void FormatDataGridView(DataGridView dgv, string reportName)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AllowUserToResizeColumns = true;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;

            switch (reportName)
            {
                case "ديون الزبائن":
                    SetColumnOrder(dgv, new string[] {
                "رقم الزبون", "اسم الزبون", "هاتف", "حد الائتمان", "رصيد حالى",
                "رقم الفاتورة الآجلة", "رقم الفاتورة", "تاريخ الفاتورة", "اسم المنتج",
                "الكمية", "باكت", "نوع الوحدة", "المبلغ الإجمالى", "المبلغ المدفوع",
                "المبلغ المتبقى", "تاريخ الدفع", "مبلغ الدفع"
            });
                    SetColumnWidths(dgv, new int[] {
                80, 150, 100, 100, 100,  // Customer info
                120, 100, 150, 150,       // Invoice info
                100, 100, 120,              // Product details
                120, 120, 120,            // Amounts
                100, 100                  // Payments
            });
                    break;

                case "ديون الموردين":
                    SetColumnOrder(dgv, new string[] {
                "رقم المورد", "اسم المورد", "حد الائتمان", "رقم الشراء", "اسم المنتج",
                "الكمية", "باكت", "تاريخ الشراء", "المبلغ الإجمالى", "المبلغ المدفوع",
                "المبلغ المتبقى", "تاريخ الدفع", "مبلغ الدفع", "نوع الوحدة", "القطع الفعلية"
            });
                    SetColumnWidths(dgv, new int[] {
                80, 150, 100, 100, 150,   // Supplier info
                100, 100, 150, 100,          // Purchase info
                100, 100, 100,             // Amounts
                120, 120, 120, 100         // Payments and units
            });
                    break;

                case "المشتريات":
                    SetColumnOrder(dgv, new string[] {
                "رقم الشراء", "تاريخ الشراء", "اسم المنتج", "المورد", "الكمية",
                "نوع الوحدة", "سعر الوحدة المشتراة", "سعر القطعة الواحدة",
                "سعر العبوة الكاملة", "الإجمالي", "طريقة الدفع", "المتبقي للدفع", "تاريخ الاستحقاق"
            });
                    SetColumnWidths(dgv, new int[] {
                100, 150, 150, 150, 70,    // Purchase info
                120, 120, 120,             // Pricing
                120, 100, 120, 100, 120    // Payment info
            });
                    break;

                case "المبيعات":
                    SetColumnOrder(dgv, new string[] {
                "رقم الفاتورة", "تاريخ البيع", "اسم المستخدم", "اسم المنتج", "الكمية",
                "نوع الوحدة", "سعر الوحدة", "الإجمالي", "طريقة الدفع", "حالة المرتجع"
            });
                    SetColumnWidths(dgv, new int[] {
                100, 150, 150, 150, 70,   // Sales info
                100, 100, 100,            // Product details
                120, 120                  // Payment status
            });
                    break;

                case "الربح":
                    SetColumnOrder(dgv, new string[] {
                "اسم المنتج", "الكمية المباعة", "متوسط سعر الشراء", "متوسط سعر البيع",
                "الإيرادات", "تكلفة البضاعة المباعة", "الربح"
            });
                    SetColumnWidths(dgv, new int[] {
                200, 100, 120, 120, 120, 150, 120
            });
                    break;

                case "المصروفات":
                    SetColumnOrder(dgv, new string[] {
                "تاريخ المصروف", "المبلغ", "الوصف", "الفئة", "طريقة الدفع", "ملاحظات"
            });
                    SetColumnWidths(dgv, new int[] { 120, 100, 200, 120, 120, 200 });
                    break;

                case "الصندوق":
                    SetColumnOrder(dgv, new string[] {
                "تاريخ الحركة", "نوع الحركة", "الوصف", "المبلغ", "الرصيد التراكمي"
            });
                    SetColumnWidths(dgv, new int[] { 150, 120, 200, 120, 150 });
                    break;
            }

            // Format numeric columns
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.ValueType == typeof(decimal) ||
                    column.HeaderText.Contains("مبلغ") ||
                    column.HeaderText.Contains("سعر") ||
                    column.HeaderText.Contains("ربح") ||
                    column.HeaderText.Contains("إجمالي"))
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle.Format = "yyyy/MM/dd";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void SetColumnOrder(DataGridView dgv, string[] columnOrder)
        {
            for (int i = 0; i < columnOrder.Length; i++)
            {
                string colName = columnOrder[i];
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].DisplayIndex = i;
                }
            }
        }

        private void SetColumnWidths(DataGridView dgv, int[] widths)
        {
            for (int i = 0; i < widths.Length; i++)
            {
                if (i < dgv.Columns.Count)
                {
                    dgv.Columns[i].Width = widths[i];
                }
            }
        }

        private DataGridView FindDgvInTab(TabPage tab)
        {
            foreach (Control control in tab.Controls)
            {
                if (control is DataGridView)
                {
                    return (DataGridView)control;
                }
            }
            return null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataGridView dgv = FindDgvInTab(tabControl.SelectedTab);
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات للتصدير", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "ملف Excel|*.xlsx";
            saveFile.Title = "حفظ التقرير";
            saveFile.FileName = "تقرير " + tabControl.SelectedTab.Text + " " + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(dgv, saveFile.FileName);
                    MessageBox.Show("تم تصدير البيانات بنجاح", "تمت العملية",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء التصدير إلى Excel: " + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Worksheet)workbook.ActiveSheet;
                worksheet.Name = tabControl.SelectedTab.Text;

                worksheet.DisplayRightToLeft = true;

                Range titleRange = worksheet.Range["A1", "A1"];
                titleRange.Merge();
                titleRange.Value = "تقرير " + tabControl.SelectedTab.Text + " - " + DateTime.Now;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                titleRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
                titleRange.Interior.Color = ColorTranslator.ToOle(Color.LightBlue);

                int startRow = 3;
                int columnIndex = 1;

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible)
                    {
                        worksheet.Cells[startRow, columnIndex] = dgv.Columns[i].HeaderText;
                        columnIndex++;
                    }
                }

                Range headerRange = worksheet.Range[
                    worksheet.Cells[startRow, 1],
                    worksheet.Cells[startRow, columnIndex - 1]
                ];

                headerRange.Font.Bold = true;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.SteelBlue);
                headerRange.Font.Color = ColorTranslator.ToOle(Color.White);
                headerRange.Borders.Weight = XlBorderWeight.xlThin;
                headerRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].IsNewRow) continue;

                    columnIndex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible)
                        {
                            object value = dgv.Rows[i].Cells[j].Value;

                            if (value != null)
                            {
                                if (dgv.Columns[j].ValueType == typeof(decimal))
                                {
                                    worksheet.Cells[i + startRow + 1, columnIndex].NumberFormat = "#,##0.00";
                                }
                                else if (dgv.Columns[j].ValueType == typeof(DateTime))
                                {
                                    worksheet.Cells[i + startRow + 1, columnIndex].NumberFormat = "yyyy/mm/dd";
                                }

                                worksheet.Cells[i + startRow + 1, columnIndex] = value;
                            }

                            columnIndex++;
                        }
                    }
                }

                if (tabControl.SelectedTab.Text == "ديون الزبائن" ||
                    tabControl.SelectedTab.Text == "ديون الموردين")
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells["المبلغ المتبقى"].Value != null)
                        {
                            decimal balance = Convert.ToDecimal(dgv.Rows[i].Cells["المبلغ المتبقى"].Value);
                            if (balance > 0)
                            {
                                Range rowRange = worksheet.Range[
                                    worksheet.Cells[i + startRow + 1, 1],
                                    worksheet.Cells[i + startRow + 1, columnIndex - 1]
                                ];
                                rowRange.Interior.Color = ColorTranslator.ToOle(Color.LightCoral);
                            }
                        }
                    }
                }

                if (tabControl.SelectedTab.Text == "الربح")
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells["الربح"].Value != null)
                        {
                            decimal profit = Convert.ToDecimal(dgv.Rows[i].Cells["الربح"].Value);
                            Range rowRange = worksheet.Range[
                                worksheet.Cells[i + startRow + 1, 1],
                                worksheet.Cells[i + startRow + 1, columnIndex - 1]
                            ];

                            rowRange.Interior.Color = profit >= 0 ?
                                ColorTranslator.ToOle(Color.LightGreen) :
                                ColorTranslator.ToOle(Color.LightCoral);

                            rowRange.Font.Bold = true;
                        }
                    }
                }

                worksheet.Columns.AutoFit();

                Range dataRange = worksheet.Range[
                    worksheet.Cells[startRow, 1],
                    worksheet.Cells[dgv.Rows.Count + startRow, columnIndex - 1]
                ];
                dataRange.Borders.Weight = XlBorderWeight.xlThin;

                workbook.SaveAs(filePath);
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(workbook);
                }

                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }

                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}