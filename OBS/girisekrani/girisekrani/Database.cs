using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace girisekrani
{
    class Database
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
