using Employee_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Business
{
    class ManageRequestsBL
    {
        RequestAndResponseData rard = new RequestAndResponseData();
        StaffData sd = new StaffData();

        internal StaffData Sd { get => sd; set => sd = value; }

        //Send Request Data to Database Request Table
        public int SendRequest(string Message, string DateTime, int Req_By)
        {
            int result = 0;
            try
            {
                result = rard.SendRequest(Message, DateTime, Req_By);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Generate Request ID
        public string RequestID()
        {
            string Req_ID = "";
            try
            {
                Req_ID = rard.RequestID();
                return Req_ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Request Message while Parsing the Req ID
        public DataTable GetReqMessage(int ReqID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = rard.GetReqMessage(ReqID);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Load Combo Box with new Requests
        public DataSet GetReqComboBoxItems()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = rard.GetReqComboBoxItems();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Requested Employee ID by Parsing the Req ID 
        public DataSet GetReqBy(int ReqID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = rard.GetReqBy(ReqID);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Requested Employee Name by Parsing the Req ID and Employee ID 
        public DataTable GetReqByName(int EmpID , int ReqID)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = rard.GetReqByName(EmpID, ReqID);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Load all employee ID in Combo box to create new users 
        public DataSet loadComboBoxByEmpID()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Sd.loadComboBoxByEmpID();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to get Employee Name by Employee ID
        public DataTable getEmployeeNameByID(int EmpID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Sd.getEmployeeNameByID(EmpID);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Check User Existing for Particular Employee or Not?
        public int IsUserAvailable(int EmpID)
        {
            int value = 0;
            try
            {
                value = Sd.IsUserAvailable(EmpID);
                return value;
            }
            catch
            {
                throw;
            }
        }

        //Get User Status by Parsing Employee ID 
        public DataTable GetUserStatusByID(int EmpID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Sd.GetUserStatusByID(EmpID);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Create new user account with username and password 
        public int CreateNewUser(string Username, string Password, int UserType, int EmpID)
        {
            int result = 0;
            try
            {
                result = Sd.CreateNewUser(Username, Password, UserType, EmpID);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
