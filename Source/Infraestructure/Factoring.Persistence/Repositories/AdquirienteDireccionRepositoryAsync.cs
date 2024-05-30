using Dapper;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class AdquirienteDireccionRepositoryAsync : IAdquirienteDireccionRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public AdquirienteDireccionRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(UbicacionAdquirienteInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_AdquirienteDireccion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cFormatoUbigeo", entity.FormatoUbigeo);
                parameters.Add("@p_cDireccion", entity.Direccion);
                parameters.Add("@p_nIdTipoDireccion", entity.IdTipoDireccion);
                parameters.Add("@p_nIdAdquiriente", entity.IdAdquiriente);

                parameters.Add("@p_nIdAdquirienteDireccion", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_nIdAdquirienteDireccion");
            }
        }

        public async Task DeleteAsync(UbicacionAdquirienteDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_AdquirienteDireccion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdAdquirienteDireccion", entity.IdAdquirienteDireccion);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IReadOnlyList<UbicacionAdquirienteListDto>> GetAllDireccionByIdAdquiriente(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_AdquirienteDireccion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdAdquiriente", id);

                var products = await connection.QueryAsync<UbicacionAdquirienteListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
    }
}
