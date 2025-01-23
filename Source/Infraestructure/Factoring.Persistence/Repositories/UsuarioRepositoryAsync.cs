using Dapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
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

        #region CRUD
        public async Task<Response<int>> AddAsync(UsuarioInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_Usuario";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cCodigoUsuario", entity.CodigoUsuario);
                parameters.Add("@p_cNombreUsuario", entity.NombreUsuario);
                parameters.Add("@p_cPassword", entity.Password);
                parameters.Add("@p_cCorreo", entity.Correo);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_nIdPais", entity.IdPais);
                parameters.Add("@p_nIdRol", entity.IdRol);
                parameters.Add("@p_nIdUsuario", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return new Response<int>(parameters.Get<int>("p_nIdUsuario"));
            }
        }

        public async Task<Response<int>> UpdateAsync(UsuarioUpdateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Actualiza_Usuario";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdUsuario", entity.IdUsuario);
                parameters.Add("@p_cNombreUsuario", entity.NombreUsuario);
                parameters.Add("@p_cPassword", entity.Password);
                parameters.Add("@p_cCorreo", entity.Correo);
                parameters.Add("@p_cnActivo", entity.Activo);
                parameters.Add("@p_cUsuarioModificacion", entity.UsuarioModificacion);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return new Response<int>(entity.IdUsuario);
            }
        }

        public async Task<Response<int>> DeleteAsync(UsuarioDeleteDto entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Elimina_Usuario";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdUsuario", entity.IdUsuario);
                    parameters.Add("@p_cUsuarioModificacion", entity.UsuarioModificacion);
                    await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                }
                return new Response<int>(entity.IdUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioGetByIdDto> GetByIdAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_UsuarioById";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdUsuario", id);
                var data = await connection.QueryFirstOrDefaultAsync<UsuarioGetByIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IReadOnlyList<UsuarioResponseDataTable>> GetListUsuario(UsuarioRequestDataTable model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Usuario";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@filter_cCodigoUsuario", model.FilterCodigoUsuario);
                parameters.Add("@filter_cNombreUsuario", model.FilterNombreUsuario);
                parameters.Add("@filter_nActivo", model.FilterActivo);
                parameters.Add("@filter_nIdPais", model.FilterIdPais);
                parameters.Add("@filter_nIdRol", model.FilterIdRol);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);

                var List = await connection.QueryAsync<UsuarioResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return List.AsList();
            }
        }

        #endregion

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

        public async Task<Response<int>> ChangePassword(ChangePasswordRequest entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Actualiza_Contrasena";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdUsuario", entity.IdUsuario);
                    parameters.Add("@p_cPassword", entity.NewPassword);
                    parameters.Add("@p_MustChangePassword", entity.MustChangePassword);
                    await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                }
                return new Response<int>(entity.IdUsuario,"La contraseña se actualizo correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
