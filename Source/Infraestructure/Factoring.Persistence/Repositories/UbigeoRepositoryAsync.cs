using Dapper;
using Factoring.Application.DTOs.Ubigeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class UbigeoRepositoryAsync : IUbigeoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public UbigeoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyList<UbigeoGetDto>> GetUbigeoAsync(int IdPais, int Tipo, string Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Ubigeos";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdPais", IdPais);
                parameters.Add("@p_nTipo", Tipo);
                parameters.Add("@p_cCodigo", Codigo);
                var giradorList = await connection.QueryAsync<UbigeoGetDto>(query, parameters, commandType: CommandType.StoredProcedure);
                return giradorList.AsList();
            }
        }


        public async Task<IReadOnlyList<UbigeoDataPeru>> GetUbigeoDataPeruAsync(string codDep, string codProv, string distrito)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Ubigeos_Listado";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cCodDep", codDep);
                parameters.Add("@p_cCodProv", codProv);
                parameters.Add("@p_cCodDistrito", distrito);
                var ubigeoList = await connection.QueryAsync<UbigeoDataPeru>(query, parameters, commandType: CommandType.StoredProcedure);
                return ubigeoList.AsList();
            }
        }
    }
}
