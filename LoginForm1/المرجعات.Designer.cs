namespace LoginForm1
{
    partial class المرجعات
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvSaleItems = new System.Windows.Forms.DataGridView();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnLoadSale = new System.Windows.Forms.Button();
            this.btnProcessReturn = new System.Windows.Forms.Button();
            this.panelInputs = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtSaleID = new System.Windows.Forms.TextBox();
            this.lblSaleID = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).BeginInit();
            this.panelControls.SuspendLayout();
            this.panelInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(400, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إدارة المرتجعات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvSaleItems);
            this.panelMain.Controls.Add(this.panelControls);
            this.panelMain.Controls.Add(this.panelInputs);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15);
            this.panelMain.Size = new System.Drawing.Size(950, 490);
            this.panelMain.TabIndex = 1;
            // 
            // dgvSaleItems
            // 
            this.dgvSaleItems.AllowUserToAddRows = false;
            this.dgvSaleItems.AllowUserToDeleteRows = false;
            this.dgvSaleItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSaleItems.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvSaleItems.Location = new System.Drawing.Point(15, 15);
            this.dgvSaleItems.MultiSelect = false;
            this.dgvSaleItems.Name = "dgvSaleItems";
            this.dgvSaleItems.ReadOnly = true;
            this.dgvSaleItems.RowHeadersWidth = 51;
            this.dgvSaleItems.RowTemplate.Height = 29;
            this.dgvSaleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleItems.Size = new System.Drawing.Size(920, 260);
            this.dgvSaleItems.TabIndex = 18;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.button1);
            this.panelControls.Controls.Add(this.btnLoadSale);
            this.panelControls.Controls.Add(this.btnProcessReturn);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(15, 275);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(920, 75);
            this.panelControls.TabIndex = 19;
            // 
            // btnLoadSale
            // 
            this.btnLoadSale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadSale.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLoadSale.FlatAppearance.BorderSize = 0;
            this.btnLoadSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadSale.ForeColor = System.Drawing.Color.White;
            this.btnLoadSale.Location = new System.Drawing.Point(540, 15);
            this.btnLoadSale.Name = "btnLoadSale";
            this.btnLoadSale.Size = new System.Drawing.Size(150, 45);
            this.btnLoadSale.TabIndex = 17;
            this.btnLoadSale.Text = "بحث عن البيع";
            this.btnLoadSale.UseVisualStyleBackColor = false;
            this.btnLoadSale.Click += new System.EventHandler(this.btnLoadSale_Click);
            // 
            // btnProcessReturn
            // 
            this.btnProcessReturn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProcessReturn.BackColor = System.Drawing.Color.ForestGreen;
            this.btnProcessReturn.FlatAppearance.BorderSize = 0;
            this.btnProcessReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessReturn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessReturn.ForeColor = System.Drawing.Color.White;
            this.btnProcessReturn.Location = new System.Drawing.Point(230, 15);
            this.btnProcessReturn.Name = "btnProcessReturn";
            this.btnProcessReturn.Size = new System.Drawing.Size(150, 45);
            this.btnProcessReturn.TabIndex = 13;
            this.btnProcessReturn.Text = "معالجة المرتجع";
            this.btnProcessReturn.UseVisualStyleBackColor = false;
            this.btnProcessReturn.Click += new System.EventHandler(this.btnProcessReturn_Click);
            // 
            // panelInputs
            // 
            this.panelInputs.Controls.Add(this.txtQuantity);
            this.panelInputs.Controls.Add(this.lblQuantity);
            this.panelInputs.Controls.Add(this.txtSaleID);
            this.panelInputs.Controls.Add(this.lblSaleID);
            this.panelInputs.Controls.Add(this.cmbReason);
            this.panelInputs.Controls.Add(this.lblReason);
            this.panelInputs.Controls.Add(this.cmbProduct);
            this.panelInputs.Controls.Add(this.lblProduct);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInputs.Location = new System.Drawing.Point(15, 350);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(920, 125);
            this.panelInputs.TabIndex = 20;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(540, 75);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 34);
            this.txtQuantity.TabIndex = 21;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantity.Location = new System.Drawing.Point(750, 78);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(67, 28);
            this.lblQuantity.TabIndex = 20;
            this.lblQuantity.Text = "الكمية:";
            // 
            // txtSaleID
            // 
            this.txtSaleID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSaleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSaleID.Location = new System.Drawing.Point(540, 15);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.Size = new System.Drawing.Size(200, 34);
            this.txtSaleID.TabIndex = 19;
            // 
            // lblSaleID
            // 
            this.lblSaleID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSaleID.AutoSize = true;
            this.lblSaleID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSaleID.Location = new System.Drawing.Point(750, 18);
            this.lblSaleID.Name = "lblSaleID";
            this.lblSaleID.Size = new System.Drawing.Size(109, 28);
            this.lblSaleID.TabIndex = 18;
            this.lblSaleID.Text = "رقم الفاتورة:";
            // 
            // cmbReason
            // 
            this.cmbReason.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(180, 75);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(200, 36);
            this.cmbReason.TabIndex = 17;
            // 
            // lblReason
            // 
            this.lblReason.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReason.Location = new System.Drawing.Point(390, 78);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(115, 28);
            this.lblReason.TabIndex = 16;
            this.lblReason.Text = "سبب الإرجاع:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(180, 15);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(200, 36);
            this.cmbProduct.TabIndex = 15;
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProduct.Location = new System.Drawing.Point(390, 18);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(66, 28);
            this.lblProduct.TabIndex = 14;
            this.lblProduct.Text = "المنتج:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(385, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 18;
            this.button1.Text = "التقارير";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // المرجعات
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "المرجعات";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة المرتجعات";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvSaleItems;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnLoadSale;
        private System.Windows.Forms.Button btnProcessReturn;
        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtSaleID;
        private System.Windows.Forms.Label lblSaleID;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button button1;
    }
}