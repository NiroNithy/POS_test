using POS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.DAL
{
    public class ProductDal:Databaseconfig
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                using (con)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT [id],[product_code],[product_name],[catogary_name] FROM [dbo].[Products]";
                    cmd.CommandType = CommandType.Text;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    cmd.Dispose();
                    con.Dispose();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
                throw;
            }


        }
        public static DataRow GetByIdRow(Int32 id)
        {
            DataRow datar = null;

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                using (con)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = $"SELECT [id],[product_code],[product_name],[catogary_name],[catogary_id] FROM [dbo].[Products] WHERE [id]='{id}'";
                    cmd.CommandType = CommandType.Text;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    if (dt != null)
                    {
                        datar = dt.Rows[0];
                    }
                    cmd.Dispose();
                    con.Dispose();
                    return datar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
                throw;
            }

        }
        public static Boolean Insert(Models.Product product)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Products] ([product_code],[product_name],[catogary_name],[catogary_id])VALUES ( '" + product.Code + "','" + product.Name + "','" + product.catogaryName + "','" + product.catogaryId + "')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }

        }
        public static Boolean Update(Models.Product product)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[Products] SET [product_code] = '{product.Code}',[product_name] = '{product.Name}' ,[catogary_name] = '{product.catogaryName}',[catogary_id] = '{product.catogaryId}' WHERE [id]='{product.Id}'", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public static DataTable SearchProduct(string column, string searchname)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

                using (con)
                {

                    SqlCommand cmd = new SqlCommand("select * from Products where " + column + " like '%" + searchname + "%'", con);
                    using (cmd)
                    {
                        ConnectionState state = con.State;
                        if (state != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        dt.Load(cmd.ExecuteReader());
                        con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
                throw;
            }
        }
        public static Boolean Delete(Int32 id)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                ConnectionState state = con.State;
                if (state != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Products] WHERE [id]='" + id + "'", con);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }
    }
}
