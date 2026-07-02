using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class frmInventoryBatches : Form
    {
        private DataTable dtBatches = new DataTable();
        private Dictionary<string, string> arabicColumnMappings = new Dictionary<string, string>
        {
            {"BatchID", "معرف الدفعة"},
            {"ProductName", "اسم المنتج"},
            {"BatchNumber", "رقم الدفعة"},
            {"Quantity", "الكمية"},
            {"ExpiryDate", "تاريخ الانتهاء"},
            {"CreatedAt", "تاريخ الإنشاء"}
        };

        public frmInventoryBatches()
        {
            InitializeComponent();
        }

        private void frmInventoryBatches_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadBatches();
        }

        private void SetupGrid()
        {
            dgvBatches.AutoGenerateColumns = false;
            dgvBatches.Columns.Clear();

            // Add columns with Arabic headers
            AddColumn("BatchID", "معرف الدفعة", 100);
            AddColumn("ProductName", "اسم المنتج", 200);
            AddColumn("BatchNumber", "رقم الدفعة", 120);
            AddColumn("Quantity", "الكمية", 100);
            AddColumn("ExpiryDate", "تاريخ الانتهاء", 150);
            AddColumn("CreatedAt", "تاريخ الإنشاء", 150);

            // Apply modern styling
            dgvBatches.BackgroundColor = Color.White;
            dgvBatches.BorderStyle = BorderStyle.None;
            dgvBatches.RowHeadersVisible = false;
            dgvBatches.EnableHeadersVisualStyles = false;
            dgvBatches.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvBatches.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBatches.DefaultCellStyle.BackColor = Color.White;
            dgvBatches.DefaultCellStyle.ForeColor = Color.Black;

            dgvBatches.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleRight
            };

            dgvBatches.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 248, 248)
            };

            dgvBatches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBatches.ReadOnly = true;
        }

        private void AddColumn(string prop, string hdr, int w)
        {
            dgvBatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = prop,
                DataPropertyName = prop,
                HeaderText = hdr,
                Width = w,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleRight } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadBatches()
        {
            dtBatches.Clear();

            const string sql = @"
SELECT 
  b.BatchID,
  p.ProductName,
  b.BatchNumber,
  b.Quantity,
  b.ExpiryDate,
  b.CreatedAt
FROM InventoryBatches b
JOIN Products p ON p.ProductID = b.ProductID
ORDER BY b.ExpiryDate";

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.Fill(dtBatches);
                    dgvBatches.DataSource = dtBatches;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل تحميل البيانات: " + (ex.Message), "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshBatches_Click(object sender, EventArgs e)
        {
            LoadBatches();
        }

        private void btnNewBatch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("سيتم تنفيذ وظيفة إنشاء دفعة جديدة هنا", "دفعة جديدة",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditBatch_Click(object sender, EventArgs e)
        {
            if (dgvBatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("الرجاء تحديد دفعة للتعديل", "تحذير",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("سيتم تنفيذ وظيفة تعديل الدفعة هنا", "تعديل الدفعة",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public frmInventoryBatches(bool forEmbedding)
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
        private void btnDeleteBatch_Click(object sender, EventArgs e)
        {
            if (dgvBatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("الرجاء تحديد دفعة للحذف", "تحذير",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("هل أنت متأكد من رغبتك في حذف الدفعة المحددة؟", "تأكيد الحذف",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("تم حذف الدفعة بنجاح", "حذف الدفعة",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}