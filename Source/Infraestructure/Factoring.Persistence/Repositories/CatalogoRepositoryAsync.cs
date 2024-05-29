using Dapper;
using Factoring.Application.DTOs.Catalogo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class CatalogoRepositoryAsync : ICatalogoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public CatalogoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IReadOnlyList<CatalogoResponseListDto>> GetListCatalogo(CatalogoListDto model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Catalogo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nTipo", model.Tipo);
                parameters.Add("@p_nCodigo", model.Codigo);
                parameters.Add("@p_cValor", model.Valor);
                var giradorList = await connection.QueryAsync<CatalogoResponseListDto>(query, parameters, commandType: CommandType.StoredProcedure);
                return giradorList.AsList();
            }
        }
        public async Task<IReadOnlyList<CatalogoResponseListDto>> GetListCategoriaCatalogo(CatalogoListDto model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Categoria_PorGirador";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", model.Codigo);
                var giradorList = await connection.QueryAsync<CatalogoResponseListDto>(query, parameters, commandType: CommandType.StoredProcedure);
                return giradorList.AsList();
            }
        }

    }
}
