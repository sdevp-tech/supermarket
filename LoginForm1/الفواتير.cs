using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class الفواتير : Form
    {
        private string connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";
        private DataTable invoiceDetails;
        int invoiceId;
        public الفواتير()
        {
            InitializeComponent();
            printDocument1.PrintPage += printDocument1_PrintPage;
            printPreviewDialog1.Document = printDocument1;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            ClearInvoiceDetails();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                MessageBox.Show("Please enter an invoice number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtInvoiceNumber.Text, out invoiceId))
            {
                MessageBox.Show("Please enter a valid invoice number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SearchInvoice(invoiceId);
        }

        private void SearchInvoice(int invoiceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Modified query with explicit column aliases
                    string headerQuery = @"
                SELECT 
                    s.SaleID, 
                    s.SaleDate, 
                    s.TotalAmount,  -- Make sure this matches your DB column name
                    u.Username AS CashierName
                FROM Sales s
                INNER JOIN Users u ON s.UserID = u.UserID
                WHERE s.SaleID = @SaleID";

                    using (SqlCommand command = new SqlCommand(headerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", invoiceId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblCashierName.Text = reader["CashierName"].ToString();
                                lblInvoiceDate.Text = Convert.ToDateTime(reader["SaleDate"]).ToString("yyyy-MM-dd HH:mm");

                                // Debug output to verify the value
                                decimal total = Convert.ToDecimal(reader["TotalAmount"]);
                                Console.WriteLine("DEBUG - Total from DB: " + (total));

                                lblInvoiceTotal.Text = total.ToString("C");
                            }
                            else
                            {
                                ClearInvoiceDetails();
                                MessageBox.Show("Invoice not found");
                                return;
                            }
                        }
                    }

                    // Get invoice items
                    string itemsQuery = @"
                        SELECT p.ProductName, sd.Quantity, sd.UnitPrice, sd.Total
                        FROM SaleDetails sd
                        INNER JOIN Products p ON sd.ProductID = p.ProductID
                        WHERE sd.SaleID = @SaleID";

                    invoiceDetails = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(itemsQuery, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SaleID", invoiceId);
                        adapter.Fill(invoiceDetails);
                    }

                    dgvInvoiceItems.DataSource = invoiceDetails;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching invoice:" + (ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvInvoiceItems.Columns["ProductName"].HeaderText = "Product Name";
            dgvInvoiceItems.Columns["Quantity"].HeaderText = "Qty";
            dgvInvoiceItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            dgvInvoiceItems.Columns["Total"].HeaderText = "Total";

            dgvInvoiceItems.Columns["UnitPrice"].DefaultCellStyle.Format = "C";
            dgvInvoiceItems.Columns["Total"].DefaultCellStyle.Format = "C";

            dgvInvoiceItems.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInvoiceItems.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInvoiceItems.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ClearInvoiceDetails()
        {
            lblCashierName.Text = "";
            lblInvoiceDate.Text = "";
            lblInvoiceTotal.Text = "";
            dgvInvoiceItems.DataSource = null;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInvoiceNumber.Text))
            {
                MessageBox.Show("Please search for an invoice first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (invoiceDetails == null || invoiceDetails.Rows.Count == 0)
            {
                MessageBox.Show("No invoice items found to print", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify we have data to print
            if (string.IsNullOrEmpty(lblCashierName.Text) ||
                string.IsNullOrEmpty(lblInvoiceDate.Text) ||
                string.IsNullOrEmpty(lblInvoiceTotal.Text))
            {
                MessageBox.Show("Incomplete invoice data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set up fonts
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 10, FontStyle.Bold);

            // Set up margins and starting position
            int leftMargin = 50;
            int rightMargin = 50;
            int topMargin = 50;
            int yPos = topMargin;

            // Draw title
            string title = "فاتورة بيع";
            e.Graphics.DrawString(title, titleFont, Brushes.Black,
                new PointF((e.PageBounds.Width - e.Graphics.MeasureString(title, titleFont).Width) / 2, yPos));
            yPos += 40;

            // Draw invoice header information
            e.Graphics.DrawString("رقم الفاتورة:" + (txtInvoiceNumber.Text), headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString("التاريخ: " + (lblInvoiceDate.Text), headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString("المحاسب: " + (lblCashierName.Text), headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Draw column headers
            e.Graphics.DrawString("المنتج", headerFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString("الكمية", headerFont, Brushes.Black, leftMargin + 300, yPos);
            e.Graphics.DrawString("السعر", headerFont, Brushes.Black, leftMargin + 400, yPos);
            e.Graphics.DrawString("الاجمالي", headerFont, Brushes.Black, leftMargin + 500, yPos);
            yPos += 25;

            // Draw line under headers
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - rightMargin, yPos);
            yPos += 10;

            // Draw invoice items
            foreach (DataRow row in invoiceDetails.Rows)
            {
                e.Graphics.DrawString(row["ProductName"].ToString(), regularFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString(row["Quantity"].ToString(), regularFont, Brushes.Black, leftMargin + 300, yPos);
                e.Graphics.DrawString(Convert.ToDecimal(row["UnitPrice"]).ToString("C"), regularFont, Brushes.Black, leftMargin + 400, yPos);
                e.Graphics.DrawString(Convert.ToDecimal(row["Total"]).ToString("C"), regularFont, Brushes.Black, leftMargin + 500, yPos);
                yPos += 20;
            }

            yPos += 20;

            // Draw total
            e.Graphics.DrawString("الاجمالي:", headerFont, Brushes.Black, leftMargin + 400, yPos);
            e.Graphics.DrawString(lblInvoiceTotal.Text, headerFont, Brushes.Black, leftMargin + 500, yPos);
            yPos += 30;

            // Draw footer
            string footer = "مرحبا بك في متجرنا";
            e.Graphics.DrawString(footer, regularFont, Brushes.Black,
                new PointF((e.PageBounds.Width - e.Graphics.MeasureString(footer, regularFont).Width) / 2, yPos));

            // Indicate we're done (no more pages)
            e.HasMorePages = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}