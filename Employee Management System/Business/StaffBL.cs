using Employee_Management_System.Data;
using System;
using System.Data;

namespace Employee_Management_System.Business
{
    class StaffBL
    {
        StaffData sd = new StaffData();
        DataTable dt = new DataTable();
        RequestAndResponseData rrd = new RequestAndResponseData();
        LoginData ld = new LoginData();

        //Generate Next Employee Number 
        public string EmpNo()
        {
            try
            {
                String Emp_ID = sd.EmpNo();
                return Emp_ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Adding Staff details
        public int AddStaff(int EmpID, string FirstName, string Surname, string Contact, string Email, string No, string Line1, string Line2, int PostCode, string Designation, string Department, string JobTitle, int Gender, int JobStatus, Byte[] ImageByteArray)
        {
            int result = 0;
            try
            {
                result = sd.AddStaff(EmpID,FirstName,Surname,Contact,Email,No,Line1,Line2,PostCode,Designation,Department,JobTitle,Gender,JobStatus, ImageByteArray);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //Retrieve all staff details
        public DataTable ViewAllEmployees()
        {
            try
            {
                dt = sd.ViewAllEmployees();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Generate Request ID
        public string RequestID()
        {
            try
            {
                String RequestID = rrd.RequestID();
                return RequestID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Employee ID for current username
        public string GetEmpID(string username)
        {
            string EmpID = "";
            try
            {
                EmpID = ld.getEmpID(username);
                return EmpID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Profile Data of a Staff
        public DataTable ViewProfile(int EmpID)
        {
            try
            {
                dt.Clear();
                dt = sd.ViewProfile(EmpID);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Load Combo box with Request ID's for only selected Employee
        public DataSet GetReqComboBoxItems(int EmpID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = sd.GetReqComboBoxItems(EmpID);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
