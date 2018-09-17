using Employee_Management_System.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System.View
{
    public partial class Management_Profile : Form
    {
        ManageRequestsBL mrb = new ManageRequestsBL();
        StaffBL sb = new StaffBL();
        
        public Management_Profile()
        {
            InitializeComponent();
        }

        private void Management_Profile_Load(object sender, EventArgs e)
        {
            lblUsername.Text = LoginForm.SetValueForText1;
            lblEmployeeID.Text = LoginForm.EmpID;
            int EmpID = Convert.ToInt32(LoginForm.EmpID);
            DataTable dt = new DataTable();
            string time = DateTime.Now.ToString("h:mm:ss tt");
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            lblDate.Text = date;
            lblTime.Text = time;
            dt = sb.ViewProfile(EmpID);

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

            DataSet ds = mrb.GetReqComboBoxItems();
            cmbReqID.ValueMember = "Req_ID";
            cmbReqID.DisplayMember = "Req_ID";
            cmbReqID.DataSource = ds.Tables[0];
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbReqID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Req = cmbReqID.SelectedValue.ToString();
            int ReqID = Convert.ToInt32(Req);
            DataTable dTable = mrb.GetReqMessage(ReqID);
            foreach (DataRow dr in dTable.Rows)
            {
                int EmpID = Convert.ToInt32(dr[3].ToString());
                DataTable dTb = mrb.GetReqByName(EmpID, ReqID);
                string abc = dTb.ToString();
                foreach (DataRow dr2 in dTb.Rows)
                {
                    string Name = dr2[0].ToString();
                    string Date = dr2[1].ToString(); 
                    lblRequestedBy.Text = "Employee ID : " + EmpID.ToString() + " Name : " + Name +"   Requested ON : " + Date;
                }
            }
        }
    }
}
