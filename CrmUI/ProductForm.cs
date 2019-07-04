using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(Product product) : this()
        {
            textBox1.Text = product.Name;
            numericUpDown1.Value = product.Price;
            numericUpDown2.Value = product.Count;
            this.Product = product;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = textBox1.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);
            Close();
        }
    }
}
