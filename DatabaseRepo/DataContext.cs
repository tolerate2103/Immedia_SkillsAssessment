using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepo
{
    public class DataContext
    {
        public string ConnectionString { get; set; }
        public DataContext()
        {
            ConnectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;database=ImmediaDb;integrated security=yes";
        }

        public void OpenConnection()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Close();
            }
        }
    }
}
