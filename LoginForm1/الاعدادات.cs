using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class DatabaseSettingsForm : Form
    {
        private readonly string databaseName = "mini_supermarket";
        private readonly string serverName = "DESKTOP-J6KA8B8";
        private readonly string connectionString;

        public DatabaseSettingsForm()
        {
            InitializeComponent();

            // Set connection string with your specific values
            connectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True",
                                            serverName, databaseName);

            // Display current configuration
            lblServer.Text = serverName;
            lblDatabase.Text = databaseName;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Backup Files (*.bak)|*.bak";
                saveDialog.FileName = string.Format("{0}_{1:yyyyMMdd_HHmmss}.bak",
                                                  databaseName, DateTime.Now);

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string backupPath = saveDialog.FileName;

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            string query = string.Format(
                                "BACKUP DATABASE [{0}] TO DISK = @backupPath WITH FORMAT, " +
                                "MEDIANAME = 'SQLServerBackups', " +
                                "NAME = 'Full Backup of {0}';",
                                databaseName);

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@backupPath", backupPath);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Backup created successfully!", "Success",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Backup failed: {0}", ex.Message), "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Backup Files (*.bak)|*.bak";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string backupPath = openDialog.FileName;
                        string masterConnStr = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True",
                                                           serverName);

                        using (SqlConnection masterConn = new SqlConnection(masterConnStr))
                        {
                            masterConn.Open();

                            // Set database to single user mode
                            string singleUserQuery = string.Format(
                                "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
                                databaseName);
                            using (SqlCommand cmd = new SqlCommand(singleUserQuery, masterConn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Restore database
                            string restoreQuery = string.Format(
                                "RESTORE DATABASE [{0}] FROM DISK = @backupPath WITH REPLACE, RECOVERY",
                                databaseName);

                            using (SqlCommand cmd = new SqlCommand(restoreQuery, masterConn))
                            {
                                cmd.Parameters.AddWithValue("@backupPath", backupPath);
                                cmd.ExecuteNonQuery();
                            }

                            // Set database back to multi-user mode
                            string multiUserQuery = string.Format(
                                "ALTER DATABASE [{0}] SET MULTI_USER",
                                databaseName);
                            using (SqlCommand cmd = new SqlCommand(multiUserQuery, masterConn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Database restored successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Restore failed: {0}", ex.Message), "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnResetDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("WARNING: This will DELETE ALL DATA!\nContinue?",
                              "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Create SQL script with proper order of operations
                    string resetScript = @"
            BEGIN TRY
                BEGIN TRANSACTION;
                
                -- Disable constraints
                EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';
                
                -- Clear all data in proper order (child tables first)
                DELETE FROM CreditPayments;
                DELETE FROM CreditSales;
                DELETE FROM Returns;
                DELETE FROM SaleDetails;
                DELETE FROM Sales;
                DELETE FROM SupplierPayments;
                DELETE FROM Purchases;
                DELETE FROM Expenses;
                DELETE FROM InventoryWarnings;
                DELETE FROM Inventory;
                DELETE FROM Products;
                DELETE FROM Categories;
                DELETE FROM Suppliers;
                DELETE FROM Customers;
                DELETE FROM Users;
                DELETE FROM CashBox;
                DELETE FROM InventoryBatches;
                DELETE FROM ExpiryNotifications;
                -- Reset identity counters
                DBCC CHECKIDENT ('CreditPayments', RESEED, 0);
                DBCC CHECKIDENT ('CreditSales', RESEED, 0);
                DBCC CHECKIDENT ('Returns', RESEED, 0);
                DBCC CHECKIDENT ('SaleDetails', RESEED, 0);
                DBCC CHECKIDENT ('Sales', RESEED, 0);
                DBCC CHECKIDENT ('SupplierPayments', RESEED, 0);
                DBCC CHECKIDENT ('Purchases', RESEED, 0);
                DBCC CHECKIDENT ('Expenses', RESEED, 0);
                DBCC CHECKIDENT ('InventoryWarnings', RESEED, 0);
                DBCC CHECKIDENT ('Inventory', RESEED, 0);
                DBCC CHECKIDENT ('Products', RESEED, 0);
                DBCC CHECKIDENT ('Categories', RESEED, 0);
                DBCC CHECKIDENT ('Suppliers', RESEED, 0);
                DBCC CHECKIDENT ('Customers', RESEED, 0);
                DBCC CHECKIDENT ('Users', RESEED, 0);
                DBCC CHECKIDENT ('CashBox', RESEED, 0);
                DBCC CHECKIDENT ('InventoryBatches', RESEED, 0);
                DBCC CHECKIDENT ('ExpiryNotifications', RESEED, 0);
                
                -- Create default admin (password: admin123)
                INSERT INTO Users (Username, UserType, PasswordHash, IsActive)
                VALUES ('admin', 'Admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 1);
                
                -- Add initial cash balance
                INSERT INTO CashBox (TransactionDate, TransactionType, Amount, Description, UserID)
                VALUES (GETDATE(), 'Initial', 10000.00, 'رصيد افتتاحي للصندوق', 1);
                
                -- Re-enable constraints
                EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL';
                
                COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                IF @@TRANCOUNT > 0
                    ROLLBACK TRANSACTION;
                    
                DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
                DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
                DECLARE @ErrorState INT = ERROR_STATE();
                
                RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
            END CATCH";

                    using (SqlCommand cmd = new SqlCommand(resetScript, conn))
                    {
                        // Set longer timeout (5 minutes)
                        cmd.CommandTimeout = 300;

                        // Execute the entire script as one batch
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Database reset successfully!\nAdmin user created with password: admin123\nInitial cash balance: 10,000",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset failed: " + (ex.Message), "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
