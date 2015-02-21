using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace portfolio.App_Code
{
    static class ConnectionClass
    {
        private static SqlCeConnection conn;
        private static SqlCommand command;
        public void connect()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BlogPosts"].ToString();
            conn = new SqlCeConnection(connectionString);
            command = new SqlCommand("",conn);
        }
    }
}
