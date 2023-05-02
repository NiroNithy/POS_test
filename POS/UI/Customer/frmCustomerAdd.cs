using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.Customer
{
    public partial class frmCustomerAdd : Form
    {
        Int32 customerId;
        public frmCustomerAdd()
        {
            InitializeComponent();
          
        }
        public frmCustomerAdd(Int32 id)
        {
            InitializeComponent();
            this.customerId = id;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean Validation()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter the Customer Name?");
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
        public void Reset()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            this.customerId= 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //DAL.CustomerDal.Insert();
            bool is_save = false;
            Models.Customer customer = new Models.Customer();
            customer.Name = txtName.Text;
            customer.Address = txtAddress.Text;
            customer.Phone = txtPhone.Text;
            if (Validation())
            {
                if (this.customerId != 0)
                {
                    customer.Id = this.customerId;
                    is_save = DAL.CustomerDal.Update(customer);
                    this.Close();
                }
                else
                {
                    is_save = DAL.CustomerDal.Insert(customer);
                    

                }

                if (is_save)
                {
                    MessageBox.Show("New Customer is added successfully");
                    Reset();
                   
                }
                else
                {
                    MessageBox.Show("New Customer is not added!!! Try again");
                }

            }
        }

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            if (this.customerId != 0)
            {
                btnSave.Text = "Update";
                label1.Text = "Update Customer";
                /*DataTable dt = DAL.CustomerDal.GetById(this.customerId);
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    txtName.Text = dr["customer_name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtPhone.Text = dr["telephone_no"].ToString();
                }*/
                DataRow dr = DAL.CustomerDal.GetByIdRow(this.customerId);
                if (dr != null)
                {
                    txtName.Text = dr["customer_name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtPhone.Text = dr["telephone_no"].ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
