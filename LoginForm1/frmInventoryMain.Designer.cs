namespace LoginForm1
{
    partial class frmInventoryMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnExpiry;
        private System.Windows.Forms.Button btnBatches;
        private System.Windows.Forms.Panel pnlMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnBatches = new System.Windows.Forms.Button();
            this.btnExpiry = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.pnlButtons.Controls.Add(this.button1);
            this.pnlButtons.Controls.Add(this.btnBatches);
            this.pnlButtons.Controls.Add(this.btnExpiry);
            this.pnlButtons.Controls.Add(this.btnInventory);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1200, 60);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnBatches
            // 
            this.btnBatches.FlatAppearance.BorderSize = 0;
            this.btnBatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatches.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatches.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBatches.Location = new System.Drawing.Point(300, 0);
            this.btnBatches.Name = "btnBatches";
            this.btnBatches.Size = new System.Drawing.Size(300, 60);
            this.btnBatches.TabIndex = 2;
            this.btnBatches.Text = "الدفعات";
            this.btnBatches.UseVisualStyleBackColor = true;
            this.btnBatches.Click += new System.EventHandler(this.btnBatches_Click);
            // 
            // btnExpiry
            // 
            this.btnExpiry.FlatAppearance.BorderSize = 0;
            this.btnExpiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpiry.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExpiry.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExpiry.Location = new System.Drawing.Point(600, 0);
            this.btnExpiry.Name = "btnExpiry";
            this.btnExpiry.Size = new System.Drawing.Size(300, 60);
            this.btnExpiry.TabIndex = 1;
            this.btnExpiry.Text = "تواريخ الانتهاء";
            this.btnExpiry.UseVisualStyleBackColor = true;
            this.btnExpiry.Click += new System.EventHandler(this.btnExpiry_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventory.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnInventory.Location = new System.Drawing.Point(900, 0);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(300, 60);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "المخزان";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1200, 640);
            this.pnlMain.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "إنشاء باركود";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInventoryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Name = "frmInventoryMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "المخزن - الإدارة الشاملة";
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button1;
    }
}