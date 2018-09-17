using Employee_Management_System.Business;
using Employee_Management_System.View;
using System;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class LoginForm : Form
    {
        StaffBL sb = new StaffBL();
        AdminPanel ap = new AdminPanel();
        StaffProfile sp = new StaffProfile();
        LoginAuth obj = new LoginAuth();
        public static string SetValueForText1 = "";
        public static int UserTypeLogin = 0;
        public static string EmpID;

        internal AuditBL Ab { get; set; } = new AuditBL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            rdoAdmin.Checked = true;
            txtUsername.Focus();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs exyz)
        {
            if (exyz.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        public void LoginFunction()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string AuditInfo = "Logged into the System";

            if (username != "" && password != "")
            {
                if (rdoAdmin.Checked == true)
                {
                    int UserType = 1;
                    int auth = obj.Admin_Auth(username, password, UserType);
                    try
                    {
                        if (auth == 1)
                        {
                            ap = new AdminPanel();
                            SetValueForText1 = txtUsername.Text;
                            UserTypeLogin = 1;
                            EmpID = sb.GetEmpID(username);
                            Ab.InsertAudit(SetValueForText1, AuditInfo);
                            ap.Show();
                            Hide();
                        }
                        else
                        {
                            switch (MessageBox.Show("Authentication Failed? try again",
                            "Login Failed",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                            {
                                case DialogResult.Yes:
                                    this.Hide();
                                    LoginForm form = new LoginForm();
                                    form.Show();
                                    break;

                                case DialogResult.No:
                                    Application.Exit();
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else if (rdoManager.Checked == true)
                {
                    int UserType = 2;
                    int auth = obj.Manager_Auth(username, password, UserType);
                    try
                    {
                        if (auth == 1)
                        {
                            Management_Profile mp = new Management_Profile();
                            SetValueForText1 = txtUsername.Text;
                            UserTypeLogin = 2;
                            EmpID = sb.GetEmpID(username);
                            Ab.InsertAudit(SetValueForText1, AuditInfo);
                            mp.Show();
                            Hide();
                        }
                        else
                        {
                            switch (MessageBox.Show("Authentication Failed? try again",
                            "Login Failed",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                            {
                                case DialogResult.Yes:
                                    this.Hide();
                                    LoginForm form = new LoginForm();
                                    form.Show();
                                    break;

                                case DialogResult.No:
                                    Application.Exit();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (rdoStaff.Checked == true)
                {
                    int UserType = 3;
                    int auth = obj.Staff_Auth(username, password, UserType);
                    try
                    {
                        if (auth == 1)
                        {
                            sp = new StaffProfile();
                            SetValueForText1 = txtUsername.Text;
                            EmpID = sb.GetEmpID(username);
                            UserTypeLogin = 3;
                            Ab.InsertAudit(SetValueForText1, AuditInfo);
                            sp.Show();
                            Hide();
                        }
                        else
                        {
                            switch (MessageBox.Show("Authentication Failed? try again",
                            "Login Failed",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                            {
                                case DialogResult.Yes:
                                    Hide();
                                    LoginForm form = new LoginForm();
                                    form.Show();
                                    break;

                                case DialogResult.No:
                                    Application.Exit();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

            else
            {
                try
                {
                    switch (MessageBox.Show("Username &/or Password cannot be Empty",
                            "Login Failed",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            Hide();
                            LoginForm form = new LoginForm();
                            form.Show();
                            break;
                        case DialogResult.No:
                            Application.Exit();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            LoginFunction();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs abc)
        {
            if (abc.KeyChar == 13)
            {
                LoginFunction();
            }
        }
    }
}