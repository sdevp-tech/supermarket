using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace LoginForm1
{
    public partial class IncomeCalculatorForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";

        public IncomeCalculatorForm()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.Columns.Clear();

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SaleID",
                HeaderText = "رقم البيع",
                Name = "colID",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SaleDate",
                HeaderText = "تاريخ البيع",
                Name = "colSaleDate",
                Width = 200
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Salesperson",
                HeaderText = "اسم البائع",
                Name = "colUserType",
                Width = 100
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "اسم المنتج",
                Name = "colIsActive",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NetQuantity",
                HeaderText = "الكمية",
                Name = "colNetQuantity",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "سعر الشراء",
                Name = "colUnitPrice",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalIncome",
                HeaderText = "إجمالي الدخل",
                Name = "colTotalIncome",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalCost",
                HeaderText = "إجمالي التكلفة",
                Name = "colTotalCost",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Profit",
                HeaderText = "الربح",
                Name = "colProfit",
                Width = 150
            });
        }

        private void IncomeCalculatorForm_Load_1(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today.AddMonths(-1);
            dtpToDate.Value = DateTime.Today;
            LoadSalespersons();
            btnCalculate.Click += new EventHandler(btnCalculate_Click_1);
            btnExport.Click += new EventHandler(btnExport_Click_1);
        }

        private void LoadSalespersons()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserID, Username FROM Users WHERE UserType IN ('Manager', 'Cashier') ORDER BY Username";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow newRow = dt.NewRow();
                    newRow["UserID"] = 0;
                    newRow["Username"] = "All Salespersons";
                    dt.Rows.InsertAt(newRow, 0);

                    cboSalesperson.DataSource = dt;
                    cboSalesperson.DisplayMember = "Username";
                    cboSalesperson.ValueMember = "UserID";
                    cboSalesperson.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading salespersons: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("From date cannot be after To date", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Updated query with correct cost calculation for packages
                    string salesQuery = @"SELECT 
                        s.SaleID,
                        s.SaleDate, 
                        u.Username AS Salesperson, 
                        p.ProductName, 
                        sd.Quantity - ISNULL((SELECT SUM(r.Quantity) 
                                             FROM Returns r 
                                             WHERE r.SaleID = s.SaleID 
                                             AND r.ProductID = p.ProductID), 0) AS NetQuantity,
                        sd.UnitPrice, 
                        (sd.Quantity - ISNULL((SELECT SUM(r.Quantity) 
                                             FROM Returns r 
                                             WHERE r.SaleID = s.SaleID 
                                             AND r.ProductID = p.ProductID), 0)) * sd.UnitPrice AS TotalIncome,
                        -- FIX: Calculate cost based on package/unit sales
                        (sd.Quantity - ISNULL((SELECT SUM(r.Quantity) 
                                             FROM Returns r 
                                             WHERE r.SaleID = s.SaleID 
                                             AND r.ProductID = p.ProductID), 0)) 
                        * 
                        CASE 
                            WHEN sd.IsPackage = 1 THEN p.PackageSize * p.PurchasePrice 
                            ELSE p.PurchasePrice 
                        END AS TotalCost,
                        -- Calculate profit using fixed cost calculation
                        (sd.Quantity - ISNULL((SELECT SUM(r.Quantity) 
                                             FROM Returns r 
                                             WHERE r.SaleID = s.SaleID 
                                             AND r.ProductID = p.ProductID), 0)) * sd.UnitPrice 
                        - 
                        (sd.Quantity - ISNULL((SELECT SUM(r.Quantity) 
                                             FROM Returns r 
                                             WHERE r.SaleID = s.SaleID 
                                             AND r.ProductID = p.ProductID), 0)) 
                        * 
                        CASE 
                            WHEN sd.IsPackage = 1 THEN p.PackageSize * p.PurchasePrice 
                            ELSE p.PurchasePrice 
                        END AS Profit
                    FROM SaleDetails sd
                    INNER JOIN Sales s ON sd.SaleID = s.SaleID
                    INNER JOIN Products p ON sd.ProductID = p.ProductID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    WHERE s.SaleDate BETWEEN @FromDate AND @ToDate
                    AND s.IsFinalized = 1
                    AND (@SalespersonID = 0 OR s.UserID = @SalespersonID)
                    AND (sd.Quantity - ISNULL((SELECT SUM(r.Quantity) 
                                             FROM Returns r 
                                             WHERE r.SaleID = s.SaleID 
                                             AND r.ProductID = p.ProductID), 0)) > 0
                    ORDER BY s.SaleDate, u.Username";

                    SqlDataAdapter salesAdapter = new SqlDataAdapter(salesQuery, conn);
                    salesAdapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                    salesAdapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1));
                    salesAdapter.SelectCommand.Parameters.AddWithValue("@SalespersonID", Convert.ToInt32(cboSalesperson.SelectedValue));

                    DataTable salesTable = new DataTable();
                    salesAdapter.Fill(salesTable);

                    dgvResults.DataSource = salesTable;
                    CalculateTotals(salesTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating income: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals(DataTable salesTable)
        {
            decimal totalIncome = 0;
            decimal totalCost = 0;
            decimal totalProfit = 0;

            foreach (DataRow row in salesTable.Rows)
            {
                totalIncome += Convert.ToDecimal(row["TotalIncome"]);
                totalCost += Convert.ToDecimal(row["TotalCost"]);
                totalProfit += Convert.ToDecimal(row["Profit"]);
            }

            // Use regular formatting instead of currency
            lblTotalIncome.Text = totalIncome.ToString("N2");
            lblTotalPurchases.Text = totalCost.ToString("N2");
            lblProfit.Text = totalProfit.ToString("N2");

            lblProfit.ForeColor = totalProfit >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            if (dgvResults.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xls)|*.xls";
            sfd.FileName = "IncomeReport_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create HTML content for Excel
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                    sb.AppendLine("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                    sb.AppendLine("xmlns=\"http://www.w3.org/TR/REC-html40\">");
                    sb.AppendLine("<head>");
                    sb.AppendLine("<meta charset=\"utf-8\">");
                    sb.AppendLine("<!--[if gte mso 9]>");
                    sb.AppendLine("<xml>");
                    sb.AppendLine("<x:ExcelWorkbook>");
                    sb.AppendLine("<x:ExcelWorksheets>");
                    sb.AppendLine("<x:ExcelWorksheet>");
                    sb.AppendLine("<x:Name>Income Report</x:Name>");
                    sb.AppendLine("<x:WorksheetOptions>");
                    sb.AppendLine("<x:DisplayGridlines/>");
                    sb.AppendLine("</x:WorksheetOptions>");
                    sb.AppendLine("</x:ExcelWorksheet>");
                    sb.AppendLine("</x:ExcelWorksheets>");
                    sb.AppendLine("</x:ExcelWorkbook>");
                    sb.AppendLine("</xml>");
                    sb.AppendLine("<![endif]-->");
                    sb.AppendLine("</head>");
                    sb.AppendLine("<body>");
                    sb.AppendLine("<table border='1'>");

                    // Add headers
                    sb.Append("<tr>");
                    foreach (DataGridViewColumn col in dgvResults.Columns)
                    {
                        sb.AppendFormat("<th style='background-color: #D3D3D3;'>{0}</th>", col.HeaderText);
                    }
                    sb.AppendLine("</tr>");

                    // Add data rows
                    foreach (DataGridViewRow row in dgvResults.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.Append("<td>");
                            sb.Append(cell.Value == null ? "" : cell.Value.ToString());
                            sb.Append("</td>");
                        }
                        sb.AppendLine("</tr>");
                    }

                    // Add totals row
                    sb.Append("<tr style='font-weight:bold; background-color:#E6E6E6;'>");
                    sb.Append("<td colspan='6' align='right'>Totals:</td>");
                    sb.AppendFormat("<td>{0}</td>", lblTotalIncome.Text);
                    sb.AppendFormat("<td>{0}</td>", lblTotalPurchases.Text);
                    sb.AppendFormat("<td>{0}</td>", lblProfit.Text);
                    sb.AppendLine("</tr>");

                    sb.AppendLine("</table>");
                    sb.AppendLine("</body>");
                    sb.AppendLine("</html>");

                    // Write to file
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Data exported successfully to Excel file", "Export Complete",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data: " + ex.Message, "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}