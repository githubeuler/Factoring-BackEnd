using Dapper;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class GiradorDireccionRepositoryAsync : IGiradorDireccionRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public GiradorDireccionRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(UbicacionGiradorInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_GiradorDireccion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cFormatoUbigeo", entity.FormatoUbigeo);
                parameters.Add("@p_cDireccion", entity.Direccion);
                parameters.Add("@p_nIdTipoDireccion", entity.IdTipoDireccion);
                parameters.Add("@p_nIdGirador", entity.IdGirador);
                parameters.Add("@p_nIdGiradorDireccion", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("p_nIdGiradorDireccion");
            }
        }

        public async Task DeleteAsync(UbicacionGiradorDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_GiradorDireccion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGiradorDireccion", entity.IdGiradorDireccion);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IReadOnlyList<UbicacionGiradorListDto>> GetAllDireccionByGirador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_GiradorDireccion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", id);

                var products = await connection.QueryAsync<UbicacionGiradorListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                var data = products.AsList();
                return data;
            }
        }


        public async Task<UbicacionGiradorSingleDto> GetUbicacionSingleAsync(string codDep, string codProv, string codDistrito)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Ubigeos_Listado";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cCodDep", codDep);
                parameters.Add("@p_cCodProv", codProv);
                parameters.Add("@p_cCodDistrito", codDistrito);
                var ubicacion = await connection.QueryFirstOrDefaultAsync<UbicacionGiradorSingleDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return ubicacion;
            }

        }

        public async Task<DireccionGiradorSingleDto> GetDireccionSingleAsync(int idGirador, int tipo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_GiradorDireccion_Operaciones";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nTipo", tipo);
                parameters.Add("@p_nIdGirador", idGirador);
                var ubicacion = await connection.QueryFirstOrDefaultAsync<DireccionGiradorSingleDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return ubicacion;
            }
        }
    }
}
