using Dapper;
using Factoring.Application.DTOs.Pais;
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
    public class PaisRepositoryAsync : IPaisRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public PaisRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IReadOnlyList<GrupoListDto>> GetListGrupo(int tipo, int? idPais)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Consulta_GrupoEconomico";
            var parameters = new DynamicParameters();
            parameters.Add("@p_nTipo", tipo);
            parameters.Add("@p_nIdPais", idPais);
            var giradorList = await connection.QueryAsync<GrupoListDto>(query, parameters, commandType: CommandType.StoredProcedure);
            return giradorList.AsList();
        }

        public async Task<IReadOnlyList<PaisResponseListDto>> GetListPais()
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Consulta_Pais";
            var List = await connection.QueryAsync<PaisResponseListDto>(query, null, commandType: CommandType.StoredProcedure);
            return List.AsList();
        }

        public async Task<IReadOnlyList<SectorListDto>> GetListSector(int tipo, int? idPais)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Consulta_Sector";
            var parameters = new DynamicParameters();
            parameters.Add("@p_nTipo", tipo);
            parameters.Add("@p_nIdPais", idPais);
            var giradorList = await connection.QueryAsync<SectorListDto>(query, parameters, commandType: CommandType.StoredProcedure);
            return giradorList.AsList();
        }
    }
}