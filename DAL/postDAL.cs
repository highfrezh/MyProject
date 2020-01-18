using Electoric_Voting_System.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electoric_Voting_System.DAL
{
    class postDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Data from Database
        public DataTable Select()
        {
            // static Mathod to connect Database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Temporary Data Table to hold Data from database
            DataTable dt = new DataTable();

            try
            {
                // Sql quary to get from database
                string sql = "SELECT * FROM tbl_post";
                // For excuting command
                SqlCommand cmd = new SqlCommand(sql, conn); //Sqlcommand is use to pass Query to database
                //Getting Data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd); //SqlDataAdapter is use to execute the Query pass to Database and hold the data from the Query
                //Database connection open
                conn.Open();
                // Fill data in our DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                // Throw message if any error occours

                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Closing connection
                conn.Close();
            }
            //Return the value into Datatable
            return dt;
        }
        #endregion
        #region Insert Data in Database
        public bool Insert(postBLL asp)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "INSERT INTO tbl_post (PostName, DateTime) VALUES (@PostName, @DateTime)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //cmd.Parameters.AddWithValue("@AspirantID", asp.AspirantID);
                cmd.Parameters.AddWithValue("@PostName", asp.PostName);
                cmd.Parameters.AddWithValue("@DateTime", asp.DateTime);

                conn.Open();

                int row = cmd.ExecuteNonQuery(); //ExecuteNonQuery command will execute the Query and return number of Rows affected from database

                //If the quary excuted successfully then the Value of row will be greater than 0 else it will less than 0
                if (row > 0)
                {
                    //Quary successfull
                    isSuccess = true;

                }
                else
                {
                    //Quary failed
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion
        #region Delete data from database
        public bool Delete(postBLL asp)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM tbl_post WHERE PostID=@PostID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PostID", asp.PostID);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Quary execute successfull
                    isSuccess = true;
                }
                else
                {
                    //Quary execution fail
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }


        #endregion
    }
}
