
namespace BrewBreeze
{
    partial class ProductDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtProductName = new System.Windows.Forms.Label();
            this.productImg = new System.Windows.Forms.PictureBox();
            this.txtPrice = new System.Windows.Forms.Label();
            this.lblNotAvailable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productImg)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.AutoSize = true;
            this.txtProductName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.ForeColor = System.Drawing.Color.White;
            this.txtProductName.Location = new System.Drawing.Point(4, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(97, 20);
            this.txtProductName.TabIndex = 0;
            this.txtProductName.Text = "Product Name";
            // 
            // productImg
            // 
            this.productImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productImg.Location = new System.Drawing.Point(112, 36);
            this.productImg.Name = "productImg";
            this.productImg.Size = new System.Drawing.Size(85, 75);
            this.productImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.productImg.TabIndex = 1;
            this.productImg.TabStop = false;
            // 
            // txtPrice
            // 
            this.txtPrice.AutoSize = true;
            this.txtPrice.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.White;
            this.txtPrice.Location = new System.Drawing.Point(3, 82);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(86, 29);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.Text = "P100.00";
            // 
            // lblNotAvailable
            // 
            this.lblNotAvailable.AutoSize = true;
            this.lblNotAvailable.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNotAvailable.Location = new System.Drawing.Point(5, 36);
            this.lblNotAvailable.Name = "lblNotAvailable";
            this.lblNotAvailable.Size = new System.Drawing.Size(78, 16);
            this.lblNotAvailable.TabIndex = 3;
            this.lblNotAvailable.Text = "Not Available";
            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.lblNotAvailable);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.productImg);
            this.Controls.Add(this.txtProductName);
            this.Name = "ProductDetails";
            this.Size = new System.Drawing.Size(200, 114);
            ((System.ComponentModel.ISupportInitialize)(this.productImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtProductName;
        private System.Windows.Forms.PictureBox productImg;
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label lblNotAvailable;
    }
}
