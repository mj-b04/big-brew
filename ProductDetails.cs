using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BrewBreeze
{
    public partial class ProductDetails : UserControl
    {
        public int Quantity { get; set; }
        public ProductDetails()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.Size = new Size(200, 114);
            this.Margin = new Padding(5);
            this.Cursor = Cursors.Hand;
        }

        public void SetProductDetails(string productName, string price, byte[] productPhoto, int quantity)
        {
            txtProductName.Text = productName;
            txtPrice.Text = price;

            if (productPhoto != null && productPhoto.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(productPhoto))
                {
                    productImg.Image = Image.FromStream(ms);
                }
            }
            else
            {
                productImg.Image = Properties.Resources.defaultImage;
            }

            Quantity = quantity;

            if (Quantity <= 0)
            {
                lblNotAvailable.Visible = true;
                lblNotAvailable.Text = "Not Available";
                lblNotAvailable.ForeColor = Color.Red;
            }
            else
            {
                lblNotAvailable.Visible = true;
                lblNotAvailable.Text = $"Available: {Quantity}";
                lblNotAvailable.ForeColor = Color.White;
            }
        }
    }
}
