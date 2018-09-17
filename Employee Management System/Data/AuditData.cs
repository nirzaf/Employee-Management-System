using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Data
{
    class AuditData
    {
        DataCon newCon = new DataCon();
        public void InsertAudit(string AuditBy, string AuditInfo)
        {
            string date = DateTime.Today.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Audit_Trail (Audit_by,Audit_Date,Audit_Time,Audit_Info) VALUES ('" + AuditBy + "','" + date + "','" + time + "','" + AuditInfo + "' )", newCon.Con);
                cmd.ExecuteNonQuery();
                newCon.Con.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
