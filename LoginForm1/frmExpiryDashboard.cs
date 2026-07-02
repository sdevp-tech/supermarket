using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LoginForm1
{
    public partial class frmExpiryDashboard : Form
    {
        private DataTable dtUpcoming = new DataTable();
        private Dictionary<string, string> arabicColumnMappings = new Dictionary<string, string>
        {
            {"BatchID", "رقم الدفعة"},
            {"ProductID", " رقم المنتج"},
            {"ProductName", "اسم المنتج"},
            {"ExpiryDate", "تاريخ الانتهاء"},
            {"DaysToExpire", "الأيام المتبقية"},
            {"Quantity", "الكمية"}
            // Add more mappings as needed
        };

        public frmExpiryDashboard()
        {
            InitializeComponent();
        }

        private void frmExpiryDashboard_Load(object sender, EventArgs e)
        {
            FormatDataGridView();
            LoadUpcoming();
        }

        private void FormatDataGridView()
        {
            dgvUpcoming.BackgroundColor = Color.White;
            dgvUpcoming.BorderStyle = BorderStyle.None;
            dgvUpcoming.RowHeadersVisible = false;
            dgvUpcoming.EnableHeadersVisualStyles = false;
            dgvUpcoming.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvUpcoming.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUpcoming.DefaultCellStyle.BackColor = Color.White;
            dgvUpcoming.DefaultCellStyle.ForeColor = Color.Black;

            dgvUpcoming.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleRight
            };

            dgvUpcoming.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 248, 248)
            };
        }

        private void LoadUpcoming()
        {
            dtUpcoming.Clear();
            const string sql = @"SELECT * FROM vw_UpcomingExpiries";

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.Fill(dtUpcoming);
                    dgvUpcoming.DataSource = dtUpcoming;
                    TranslateColumnHeaders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل تحميل البيانات: " + (ex.Message), "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public frmExpiryDashboard(bool forEmbedding)
        {
            InitializeComponent();

            if (forEmbedding)
            {
                this.ControlBox = false;
                this.ShowIcon = false;
                this.Text = string.Empty;
                // Remove any standalone form behavior
            }
            else
            {
                // Original initialization for standalone use
            }
        }
        private void TranslateColumnHeaders()
        {
            foreach (DataGridViewColumn column in dgvUpcoming.Columns)
            {
                // Translate if mapping exists
                if (arabicColumnMappings.ContainsKey(column.Name))
                {
                    column.HeaderText = arabicColumnMappings[column.Name];
                }
                // Apply Arabic formatting
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUpcoming();
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand("EXEC NotifyExpiringProducts", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("تم إرسال التنبيهات بنجاح!", "تنبيه",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل إرسال التنبيهات: " + (ex.Message), "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}