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
    class aspirantRegDAL
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
                string sql = "SELECT * FROM tbl_aspirant_reg";
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
        public bool Insert(aspirantRegBLL asp)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "INSERT INTO tbl_aspirant_reg (FirstName, LastName, NickName, AdmissionNo, Department, Post, Religion, CurrentLevel, ImageUrl, Sex, Phone, DateTime) VALUES (@FirstName, @LastName, @NickName, @AdmissionNo, @Department, @Post, @Religion, @CurrentLevel, @ImageUrl, @Sex, @Phone, @DateTime)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //cmd.Parameters.AddWithValue("@AspirantID", asp.AspirantID);
                cmd.Parameters.AddWithValue("@FirstName", asp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", asp.LastName);
                cmd.Parameters.AddWithValue("@NickName", asp.NickName);
                cmd.Parameters.AddWithValue("@AdmissionNo", asp.AdmissionNo);
                cmd.Parameters.AddWithValue("@Department", asp.Department);
                cmd.Parameters.AddWithValue("@Post", asp.Post);
                cmd.Parameters.AddWithValue("@Religion", asp.Religion);
                cmd.Parameters.AddWithValue("@CurrentLevel", asp.CurrentLevel);
                cmd.Parameters.AddWithValue("@ImageUrl", asp.ImageUrl);
                cmd.Parameters.AddWithValue("@Sex", asp.Sex);
                cmd.Parameters.AddWithValue("@Phone", asp.Phone);
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
        #region Update Data in Database
        public bool update(aspirantRegBLL asp)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE tbl_aspirant_reg SET FirstName =@FirstName, LastName=@LastName, NickName=@NickName, AdmissionNo=@AdmissionNo, Department=@Department, Post=@Post, Religion=@Religion, CurrentLevel=@CurrentLevel, ImageUrl=@ImageUrl, Sex=@Sex, Phone=@Phone, DateTime=@DateTime WHERE AspirantID=@AspirantID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@AspirantID", asp.AspirantID);
                cmd.Parameters.AddWithValue("@FirstName", asp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", asp.LastName);
                cmd.Parameters.AddWithValue("@NickName", asp.NickName);
                cmd.Parameters.AddWithValue("@AdmissionNo", asp.AdmissionNo);
                cmd.Parameters.AddWithValue("@Post", asp.Post);
                cmd.Parameters.AddWithValue("@Religion", asp.Religion);
                cmd.Parameters.AddWithValue("@CurrentLevel", asp.CurrentLevel);
                cmd.Parameters.AddWithValue("@ImageUrl", asp.ImageUrl);
                cmd.Parameters.AddWithValue("@Sex", asp.Sex);
                cmd.Parameters.AddWithValue("@Phone", asp.Phone);
                cmd.Parameters.AddWithValue("@DateTime", asp.DateTime);
                cmd.Parameters.AddWithValue("@Department", asp.Department);

                conn.Open();

                int rows = cmd.ExecuteNonQuery(); //ExecuteNonQuery command will execute the Query and return number of Rows affected from database 
                if (rows > 0)
                {
                    //Query is executed successfull 
                    isSuccess = true;
                }
                else
                {
                    //Quary fail to execute
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
        public bool Delete(aspirantRegBLL asp)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM tbl_aspirant_reg WHERE AspirantID=@AspirantID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@AspirantID", asp.AspirantID);

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
        #region search user on database using keywords
        public DataTable search(string keywords)
        {
            // static Mathod to connect Database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            // To hold the data   
            DataTable dt = new DataTable();

            try
            {
                // Sql quary to get from database
                string sql = "SELECT * FROM tbl_aspirant_reg WHERE AspirantID LIKE '%" + keywords + "%' OR FirstName LIKE '%" + keywords + "%' OR LastName LIKE '%" + keywords + "%' OR NickName LIKE '%" + keywords + "%'";
                // For excuting command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Getting Data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
            //Return the value in Datatable
            return dt;
        }
        #endregion
    }
}
