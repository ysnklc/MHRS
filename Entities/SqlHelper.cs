using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class SqlHelper
    {
        private const string ConnectionString = "server=213.14.92.74;database=alfa_w2_adonet_orange_db;uid=alfa_w2_adonet_orange_user;pwd=CL2njdhv";

        public static SqlCommand CreateSqlCommand()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            return command;



        }
    }
}
