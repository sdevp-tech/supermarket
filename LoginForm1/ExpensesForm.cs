using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class ExpensesForm : Form
    {
        private SqlConnection conn;
        private Dictionary<string, string> paymentMethodMap = new Dictionary<string, string>();

        public ExpensesForm()
        {
            InitializeComponent();
            conn = DatabaseHelper.GetConnection();
            InitializePaymentMethodMapping();
        }

        private void InitializePaymentMethodMapping()
        {
            // Map UI display values to database values
            paymentMethodMap.Add("نقدي", "نقدأ");
            paymentMethodMap.Add("تحويل بنكي", "تحويل");
            paymentMethodMap.Add("بطاقة", "بطاقة");
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            // Populate expense categories
            cmbCategory.Items.AddRange(new object[] { "رواتب", "إيجار", "مرافق", "صيانة", "نقل", "مواد مكتبية", "أخرى" });
            cmbCategory.SelectedIndex = 0;

            // Load and display payment methods
            LoadPaymentMethods();

            dtpDate.Value = DateTime.Today;
            LoadExpenses();
        }

        private void LoadPaymentMethods()
        {
            try
            {
                cmbMethod.Items.Clear();
                List<string> dbValues = new List<string>();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Query to get allowed payment methods from check constraint
                    string query = @"SELECT definition 
                                    FROM sys.check_constraints 
                                    WHERE name = 'ck_expenses_payment'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    string constraintDefinition = cmd.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(constraintDefinition))
                    {
                        // Clean and parse constraint definition
                        constraintDefinition = constraintDefinition
                            .Replace("(", "")
                            .Replace(")", "")
                            .Replace("'", "")
                            .Replace("PaymentMethod = ", "")
                            .Replace("PaymentMethod=", "")
                            .Replace(" ", "");

                        string[] allowedMethods = constraintDefinition.Split(
                            new string[] { "OR", "AND" },
                            StringSplitOptions.RemoveEmptyEntries
                        );

                        foreach (string method in allowedMethods)
                        {
                            if (!string.IsNullOrWhiteSpace(method))
                            {
                                dbValues.Add(method.Trim());
                            }
                        }
                    }
                }

                // If we didn't get any values, use defaults
                if (dbValues.Count == 0)
                {
                    dbValues.AddRange(new string[] { "نقدأ", "تحويل", "بطاقة" });
                }

                // Add UI-friendly names to ComboBox
                foreach (KeyValuePair<string, string> mapping in paymentMethodMap)
                {
                    if (dbValues.Contains(mapping.Value))
                    {
                        cmbMethod.Items.Add(mapping.Key);
                    }
                }

                // Set default selection
                if (cmbMethod.Items.Count > 0)
                {
                    cmbMethod.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل طرق الدفع: " + ex.Message);
                // Fallback to UI values
                cmbMethod.Items.AddRange(new string[] { "نقدي", "تحويل بنكي", "بطاقة" });
                cmbMethod.SelectedIndex = 0;
            }
        }

        private void LoadExpenses()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = "SELECT ExpenseID, ExpenseDate, Amount, Description, Category, PaymentMethod, Notes FROM Expenses";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvExpenses.DataSource = dt;
                    FormatExpensesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المصروفات: " + ex.Message);
            }
        }

        private void FormatExpensesGrid()
        {
            if (dgvExpenses.Columns.Count == 0) return;

            // Create reverse mapping for display
            Dictionary<string, string> reverseMap = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in paymentMethodMap)
            {
                reverseMap.Add(kvp.Value, kvp.Key);
            }

            // Set Arabic headers
            dgvExpenses.Columns["ExpenseID"].HeaderText = "رقم المصروف";
            dgvExpenses.Columns["ExpenseDate"].HeaderText = "التاريخ";
            dgvExpenses.Columns["Amount"].HeaderText = "المبلغ";
            dgvExpenses.Columns["Description"].HeaderText = "الوصف";
            dgvExpenses.Columns["Category"].HeaderText = "الفئة";
            dgvExpenses.Columns["PaymentMethod"].HeaderText = "طريقة الدفع";
            dgvExpenses.Columns["Notes"].HeaderText = "ملاحظات";

            // Format columns
            dgvExpenses.Columns["ExpenseDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvExpenses.Columns["Amount"].DefaultCellStyle.Format = "N2";
            dgvExpenses.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Convert database values to display values
            foreach (DataGridViewRow row in dgvExpenses.Rows)
            {
                if (row.Cells["PaymentMethod"].Value != null)
                {
                    string dbValue = row.Cells["PaymentMethod"].Value.ToString();
                    if (reverseMap.ContainsKey(dbValue))
                    {
                        row.Cells["PaymentMethod"].Value = reverseMap[dbValue];
                    }
                }
            }

            // Adjust column widths
            dgvExpenses.Columns["ExpenseID"].Width = 80;
            dgvExpenses.Columns["ExpenseDate"].Width = 100;
            dgvExpenses.Columns["Amount"].Width = 100;
            dgvExpenses.Columns["Description"].Width = 200;
            dgvExpenses.Columns["Category"].Width = 120;
            dgvExpenses.Columns["PaymentMethod"].Width = 120;
            dgvExpenses.Columns["Notes"].Width = 250;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount;
            // Validate description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("الرجاء إدخال وصف للمصروف");
                txtDescription.Focus();
                return;
            }

            // Validate amount
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("الرجاء إدخال مبلغ صحيح أكبر من الصفر");
                txtAmount.SelectAll();
                txtAmount.Focus();
                return;
            }

            try
            {
                using (SqlConnection addConn = DatabaseHelper.GetConnection())
                {
                    addConn.Open();
                    string query = @"INSERT INTO Expenses 
                                    (ExpenseDate, Amount, Description, Category, PaymentMethod, Notes, UserID)
                                    VALUES (@Date, @Amount, @Description, @Category, @Method, @Notes, @UserID)";

                    SqlCommand cmd = new SqlCommand(query, addConn);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                    // Get selected values safely
                    string category = cmbCategory.SelectedItem != null ?
                                      cmbCategory.SelectedItem.ToString() :
                                      "أخرى";

                    string displayMethod = cmbMethod.SelectedItem != null ?
                                          cmbMethod.SelectedItem.ToString() :
                                          "نقدي";

                    // Map to database value
                    string dbMethod = paymentMethodMap.ContainsKey(displayMethod) ?
                                      paymentMethodMap[displayMethod] :
                                      displayMethod;

                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Method", dbMethod);

                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم إضافة المصروف بنجاح!");

                    // Clear form and refresh data
                    txtDescription.Clear();
                    txtAmount.Clear();
                    txtNotes.Clear();
                    cmbCategory.SelectedIndex = 0;
                    if (cmbMethod.Items.Count > 0) cmbMethod.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Today;

                    LoadExpenses();
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle constraint violation specifically
                if (sqlEx.Number == 547) // Constraint check violation
                {
                    MessageBox.Show("قيمة طريقة الدفع غير صالحة. الرجاء اختيار قيمة من القائمة المنسدلة.");
                }
                else
                {
                    MessageBox.Show("خطأ في قاعدة البيانات: " + sqlEx.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExpenses();
        }
    }
}