using Electoric_Voting_System.BLL;
using Electoric_Voting_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electoric_Voting_System.UI
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        userDAL dal = new userDAL();
        userBLL u = new userBLL();

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            u.FirstName = txtFirstname.Text;
            u.LastName = txtLastname.Text;
            u.Username = txtUsername.Text;
            u.Password = txtPassword.Text;
            u.Email = txtEmail.Text;
            u.Contact = Convert.ToInt32(txtContact.Text);
            u.Gender = cmbGender.Text;
            u.Address = txtAddress.Text;
            u.UserType = cmbUserType.Text;
            u.DateTime = DateTime.Now;

            // Inserting in to database
            bool success = dal.Insert(u);
            // If the data is successfully inserted then the value of success will be true else it will be false
            if (success == true)
            {
                //Data successfully inserted
                MessageBox.Show("User successfully Added.");
                Clear();
            }
            else
            {
                //Fail to insert Data
                MessageBox.Show("Fail To Add User Try Again.");
            }
            //Refresh Data grid View
            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
        }
        private void Clear()
        {
            txtUserID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            cmbGender.Text = "";
            txtAddress.Text = "";
            cmbUserType.Text = "";
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Getting Data from UI
            u.UserID = Convert.ToInt32(txtUserID.Text);
            u.FirstName = txtFirstname.Text;
            u.LastName = txtLastname.Text;
            u.Username = txtUsername.Text;
            u.Password = txtPassword.Text;
            u.Email = txtEmail.Text;
            u.Contact = Convert.ToInt32 (txtContact.Text);
            u.Gender = cmbGender.Text;
            u.Address = txtAddress.Text;
            u.UserType = cmbUserType.Text;
            u.DateTime = DateTime.Now;

            //update data into database
            bool success = dal.update(u);
            // if data is updated successfully then the valu of success is true else it will be false
            if (success == true)
            {
                //Data updated successfully
                MessageBox.Show("User successfully updated");
                Clear();

            }
            else
            {
                //Data update fail
                MessageBox.Show("Failed to Update User");
                Clear();

            }
            //refreshing Data Grid view
            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Getting User ID from form 
            u.UserID = Convert.ToInt32(txtUserID.Text);

            bool success = dal.Delete(u);
            // if Data is deleted then the value of  success will be true else the value of success will be false
            if (success == true)
            {
                // user deleted successfully
                MessageBox.Show("User Successfully Deleted");
                Clear();
            }
            else
            {
                // failed to delete user
                MessageBox.Show("Failed to Delete User");
            }
            // Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // get keywords from text box 
            string keywords = txtSearch.Text;

            //check if keywords have value or not 
            if (keywords != null)
            {
                //show user base on keyword
                DataTable dt = dal.search(keywords);
                dgvUser.DataSource = dt;

            }
            else
            {
                // show all user from database
                DataTable dt = dal.Select();
                dgvUser.DataSource = dt;
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            // show all user from database
            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
        }

        private void dgvUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of partitular Row
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUser.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstname.Text = dgvUser.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastname.Text = dgvUser.Rows[rowIndex].Cells[2].Value.ToString();
            txtUsername.Text = dgvUser.Rows[rowIndex].Cells[3].Value.ToString();
            txtPassword.Text = dgvUser.Rows[rowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dgvUser.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUser.Rows[rowIndex].Cells[6].Value.ToString();
            cmbGender.Text = dgvUser.Rows[rowIndex].Cells[7].Value.ToString();
            txtAddress.Text = dgvUser.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUserType.Text = dgvUser.Rows[rowIndex].Cells[9].Value.ToString();
            
        }
    }
}
