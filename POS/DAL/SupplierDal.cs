using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace POS.DAL
{
    public class SupplierDal:Databaseconfig
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
                    cmd.CommandText = "SELECT [id],[supplier_name],[address],[telephone_no] FROM [dbo].[suppliers]";
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
        public static DataRow GetRowById(Int32 id)
        {
            DataRow datar = null;

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                using (con)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = $"SELECT [id],[supplier_name],[address],[telephone_no] FROM [dbo].[suppliers] WHERE [id]='{id}'";
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
        public static bool Insert(Models.Supplier sup)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[suppliers] ([supplier_name],[address],[telephone_no]) VALUES( '" + sup.Name + "','" +sup.Address + "','" + sup.Phone + "')",con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public static bool Update(Models.Supplier sup)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[suppliers] SET  [supplier_name]= '{sup.Name}',[address] = '{sup.Address}' ,[telephone_no] = '{sup.Phone}' WHERE [id]='{sup.Id}'", con);
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
        public static bool Delete(Int32 id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[suppliers] WHERE [id]='" + id + "'", con);
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
        public static DataTable SearchSupplier(string column, string searchname)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                // SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("select * from suppliers where " + column + " like '%" + searchname + "%'", con);
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
    }
}
