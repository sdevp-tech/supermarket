using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class المرجعات : Form
    {
        private const string connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";
        private DataTable saleItems;

        public المرجعات()
        {
            InitializeComponent();
            cmbReason.Items.AddRange(new string[] { "غير راية", "اخطا في المنتج" });
        }

        private void btnLoadSale_Click(object sender, EventArgs e)
        {
            int saleID;

            if (!int.TryParse(txtSaleID.Text, out saleID))
            {
                MessageBox.Show("الرجاء إدخال رقم فاتورة صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT sd.ProductID, p.ProductName, sd.Quantity AS SoldQuantity " +
                        "FROM SaleDetails sd " +
                        "JOIN Products p ON sd.ProductID = p.ProductID " +
                        "WHERE sd.SaleID = @SaleID", conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    saleItems = new DataTable();
                    adapter.Fill(saleItems);

                    if (saleItems.Rows.Count == 0)
                    {
                        MessageBox.Show("لا توجد منتجات في الفاتورة المحددة", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dgvSaleItems.DataSource = saleItems;
                    cmbProduct.DataSource = saleItems;
                    cmbProduct.DisplayMember = "ProductName";
                    cmbProduct.ValueMember = "ProductID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل بيانات الفاتورة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcessReturn_Click(object sender, EventArgs e)
        {
            int saleID;
            int returnQty;
            // Validate inputs
            if (!int.TryParse(txtSaleID.Text, out saleID))
            {
                MessageBox.Show("رقم الفاتورة غير صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("الرجاء اختيار منتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out returnQty) || returnQty <= 0)
            {
                MessageBox.Show("الرجاء إدخال كمية صحيحة (أكبر من الصفر)", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbReason.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء اختيار سبب الاسترجاع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int productID = (int)cmbProduct.SelectedValue;
            string reason = cmbReason.Text;

            try
            {
                // Verify product exists in sale
                int soldQty = GetSoldQuantity(saleID, productID);
                if (soldQty <= 0)
                {
                    MessageBox.Show("هذا المنتج غير موجود في الفاتورة المحددة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check available quantity to return
                int alreadyReturned = GetAlreadyReturned(saleID, productID);
                int remainingQty = soldQty - alreadyReturned;

                if (returnQty > remainingQty)
                {
                    MessageBox.Show("يمكنك استرجاع حد أقصى " + (remainingQty) + " وحدة من هذا المنتج",
                                   "خطأ في الكمية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Process the return
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert return record
                            SqlCommand cmd = new SqlCommand(
                                "INSERT INTO Returns (SaleID, ProductID, Quantity, Reason) " +
                                "VALUES (@SaleID, @ProductID, @Quantity, @Reason)", conn, transaction);
                            cmd.Parameters.AddWithValue("@SaleID", saleID);
                            cmd.Parameters.AddWithValue("@ProductID", productID);
                            cmd.Parameters.AddWithValue("@Quantity", returnQty);
                            cmd.Parameters.AddWithValue("@Reason", reason);
                            cmd.ExecuteNonQuery();

                            // Update sale total
                            cmd = new SqlCommand(
                                "UPDATE Sales SET TotalAmount = TotalAmount - " +
                                "(SELECT @Quantity * UnitPrice FROM SaleDetails " +
                                "WHERE SaleID = @SaleID AND ProductID = @ProductID) " +
                                "WHERE SaleID = @SaleID", conn, transaction);
                            cmd.Parameters.AddWithValue("@SaleID", saleID);
                            cmd.Parameters.AddWithValue("@ProductID", productID);
                            cmd.Parameters.AddWithValue("@Quantity", returnQty);
                            cmd.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("تمت عملية الاسترجاع بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("فشلت عملية الاسترجاع: " + (ex.Message), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + (ex.Message), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSoldQuantity(int saleID, int productID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT COALESCE(
                            (SELECT Quantity 
                             FROM SaleDetails 
                             WHERE SaleID = @SaleID AND ProductID = @ProductID), 0)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        var result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return 0; // Fail-safe return
            }
        }

        private int GetAlreadyReturned(int saleID, int productID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT COALESCE(
                            (SELECT SUM(Quantity) 
                             FROM Returns 
                             WHERE SaleID = @SaleID AND ProductID = @ProductID), 0)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        var result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return 0; // Fail-safe return
            }
        }

        private void ClearForm()
        {
            txtSaleID.Clear();
            dgvSaleItems.DataSource = null;
            cmbProduct.DataSource = null;
            txtQuantity.Clear();
            cmbReason.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            تقارير_المبيعات RE = new تقارير_المبيعات();
            RE.Show();
        }
    }
}   