using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.Supplier
{
    public partial class frmSupplierMaster : Form
    {
        string id = null;
       // string Name = null;
        public frmSupplierMaster()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplierCreate add = new frmSupplierCreate();
            add.ShowDialog();
            DataTable dt = DAL.SupplierDal.GetAll();
            dgvSupplier.DataSource = dt;
        }

        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.SupplierDal.GetAll();
            dgvSupplier.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
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
            frmSupplierCreate edit = new frmSupplierCreate(Convert.ToInt32(this.id));
            edit.ShowDialog();
            DataTable dt = DAL.SupplierDal.GetAll();
            dgvSupplier.DataSource = dt;
        }

        private void dgvSupplier_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.id = dgvSupplier.SelectedRows[0].Cells["id"].Value.ToString();
            this.Name = dgvSupplier.SelectedRows[0].Cells["supplier_name"].Value.ToString();
            MessageBox.Show(this.Name + " details is selected!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete \nSupplier Name: " + this.Name + "", "conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (DAL.SupplierDal.Delete(Convert.ToInt32(this.id)))
                {
                    DataTable dt = DAL.SupplierDal.GetAll();
                    dgvSupplier.DataSource = dt;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.SupplierDal.SearchSupplier(cmbSearch.Text, txtSearch.Text);
            dgvSupplier.DataSource = dt;
            txtSearch.Text = "";
            cmbSearch.Text = "None";
        }
    }
}
