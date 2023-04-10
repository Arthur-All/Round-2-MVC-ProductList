using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Model.Models.Context
{
    public static class DapperConnection
    {
        public static IDbConnection AddConnection(this IDbConnection connection, IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DBProductConnection"));

            return connection;
        }
    }
}
