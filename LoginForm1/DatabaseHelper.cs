using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace LoginForm1
{
    class DatabaseHelper
    {
        private const string _connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
