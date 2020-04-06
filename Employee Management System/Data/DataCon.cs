using System.Data.SqlClient;

namespace Employee_Management_System.Data
{
    class DataCon
    {
        public SqlConnection Con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DbEMS;Integrated Security=True; MultipleActiveResultSets=True;");
    }
}
