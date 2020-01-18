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
    class userDAL
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
                string sql = "SELECT * FROM tbl_user";
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
        public bool Insert(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "INSERT INTO tbl_user (FirstName, LastName, Username, Password, Email, Contact, Gender, Address, UserType, DateTime) VALUES (@FirstName, @LastName, @Username, @Password, @Email, @Contact, @Gender, @Address, @UserType, @DateTime)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //cmd.Parameters.AddWithValue("@AspirantID", asp.AspirantID);
                cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
                cmd.Parameters.AddWithValue("@LastName", u.LastName);
                cmd.Parameters.AddWithValue("@Username", u.Username);
                cmd.Parameters.AddWithValue("@Password", u.Password);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Contact", u.Contact);
                cmd.Parameters.AddWithValue("@Gender", u.Gender);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@UserType", u.UserType);
                cmd.Parameters.AddWithValue("@DateTime", u.DateTime);

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
        public bool update(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE tbl_user SET FirstName =@FirstName, LastName=@LastName, Username=@Username, Password=@Password, Email=@Email, Contact=@Contact, Gender=@Gender, Address=@Address, UserType=@UserType, DateTime=@DateTime WHERE userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", u.UserID);
                cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
                cmd.Parameters.AddWithValue("@LastName", u.LastName);
                cmd.Parameters.AddWithValue("@Username", u.Username);
                cmd.Parameters.AddWithValue("@Password", u.Password);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Contact", u.Contact);
                cmd.Parameters.AddWithValue("@Gender", u.Gender);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@UserType", u.UserType);
                cmd.Parameters.AddWithValue("@DateTime", u.DateTime);
         
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
        public bool Delete(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM tbl_user WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", u.UserID);

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
                string sql = "SELECT * FROM tbl_user WHERE UserID LIKE '%" + keywords + "%' OR FirstName LIKE '%" + keywords + "%' OR LastName LIKE '%" + keywords + "%' OR Username LIKE '%" + keywords + "%'";
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
