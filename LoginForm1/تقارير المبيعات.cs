using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace LoginForm1
{
    public partial class تقارير_المبيعات : Form
    {
        private SqlConnection con = DatabaseHelper.GetConnection();

        // Helper class to store sale info
        private class SaleInfo
        {
            public decimal SaleTotal { get; set; }
            public string PaymentMethod { get; set; }
        }

        public تقارير_المبيعات()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Load += SalesReportForm_Load;
            this.Resize += SalesReportForm_Resize;
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            ConfigureDataGridView();
            LoadSalesData();
        }

        private void SalesReportForm_Resize(object sender, EventArgs e)
        {
            if (dgvSales.Columns.Count > 0)
            {
                int totalWidth = dgvSales.ClientSize.Width;
                foreach (DataGridViewColumn column in dgvSales.Columns)
                {
                    column.Width = totalWidth / dgvSales.Columns.Count;
                }
            }
        }

        private void ConfigureDataGridView()
        {
            dgvSales.AutoGenerateColumns = false;
            dgvSales.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            dgvSales.EnableHeadersVisualStyles = false;
            dgvSales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSales.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvSales.Columns.Clear();

            AddColumn("SaleID", "رقم الفاتورة", 80);
            AddColumn("SaleDate", "تاريخ البيع", 120);
            AddColumn("CashierName", "اسم الموظف", 120);
            AddColumn("ProductName", "اسم المنتج", 150);
            AddColumn("Barcode", "الباركود", 100);
            AddColumn("CategoryName", "الفئة", 100);
            AddColumn("Quantity", "الكمية", 70, "N0");
            AddColumn("UnitPrice", "سعر الوحدة", 90, "N2");
            AddColumn("TotalPrice", "الإجمالي", 100, "N2");
            AddColumn("PaymentMethod", "طريقة الدفع", 100);
            AddColumn("ItemsCount", "عدد الأصناف", 80, "N0");
            AddColumn("ReturnStatus", "حالة المرتجع", 100);
        }

        private void AddColumn(string name, string header, int width, string format = null)
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = name;
            col.HeaderText = header;
            col.Width = width;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (!string.IsNullOrEmpty(format))
            {
                col.DefaultCellStyle.Format = format;
            }

            dgvSales.Columns.Add(col);
        }

        private void LoadSalesData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string query = @"SELECT 
                s.SaleID,
                FORMAT(s.SaleDate, 'yyyy-MM-dd HH:mm') AS SaleDate,
                u.Username AS CashierName,
                p.ProductName,
                p.Barcode,
                cat.CategoryName,
                sd.Quantity,
                sd.UnitPrice,
                sd.Total AS TotalPrice,
                s.TotalAmount AS SaleTotal,
                s.PaymentMethod,
                (SELECT COUNT(*) FROM SaleDetails WHERE SaleID = s.SaleID) AS ItemsCount,
                CASE 
                    WHEN EXISTS (SELECT 1 FROM Returns r 
                                 WHERE r.SaleID = s.SaleID AND r.ProductID = p.ProductID) 
                    THEN 'مرتجع' 
                    ELSE 'غير مرتجع' 
                END AS ReturnStatus
            FROM Sales s
            JOIN SaleDetails sd ON s.SaleID = sd.SaleID
            JOIN Products p ON sd.ProductID = p.ProductID
            JOIN Categories cat ON p.CategoryID = cat.CategoryID
            JOIN Users u ON s.UserID = u.UserID
            WHERE s.SaleDate BETWEEN @StartDate AND @EndDate
            AND s.IsFinalized = 1
            ORDER BY s.SaleDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSales.DataSource = dt;
                    CalculateTotals(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CalculateTotals(DataTable dt)
        {
            // Reset all totals
            lblTotalSales.Text = "0.00";
            lblTotalItems.Text = "0";
            lblSoldInvoices.Text = "0";
            lblReturnedInvoices.Text = "0";
            lblCashTotal.Text = "0.00";
            lblCreditTotal.Text = "0.00";
            lblEWalletTotal.Text = "0.00";
            lblCardTotal.Text = "0.00";

            if (dt.Rows.Count == 0)
            {
                lblTotalSales.Text = "لا توجد بيانات";
                return;
            }

            try
            {
                // Calculate total sales (sum of distinct sale totals)
                decimal totalSales = 0;
                var distinctSales = new Dictionary<int, SaleInfo>();
                var returnedInvoices = new HashSet<int>();

                // Payment type totals
                decimal cashTotal = 0;
                decimal creditTotal = 0;
                decimal ewalletTotal = 0;
                decimal cardTotal = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int saleId = Convert.ToInt32(row["SaleID"]);
                    decimal saleTotal = Convert.ToDecimal(row["SaleTotal"]);
                    string paymentMethod = row["PaymentMethod"].ToString();

                    if (!distinctSales.ContainsKey(saleId))
                    {
                        distinctSales.Add(saleId, new SaleInfo
                        {
                            SaleTotal = saleTotal,
                            PaymentMethod = paymentMethod
                        });
                        totalSales += saleTotal;

                        // Update payment type totals
                        switch (paymentMethod)
                        {
                            case "Cash":
                                cashTotal += saleTotal;
                                break;
                            case "Credit":
                                creditTotal += saleTotal;
                                break;
                            case "EWallet":
                                ewalletTotal += saleTotal;
                                break;
                            case "Card":
                                cardTotal += saleTotal;
                                break;
                        }
                    }

                    // Check if this product was returned
                    if (row["ReturnStatus"].ToString() == "مرتجع")
                    {
                        returnedInvoices.Add(saleId);
                    }
                }

                // Calculate total items
                int totalItems = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalItems += Convert.ToInt32(row["Quantity"]);
                }

                // Get transaction count
                int transactionCount = distinctSales.Count;
                int returnedInvoiceCount = returnedInvoices.Count;
                int soldInvoiceCount = transactionCount - returnedInvoiceCount;

                // Calculate net sales (excluding returns)
                decimal netSales = totalSales;
                foreach (int invoiceId in returnedInvoices)
                {
                    netSales -= distinctSales[invoiceId].SaleTotal;
                }

                // Update labels
                lblTotalSales.Text = netSales.ToString("N2");
                lblTotalItems.Text = totalItems.ToString("N0");
                lblSoldInvoices.Text = soldInvoiceCount.ToString();
                lblReturnedInvoices.Text = returnedInvoiceCount.ToString();
                lblCashTotal.Text = cashTotal.ToString("N2");
                lblCreditTotal.Text = creditTotal.ToString("N2");
                lblEWalletTotal.Text = ewalletTotal.ToString("N2");
                lblCardTotal.Text = cardTotal.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في حساب الإجماليات: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvSales.Rows.Count == 0 || dgvSales.DataSource == null)
            {
                MessageBox.Show("لا توجد بيانات للطباعة", "تحذير",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += new PrintPageEventHandler(PrintSalesReport);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.WindowState = FormWindowState.Maximized;
            preview.Text = "معاينة طباعة تقرير المبيعات";

            preview.ShowDialog();
        }

        private void PrintSalesReport(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            e.PageSettings.Landscape = true;

            try
            {
                Font titleFont = new Font("Tahoma", 16, FontStyle.Bold);
                Font headerFont = new Font("Tahoma", 10, FontStyle.Bold);
                Font normalFont = new Font("Tahoma", 9);
                Font smallFont = new Font("Tahoma", 8);

                StringFormat arabicFormat = new StringFormat();
                arabicFormat.Alignment = StringAlignment.Far;
                arabicFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                arabicFormat.LineAlignment = StringAlignment.Center;

                int leftMargin = 100;
                int rightMargin = 100;
                int topMargin = 100;
                int bottomMargin = 100;

                int printableWidth = e.PageBounds.Width - leftMargin - rightMargin;
                int printableHeight = e.PageBounds.Height - topMargin - bottomMargin;
                int currentY = topMargin;

                e.Graphics.DrawString("شركة تجارية", titleFont, Brushes.Black,
                                   new RectangleF(leftMargin, currentY, printableWidth, titleFont.Height),
                                   arabicFormat);
                currentY += titleFont.Height + 20;

                string title = "تقرير المبيعات";
                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                                   new RectangleF(leftMargin, currentY, printableWidth, titleFont.Height),
                                   arabicFormat);
                currentY += titleFont.Height + 20;

                string dateRange = string.Format("الفترة من {0} إلى {1}",
                    dtpStartDate.Value.ToString("yyyy/MM/dd"),
                    dtpEndDate.Value.ToString("yyyy/MM/dd"));
                e.Graphics.DrawString(dateRange, headerFont, Brushes.Black,
                                   new RectangleF(leftMargin, currentY, printableWidth, headerFont.Height),
                                   arabicFormat);
                currentY += headerFont.Height + 30;

                string summary = string.Format("عدد الفواتير المباعة: {0} | عدد الفواتير المرتجعة: {1} | صافي المبيعات: {2:N2}",
                    lblSoldInvoices.Text, lblReturnedInvoices.Text, lblTotalSales.Text);
                e.Graphics.DrawString(summary, headerFont, Brushes.Black,
                                   new RectangleF(leftMargin, currentY, printableWidth, headerFont.Height),
                                   arabicFormat);
                currentY += headerFont.Height + 30;

                float[] columnWidths = new float[dgvSales.Columns.Count];
                float totalColumnsWidth = 0;

                for (int i = 0; i < dgvSales.Columns.Count; i++)
                {
                    if (dgvSales.Columns[i].Visible)
                    {
                        columnWidths[i] = e.Graphics.MeasureString(
                            dgvSales.Columns[i].HeaderText, headerFont).Width + 20;
                        totalColumnsWidth += columnWidths[i];
                    }
                }

                if (totalColumnsWidth > printableWidth)
                {
                    float ratio = printableWidth / totalColumnsWidth;
                    for (int i = 0; i < columnWidths.Length; i++)
                    {
                        columnWidths[i] *= ratio;
                    }
                    totalColumnsWidth = printableWidth;
                }

                float currentX = e.PageBounds.Width - rightMargin;
                int headerHeight = (int)(headerFont.Height * 1.5);

                for (int i = 0; i < dgvSales.Columns.Count; i++)
                {
                    if (dgvSales.Columns[i].Visible)
                    {
                        RectangleF rect = new RectangleF(
                            currentX - columnWidths[i],
                            currentY,
                            columnWidths[i],
                            headerHeight);

                        e.Graphics.FillRectangle(Brushes.LightGray, rect);
                        e.Graphics.DrawRectangle(Pens.DarkGray, rect.X, rect.Y, rect.Width, rect.Height);

                        e.Graphics.DrawString(dgvSales.Columns[i].HeaderText,
                                            headerFont, Brushes.Black,
                                            rect, arabicFormat);

                        currentX -= columnWidths[i];
                    }
                }
                currentY += headerHeight;

                bool morePages = false;
                int rowsPrinted = 0;
                int rowHeight = (int)(normalFont.Height * 1.2);

                while (rowsPrinted < dgvSales.Rows.Count && !morePages)
                {
                    if (dgvSales.Rows[rowsPrinted].IsNewRow)
                    {
                        rowsPrinted++;
                        continue;
                    }

                    if (currentY + rowHeight > e.PageBounds.Height - bottomMargin)
                    {
                        morePages = true;
                        break;
                    }

                    currentX = e.PageBounds.Width - rightMargin;

                    for (int i = 0; i < dgvSales.Columns.Count; i++)
                    {
                        if (dgvSales.Columns[i].Visible)
                        {
                            DataGridViewCell cell = dgvSales.Rows[rowsPrinted].Cells[i];
                            string cellValue = cell.Value != null ? cell.Value.ToString() : "";

                            RectangleF cellRect = new RectangleF(
                                currentX - columnWidths[i],
                                currentY,
                                columnWidths[i],
                                rowHeight);

                            if (rowsPrinted % 2 == 0)
                                e.Graphics.FillRectangle(Brushes.White, cellRect);
                            else
                                e.Graphics.FillRectangle(Brushes.WhiteSmoke, cellRect);

                            e.Graphics.DrawRectangle(Pens.LightGray, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                            e.Graphics.DrawString(cellValue, normalFont, Brushes.Black,
                                               cellRect, arabicFormat);

                            currentX -= columnWidths[i];
                        }
                    }

                    currentY += rowHeight;
                    rowsPrinted++;
                }

                string footer = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                e.Graphics.DrawString(footer, smallFont, Brushes.Black,
                                   leftMargin, e.PageBounds.Height - bottomMargin + 20);

                string pageNum = "الصفحة 1";
                e.Graphics.DrawString(pageNum, smallFont, Brushes.Black,
                                   e.PageBounds.Width - rightMargin - 50,
                                   e.PageBounds.Height - bottomMargin + 20,
                                   arabicFormat);

                e.HasMorePages = morePages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الطباعة: " + ex.Message, "خطأ",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "ملف Excel|*.xlsx";
            saveFile.Title = "حفظ التقرير";
            saveFile.FileName = string.Format("تقرير المبيعات {0:yyyy-MM-dd}", DateTime.Now);

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(saveFile.FileName);
            }
        }

        private void ExportToExcel(string filePath)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                worksheet.Name = "تقرير المبيعات";

                int columnIndex = 1;
                foreach (DataGridViewColumn column in dgvSales.Columns)
                {
                    if (column.Visible)
                    {
                        worksheet.Cells[1, columnIndex] = column.HeaderText;
                        columnIndex++;
                    }
                }

                for (int i = 0; i < dgvSales.Rows.Count; i++)
                {
                    if (dgvSales.Rows[i].IsNewRow) continue;

                    columnIndex = 1;
                    foreach (DataGridViewCell cell in dgvSales.Rows[i].Cells)
                    {
                        if (cell.OwningColumn.Visible)
                        {
                            worksheet.Cells[i + 2, columnIndex] = cell.Value != null ? cell.Value.ToString() : "";
                            columnIndex++;
                        }
                    }
                }

                Microsoft.Office.Interop.Excel.Range range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dgvSales.Rows.Count, columnIndex - 1]];
                range.EntireColumn.AutoFit();

                Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnIndex - 1]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(37, 37, 38));
                headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                workbook.Close(false, Type.Missing, Type.Missing);
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("تم تصدير البيانات بنجاح إلى: " + filePath, "تم",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التصدير إلى Excel: " + ex.Message, "خطأ",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            الفواتير invo = new الفواتير();
            invo.Show();
        }
    }
}