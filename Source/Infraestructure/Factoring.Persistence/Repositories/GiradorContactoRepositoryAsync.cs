using Dapper;
using Factoring.Application.DTOs.Girador.ContactoGirador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class GiradorContactoRepositoryAsync : IGiradorContactoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public GiradorContactoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ResponseContatDto> AddAsync(ContactoGiradorCreateDto entity)
        {
            ResponseContatDto obj = new ResponseContatDto();
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_GiradorContacto";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cNombre", entity.Nombre);
                parameters.Add("@p_cApellidoPaterno", entity.ApellidoPaterno);
                parameters.Add("@p_cApellidoMaterno", entity.ApellidoMaterno);
                parameters.Add("@p_cCelular", entity.Celular);
                parameters.Add("@p_cEmail", entity.Email);
                parameters.Add("@p_nIdGirador", entity.IdGirador);
                parameters.Add("@p_nIdTipoContacto", entity.IdTipoContacto);
                parameters.Add("@p_nIdGiradorContacto", DbType.String, direction: ParameterDirection.Output);
                parameters.Add("@p_nIdUsuario", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                obj.IdGiradorContacto = parameters.Get<int>("p_nIdGiradorContacto");
                obj.IdUsuario = parameters.Get<int>("p_nIdUsuario");
                //parameters.Get<int>("p_nIdGiradorContacto");
                //parameters.Get<int>("p_nIdUsuario");

                return obj;//parameters.Get<ResponseContatDto>(obj.ToString());
            }
        }

        public async Task DeleteAsync(ContactoGiradorDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_GiradorContacto";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGiradorContacto", entity.IdGiradorContacto);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IReadOnlyList<ContactoGiradorResponseListDto>> GetAllContactoByIdGirador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_GiradorContacto";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", id);

                var products = await connection.QueryAsync<ContactoGiradorResponseListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
    }
}