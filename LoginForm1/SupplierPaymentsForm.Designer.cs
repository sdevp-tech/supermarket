using System.Drawing;
using System.Windows.Forms;

namespace LoginForm1
{
    partial class SupplierPaymentsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.gbPayment = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtPurchaseID = new System.Windows.Forms.TextBox();
            this.lblPurchaseID = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.gbPayment.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(1099, 720);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Controls.Add(this.dgvPurchases);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(300, 0);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDataGrid.Size = new System.Drawing.Size(799, 720);
            this.pnlDataGrid.TabIndex = 1;
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.AllowUserToAddRows = false;
            this.dgvPurchases.AllowUserToDeleteRows = false;
            this.dgvPurchases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchases.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchases.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPurchases.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvPurchases.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPurchases.RowTemplate.Height = 35;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(779, 700);
            this.dgvPurchases.TabIndex = 0;
            this.dgvPurchases.SelectionChanged += new System.EventHandler(this.dgvPurchases_SelectionChanged);
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.gbPayment);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(300, 720);
            this.pnlForm.TabIndex = 0;
            // 
            // gbPayment
            // 
            this.gbPayment.Controls.Add(this.txtNotes);
            this.gbPayment.Controls.Add(this.label7);
            this.gbPayment.Controls.Add(this.cmbMethod);
            this.gbPayment.Controls.Add(this.label6);
            this.gbPayment.Controls.Add(this.dtpDate);
            this.gbPayment.Controls.Add(this.label5);
            this.gbPayment.Controls.Add(this.txtAmount);
            this.gbPayment.Controls.Add(this.label4);
            this.gbPayment.Controls.Add(this.txtBalance);
            this.gbPayment.Controls.Add(this.label3);
            this.gbPayment.Controls.Add(this.txtPaid);
            this.gbPayment.Controls.Add(this.label2);
            this.gbPayment.Controls.Add(this.txtTotal);
            this.gbPayment.Controls.Add(this.label1);
            this.gbPayment.Controls.Add(this.txtSupplier);
            this.gbPayment.Controls.Add(this.lblSupplier);
            this.gbPayment.Controls.Add(this.txtPurchaseID);
            this.gbPayment.Controls.Add(this.lblPurchaseID);
            this.gbPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPayment.Enabled = false;
            this.gbPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gbPayment.Location = new System.Drawing.Point(0, 0);
            this.gbPayment.Name = "gbPayment";
            this.gbPayment.Size = new System.Drawing.Size(300, 520);
            this.gbPayment.TabIndex = 1;
            this.gbPayment.TabStop = false;
            this.gbPayment.Text = "تفاصيل الدفع";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNotes.Location = new System.Drawing.Point(10, 278);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(148, 33);
            this.txtNotes.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label7.Location = new System.Drawing.Point(187, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 28);
            this.label7.TabIndex = 16;
            this.label7.Text = "ملاحظات";
            // 
            // cmbMethod
            // 
            this.cmbMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMethod.BackColor = System.Drawing.Color.White;
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "نقدي",
            "تحويل بنكي",
            "شيك",
            "بطاقة ائتمان"});
            this.cmbMethod.Location = new System.Drawing.Point(10, 242);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(148, 36);
            this.cmbMethod.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label6.Location = new System.Drawing.Point(174, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "طريقة الدفع";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(10, 205);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(148, 33);
            this.dtpDate.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label5.Location = new System.Drawing.Point(171, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "تاريخ الدفعة";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(10, 169);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(148, 33);
            this.txtAmount.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label4.Location = new System.Drawing.Point(174, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "مبلغ الدفعة";
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBalance.Location = new System.Drawing.Point(10, 132);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(148, 33);
            this.txtBalance.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label3.Location = new System.Drawing.Point(174, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "المبلغ المتبقي";
            // 
            // txtPaid
            // 
            this.txtPaid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaid.BackColor = System.Drawing.Color.White;
            this.txtPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPaid.Location = new System.Drawing.Point(10, 96);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.Size = new System.Drawing.Size(148, 33);
            this.txtPaid.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(174, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "المبلغ المدفوع";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(10, 60);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(148, 33);
            this.txtTotal.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(157, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "المبلغ الإجمالي";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplier.BackColor = System.Drawing.Color.White;
            this.txtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSupplier.Location = new System.Drawing.Point(10, 23);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(148, 33);
            this.txtSupplier.TabIndex = 3;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblSupplier.Location = new System.Drawing.Point(174, 24);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(101, 28);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "اسم المورد";
            // 
            // txtPurchaseID
            // 
            this.txtPurchaseID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPurchaseID.BackColor = System.Drawing.Color.White;
            this.txtPurchaseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseID.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPurchaseID.Location = new System.Drawing.Point(10, 314);
            this.txtPurchaseID.Name = "txtPurchaseID";
            this.txtPurchaseID.ReadOnly = true;
            this.txtPurchaseID.Size = new System.Drawing.Size(148, 33);
            this.txtPurchaseID.TabIndex = 1;
            // 
            // lblPurchaseID
            // 
            this.lblPurchaseID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPurchaseID.AutoSize = true;
            this.lblPurchaseID.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPurchaseID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblPurchaseID.Location = new System.Drawing.Point(174, 319);
            this.lblPurchaseID.Name = "lblPurchaseID";
            this.lblPurchaseID.Size = new System.Drawing.Size(91, 28);
            this.lblPurchaseID.TabIndex = 0;
            this.lblPurchaseID.Text = "رقم الشراء";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRecord);
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 520);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlButtons.Size = new System.Drawing.Size(300, 200);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnRecord
            // 
            this.btnRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Location = new System.Drawing.Point(10, 10);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(280, 50);
            this.btnRecord.TabIndex = 2;
            this.btnRecord.Text = "تسجيل الدفع";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(10, 70);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(280, 50);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "جديد";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(10, 130);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(280, 50);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // SupplierPaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1099, 720);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "SupplierPaymentsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدفوعات الموردين";
            this.Load += new System.EventHandler(this.SupplierPayments_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.gbPayment.ResumeLayout(false);
            this.gbPayment.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox gbPayment;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtPurchaseID;
        private System.Windows.Forms.Label lblPurchaseID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
    }
}