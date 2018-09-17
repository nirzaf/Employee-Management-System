using Employee_Management_System.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace Employee_Management_System.View
{


    public partial class StaffProfile : Form
    {
        StaffBL sb = new StaffBL();
        ManageRequestsBL mrb =new  ManageRequestsBL();

        public StaffProfile()
        {
            InitializeComponent();
        }

        private void StaffProfile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbEMSDataSet.Request' table. You can move, or remove it, as needed.
            lblLoggedInAs.Text = LoginForm.SetValueForText1;
            lblEmployeeID.Text = LoginForm.EmpID; 
            int EmpID = Convert.ToInt32(LoginForm.EmpID);
            DataTable dt = new DataTable();
            string time = DateTime.Now.ToString("h:mm:ss tt");
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            lblDate.Text = date;
            lblTime.Text = time;
            dt = sb.ViewProfile(EmpID);
            lblRequestID.Text = mrb.RequestID();

            foreach (DataRow dr in dt.Rows)
            {
                txtFirstName.Text = dr[1].ToString();
                txtSurname.Text = dr[2].ToString();
                txtContact.Text = dr[3].ToString();
                txtEmail.Text = dr[4].ToString();
                txtHouseNo.Text = dr[5].ToString();
                txtStreetName.Text = dr[6].ToString();
                txtCity.Text = dr[7].ToString();
                txtPostCode.Text = dr[8].ToString();
                txtDesignation.Text = dr[9].ToString();
                txtDepartment.Text = dr[10].ToString();
                txtJobTitle.Text = dr[11].ToString();
                if (Convert.ToInt32(dr[12].ToString()) == 1)
                {
                    lblGender.Text = "Male";
                }
                else
                {
                    lblGender.Text = "Female";
                }
                if (Convert.ToInt32(dr[13].ToString()) == 1)
                {
                    lblStatus.Text = "Active";
                }
                else
                {
                    lblStatus.Text = "Inactive";
                }
            }

            DataSet ds = sb.GetReqComboBoxItems(EmpID);
            cmbReqID.ValueMember = "Req_ID";
            cmbReqID.DisplayMember = "Req_ID";
            cmbReqID.DataSource = ds.Tables[0];

        }

        public void FormLoad()
        {
            lblRequestID.Text = sb.RequestID();
        }

        public void Refersh()
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

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image";
            imageColumn.DataPropertyName = "Image";
            imageColumn.HeaderText = "Image";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvEmp.Columns.Insert(5, imageColumn);
            dgvEmp.RowTemplate.Height = 100;
            dgvEmp.Columns[5].Width = 100;

        }
        private void TextMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tabRequestManagement_Click(object sender, EventArgs e)
        {

        }

        private void pBoxSend_Click(object sender, EventArgs e)
        {
            int ReqID = Convert.ToInt32(lblRequestID.Text);
            string Message = TextMessage.Text;
            string DateTime = lblDate.Text + " " + lblTime.Text;
            int Req_by = Convert.ToInt32(lblEmployeeID.Text);
            int result = mrb.SendRequest(Message,DateTime,Req_by);
            if (result == 1)
            {
                MessageBox.Show("Message Sent Successfully");
            }
            else
            {
                MessageBox.Show("Something Went Wrong Please try again");
            }
        }

        private void cmbReqID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Req = cmbReqID.SelectedValue.ToString();
            int ReqID = Convert.ToInt32(Req);
            DataTable dTable = mrb.GetReqMessage(ReqID);
            foreach (DataRow dr in dTable.Rows)
            {
                rTextBoxRequest.Text = dr[1].ToString();
            }
        }

        private void cmbReqID_Enter(object sender, EventArgs e)
        {
            string Req = cmbReqID.SelectedValue.ToString();
            int ReqID = Convert.ToInt32(Req);
            DataTable dTable = mrb.GetReqMessage(ReqID);
            foreach (DataRow dr in dTable.Rows)
            {
                rTextBoxRequest.Text = dr[1].ToString();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
