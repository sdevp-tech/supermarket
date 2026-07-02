namespace LoginForm1
{
    partial class تقارير_المبيعات
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblCardTotal = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblEWalletTotal = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblCreditTotal = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCashTotal = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblReturnedInvoices = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSoldInvoices = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDataGrid);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1476, 716);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Controls.Add(this.dgvSales);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(300, 0);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDataGrid.Size = new System.Drawing.Size(1176, 716);
            this.pnlDataGrid.TabIndex = 1;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSales.ColumnHeadersHeight = 40;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvSales.Location = new System.Drawing.Point(10, 10);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowTemplate.Height = 35;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(1156, 696);
            this.dgvSales.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpPayment);
            this.pnlLeft.Controls.Add(this.grpSummary);
            this.pnlLeft.Controls.Add(this.grpFilters);
            this.pnlLeft.Controls.Add(this.pnlButtons);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(300, 716);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.lblCardTotal);
            this.grpPayment.Controls.Add(this.label26);
            this.grpPayment.Controls.Add(this.lblEWalletTotal);
            this.grpPayment.Controls.Add(this.label24);
            this.grpPayment.Controls.Add(this.lblCreditTotal);
            this.grpPayment.Controls.Add(this.label22);
            this.grpPayment.Controls.Add(this.lblCashTotal);
            this.grpPayment.Controls.Add(this.label20);
            this.grpPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPayment.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grpPayment.Location = new System.Drawing.Point(0, 400);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(300, 200);
            this.grpPayment.TabIndex = 2;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "طرق الدفع";
            // 
            // lblCardTotal
            // 
            this.lblCardTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCardTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardTotal.Location = new System.Drawing.Point(20, 145);
            this.lblCardTotal.Name = "lblCardTotal";
            this.lblCardTotal.Size = new System.Drawing.Size(120, 23);
            this.lblCardTotal.TabIndex = 7;
            this.lblCardTotal.Text = "0.00";
            this.lblCardTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(150, 148);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 22);
            this.label26.TabIndex = 6;
            this.label26.Text = "بطاقة";
            // 
            // lblEWalletTotal
            // 
            this.lblEWalletTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEWalletTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEWalletTotal.Location = new System.Drawing.Point(20, 110);
            this.lblEWalletTotal.Name = "lblEWalletTotal";
            this.lblEWalletTotal.Size = new System.Drawing.Size(120, 23);
            this.lblEWalletTotal.TabIndex = 5;
            this.lblEWalletTotal.Text = "0.00";
            this.lblEWalletTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(150, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 22);
            this.label24.TabIndex = 4;
            this.label24.Text = "محفظة";
            // 
            // lblCreditTotal
            // 
            this.lblCreditTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreditTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreditTotal.Location = new System.Drawing.Point(20, 75);
            this.lblCreditTotal.Name = "lblCreditTotal";
            this.lblCreditTotal.Size = new System.Drawing.Size(120, 23);
            this.lblCreditTotal.TabIndex = 3;
            this.lblCreditTotal.Text = "0.00";
            this.lblCreditTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(150, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 22);
            this.label22.TabIndex = 2;
            this.label22.Text = "اجل";
            // 
            // lblCashTotal
            // 
            this.lblCashTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCashTotal.Location = new System.Drawing.Point(20, 40);
            this.lblCashTotal.Name = "lblCashTotal";
            this.lblCashTotal.Size = new System.Drawing.Size(120, 23);
            this.lblCashTotal.TabIndex = 1;
            this.lblCashTotal.Text = "0.00";
            this.lblCashTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(150, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 22);
            this.label20.TabIndex = 0;
            this.label20.Text = "نقدي";
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lblReturnedInvoices);
            this.grpSummary.Controls.Add(this.label18);
            this.grpSummary.Controls.Add(this.lblSoldInvoices);
            this.grpSummary.Controls.Add(this.label16);
            this.grpSummary.Controls.Add(this.lblTotalItems);
            this.grpSummary.Controls.Add(this.label14);
            this.grpSummary.Controls.Add(this.lblTotalSales);
            this.grpSummary.Controls.Add(this.label12);
            this.grpSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSummary.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grpSummary.Location = new System.Drawing.Point(0, 200);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(300, 200);
            this.grpSummary.TabIndex = 1;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "ملخص المبيعات";
            // 
            // lblReturnedInvoices
            // 
            this.lblReturnedInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReturnedInvoices.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblReturnedInvoices.Location = new System.Drawing.Point(20, 145);
            this.lblReturnedInvoices.Name = "lblReturnedInvoices";
            this.lblReturnedInvoices.Size = new System.Drawing.Size(120, 23);
            this.lblReturnedInvoices.TabIndex = 7;
            this.lblReturnedInvoices.Text = "0";
            this.lblReturnedInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(150, 148);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 22);
            this.label18.TabIndex = 6;
            this.label18.Text = "الفواتير المرتجعة";
            // 
            // lblSoldInvoices
            // 
            this.lblSoldInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoldInvoices.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoldInvoices.Location = new System.Drawing.Point(20, 110);
            this.lblSoldInvoices.Name = "lblSoldInvoices";
            this.lblSoldInvoices.Size = new System.Drawing.Size(120, 23);
            this.lblSoldInvoices.TabIndex = 5;
            this.lblSoldInvoices.Text = "0";
            this.lblSoldInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(150, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 22);
            this.label16.TabIndex = 4;
            this.label16.Text = "الفواتير المباعة";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalItems.Location = new System.Drawing.Point(20, 75);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(120, 23);
            this.lblTotalItems.TabIndex = 3;
            this.lblTotalItems.Text = "0";
            this.lblTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(150, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 22);
            this.label14.TabIndex = 2;
            this.label14.Text = "إجمالي الأصناف";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSales.Location = new System.Drawing.Point(20, 40);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(120, 23);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "0.00";
            this.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(150, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "إجمالي المبيعات";
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.btnFilter);
            this.grpFilters.Controls.Add(this.label11);
            this.grpFilters.Controls.Add(this.label10);
            this.grpFilters.Controls.Add(this.dtpStartDate);
            this.grpFilters.Controls.Add(this.dtpEndDate);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilters.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilters.Location = new System.Drawing.Point(0, 0);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(300, 200);
            this.grpFilters.TabIndex = 0;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "تصفية البيانات";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(20, 140);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(250, 40);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "تطبيق التصفية";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 22);
            this.label11.TabIndex = 3;
            this.label11.Text = "تاريخ النهاية";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "تاريخ البداية";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.CustomFormat = "yyyy/MM/dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(20, 40);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(158, 29);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CustomFormat = "yyyy/MM/dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(20, 90);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(158, 29);
            this.dtpEndDate.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnPrintInvoice);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 587);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(300, 129);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnPrintInvoice.FlatAppearance.BorderSize = 0;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(20, 90);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(260, 35);
            this.btnPrintInvoice.TabIndex = 2;
            this.btnPrintInvoice.Text = "طباعة فاتورة";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(20, 50);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(260, 35);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "تصدير إلى Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(20, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(260, 35);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "طباعة التقرير";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // تقارير_المبيعات
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1476, 716);
            this.Controls.Add(this.pnlMain);
            this.Name = "تقارير_المبيعات";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تقارير المبيعات";
            this.pnlMain.ResumeLayout(false);
            this.pnlDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblCardTotal;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblEWalletTotal;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblCreditTotal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCashTotal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblReturnedInvoices;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblSoldInvoices;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
    }
}