using Dapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Domain.Entities;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class UsuarioRepositoryAsync : IUsuarioRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuarioRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Rol>> GetByIdRolesForUser(int id)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "GetRolesUserById";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);
                    var roles = await connection.QueryAsync<Rol>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return roles.AsList();
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        public async Task<List<MenuResponse>> GetListMenu(AuthenticationRequest userRequest)
        {
            List<MenuResponse> lista = new List<MenuResponse>();
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Menu";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cCodigoUsuario", userRequest.Username);
                var list = await connection.QueryAsync<MenuResponse>(query, param: parameters, commandType: CommandType.StoredProcedure);
                lista = list.AsList();
                return lista;
            }
        }

        public async Task<AuthenticationResponse> GetUserAuth(AuthenticationRequest userRequest)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Consulta_Usuarios";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nTipo", 1);
                    parameters.Add("@p_cCodigoUsuario", userRequest.Username);
                    parameters.Add("@p_cPassword", userRequest.Password);
                    var user = await connection.QueryFirstOrDefaultAsync<AuthenticationResponse>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}
