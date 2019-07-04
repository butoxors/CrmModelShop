using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }


        public SellerForm()
        {
            InitializeComponent();
        }
        public SellerForm(Seller seller) : this()
        {
            this.Seller = seller;
            textBox1.Text = seller.Name;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            Seller = Seller ?? new Seller();
            Seller.Name = textBox1.Text;
            Close();
        }
    }
}
