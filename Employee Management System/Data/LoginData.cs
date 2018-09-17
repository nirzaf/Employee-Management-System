using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Data
{
    class LoginData
    {
        DataCon newCon = new DataCon();
        
        public int AdminLogin(string username, string password, int UserType)
        {
            int value = 0;
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand check_auth = new SqlCommand("SELECT * FROM Users WHERE Username = '" + username + "' and Password = '" + password + "' and User_Type = '"+ UserType +"'", newCon.Con);
                SqlDataReader reader = check_auth.ExecuteReader();
                if (reader.HasRows)
                {
                    value = 1;
                    return value;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                throw;
            }
        }

        public int ManagerLogin(string username, string password, int UserType)
        {
            int value = 0;
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand check_auth = new SqlCommand("SELECT * FROM Users WHERE Username = '" + username + "' and Password = '" + password + "' and User_Type = '" + UserType + "'", newCon.Con);
                SqlDataReader reader = check_auth.ExecuteReader();
                if (reader.HasRows)
                {
                    value = 1;
                    return value;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                throw;
            }
        }

        public int StaffLogin(string username, string password, int UserType)
        {
            int value = 0;
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand check_auth = new SqlCommand("SELECT * FROM Users WHERE Username = '" + username + "' and Password = '" + password + "' and User_Type = '" + UserType + "'", newCon.Con);
                SqlDataReader reader = check_auth.ExecuteReader();
                if (reader.HasRows)
                {
                    value = 1;
                    return value;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                throw;
            }           
        }

        public string getEmpID(string username)
        {
            try
            {
                string EmpID = "";
                string query = "Select Emp_ID From Users Where username = '"+username+"'";
                SqlCommand cmd = new SqlCommand(query, newCon.Con);
                SqlDataReader dr;
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    try
                    {
                        EmpID = dr[0].ToString();
                        return EmpID;
                    }
                    catch (Exception)
                    {
                        throw;
                    }                  
                }
                return EmpID;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
