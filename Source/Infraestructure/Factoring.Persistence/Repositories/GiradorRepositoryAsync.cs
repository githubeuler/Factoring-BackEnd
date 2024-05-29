using Dapper;
using Factoring.Application.DTOs.Girador;
//using Factoring.Application.DTOs.Girador;
//using Factoring.Application.DTOs.Girador.Confirming;
//using Factoring.Application.Features.Girador.Queries.GetGiradorDocumentosFileName;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
/*using Factoring.Infraestructure.Persistence.Data*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class GiradorRepositoryAsync : IGiradorRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public GiradorRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyList<GiradorResponseList>> GetListaGirador()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Girador_Combo";
                var giradorList = await connection.QueryAsync<GiradorResponseList>(query, null, commandType: CommandType.StoredProcedure);
                return giradorList.AsList();
            }
        }

    }
}
