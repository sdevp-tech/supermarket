using System.Windows.Forms;

namespace LoginForm1
{
    partial class POS
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
            this.dgvSaleItems = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnVoidSale = new System.Windows.Forms.Button();
            this.btnReturns = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkPackageMode = new System.Windows.Forms.CheckBox();
            this.lblPackageMode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSaleItems
            // 
            this.dgvSaleItems.AllowUserToAddRows = false;
            this.dgvSaleItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvSaleItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSaleItems.EnableHeadersVisualStyles = false;
            this.dgvSaleItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvSaleItems.Location = new System.Drawing.Point(15, 195);
            this.dgvSaleItems.Name = "dgvSaleItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSaleItems.RowTemplate.Height = 35;
            this.dgvSaleItems.Size = new System.Drawing.Size(849, 212);
            this.dgvSaleItems.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotal.Location = new System.Drawing.Point(717, 38);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(154, 38);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(764, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "المجموع:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(729, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "المبلغ المدفوع:";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmountPaid.BackColor = System.Drawing.Color.White;
            this.txtAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtAmountPaid.Location = new System.Drawing.Point(722, 125);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(153, 35);
            this.txtAmountPaid.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(626, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "الباقي:";
            // 
            // lblChange
            // 
            this.lblChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChange.BackColor = System.Drawing.Color.Transparent;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.Black;
            this.lblChange.Location = new System.Drawing.Point(464, 127);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(154, 29);
            this.lblChange.TabIndex = 6;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnProcessPayment.FlatAppearance.BorderSize = 0;
            this.btnProcessPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessPayment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnProcessPayment.ForeColor = System.Drawing.Color.White;
            this.btnProcessPayment.Location = new System.Drawing.Point(15, 92);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(154, 38);
            this.btnProcessPayment.TabIndex = 8;
            this.btnProcessPayment.Text = "سدد";
            this.btnProcessPayment.UseVisualStyleBackColor = false;
            this.btnProcessPayment.Click += new System.EventHandler(this.btnProcessPayment_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(177, 92);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(154, 38);
            this.btnRemoveItem.TabIndex = 9;
            this.btnRemoveItem.Text = "إزالة";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            // 
            // btnVoidSale
            // 
            this.btnVoidSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoidSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnVoidSale.FlatAppearance.BorderSize = 0;
            this.btnVoidSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoidSale.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnVoidSale.ForeColor = System.Drawing.Color.White;
            this.btnVoidSale.Location = new System.Drawing.Point(339, 92);
            this.btnVoidSale.Name = "btnVoidSale";
            this.btnVoidSale.Size = new System.Drawing.Size(103, 38);
            this.btnVoidSale.TabIndex = 10;
            this.btnVoidSale.Text = "إلغاء";
            this.btnVoidSale.UseVisualStyleBackColor = false;
            // 
            // btnReturns
            // 
            this.btnReturns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnReturns.FlatAppearance.BorderSize = 0;
            this.btnReturns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturns.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnReturns.ForeColor = System.Drawing.Color.Black;
            this.btnReturns.Location = new System.Drawing.Point(15, 137);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(154, 38);
            this.btnReturns.TabIndex = 11;
            this.btnReturns.Text = "مرتجع";
            this.btnReturns.UseVisualStyleBackColor = false;
            this.btnReturns.Click += new System.EventHandler(this.btnReturns_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(179, 137);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 38);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // chkPackageMode
            // 
            this.chkPackageMode.AutoSize = true;
            this.chkPackageMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPackageMode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkPackageMode.Location = new System.Drawing.Point(24, 73);
            this.chkPackageMode.Name = "chkPackageMode";
            this.chkPackageMode.Size = new System.Drawing.Size(17, 16);
            this.chkPackageMode.TabIndex = 13;
            this.chkPackageMode.UseVisualStyleBackColor = true;
            // 
            // lblPackageMode
            // 
            this.lblPackageMode.AutoSize = true;
            this.lblPackageMode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPackageMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPackageMode.Location = new System.Drawing.Point(70, 67);
            this.lblPackageMode.Name = "lblPackageMode";
            this.lblPackageMode.Size = new System.Drawing.Size(165, 28);
            this.lblPackageMode.TabIndex = 14;
            this.lblPackageMode.Text = "وضع التعبئة: وحدة";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(764, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 28);
            this.label4.TabIndex = 15;
            this.label4.Text = "التاريخ:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(628, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(88, 28);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "01/01/2025";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(646, 32);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(68, 28);
            this.lblTime.TabIndex = 17;
            this.lblTime.Text = "00:00:00";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(764, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 28);
            this.label5.TabIndex = 18;
            this.label5.Text = "الوقت:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbCustomer.BackColor = System.Drawing.Color.White;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(125, 17);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(153, 36);
            this.cmbCustomer.TabIndex = 19;
            this.cmbCustomer.Visible = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustomer.Location = new System.Drawing.Point(45, 25);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(66, 28);
            this.lblCustomer.TabIndex = 20;
            this.lblCustomer.Text = "الزبون:";
            this.lblCustomer.Visible = false;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.White;
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(532, 52);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(153, 36);
            this.cmbPaymentMethod.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(550, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 28);
            this.label6.TabIndex = 22;
            this.label6.Text = "طريقة الدفع:";
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.dgvSaleItems);
            this.panelContainer.Controls.Add(this.panelHeader);
            this.panelContainer.Controls.Add(this.panelFooter);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(879, 624);
            this.panelContainer.TabIndex = 23;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.label8);
            this.panelHeader.Controls.Add(this.label7);
            this.panelHeader.Controls.Add(this.txtBarcode);
            this.panelHeader.Controls.Add(this.label5);
            this.panelHeader.Controls.Add(this.lblTime);
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Controls.Add(this.label4);
            this.panelHeader.Controls.Add(this.lblPackageMode);
            this.panelHeader.Controls.Add(this.chkPackageMode);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(879, 189);
            this.panelHeader.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(58, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 28);
            this.label8.TabIndex = 20;
            this.label8.Text = "باركود المنتج";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(399, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 28);
            this.label7.TabIndex = 19;
            this.label7.Text = "اسم المنتج";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarcode.Location = new System.Drawing.Point(15, 15);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(256, 39);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.lblCustomer);
            this.panelFooter.Controls.Add(this.cmbCustomer);
            this.panelFooter.Controls.Add(this.label6);
            this.panelFooter.Controls.Add(this.cmbPaymentMethod);
            this.panelFooter.Controls.Add(this.txtAmountPaid);
            this.panelFooter.Controls.Add(this.label2);
            this.panelFooter.Controls.Add(this.lblChange);
            this.panelFooter.Controls.Add(this.label3);
            this.panelFooter.Controls.Add(this.btnProcessPayment);
            this.panelFooter.Controls.Add(this.btnVoidSale);
            this.panelFooter.Controls.Add(this.btnRemoveItem);
            this.panelFooter.Controls.Add(this.btnReturns);
            this.panelFooter.Controls.Add(this.btnClose);
            this.panelFooter.Controls.Add(this.lblTotal);
            this.panelFooter.Controls.Add(this.label1);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 401);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(879, 223);
            this.panelFooter.TabIndex = 24;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 624);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "POS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام المبيعات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.POS_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSaleItems;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnVoidSale;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkPackageMode;
        private System.Windows.Forms.Label lblPackageMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
