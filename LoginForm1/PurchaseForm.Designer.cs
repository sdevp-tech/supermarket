namespace LoginForm1
{
    partial class PurchaseForm
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
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.grpPurchaseInfo = new System.Windows.Forms.GroupBox();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.btnSearchByBarcode = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.chkIsCredit = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPackagePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsPackage = new System.Windows.Forms.CheckBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.grpPurchaseInfo.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDataGrid);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 854);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Controls.Add(this.dgvPurchases);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(300, 0);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDataGrid.Size = new System.Drawing.Size(600, 854);
            this.pnlDataGrid.TabIndex = 1;
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.AllowUserToAddRows = false;
            this.dgvPurchases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchases.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchases.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPurchases.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchases.ColumnHeadersHeight = 40;
            this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchases.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchases.EnableHeadersVisualStyles = false;
            this.dgvPurchases.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvPurchases.Location = new System.Drawing.Point(10, 10);
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPurchases.RowHeadersVisible = false;
            this.dgvPurchases.RowTemplate.Height = 35;
            this.dgvPurchases.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(580, 834);
            this.dgvPurchases.TabIndex = 0;
           
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.grpPurchaseInfo);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(300, 854);
            this.pnlForm.TabIndex = 0;
            // 
            // grpPurchaseInfo
            // 
            this.grpPurchaseInfo.Controls.Add(this.scrollPanel);
            this.grpPurchaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPurchaseInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grpPurchaseInfo.Location = new System.Drawing.Point(0, 0);
            this.grpPurchaseInfo.Name = "grpPurchaseInfo";
            this.grpPurchaseInfo.Size = new System.Drawing.Size(300, 681);
            this.grpPurchaseInfo.TabIndex = 0;
            this.grpPurchaseInfo.TabStop = false;
            this.grpPurchaseInfo.Text = "معلومات الشراء";
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Controls.Add(this.btnSearchByBarcode);
            this.scrollPanel.Controls.Add(this.txtBarcode);
            this.scrollPanel.Controls.Add(this.lblBarcode);
            this.scrollPanel.Controls.Add(this.label11);
            this.scrollPanel.Controls.Add(this.dtpExpiryDate);
            this.scrollPanel.Controls.Add(this.txtBatchNumber);
            this.scrollPanel.Controls.Add(this.label10);
            this.scrollPanel.Controls.Add(this.txtPaidAmount);
            this.scrollPanel.Controls.Add(this.lblPaidAmount);
            this.scrollPanel.Controls.Add(this.dtpDueDate);
            this.scrollPanel.Controls.Add(this.lblDueDate);
            this.scrollPanel.Controls.Add(this.chkIsCredit);
            this.scrollPanel.Controls.Add(this.txtSearch);
            this.scrollPanel.Controls.Add(this.label9);
            this.scrollPanel.Controls.Add(this.cmbUser);
            this.scrollPanel.Controls.Add(this.label8);
            this.scrollPanel.Controls.Add(this.txtNotes);
            this.scrollPanel.Controls.Add(this.label7);
            this.scrollPanel.Controls.Add(this.txtPackagePrice);
            this.scrollPanel.Controls.Add(this.label6);
            this.scrollPanel.Controls.Add(this.chkIsPackage);
            this.scrollPanel.Controls.Add(this.txtUnitPrice);
            this.scrollPanel.Controls.Add(this.label5);
            this.scrollPanel.Controls.Add(this.txtQuantity);
            this.scrollPanel.Controls.Add(this.label4);
            this.scrollPanel.Controls.Add(this.cmbSupplier);
            this.scrollPanel.Controls.Add(this.label3);
            this.scrollPanel.Controls.Add(this.cmbProduct);
            this.scrollPanel.Controls.Add(this.label2);
            this.scrollPanel.Controls.Add(this.dtpPurchaseDate);
            this.scrollPanel.Controls.Add(this.label1);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(3, 25);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(294, 653);
            this.scrollPanel.TabIndex = 0;
            // 
            // btnSearchByBarcode
            // 
            this.btnSearchByBarcode.Location = new System.Drawing.Point(6, 450);
            this.btnSearchByBarcode.Name = "btnSearchByBarcode";
            this.btnSearchByBarcode.Size = new System.Drawing.Size(75, 30);
            this.btnSearchByBarcode.TabIndex = 29;
            this.btnSearchByBarcode.Text = "بحث";
            this.btnSearchByBarcode.UseVisualStyleBackColor = true;
            this.btnSearchByBarcode.Click += new System.EventHandler(this.btnSearchByBarcode_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Location = new System.Drawing.Point(6, 417);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(150, 33);
            this.txtBarcode.TabIndex = 28;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(180, 420);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(100, 28);
            this.lblBarcode.TabIndex = 27;
            this.lblBarcode.Text = "باركود المنتج";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(185, 387);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 28);
            this.label11.TabIndex = 26;
            this.label11.Text = "تاريخ الانتهاء";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Location = new System.Drawing.Point(3, 383);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(187, 33);
            this.dtpExpiryDate.TabIndex = 25;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchNumber.Location = new System.Drawing.Point(6, 354);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(150, 33);
            this.txtBatchNumber.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 28);
            this.label10.TabIndex = 23;
            this.label10.Text = "رقم الدفعة";
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaidAmount.Location = new System.Drawing.Point(6, 325);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(150, 33);
            this.txtPaidAmount.TabIndex = 22;
            this.txtPaidAmount.Text = "0.00";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Location = new System.Drawing.Point(160, 327);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(137, 28);
            this.lblPaidAmount.TabIndex = 21;
            this.lblPaidAmount.Text = "المبلغ المدفوع:";
            this.lblPaidAmount.Visible = false;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(6, 297);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(150, 33);
            this.dtpDueDate.TabIndex = 20;
            this.dtpDueDate.Visible = false;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(163, 300);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(145, 28);
            this.lblDueDate.TabIndex = 19;
            this.lblDueDate.Text = "تاريخ الاستحقاق:";
            this.lblDueDate.Visible = false;
            // 
            // chkIsCredit
            // 
            this.chkIsCredit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsCredit.AutoSize = true;
            this.chkIsCredit.Location = new System.Drawing.Point(6, 279);
            this.chkIsCredit.Name = "chkIsCredit";
            this.chkIsCredit.Size = new System.Drawing.Size(126, 32);
            this.chkIsCredit.TabIndex = 18;
            this.chkIsCredit.Text = "شراء بالاجل";
            this.chkIsCredit.UseVisualStyleBackColor = true;
            this.chkIsCredit.CheckedChanged += new System.EventHandler(this.chkIsCredit_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(6, 170);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 33);
            this.txtSearch.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 28);
            this.label9.TabIndex = 16;
            this.label9.Text = "بحث";
            // 
            // cmbUser
            // 
            this.cmbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(6, 250);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(150, 36);
            this.cmbUser.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 28);
            this.label8.TabIndex = 14;
            this.label8.Text = "المستخدم";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(6, 224);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(150, 33);
            this.txtNotes.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "ملاحظة";
            // 
            // txtPackagePrice
            // 
            this.txtPackagePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackagePrice.Enabled = false;
            this.txtPackagePrice.Location = new System.Drawing.Point(6, 195);
            this.txtPackagePrice.Name = "txtPackagePrice";
            this.txtPackagePrice.Size = new System.Drawing.Size(150, 33);
            this.txtPackagePrice.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "سعر العبوة";
            // 
            // chkIsPackage
            // 
            this.chkIsPackage.AutoSize = true;
            this.chkIsPackage.Location = new System.Drawing.Point(6, 150);
            this.chkIsPackage.Name = "chkIsPackage";
            this.chkIsPackage.Size = new System.Drawing.Size(127, 32);
            this.chkIsPackage.TabIndex = 5;
            this.chkIsPackage.Text = "Is Package";
            this.chkIsPackage.UseVisualStyleBackColor = true;
            this.chkIsPackage.CheckedChanged += new System.EventHandler(this.chkIsPackage_CheckedChanged);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitPrice.Location = new System.Drawing.Point(7, 125);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(150, 33);
            this.txtUnitPrice.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "سعر الحبة";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Location = new System.Drawing.Point(6, 100);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(150, 33);
            this.txtQuantity.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "الكمية";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(6, 43);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(150, 36);
            this.cmbSupplier.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "المورد";
            // 
            // cmbProduct
            // 
            this.cmbProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(6, 69);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(150, 36);
            this.cmbProduct.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "المنتج";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(6, 21);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(150, 33);
            this.dtpPurchaseDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "التاريخ";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 681);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(300, 173);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(18, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(260, 37);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(18, 43);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(260, 31);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "جديد";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(18, 107);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(260, 31);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(18, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 31);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(18, 139);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(260, 31);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 854);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PurchaseForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة المشتريات";
            this.pnlMain.ResumeLayout(false);
            this.pnlDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.grpPurchaseInfo.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpPurchaseInfo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsPackage;
        private System.Windows.Forms.TextBox txtPackagePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkIsCredit;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSearchByBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Panel scrollPanel;
    }
}