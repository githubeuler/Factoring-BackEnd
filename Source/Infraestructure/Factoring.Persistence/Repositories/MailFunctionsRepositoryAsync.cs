using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using Microsoft.Extensions.Configuration;
namespace Factoring.Persistence.Repositories
{
    public class MailFunctionsRepositoryAsync : IMailFunctionsRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        public MailFunctionsRepositoryAsync(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }

        public async Task<string> ObtenerTiempo()
        {
            string result;
            result = _configuration["TiempoEspera"].ToString();
            return await Task.FromResult(result);
        }
    }
}
