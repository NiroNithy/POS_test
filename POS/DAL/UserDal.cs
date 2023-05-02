using POS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.DAL
{
    public class UserDal : Databaseconfig
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
                    cmd.CommandText = "SELECT [id],[username],[password],[user_type] FROM [dbo].[users]";
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
        public static bool Insert(Models.User user)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[users] ([username],[password],[user_type])VALUES ( '" + user.UserName + "','" + user.Password + "','" + user.UserType + "')", con);
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
        public static DataRow GetByIdRow(Int32 id)
        {
            DataRow datar = null;

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                using (con)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = $"SELECT [id],[username],[password],[user_type] FROM [dbo].[users] WHERE [id]='{id}'";
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
        public static bool Update(Models.User user)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[users] SET  [username]= '{user.UserName}',[password] = '{user.Password}' ,[user_type] = '{user.UserType}' WHERE [id]='{user.Id}'", con);
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

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[users] WHERE [id]='" + id + "'", con);
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
        public static DataTable SearchUser(string column, string searchname)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("select * from users where " + column + " like '%" + searchname + "%'", con);
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
        public static  DataTable SearchByUserType(string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("select*from users where id='" + userId + "'", con);
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
