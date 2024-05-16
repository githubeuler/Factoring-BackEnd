using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Factoring.Persistence.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection()
                {
                    ConnectionString = _configuration.GetConnectionString("ConnectionBase")
                };
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
