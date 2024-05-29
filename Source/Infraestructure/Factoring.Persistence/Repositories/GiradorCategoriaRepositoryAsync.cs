using Dapper;
using Factoring.Application.DTOs.Girador.Confirming;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class GiradorCategoriaRepositoryAsync : IGiradorCategoriaRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public GiradorCategoriaRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async  Task<IReadOnlyList<GiradorConfirmingDto>> GetAllCategoriaByIdGirador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_GiradorCategoria";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", id);

                var products = await connection.QueryAsync<GiradorConfirmingDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
    }
}
