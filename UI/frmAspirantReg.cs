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

namespace Electoric_Voting_System
{
    public partial class frmAspirantReg : Form
    {
        public frmAspirantReg()
        {
            InitializeComponent();
        }
        aspirantRegBLL asp = new aspirantRegBLL();
        aspirantRegDAL dal = new aspirantRegDAL();
        postDAL pdal = new postDAL();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
        
        private void btnSave_Click(object sender, EventArgs e)
        {
             //Here Code to Save image to DataBase
            ImageConverter imgg = new ImageConverter();
            byte[] img=(byte[]) imgg.ConvertTo(pcAspirant.Image, Type.GetType( "System.Byte[]"));
            if (pcAspirant.Image != null)
            {
                //Getting Data from UI
                //asp.AspirantID = Convert.ToInt32(txtAspirantID.Text);
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

                // Inserting in to database
                bool success = dal.Insert(asp);
                // If the data is successfully inserted then the value of success will be true else it will be false
                if (success == true)
                {
                    //Data successfully inserted
                    MessageBox.Show("Aspirant successfully Added.");
                    Clear();
                }
                else
                {
                    //Fail to insert Data
                    MessageBox.Show("Fail To Add Aspirant Try Again.");
                }
            }
            else
            {
                //Failed to Upload picture
                MessageBox.Show("Picture Box is NULL");
            }
        }
        private void Clear ()
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

        private void btnClear_Click(object sender, EventArgs e)
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

        private void frmAspirantReg_Load(object sender, EventArgs e)
        {
            //Create a DataTable to Hold data from database
            DataTable Post = pdal.Select();
            //Specify Datasource for category comboBox
            cmbPost.DataSource = Post;
            //Specify Display member and Value member for ComboBox
            cmbPost.DisplayMember = "PostName";
            cmbPost.ValueMember = "PostName";
        }
    }
}
