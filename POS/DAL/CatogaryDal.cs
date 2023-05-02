using POS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace POS.DAL
{
    public class CatogaryDal:Databaseconfig
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
                    cmd.CommandText = "SELECT [id],[catogary_name] FROM [dbo].[catogaries]";
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
        public static bool Insert(Models.Catogary ctg)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[catogaries] ([catogary_name])VALUES ( '" + ctg.Name + "')", con);
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
        public static bool Update(Models.Catogary ctg)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[catogaries] SET [catogary_name] = '{ctg.Name}' WHERE [id]='{ctg.Id}'", con);
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
                    cmd.CommandText = $"SELECT [id],[catogary_name] FROM [dbo].[catogaries] WHERE [id]='{id}'";
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

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[catogaries] WHERE [id]='" + id + "'", con);
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
