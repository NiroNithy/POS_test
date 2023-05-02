using POS.UI.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.Product
{
    public partial class frmProductMaster : Form
    {
        string id = null;
        //string Name = null;
        public frmProductMaster()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd add = new frmProductAdd();
            add.ShowDialog();
            DataTable dt = DAL.ProductDal.GetAll();
            dgvProduct.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.ProductDal.SearchProduct(cmbSearch.Text, txtSearch.Text);
            dgvProduct.DataSource = dt;
            txtSearch.Text = "";
            cmbSearch.Text = "None";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            frmProductAdd edit = new frmProductAdd(Convert.ToInt32(this.id));
            edit.ShowDialog();
            DataTable dt = DAL.ProductDal.GetAll();
            dgvProduct.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.ProductDal.GetAll();
            dgvProduct.DataSource = dt;
        }

        private void dgvProduct_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.id = dgvProduct.SelectedRows[0].Cells["id"].Value.ToString();
            this.Name = dgvProduct.SelectedRows[0].Cells["product_name"].Value.ToString();
            MessageBox.Show(this.Name + " details is selected!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete \nProduct Name: " + this.Name + "", "conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (DAL.ProductDal.Delete(Convert.ToInt32(this.id)))
                {
                    DataTable dt = DAL.ProductDal.GetAll();
                    dgvProduct.DataSource = dt;
                }
            }
        }
    }
}
