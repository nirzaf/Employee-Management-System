using Employee_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Business
{
    class AuditBL
    {
        AuditData ad = new AuditData();
        public void InsertAudit(string AuditBy, string AuditInfo)
        {
            try
            {
                ad.InsertAudit(AuditBy, AuditInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
