using Electoric_Voting_System.BLL;
using Electoric_Voting_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electoric_Voting_System.UI
{
    public partial class frmAspirantRecord : Form
    {
        public frmAspirantRecord()
        {
            InitializeComponent();
        }
        aspirantRegDAL dal = new aspirantRegDAL();
        aspirantRegBLL asp = new aspirantRegBLL();
        postDAL pdal = new postDAL();
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAspirantRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of partitular Row
            int rowIndex = e.RowIndex;
            txtAspirantID.Text = dgvAspirantRecord.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvAspirantRecord.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvAspirantRecord.Rows[rowIndex].Cells[2].Value.ToString();
            txtNickName.Text = dgvAspirantRecord.Rows[rowIndex].Cells[3].Value.ToString();
            txtAddmission.Text = dgvAspirantRecord.Rows[rowIndex].Cells[4].Value.ToString();
            cmbDepartment.Text = dgvAspirantRecord.Rows[rowIndex].Cells[5]. Value.ToString();
            cmbPost.Text = dgvAspirantRecord.Rows[rowIndex].Cells[6].Value.ToString();
            cmbReligion.Text = dgvAspirantRecord.Rows[rowIndex].Cells[7].Value.ToString();
            cmbLevel.Text = dgvAspirantRecord.Rows[rowIndex].Cells[8].Value.ToString();
            cmbSex.Text = dgvAspirantRecord.Rows[rowIndex].Cells[10].Value.ToString();
            txtPhone.Text = dgvAspirantRecord.Rows[rowIndex].Cells[11].Value.ToString();

            // How to load Image from Data grid View to PictureBox 
            byte[] img = (byte[])dgvAspirantRecord.Rows[rowIndex].Cells[9].Value;
            MemoryStream ms = new MemoryStream(img);
            pcAspirant.Image = Image.FromStream(ms);

        }

        private void frmAspirantRecord_Load(object sender, EventArgs e)
        {
            //Create a DataTable to Hold data from database
            DataTable Post = pdal.Select();
            //Specify Datasource for category comboBox
            cmbPost.DataSource = Post;
            //Specify Display member and Value member for ComboBox
            cmbPost.DisplayMember = "PostName";
            cmbPost.ValueMember = "PostName";

            //refreshing Data Grid view
            DataTable dt = dal.Select();
            dgvAspirantRecord.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ImageConverter imgg = new ImageConverter();
            byte[] img = (byte[])imgg.ConvertTo(pcAspirant.Image, Type.GetType("System.Byte[]"));

            //Getting Data from UI
            asp.AspirantID = Convert.ToInt32(txtAspirantID.Text);
            asp.FirstName = txtFirstName.Text;
            asp.LastName = txtLastName.Text;
            asp.NickName = txtNickName.Text;
            asp.AdmissionNo = Convert.ToInt32(txtAddmission.Text);
            asp.Department = cmbDepartment.Text;
            asp.Post = cmbPost.Text;
            asp.Religion = cmbReligion.Text;
            asp.CurrentLevel = cmbLevel.Text;
            asp.ImageUrl = img;
            asp.Sex = cmbSex.Text;
            asp.Phone = Convert.ToInt32(txtAddmission.Text);
            asp.DateTime = DateTime.Now;

            //update data into database
            bool success = dal.update(asp);
            // if data is updated successfully then the valu of success is true else it will be false
            if (success == true)
            {
                //Data updated successfully
                MessageBox.Show("Aspirant successfully updated");
                Clear();

            }
            else
            {
                //Data update fail
                MessageBox.Show("Failed to Update Aspirant");
                Clear();

            }
            //refreshing Data Grid view
            DataTable dt = dal.Select();
            dgvAspirantRecord.DataSource = dt;
        }
        private void Clear()
        {
            txtAspirantID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNickName.Text = "";
            txtAddmission.Text = "";
            cmbDepartment.Text = "";
            cmbPost.Text = "";
            cmbReligion.Text = "";
            cmbLevel.Text = "";
            pcAspirant.Image = null;
            cmbSex.Text = "";
            txtPhone.Text = "";
            txtPicpath.Text = "";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog evs = new OpenFileDialog();

            evs.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (evs.ShowDialog() == DialogResult.OK)
            {
                string picpath = evs.FileName.ToString();
                txtPicpath.Text = picpath;
                pcAspirant.ImageLocation = picpath;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Getting User ID from form 
            asp.AspirantID = Convert.ToInt32(txtAspirantID.Text);

            bool success = dal.Delete(asp);
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
            dgvAspirantRecord.DataSource = dt;
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
                dgvAspirantRecord.DataSource = dt;

            }
            else
            {
                // show all user from database
                DataTable dt = dal.Select();
                dgvAspirantRecord.DataSource = dt;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // show all user from database
            DataTable dt = dal.Select();
            dgvAspirantRecord.DataSource = dt;
        }
    }
}
