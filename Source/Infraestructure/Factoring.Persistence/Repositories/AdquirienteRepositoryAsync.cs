using Dapper;
using Factoring.Application.DTOs.Adquiriente;
//using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
//using Factoring.Infraestructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class AdquirienteRepositoryAsync : IAdquirienteRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public AdquirienteRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyList<AdquirienteResponseLista>> GetListaAdquiriente()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Adquiriente_Combo";

                var adList = await connection.QueryAsync<AdquirienteResponseLista>(query, null, commandType: CommandType.StoredProcedure);
                return adList.AsList();
            }
        }
    }
}