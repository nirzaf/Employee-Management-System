using Employee_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Business
{
    class LoginAuth
    {
        LoginData obj = new LoginData();

        public int Admin_Auth(string username, string password ,int UserType)
        {
            try
            {
                int value = obj.AdminLogin(username, password, UserType);
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Manager_Auth(string username, string password, int UserType)
        {
            try
            {
                int value = obj.ManagerLogin(username, password, UserType);
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Staff_Auth(string username, string password, int UserType)
        {
            try
            {
                int value = obj.StaffLogin(username, password, UserType);
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
