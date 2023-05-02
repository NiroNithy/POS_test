using POS.Models;
using POS.UI.Supplier;
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
    public partial class UserList : Form
    {
        string id = null;
        string Type = null;
        public UserList()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUser login = new frmAddUser();
            login.ShowDialog();
            DataTable dt = DAL.UserDal.GetAll();
            dgvUser.DataSource = dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
         
            frmAddUser edit = new frmAddUser(Convert.ToInt32(this.id));
            edit.ShowDialog();
            DataTable dt = DAL.UserDal.GetAll();
            dgvUser.DataSource = dt;
        }

        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.UserDal.GetAll();
            dgvUser.DataSource = dt;
        }

        private void dgvUser_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.id = dgvUser.SelectedRows[0].Cells["id"].Value.ToString();
            this.Name= dgvUser.SelectedRows[0].Cells["username"].Value.ToString();
            MessageBox.Show(this.Name + " details is selected!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete \nUser Name: " + this.Name + "", "conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (DAL.UserDal.Delete(Convert.ToInt32(this.id)))
                {
                    DataTable dt = DAL.UserDal.GetAll();
                    dgvUser.DataSource = dt;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.UserDal.SearchUser(cmbType.Text, txtUserName.Text);
            dgvUser.DataSource = dt;
            txtUserName.Text = "";
            cmbType.Text = "None";
        }

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = DAL.UserDal.SearchByUserType(cmbType.SelectedValue.ToString());
            dgvUser.DataSource = dt;
        }
    }
}
