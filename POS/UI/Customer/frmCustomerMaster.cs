using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.Customer
{
    public partial class frmCustomerMaster : Form
    {
        
        string id =null;
       // string Name = null;
        
        public frmCustomerMaster()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerAdd add = new frmCustomerAdd();
            add.ShowDialog();
            DataTable dt = DAL.CustomerDal.GetAll();
            dgvCustomer.DataSource = dt;

        }

        public void frmCustomerMaster_Load(object sender, EventArgs e)
        {
          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            frmCustomerAdd edit = new frmCustomerAdd(Convert.ToInt32(this.id));
            edit.ShowDialog();
            DataTable dt = DAL.CustomerDal.GetAll();
            dgvCustomer.DataSource = dt;

        }

        private void dgvCustomer_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           this.id = dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString();
            this.Name = dgvCustomer.SelectedRows[0].Cells["customer_name"].Value.ToString();
            MessageBox.Show(this.Name+" details is selected!!");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete \nCustomer Name: "+this.Name+"", "conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (DAL.CustomerDal.Delete(Convert.ToInt32(this.id)))
                {
                    DataTable dt = DAL.CustomerDal.GetAll();
                    dgvCustomer.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.CustomerDal.SearchCustomer(cmbSearch.Text, txtSearch.Text);
            dgvCustomer.DataSource = dt;
            txtSearch.Text = "";
            cmbSearch.Text = "None";
        }

        private void cmbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        public void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.CustomerDal.GetAll();
            dgvCustomer.DataSource = dt;
        }
    }
}
