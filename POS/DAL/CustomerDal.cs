using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using POS.Data;
using System.Configuration;

namespace POS.DAL
{
    public class CustomerDal:Databaseconfig
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
                    cmd.CommandText = "SELECT [id],[customer_name],[address],[telephone_no] FROM [dbo].[customers]";
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
       
        public static DataTable GetById(Int32 id)
        {
            DataTable dt = new DataTable();

            try
            {
                using (con)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = $"SELECT [id],[customer_name],[address],[telephone_no] FROM [dbo].[customers] WHERE [id]='{id}'";
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
            catch(Exception ex)
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
                    cmd.CommandText = $"SELECT [id],[customer_name],[address],[telephone_no] FROM [dbo].[customers] WHERE [id]='{id}'";
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
        public static void Save()
        {
            
}
        public static bool Insert(Models.Customer cus)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[customers] ([customer_name],[address],[telephone_no])VALUES ( '" + cus.Name + "','" +cus.Address + "','" + cus.Phone + "')", con);
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
        public static bool Update(Models.Customer cus)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[customers] SET [customer_name] = '{cus.Name}',[address] = '{cus.Address}' ,[telephone_no] = '{cus.Phone}' WHERE [id]='{cus.Id}'", con);
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

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[customers] WHERE [id]='" + id + "'", con);
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
        public static DataTable SearchCustomer(string column, string searchname)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
               // SqlConnection con = new SqlConnection(connectionString);
                using (con)
                {
               
                    SqlCommand cmd = new SqlCommand("select * from customers where " + column + " like '%" + searchname + "%'", con);
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
