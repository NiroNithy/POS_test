using POS.Models;
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
    public partial class frmSupplierCreate : Form
    {
        Int32 supplierId;
        public frmSupplierCreate()
        {
            InitializeComponent();
        }
        public frmSupplierCreate(Int32 id)
        {
            InitializeComponent();
            this.supplierId = id;

        }
        private Boolean Validation()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter the Supplier Name?");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Enter the address?");
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Enter the Phone number??");
                txtPhone.Focus();
                return false;
            }
            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Reset()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            this.supplierId = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool is_save = false;
            Models.Supplier suppiler = new Models.Supplier();
            suppiler.Name = txtName.Text;
            suppiler.Address = txtAddress.Text;
            suppiler.Phone = txtPhone.Text;
            if (Validation())
            {
                if (this.supplierId != 0)
                {
                    suppiler.Id = this.supplierId;
                    is_save = DAL.SupplierDal.Update(suppiler);
                    this.Close();
                }
                else
                {
                    is_save = DAL.SupplierDal.Insert(suppiler);
                }
                if (is_save)
                {
                    MessageBox.Show("New Supplier is added successfully");
                    Reset();

                }
                else
                {
                    MessageBox.Show("New Supplier is not added!!! Try again");
                }
            }
        }

        private void frmSupplierCreate_Load(object sender, EventArgs e)
        {
            if (this.supplierId != 0)
            {
                btnAdd.Text = "Update";
                label1.Text = "Update Supplier";
                DataRow dr = DAL.SupplierDal.GetRowById(this.supplierId);
                if (dr != null)
                {
                    txtName.Text = dr["supplier_name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtPhone.Text = dr["telephone_no"].ToString();
                }
            }
        }
    }
}
