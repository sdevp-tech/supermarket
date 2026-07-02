namespace LoginForm1

{
    partial class BarcodeLabelGenerator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelUnit = new System.Windows.Forms.Label();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelBarcode = new System.Windows.Forms.Label();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.buttonGeneratePDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(278, 14);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(87, 19);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "اسم المنتج";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(62, 11);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.Location = new System.Drawing.Point(278, 44);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(53, 19);
            this.labelUnit.TabIndex = 2;
            this.labelUnit.Text = "الوحدة";
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(62, 41);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(200, 27);
            this.textBoxUnit.TabIndex = 3;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(278, 74);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(50, 19);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "السعر";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(62, 71);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(200, 27);
            this.textBoxPrice.TabIndex = 5;
            // 
            // labelBarcode
            // 
            this.labelBarcode.AutoSize = true;
            this.labelBarcode.Location = new System.Drawing.Point(278, 104);
            this.labelBarcode.Name = "labelBarcode";
            this.labelBarcode.Size = new System.Drawing.Size(94, 19);
            this.labelBarcode.TabIndex = 6;
            this.labelBarcode.Text = "قيمة الباركود";
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(62, 101);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(200, 27);
            this.textBoxBarcode.TabIndex = 7;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(278, 134);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(52, 19);
            this.labelQuantity.TabIndex = 8;
            this.labelQuantity.Text = "الكمية";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(62, 131);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(200, 27);
            this.textBoxQuantity.TabIndex = 9;
            // 
            // buttonGeneratePDF
            // 
            this.buttonGeneratePDF.Location = new System.Drawing.Point(62, 164);
            this.buttonGeneratePDF.Name = "buttonGeneratePDF";
            this.buttonGeneratePDF.Size = new System.Drawing.Size(200, 30);
            this.buttonGeneratePDF.TabIndex = 10;
            this.buttonGeneratePDF.Text = "PDF إنشاء";
            this.buttonGeneratePDF.Click += new System.EventHandler(this.buttonGeneratePDF_Click);
            // 
            // BarcodeLabelGenerator
            // 
            this.ClientSize = new System.Drawing.Size(396, 220);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelUnit);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelBarcode);
            this.Controls.Add(this.textBoxBarcode);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.buttonGeneratePDF);
            this.Name = "BarcodeLabelGenerator";
            this.Text = "Product Label Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelUnit;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelBarcode;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button buttonGeneratePDF;
    }
}

