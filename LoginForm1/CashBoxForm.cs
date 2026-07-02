using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class CashBoxForm : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";
        private Dictionary<string, string> transactionTypeMap = new Dictionary<string, string>();

        public CashBoxForm()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            InitializeTransactionTypeMap();
            LoadTransactionTypes();
            LoadUsers();
            LoadCashBoxData();
            CalculateCurrentBalance();
        }

        private void InitializeTransactionTypeMap()
        {
            // Map English values to Arabic display text
            transactionTypeMap.Add("Deposit", "ايداع");
            transactionTypeMap.Add("Withdrawal", "سحب");
            transactionTypeMap.Add("Expense", "مصروف");
            transactionTypeMap.Add("Purchase", "شراء");
            transactionTypeMap.Add("Sale", "بيع");
            transactionTypeMap.Add("Initial", "رصيد ابتدائي");
        }

        private void LoadCashBoxData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TransactionID AS 'رقم العملية', " +
                        "FORMAT(TransactionDate, 'dd/MM/yyyy HH:mm') AS 'التاريخ', " +
                        "CASE TransactionType " +
                        "   WHEN 'Deposit' THEN 'ايداع' " +
                        "   WHEN 'Withdrawal' THEN 'سحب' " +
                        "   WHEN 'Expense' THEN 'مصروف' " +
                        "   WHEN 'Purchase' THEN 'شراء' " +
                        "   WHEN 'Sale' THEN 'بيع' " +
                        "   WHEN 'Initial' THEN 'رصيد ابتدائي' " +
                        "END AS 'نوع العملية', " +
                        "Amount AS 'المبلغ', " +
                        "Description AS 'الوصف', " +
                        "u.Username AS 'المستخدم' " +
                        "FROM CashBox c " +
                        "INNER JOIN Users u ON c.UserID = u.UserID " +
                        "ORDER BY TransactionDate DESC", conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewCashBox.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateCurrentBalance()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT SUM(Amount) FROM CashBox", conn);

                    object result = cmd.ExecuteScalar();
                    decimal balance = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    // عرض الرصيد مع تمييز الإشارة
                    txtCurrentBalance.Text = balance.ToString("N2");

                    // تلوين الرصيد بناءً على قيمته
                    if (balance < 0)
                    {
                        txtCurrentBalance.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtCurrentBalance.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في حساب الرصيد: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionTypes()
        {
            cmbTransactionType.Items.Clear();

            // Add English values but display Arabic text
            foreach (var kvp in transactionTypeMap)
            {
                cmbTransactionType.Items.Add(new ComboboxItem(
                    kvp.Value,  // Display text (Arabic)
                    kvp.Key     // Value (English)
                ));
            }

            if (cmbTransactionType.Items.Count > 0)
                cmbTransactionType.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            cmbUser.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT UserID, Username FROM Users", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbUser.Items.Add(new ComboboxItem(
                            reader["Username"].ToString(),
                            Convert.ToInt32(reader["UserID"])
                        ));
                    }
                }
                if (cmbUser.Items.Count > 0)
                    cmbUser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المستخدمين: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("الرجاء إدخال مبلغ صحيح", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            if (cmbUser.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار مستخدم", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUser.Focus();
                return;
            }

            if (cmbTransactionType.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار نوع العملية", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTransactionType.Focus();
                return;
            }

            try
            {
                // Get the English value from the selected item
                string transactionType = ((ComboboxItem)cmbTransactionType.SelectedItem).Value.ToString();
                amount = Convert.ToDecimal(txtAmount.Text);

                // تحديد إشارة المبلغ بناءً على نوع العملية
                switch (transactionType)
                {
                    case "Withdrawal":
                    case "Expense":
                    case "Purchase":
                        amount = -Math.Abs(amount); // قيم سالبة للعمليات المخصومة
                        break;
                    case "Deposit":
                    case "Sale":
                    case "Initial":
                        amount = Math.Abs(amount); // قيم موجبة للعمليات المضافة
                        break;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO CashBox (TransactionDate, TransactionType, Amount, " +
                        "Description, UserID) VALUES (@date, @type, @amount, @desc, @user)", conn);

                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@type", transactionType);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@user",
                        ((ComboboxItem)cmbUser.SelectedItem).Value);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تم حفظ العملية بنجاح", "نجاح",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Clear input fields
                txtAmount.Clear();
                txtDescription.Clear();
                if (cmbTransactionType.Items.Count > 0)
                    cmbTransactionType.SelectedIndex = 0;
                if (cmbUser.Items.Count > 0)
                    cmbUser.SelectedIndex = 0;

                // Refresh data
                LoadCashBoxData();
                CalculateCurrentBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في حفظ العملية: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCashBoxData();
            CalculateCurrentBalance();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Add this method for numeric validation
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow numbers, decimal point, and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }  // Display text (Arabic)
        public object Value { get; set; }  // Internal value (English)

        public ComboboxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}