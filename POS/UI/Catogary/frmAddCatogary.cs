using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace POS.UI.Catogary
{
    public partial class frmAddCatogary : Form
    {
        Int32 catogaryId;
        public frmAddCatogary()
        {
            InitializeComponent();
        }
        public frmAddCatogary(Int32 id)
        {
            InitializeComponent();
            this.catogaryId = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean Validation()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter the Catogary Name?");
                txtName.Focus();
                return false;
            }

            return true;
        }
        public void Reset()
        {
            txtName.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool is_save = false;
            Models.Catogary catogary = new Models.Catogary();
            catogary.Name = txtName.Text;
            if (Validation())
            {
                if (this.catogaryId != 0)
                {
                    catogary.Id = this.catogaryId;
                    is_save = DAL.CatogaryDal.Update(catogary);
                    this.Close();
                }
                else
                {
                    is_save = DAL.CatogaryDal.Insert(catogary);
                }

                if (is_save)
                {
                    MessageBox.Show("New Catogary is added successfully");
                    Reset();

                }
                else
                {
                    MessageBox.Show("New Catogary is not added!!! Try again");
                }
            }
        }

        private void frmAddCatogary_Load(object sender, EventArgs e)
        {

            if (this.catogaryId != 0)
            {
                btnAdd.Text = "Update";
                label1.Text = "Update Catogary";
                DataRow dr = DAL.CatogaryDal.GetByIdRow(this.catogaryId);
                if (dr != null)
                {
                    txtName.Text = dr["catogary_name"].ToString();
                    
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
