using System;
using System.Data;
using System.Data.SqlClient;

namespace Employee_Management_System.Data
{
    class StaffData
    {
        DataCon newCon = new DataCon();
        readonly DataTable dt = new DataTable();


        //Function to Generate new Employee ID
        public string EmpNo()
        {
            if (ConnectionState.Closed == newCon.Con.State)
            {
                newCon.Con.Open();
            }

            string query = "Select max(Emp_ID) From Staff";
            SqlCommand cmd = new SqlCommand(query, newCon.Con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string invoice = dr[0].ToString();
                if (invoice == "")
                {
                    invoice = "1";
                    return invoice;
                }
                else
                {
                    return invoice;
                }
            }
            else
            {
                string message = "Something Went wrong";
                return message;
            }
        }


        //Function to Add New Staff Details
        public int AddStaff(int EmpID, string FirstName, string Surname, string Contact, string Email, string No, string Line1, string Line2, int PostCode, string Designation, string Department, string JobTitle, int Gender, int JobStatus, Byte[] ImageByteArray)
        {
            try
            {
                int result = 0;
                try
                {
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                        SqlCommand Check_Employee = new SqlCommand("SELECT * FROM Staff WHERE Emp_ID = '" + EmpID + "'", newCon.Con);
                        SqlDataReader reader = Check_Employee.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                return result;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        else
                        {
                            try
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Staff (Emp_ID,First_Name,Surname,Contact,Email,No,Line1,Line2,Post_Code,Designation,Department,Job_Title,Gender,Job_Status,Image) VALUES ('" + EmpID + "','" + FirstName + "','" + Surname + "','" + Contact + "','" + Email + "','" + No + "','" + Line1 + "','" + Line2 + "','" + PostCode + "','" + Designation + "','" + Department + "','" + JobTitle + "','" + Gender + "','" + JobStatus + "','" + ImageByteArray + "')", newCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                newCon.Con.Close();
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                newCon.Con.Close();
                                return result;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlCommand Check_Employee = new SqlCommand("SELECT * FROM Staff WHERE Emp_ID = '" + EmpID + "'", newCon.Con);
                            SqlDataReader reader = Check_Employee.ExecuteReader();

                            if (reader.HasRows)
                            {
                                try
                                {
                                    reader.Close();
                                    return result;
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                try
                                {
                                    SqlCommand cmd = new SqlCommand("INSERT INTO Staff (Emp_ID,First_Name,Surname,Contact,Email,No,Line1,Line2,Post_Code,Designation,Department,Job_Title,Gender,Job_Status,Image) VALUES ('" + EmpID + "','" + FirstName + "','" + Surname + "','" + Contact + "','" + Email + "','" + No + "','" + Line1 + "','" + Line2 + "','" + PostCode + "','" + Designation + "','" + Department + "','" + JobTitle + "','" + Gender + "','" + JobStatus + "','" + ImageByteArray + "')", newCon.Con);
                                    cmd.ExecuteNonQuery();
                                    result = 1;
                                    reader.Close();
                                    newCon.Con.Close();
                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    reader.Close();
                                    newCon.Con.Close();
                                    return result;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            newCon.Con.Close();
                            throw;
                        }

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Load All Employees 
        public DataTable ViewAllEmployees()
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From Staff";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to View all Profile Data for Selected Employee ID
        public DataTable ViewProfile(int EmpID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From Staff Where Emp_ID = '" + EmpID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                sda.Fill(dt);
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }

                string query = "Select Req_ID From Request Where Requested_By = '" + EmpID + "'";
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

        //Load all employee ID in Combo box to create new users 
        public DataSet loadComboBoxByEmpID()
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "SELECT Emp_ID FROM Staff ";
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


        //Function to get Employee Name by Employee ID
        public DataTable getEmployeeNameByID(int EmpID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "SELECT CONCAT(Staff.First_Name,' ', Staff.Surname) AS 'FullName' FROM Staff Where Emp_ID = '" + EmpID + "'";
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

        //Check User Existing for Particular Employee or Not?
        public int IsUserAvailable(int EmpID)
        {
            int value = 0;
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand check_User = new SqlCommand("SELECT * FROM Users WHERE Emp_ID = '" + EmpID + "'", newCon.Con);
                SqlDataReader reader = check_User.ExecuteReader();
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

        //Create new user account with username and password 
        public int CreateNewUser(string Username, string Password, int UserType, int EmpID)
        {
            int result = 0;
            try
            {
                try
                {
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                    }
                    string query = "INSERT INTO Users (Username,Password,User_Type,Emp_ID) Values ('" + Username + "','" + Password + "','" + UserType + "','" + EmpID + "')";
                    SqlCommand cmd = new SqlCommand(query, newCon.Con);
                    cmd.ExecuteNonQuery();
                    result = 1;
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get User Status by Parsing Employee ID 
        public DataTable GetUserStatusByID(int EmpID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "SELECT Job_Status FROM Staff Where Emp_ID = '" + EmpID + "'";
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

    }
}
