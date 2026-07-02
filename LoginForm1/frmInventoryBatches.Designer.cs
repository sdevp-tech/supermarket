namespace LoginForm1
{
    partial class frmInventoryBatches
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnRefreshBatches;
        private System.Windows.Forms.Button btnNewBatch;
        private System.Windows.Forms.Button btnEditBatch;
        private System.Windows.Forms.Button btnDeleteBatch;
        private System.Windows.Forms.DataGridView dgvBatches;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRefreshBatches = new System.Windows.Forms.Button();
            this.btnNewBatch = new System.Windows.Forms.Button();
            this.btnEditBatch = new System.Windows.Forms.Button();
            this.btnDeleteBatch = new System.Windows.Forms.Button();
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إدارة دفعات المخزون";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnDeleteBatch);
            this.pnlButtons.Controls.Add(this.btnEditBatch);
            this.pnlButtons.Controls.Add(this.btnNewBatch);
            this.pnlButtons.Controls.Add(this.btnRefreshBatches);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 50);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlButtons.Size = new System.Drawing.Size(900, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnRefreshBatches
            // 
            this.btnRefreshBatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshBatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRefreshBatches.FlatAppearance.BorderSize = 0;
            this.btnRefreshBatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBatches.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshBatches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshBatches.Location = new System.Drawing.Point(730, 10);
            this.btnRefreshBatches.Name = "btnRefreshBatches";
            this.btnRefreshBatches.Size = new System.Drawing.Size(150, 40);
            this.btnRefreshBatches.TabIndex = 0;
            this.btnRefreshBatches.Text = "تحديث البيانات";
            this.btnRefreshBatches.UseVisualStyleBackColor = false;
            this.btnRefreshBatches.Click += new System.EventHandler(this.btnRefreshBatches_Click);
            // 
            // btnNewBatch
            // 
            this.btnNewBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNewBatch.FlatAppearance.BorderSize = 0;
            this.btnNewBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewBatch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewBatch.ForeColor = System.Drawing.Color.White;
            this.btnNewBatch.Location = new System.Drawing.Point(570, 10);
            this.btnNewBatch.Name = "btnNewBatch";
            this.btnNewBatch.Size = new System.Drawing.Size(150, 40);
            this.btnNewBatch.TabIndex = 1;
            this.btnNewBatch.Text = "دفعة جديدة";
            this.btnNewBatch.UseVisualStyleBackColor = false;
            this.btnNewBatch.Click += new System.EventHandler(this.btnNewBatch_Click);
            // 
            // btnEditBatch
            // 
            this.btnEditBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditBatch.FlatAppearance.BorderSize = 0;
            this.btnEditBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBatch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditBatch.ForeColor = System.Drawing.Color.White;
            this.btnEditBatch.Location = new System.Drawing.Point(410, 10);
            this.btnEditBatch.Name = "btnEditBatch";
            this.btnEditBatch.Size = new System.Drawing.Size(150, 40);
            this.btnEditBatch.TabIndex = 2;
            this.btnEditBatch.Text = "تعديل الدفعة";
            this.btnEditBatch.UseVisualStyleBackColor = false;
            this.btnEditBatch.Click += new System.EventHandler(this.btnEditBatch_Click);
            // 
            // btnDeleteBatch
            // 
            this.btnDeleteBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteBatch.FlatAppearance.BorderSize = 0;
            this.btnDeleteBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBatch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteBatch.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBatch.Location = new System.Drawing.Point(250, 10);
            this.btnDeleteBatch.Name = "btnDeleteBatch";
            this.btnDeleteBatch.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteBatch.TabIndex = 3;
            this.btnDeleteBatch.Text = "حذف الدفعة";
            this.btnDeleteBatch.UseVisualStyleBackColor = false;
            this.btnDeleteBatch.Click += new System.EventHandler(this.btnDeleteBatch_Click);
            // 
            // dgvBatches
            // 
            this.dgvBatches.AllowUserToAddRows = false;
            this.dgvBatches.AllowUserToDeleteRows = false;
            this.dgvBatches.AllowUserToResizeRows = false;
            this.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatches.BackgroundColor = System.Drawing.Color.White;
            this.dgvBatches.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBatches.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBatches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBatches.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatches.EnableHeadersVisualStyles = false;
            this.dgvBatches.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvBatches.Location = new System.Drawing.Point(0, 110);
            this.dgvBatches.Name = "dgvBatches";
            this.dgvBatches.ReadOnly = true;
            this.dgvBatches.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvBatches.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.dgvBatches.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBatches.RowTemplate.Height = 35;
            this.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatches.Size = new System.Drawing.Size(900, 490);
            this.dgvBatches.TabIndex = 2;
            // 
            // frmInventoryBatches
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvBatches);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmInventoryBatches";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة دفعات المخزون";
            this.Load += new System.EventHandler(this.frmInventoryBatches_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            this.ResumeLayout(false);
        }
    }
}