using Dapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class FondeadorRepositoryAsync : IFondeadorRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public FondeadorRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IReadOnlyList<FondeadorGetAllDto>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultaFondeadores";
                var fondeador = await connection.QueryAsync<FondeadorGetAllDto>(query, param: null, commandType: CommandType.StoredProcedure);
                return fondeador.AsList();
            }
        }

    }
}
