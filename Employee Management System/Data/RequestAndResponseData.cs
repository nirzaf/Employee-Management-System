using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System.Data
{
    class RequestAndResponseData
    {
        DataCon newCon = new DataCon();

        //Generate Request ID
        public string RequestID()
        {
            DataCon newCon = new DataCon();
            DataTable dt = new DataTable();

            if (ConnectionState.Closed == newCon.Con.State)
            {
                newCon.Con.Open();
            }

            string query = "Select max(Req_ID) From Request";
            SqlCommand cmd = new SqlCommand(query, newCon.Con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int RequestID = Convert.ToInt32(dr[0].ToString());
                if (RequestID == 0)
                {
                    RequestID = 1;
                    return RequestID.ToString();
                }
                else
                {
                    RequestID++;
                    return RequestID.ToString();
                }
            }
            else
            {
                string message = "Something Went wrong";
                return message;
            }
        }

        //Send Request data to the database
        public int SendRequest(string Message, string DateTime, int Req_By)
        {
            int result = 0;
            int Status = 1;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Request Values ('" + Message + "','" + DateTime + "','" + Req_By + "', '" + Status + "' )", newCon.Con);
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                result = 1;
                newCon.Con.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        //Get Request message from the database to Management to make reponse
        public DataTable GetReqMessage(int ReqID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From Request Where Req_ID = '" + ReqID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Load combo box with new requests
        public DataSet GetReqComboBoxItems()
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }

                int Status = 1;
                string query = "Select Req_ID From Request Where Status = '" + Status + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetReqBy(int ReqID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select Requested_By From Request Where Req_ID = '" + ReqID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
         //Get Request Info Such as Name , Requested Date and Time 
        public DataTable GetReqByName(int EmpID, int ReqID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = @"SELECT Staff.First_Name, Request.Date FROM Staff INNER JOIN
                         Request ON Staff.Emp_ID = Request.Requested_By Where Staff.Emp_ID = '" + EmpID + "' and Request.Requested_By = '" + EmpID + "' and Request.Req_ID = '" + ReqID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Get Request Info Such as Requested Date and Time 
        public DataTable GetRequestInfo(int ReqID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select First_Name From Staff Where Emp_ID = '" +ReqID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
