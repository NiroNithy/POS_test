using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void saleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Sale.frmSaleMaster f = new Sale.frmSaleMaster();
            f.MdiParent = this;
            f.Show();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Sale.frmAddNewSale f = new Sale.frmAddNewSale();
            f.MdiParent = this;
            f.Show();
        }

        private void purchaseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Purchase.frmPurchaseMaster f = new Purchase.frmPurchaseMaster();
            f.MdiParent = this;
            f.Show();
        }

        private void newPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Purchase.frmAddNewPurchase f = new Purchase.frmAddNewPurchase();
            f.MdiParent = this;
            f.Show();
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Product.frmProductMaster f= new Product.frmProductMaster();
            f.MdiParent = this;
            f.Show();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Product.frmProductAdd f = new Product.frmProductAdd();
            f.MdiParent = this;
            f.Show();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.User.frmAddUser f = new User.frmAddUser();
            //f.MdiParent = this;
            f.Show();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.User.UserList f = new User.UserList();
            f.Show();
        }

        private void catoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Catogary.frmAddCatogary f = new Catogary.frmAddCatogary();
            f.Show();
        }

        private void catogaryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Catogary.frmCatogaryMaster f = new Catogary.frmCatogaryMaster();
            f.Show();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Customer.frmCustomerAdd f = new Customer.frmCustomerAdd();
            f.Show();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Customer.frmCustomerMaster f = new Customer.frmCustomerMaster();
            f.Show();
        }

        private void newSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Supplier.frmSupplierCreate f = new Supplier.frmSupplierCreate();
            f.Show();
        }

        private void supplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Supplier.frmSupplierMaster f = new Supplier.frmSupplierMaster();
            f.Show();
        }
    }
}
