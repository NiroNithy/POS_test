using POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.Product
{
    
    public partial class frmProductAdd : Form
    {
        Int32 productId;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public frmProductAdd(Int32 id)
        {
            InitializeComponent();
            this.productId = id;
        }
        private Boolean Validation()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Enter the Product Code??");
                txtCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter the Product Name??");
                txtName.Focus();
                return false;
            }

            if (cmbCatogary.SelectedIndex == -1)
            {
                MessageBox.Show("Enter the Catogary??");
                cmbCatogary.Focus();
                return false;
            }
            return true;
        }
        public void Reset()
        {
           txtCode.Text = "";
           txtName.Text = "";
           cmbCatogary.SelectedIndex = -1;
        }
        private void GetCatogaryComboBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("SELECT [id],[catogary_name] FROM [dbo].[catogaries]", con);
                    using (cmd)
                    {
                        ConnectionState state = con.State;
                        if (state != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        cmbCatogary.DataSource = dt;
                        cmbCatogary.DisplayMember = dt.Columns["catogary_name"].ToString();
                        cmbCatogary.ValueMember = dt.Columns["id"].ToString();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //throw;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UI.Catogary.frmAddCatogary add = new Catogary.frmAddCatogary();
            add.ShowDialog();
            GetCatogaryComboBox();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            GetCatogaryComboBox();
            if (this.productId != 0)
            {
                btnSave.Text = "Update";
                label1.Text = "Update Product";
                DataRow dr = DAL.ProductDal.GetByIdRow(this.productId);
                if (dr != null)
                {
                    txtCode.Text = dr["product_code"].ToString();
                    txtName.Text = dr["product_name"].ToString();
                    cmbCatogary.SelectedValue = dr["catogary_id"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool is_save = false;
            Models.Product product = new Models.Product();
            product.Name = txtName.Text;
            product.Code = txtCode.Text;
            product.catogaryName = cmbCatogary.Text;
            product.catogaryId = cmbCatogary.SelectedValue.ToString();
            if (Validation())
            {

                if (this.productId != 0)
                {
                    product.Id = this.productId;
                    is_save = DAL.ProductDal.Update(product);
                    this.Close();
                }
                else
                {
                    is_save = DAL.ProductDal.Insert(product);


                }

                if (is_save)
                {
                    MessageBox.Show("New Product is added successfully");
                    Reset();

                }
                else
                {
                    MessageBox.Show("New Product is not added!!! Try again");
                }
            }
        }
    }
}
