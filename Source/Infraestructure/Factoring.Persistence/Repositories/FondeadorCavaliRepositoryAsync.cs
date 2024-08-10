using Dapper;
using Factoring.Application.DTOs.Fondeador.CavaliFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class FondeadorCavaliRepositoryAsync : IFondeadorCavaliRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public FondeadorCavaliRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(CavaliFondeadorCreateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_FondeadorCavali";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iCodParticipante", entity.CodParticipante);
                parameters.Add("@p_iCodRUT", entity.CodRUT);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_iIdFondeador", entity.IdFondeador);
                parameters.Add("@p_iIdFondeadorCavali", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_iIdFondeadorCavali");
            }
        }
        public async Task<IReadOnlyList<CavaliFondeadorResponseListDto>> GetAllCavaliByIdFondeador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FondeadorCavali";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeador", id);

                var products = await connection.QueryAsync<CavaliFondeadorResponseListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
        public async Task DeleteAsync(CavaliFondeadorDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_FondeadorCavali";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeadorCavali", entity.IdFondeadorCavali);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}