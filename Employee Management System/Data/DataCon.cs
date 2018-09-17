using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Data
{
    class DataCon
    {
        public SqlConnection Con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DbEMS;Integrated Security=True; MultipleActiveResultSets=True;");
    }
}
