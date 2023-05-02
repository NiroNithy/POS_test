using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.User
{
    public partial class frmAddUser : Form
    {

        Int32 userId;
        public frmAddUser()
        {
            InitializeComponent();
        }
        public frmAddUser(Int32 id)
        {
            InitializeComponent();
            this.userId = id;
        }
      
        public void Reset()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            RbCustomer.Text = string.Empty;
            RbSupplier.Text = string.Empty;
        }
        private Boolean Validation()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Enter the User Name?");
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Enter the Password?");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            if (this.userId != 0)
            {
                Models.User user = new Models.User();
                DataRow dr = DAL.UserDal.GetByIdRow(this.userId);
                if (dr != null)
                {
                    user.UserType = dr["user_type"].ToString();
                    if (user.UserType.Trim() == "Supplier")
                    {
                        RbSupplier.Checked = true;
                    }
                    if (user.UserType.Trim() == "Customer")
                    {
                        RbCustomer.Checked = true;
                    }
                    txtUsername.Text = dr["username"].ToString();
                    txtPassword.Text = dr["password"].ToString();

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            bool is_save = false;
            Models.User user = new Models.User();
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;

            if (Validation())
            {
                if (RbSupplier.Checked)
                {
                    user.UserType = "Supplier";
                }
                if (RbCustomer.Checked)
                {
                    user.UserType = "Customer";
                }

                if (this.userId != 0)
                {
                    user.Id = this.userId;
                    is_save = DAL.UserDal.Update(user);
                    this.Close();
                }
                else
                {
                    is_save = DAL.UserDal.Insert(user);
                }
                if (is_save)
                {
                    MessageBox.Show("New User is added successfully");
                    Reset();
                }
                else
                {
                    MessageBox.Show("New User is not added!!! Try again");
                }
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
