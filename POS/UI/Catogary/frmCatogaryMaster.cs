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

namespace POS.UI.Catogary
{
    public partial class frmCatogaryMaster : Form
    {
        string id = null;
       // string Name = null;
        public frmCatogaryMaster()
        {
            InitializeComponent();
        }
      

        private void frmCatogaryMaster_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.CatogaryDal.GetAll();
            dgvCatogary.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCatogary add = new frmAddCatogary();
            add.ShowDialog();
            DataTable dt = DAL.CatogaryDal.GetAll();
            dgvCatogary.DataSource = dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            frmAddCatogary edit = new frmAddCatogary(Convert.ToInt32(this.id));
            edit.ShowDialog();
            DataTable dt = DAL.CatogaryDal.GetAll();
            dgvCatogary.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCatogary_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.id =dgvCatogary.SelectedRows[0].Cells["id"].Value.ToString();
            this.Name = dgvCatogary.SelectedRows[0].Cells["catogary_name"].Value.ToString();
            MessageBox.Show(this.Name + " details is selected!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please Double click the DataGrid Row!!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete \nCatogary Name: " + this.Name + "", "conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (DAL.CatogaryDal.Delete(Convert.ToInt32(this.id)))
                {
                    DataTable dt = DAL.CatogaryDal.GetAll();
                    dgvCatogary.DataSource = dt;
                }
            }
        }
    }
}
