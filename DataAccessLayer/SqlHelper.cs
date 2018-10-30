using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static class SqlHelper
    {
        private const string ConnectionString = "server=.;database=mhrs;trusted_connection=true";

        public static SqlCommand CreateSqlCommand() {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            return command;  
        
        
        
        }
    }
}
