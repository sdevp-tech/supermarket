using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace LoginForm1
{
    public partial class المخزان : Form
    {
        private const string connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";

        public المخزان()
        {
            InitializeComponent();
            LoadInventory();
            CheckLowStock();

            SetupProductComboBoxColumn(); // Add this line
        }



        private void SetupProductComboBoxColumn()
        {
            // Load products for the ComboBox
            DataTable productsDt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductID, ProductName AS 'اسم المنتج' FROM Products", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(productsDt);
            }

            // Create and configure the ComboBox column
            DataGridViewComboBoxColumn productColumn = new DataGridViewComboBoxColumn();
            productColumn.HeaderText = "اسم المنتج";
            productColumn.DataPropertyName = "ProductID";
            productColumn.Name = "اسم المنتج";
            productColumn.DisplayMember = "اسم المنتج";
            productColumn.ValueMember = "ProductID";
            productColumn.DataSource = productsDt;

            // Replace the existing ProductName column
            if (dgvInventory.Columns.Contains("ProductName"))
            {
                dgvInventory.Columns.Remove("ProductName");
            }
            dgvInventory.Columns.Add(productColumn);
            dgvInventory.Columns["اسم المنتج"].DisplayIndex = 1; // Adjust display index as needed

            // Hide the ProductID column
            dgvInventory.Columns["ProductID"].Visible = false;
        }

        private void LoadInventory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Modified query to include ProductID
                SqlCommand cmd = new SqlCommand(
                    "SELECT i.InventoryID as 'الرقم', p.ProductID,  i.Quantity as 'الكمية', p.ReorderLevel as 'مستوى الطلب' " +
                    "FROM Inventory i " +
                    "JOIN Products p ON i.ProductID = p.ProductID", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvInventory.DataSource = dt;

                // Highlight low-stock items
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    if (row.IsNewRow) continue;
                    int stock = Convert.ToInt32(row.Cells["الكمية"].Value);
                    int reorderLevel = Convert.ToInt32(row.Cells["مستوى الطلب"].Value);
                    if (stock <= reorderLevel)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        private void CheckLowStock()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT p.ProductName, i.Quantity, p.ReorderLevel " +
                    "FROM Inventory i " +
                    "JOIN Products p ON i.ProductID = p.ProductID " +
                    "WHERE i.Quantity <= p.ReorderLevel", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder alert = new StringBuilder();
                alert.AppendLine("Low Stock Alert!\n-----------------");

                while (reader.Read())
                {
                    alert.AppendLine(
                        reader["ProductName"] + ": " +
                        reader["Quantity"] + " left (Reorder at " +
                        reader["ReorderLevel"] + ")"
                    );
                }

                if (alert.Length > 0)
                {
                    MessageBox.Show(alert.ToString(), "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        // Load purchase history




        // Refresh data
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadInventory();

        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT i.InventoryID, p.ProductID, p.ProductName, i.Quantity, p.ReorderLevel " +
                    "FROM Inventory i " +
                    "JOIN Products p ON i.ProductID = p.ProductID " +
                    "WHERE p.Barcode LIKE @Barcode", conn);
                cmd.Parameters.AddWithValue("@Barcode", "%" + (txtBarcodeFilter.Text) + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvInventory.DataSource = dt;
            }
        }



        private void btnExport_Click_1(object sender, EventArgs e)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "CSV Files (*.csv)|*.csv";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csv = new StringBuilder();
                string filter = txtBarcodeFilter.Text;

                if (string.IsNullOrEmpty(filter))
                {
                    csv.AppendLine("ProductName,Quantity,ReorderLevel");
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {

                        csv.AppendLine(

                            "" + (row.Cells["ProductName"].Value) + "," +
                            "" + (row.Cells["Quantity"].Value) + "," +
                            "" + (row.Cells["ReorderLevel"].Value) + ""
                        );
                    }
                }
                else if (!string.IsNullOrEmpty(filter))
                {
                    csv.AppendLine("ProductID,ProductName,Quantity,ReorderLevel");

                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {

                        csv.AppendLine(
                            "" + (row.Cells["ProductID"].Value) + "," +
                            "" + (row.Cells["ProductName"].Value) + "," +
                            "" + (row.Cells["Quantity"].Value) + "," +
                            "" + (row.Cells["ReorderLevel"].Value) + ""
                        );
                    }
                }


                File.WriteAllText(saveFile.FileName, csv.ToString());
                MessageBox.Show("Exported successfully!");
            }
        }

        // Add this new method for saving changes
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvInventory.DataSource;
            bool hasChanges = false;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        // Insert new inventory record
                        int productID = Convert.ToInt32(row["ProductID"]);
                        int quantity = Convert.ToInt32(row["الكمية"]);

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "INSERT INTO Inventory (ProductID, Quantity) VALUES (@ProductID, @Quantity)", conn);
                            cmd.Parameters.AddWithValue("@ProductID", productID);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.ExecuteNonQuery();
                        }
                        hasChanges = true;
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                        // Update existing inventory record's Quantity
                        int inventoryID = Convert.ToInt32(row["الرقم"]);
                        int quantity = Convert.ToInt32(row["الكمية"]);

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "UPDATE Inventory SET Quantity = @Quantity WHERE InventoryID = @InventoryID", conn);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@InventoryID", inventoryID);
                            cmd.ExecuteNonQuery();
                        }
                        hasChanges = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (hasChanges)
            {
                LoadInventory(); // Refresh to show new data
                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvInventory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvInventory.Columns[e.ColumnIndex].Name == "ProductName")
            {
                // Allow editing only for new rows
                if (!dgvInventory.Rows[e.RowIndex].IsNewRow)
                {
                    e.Cancel = true;
                }
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product to delete!");
                return;
            }

            int InventoryID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["الرقم"].Value);
            if (MessageBox.Show("Delete this Product from inventroy?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM Inventory WHERE InventoryID = @InventoryID ", conn);
                        cmd.Parameters.AddWithValue("@InventoryID", InventoryID);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("inventory deleted!");
                    LoadInventory();
                }
                catch
                {
                    MessageBox.Show("هناك مشكلة يرجاء مراجعة الوجهات الخرى المتصلة بهذه الواجهه");
                }


            }
        }













    }

}