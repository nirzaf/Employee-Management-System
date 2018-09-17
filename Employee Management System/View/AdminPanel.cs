using Employee_Management_System.Business;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Employee_Management_System.View
{
    public partial class AdminPanel : Form
    {
        StaffBL sb = new StaffBL();
        ManageRequestsBL mrb = new ManageRequestsBL();
        public string FilePath = "";
        public static int JobStatus=1;
        //private Byte[] ImageByteArray;
        private byte[] data;

        public int EmpID { get; private set; }
        public static int SelectedEmpID;

        public AdminPanel()
        {
            InitializeComponent();
        }

        //Function to Load Employee ID Combo Box
        public void LoadCmbEmployeeID()
        {
            DataSet ds = mrb.loadComboBoxByEmpID();
            cmbEmployeeID.ValueMember = "Emp_ID";
            cmbEmployeeID.DisplayMember = "Emp_ID";
            cmbEmployeeID.DataSource = ds.Tables[0];
            Refersh();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            lbllUsername.Text = LoginForm.SetValueForText1;
            int EmpID = Convert.ToInt32(sb.EmpNo());
            //SelectedEmpID = Convert.ToInt32(cmbEmployeeID.SelectedValue.ToString());
            EmpID++;
            lblEmployeeID.Text = EmpID.ToString();
            rdoMale.Checked = true;
            rdoAdmin.Checked = true;
            LoadCmbEmployeeID();
        }

        public void AddStaff()
        {
            int EmpID = Convert.ToInt32(lblEmployeeID.Text);
            string FirstName = txtFirstName.Text;
            string Surname = txtSurname.Text;
            string Contact = txtContact.Text;
            string Email = txtEmail.Text;
            string No = txtHouseNo.Text;
            string Street = txtStreetName.Text;
            string City = txtCity.Text;
            int PostCode = Convert.ToInt32(txtPostCode.Text);
            string Designation = txtDesignation.Text;
            string Department = txtDepartment.Text;
            string JobTitle = txtJobTitle.Text;
            int Gender;
            if (rdoMale.Checked == true)
            {
                Gender = 1;
            }
            else
            {
                Gender = 2;
            }

            if (rdoAdmin.Checked == true)
            {
                JobStatus = 1;
            }
            else if (rdoManager.Checked == true)
            {
                JobStatus = 2;
            }
            else if (rdoStaff.Checked == true)
            {
                JobStatus = 3;
            }

            if (FilePath == "")
            {
                try
                {
                    if (data.Length != 0)
                    {
                        data = new byte[] { };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                //Image temp = new Bitmap(FilePath);
                //MemoryStream stream = new MemoryStream();
                //temp.Save(stream, ImageFormat.Jpeg);
                //ImageByteArray = stream.ToArray();

                Image myImage = Image.FromFile(FilePath);
                //byte[] data;
                using (MemoryStream ms = new MemoryStream())
                {
                    myImage.Save(ms, ImageFormat.Bmp);
                    data = ms.ToArray();
                }

            }

            int result = sb.AddStaff(EmpID, FirstName, Surname, Contact, Email, No, Street, City, PostCode, Designation, Department, JobTitle, Gender, JobStatus, data);

            if (result == 1)
            {
                MessageBox.Show("Successsfully Added");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void picAddEmployee_Click(object sender, EventArgs e)
        {
            AddStaff();
            LoadCmbEmployeeID();
            Refersh();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpj,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;
                pBoxProfile.Image = new Bitmap(FilePath);

            }
        }

        private void Refersh()
        {
            dgvEmp.DataSource = sb.ViewAllEmployees();
            dgvEmp.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmp.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmp.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmp.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmp.Columns[5].Visible = false;
            dgvEmp.Columns[6].Visible = false;
            dgvEmp.Columns[7].Visible = false;
            dgvEmp.Columns[8].Visible = false;
            dgvEmp.Columns[9].Visible = false;
            dgvEmp.Columns[10].Visible = false;
            dgvEmp.Columns[11].Visible = false;
            dgvEmp.Columns[12].Visible = false;
            dgvEmp.Columns[13].Visible = false;
            dgvEmp.Columns[14].Visible = false;

            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn.Name = "Image";
            //imageColumn.DataPropertyName = "Image";
            //imageColumn.HeaderText = "Image";
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dgvEmp.Columns.Insert(5, imageColumn);
            //dgvEmp.RowTemplate.Height = 100;
            //dgvEmp.Columns[5].Width = 100;

        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LabelEmployeeID.Text = dgvEmp.CurrentRow.Cells[0].Value.ToString();
            TextFirstName.Text = dgvEmp.CurrentRow.Cells[1].Value.ToString();
            TextSurname.Text = dgvEmp.CurrentRow.Cells[2].Value.ToString();
            TextContact.Text = dgvEmp.CurrentRow.Cells[3].Value.ToString();
            TextEmail.Text = dgvEmp.CurrentRow.Cells[4].Value.ToString();
            TextHouseNo.Text = dgvEmp.CurrentRow.Cells[5].Value.ToString();
            TextStreetName.Text = dgvEmp.CurrentRow.Cells[6].Value.ToString();
            TextCity.Text = dgvEmp.CurrentRow.Cells[7].Value.ToString();
            TextPostCode.Text = dgvEmp.CurrentRow.Cells[8].Value.ToString();
            TextDesignation.Text = dgvEmp.CurrentRow.Cells[9].Value.ToString();
            TextDepartment.Text = dgvEmp.CurrentRow.Cells[10].Value.ToString();
            TextJobTitle.Text = dgvEmp.CurrentRow.Cells[11].Value.ToString();
            if (dgvEmp.CurrentRow.Cells[12].Value.ToString() == "1")
            {
                RadioMale.Checked = true;
            }
            else
            {
                RadioFemale.Checked = true;
            }
            if (dgvEmp.CurrentRow.Cells[13].Value.ToString() == "1")
            {
                RadioActive.Checked = true;
            }
            else
            {
                RadioInactive.Checked = true;
            }

            //Byte[] ImageArray = (Byte[])dgvEmp.CurrentRow.Cells[14].Value;

            //Image myImage;

            //if (ImageArray.Length == 0)
            //{
            //    MessageBox.Show("No Image Added");
            //}
            //else
            //{
            //    //byte[] data = (byte[])(Byte[])dgvEmp.CurrentRow.Cells[14].Value;
            //    //using (MemoryStream stream = new MemoryStream(data))
            //    //{
            //    //    myImage = new Bitmap(stream);
            //    //    PicBoxProfile.Image = myImage;
            //    //}
            //    ////Byte[] img = (Byte[])dgvEmp.CurrentRow.Cells[14].Value;

            //    //MemoryStream ms = new MemoryStream(img);

            //    //PicBoxProfile.Image = Image.FromStream(ms);
            //}
            tabUpdate.Show();
            tabUpdate.Focus();
        }

        private void dgvEmp_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            tabUpdate.Show();
            tabUpdate.Focus();
        }

        private void dgvEmp_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabUpdate.Show();
            tabUpdate.Focus();
        }

        private void tabManageEmployee_Selected(object sender, TabControlEventArgs e)
        {
            //Refersh();
        }

        private void manageUsers_Click(object sender, EventArgs e)
        {

        }

        private void createUser_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string Emp_ID = cmbEmployeeID.SelectedValue.ToString();
            SelectedEmpID = Convert.ToInt32(Emp_ID);
            DataTable dTable = mrb.getEmployeeNameByID(SelectedEmpID);
            foreach (DataRow dr in dTable.Rows)
            {
                lblEmployeeName.Text = dr[0].ToString();
            }

            int UserExist = mrb.IsUserAvailable(SelectedEmpID);
            if (UserExist == 1)
            {
                lblMessage.Text = "**Warning : Already User Account Exist Associate with this Employee ID";
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        public void CreateUserAccount()
        {
            DataTable dt = mrb.GetUserStatusByID(SelectedEmpID);
            int UserStatus;
            foreach (DataRow dr in dt.Rows)
            {
                UserStatus = Convert.ToInt32(dr[0].ToString());
                string Username = txtUsername.Text;
                string Password = txtPassword.Text;

                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    int result = mrb.CreateNewUser(Username, Password, UserStatus, SelectedEmpID);
                    if (result == 1)
                    {
                        MessageBox.Show("Successfully Account Created");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong");
                    }
                }
                else
                {
                    MessageBox.Show("Both Password Fields Should be Same");
                    txtConfirmPassword.Focus();
                }
            }
            

        }
        
        private void pBoxCreateAccount_Click(object sender, EventArgs e)
        {
            CreateUserAccount();
            LoadCmbEmployeeID();
        }
    }
}
