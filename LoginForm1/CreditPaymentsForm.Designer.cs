namespace LoginForm1
{
    partial class CreditPaymentsForm
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.dgvCreditSales = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSavePayment = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.bottomSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditSales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomSplitContainer)).BeginInit();
            this.bottomSplitContainer.Panel1.SuspendLayout();
            this.bottomSplitContainer.Panel2.SuspendLayout();
            this.bottomSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 28);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1014, 278);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            // 
            // dgvCreditSales
            // 
            this.dgvCreditSales.AllowUserToAddRows = false;
            this.dgvCreditSales.AllowUserToDeleteRows = false;
            this.dgvCreditSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreditSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCreditSales.Location = new System.Drawing.Point(3, 28);
            this.dgvCreditSales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCreditSales.MultiSelect = false;
            this.dgvCreditSales.Name = "dgvCreditSales";
            this.dgvCreditSales.ReadOnly = true;
            this.dgvCreditSales.RowHeadersVisible = false;
            this.dgvCreditSales.RowHeadersWidth = 51;
            this.dgvCreditSales.RowTemplate.Height = 24;
            this.dgvCreditSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditSales.Size = new System.Drawing.Size(603, 243);
            this.dgvCreditSales.TabIndex = 1;
            this.dgvCreditSales.SelectionChanged += new System.EventHandler(this.dgvCreditSales_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustomerInfo);
            this.groupBox1.Controls.Add(this.dgvCustomers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1020, 310);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "العملاء المدينون";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblCustomerInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(3, 275);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(1014, 31);
            this.lblCustomerInfo.TabIndex = 1;
            this.lblCustomerInfo.Text = "حدد عميلاً لعرض تفاصيل الدين";
            this.lblCustomerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCreditSales);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(609, 275);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "فواتير الدين";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSavePayment);
            this.groupBox3.Controls.Add(this.txtNotes);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbPaymentMethod);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtAmount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpPaymentDate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(401, 275);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تسديد دين";
            // 
            // btnSavePayment
            // 
            this.btnSavePayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSavePayment.FlatAppearance.BorderSize = 0;
            this.btnSavePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePayment.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePayment.ForeColor = System.Drawing.Color.White;
            this.btnSavePayment.Location = new System.Drawing.Point(6, 216);
            this.btnSavePayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSavePayment.Name = "btnSavePayment";
            this.btnSavePayment.Size = new System.Drawing.Size(256, 48);
            this.btnSavePayment.TabIndex = 8;
            this.btnSavePayment.Text = "حفظ الدفعة";
            this.btnSavePayment.UseVisualStyleBackColor = false;
            this.btnSavePayment.Click += new System.EventHandler(this.btnSavePayment_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(6, 151);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(256, 57);
            this.txtNotes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "ملاحظات:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "نقدي",
            "تحويل بنكي",
            "بطاقة ائتمان"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(6, 112);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(256, 31);
            this.cmbPaymentMethod.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "طريقة الدفع:";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.Location = new System.Drawing.Point(6, 73);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(256, 31);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "المبلغ:";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(6, 33);
            this.dtpPaymentDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(256, 31);
            this.dtpPaymentDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاريخ الدفعة:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(896, 14);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 48);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplitContainer.Location = new System.Drawing.Point(12, 70);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.groupBox1);
            this.mainSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.bottomSplitContainer);
            this.mainSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainSplitContainer.Size = new System.Drawing.Size(1020, 595);
            this.mainSplitContainer.SplitterDistance = 310;
            this.mainSplitContainer.SplitterWidth = 10;
            this.mainSplitContainer.TabIndex = 6;
            // 
            // bottomSplitContainer
            // 
            this.bottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.bottomSplitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bottomSplitContainer.Name = "bottomSplitContainer";
            // 
            // bottomSplitContainer.Panel1
            // 
            this.bottomSplitContainer.Panel1.Controls.Add(this.groupBox2);
            this.bottomSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // bottomSplitContainer.Panel2
            // 
            this.bottomSplitContainer.Panel2.Controls.Add(this.groupBox3);
            this.bottomSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bottomSplitContainer.Size = new System.Drawing.Size(1020, 275);
            this.bottomSplitContainer.SplitterDistance = 609;
            this.bottomSplitContainer.SplitterWidth = 10;
            this.bottomSplitContainer.TabIndex = 0;
            // 
            // CreditPaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 677);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.btnRefresh);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreditPaymentsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة ديون العملاء";
            this.Load += new System.EventHandler(this.CreditPaymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditSales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.bottomSplitContainer.Panel1.ResumeLayout(false);
            this.bottomSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottomSplitContainer)).EndInit();
            this.bottomSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvCreditSales;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSavePayment;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer bottomSplitContainer;
    }
}