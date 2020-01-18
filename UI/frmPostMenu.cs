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
    public partial class frmPostMenu : Form
    {
        public frmPostMenu()
        {
            InitializeComponent();
        }
        postBLL p = new postBLL();
        postDAL dal = new postDAL();
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Getting User ID from form 
            p.PostID = Convert.ToInt32(txtPostID.Text);

            bool success = dal.Delete(p);
            // if Data is deleted then the value of  success will be true else the value of success will be false
            if (success == true)
            {
                // user deleted successfully
                MessageBox.Show("Post Successfully Deleted");
                Clear();
            }
            else
            {
                // failed to delete user
                MessageBox.Show("Failed to Delete Post");
            }
            // Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvPost.DataSource = dt;
        }

        private void frmPostMenu_Load(object sender, EventArgs e)
        {
            // Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvPost.DataSource = dt;
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Getting Data from UI
            p.PostName = txtPostName.Text;
            p.DateTime = DateTime.Now;

            // Inserting in to database
            bool success = dal.Insert(p);
            // If the data is successfully inserted then the value of success will be true else it will be false
            if (success == true)
            {
                //Data successfully inserted
                MessageBox.Show("Post successfully Added.");
                Clear();
            }
            else
            {
                //Fail to insert Data
                MessageBox.Show("Fail To Add Post Try Again.");
            }
            DataTable dt = dal.Select();
            dgvPost.DataSource = dt;
        }
        private void Clear()
        {
            txtPostName.Text = "";
            txtPostID.Text = "";
        }

        private void dgvPost_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of partitular Row
            int rowIndex = e.RowIndex;
            txtPostID.Text = dgvPost.Rows[rowIndex].Cells[0].Value.ToString();
            txtPostName.Text = dgvPost.Rows[rowIndex].Cells[1].Value.ToString();
        }
    }
}
