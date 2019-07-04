using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }
        public CustomerForm(Customer customer) : this()
        {
            this.Customer = customer;
            textBox1.Text = customer.Name;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.Name = textBox1.Text;
            Close();
        }
    }
}
