using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ZXing;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace LoginForm1
{
    public partial class BarcodeLabelGenerator : Form
    {
        public BarcodeLabelGenerator()
        {
            InitializeComponent();
        }

        private void buttonGeneratePDF_Click(object sender, EventArgs e)
        {
            string productName = textBoxName.Text;
            string unit = textBoxUnit.Text;
            string price = textBoxPrice.Text;
            string barcodeValue = textBoxBarcode.Text;
            int labelCount;

            if (!int.TryParse(textBoxQuantity.Text, out labelCount) || labelCount <= 0)
            {
                MessageBox.Show("Enter a valid label quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 200,
                    Height = 60,
                    Margin = 2
                }
            };

            Bitmap barcodeBitmap = writer.Write(barcodeValue);

            Bitmap labelBitmap = new Bitmap(300, 150);
            using (Graphics g = Graphics.FromImage(labelBitmap))
            {
                g.Clear(Color.White);
                g.DrawString(string.Format("Name: {0}", productName), new Font("Arial", 10), Brushes.Black, new PointF(10, 10));
                g.DrawString(string.Format("Unit: {0}", unit), new Font("Arial", 10), Brushes.Black, new PointF(10, 30));
                g.DrawString(string.Format("Price: {0}", price), new Font("Arial", 10), Brushes.Black, new PointF(10, 50));
                g.DrawImage(barcodeBitmap, new Point(10, 70));
            }

            PdfDocument doc = new PdfDocument();
            for (int i = 0; i < labelCount; i++)
            {
                PdfPage page = doc.AddPage();
                page.Width = XUnit.FromMillimeter(85);  // You can adjust label size
                page.Height = XUnit.FromMillimeter(45);
                XGraphics gfx = XGraphics.FromPdfPage(page);

                using (MemoryStream ms = new MemoryStream())
                {
                    labelBitmap.Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    XImage img = XImage.FromStream(ms);
                    gfx.DrawImage(img, 0, 0, labelBitmap.Width, labelBitmap.Height);
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.FileName = "Labels_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                doc.Save(sfd.FileName);
                MessageBox.Show("Saved to: " + sfd.FileName);
            }

        }
    }
}
