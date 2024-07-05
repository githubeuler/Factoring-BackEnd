using Dapper;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class GiradorDocumentoRepositoryAsync : IGiradorDocumentoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public GiradorDocumentoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(DocumentosGiradorInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_GiradorDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdTipoDocumento", entity.IdTipoDocumento);
                parameters.Add("@p_cRuta", entity.Ruta);
                parameters.Add("@p_cNombreDocumento", entity.NombreDocumento);
                parameters.Add("@p_nIdGirador", entity.IdGirador);
                parameters.Add("@p_nIdGiradorDocumento", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_nIdGiradorDocumento");
            }
        }

        public async Task DeleteAsync(DocumentosGiradorDeleteDto entity)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_GiradorDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGiradorDocumento", entity.IdGiradorDocumento);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }

        }


        public async Task<IReadOnlyList<DocumentosGiradorListDto>> GetAllDocumentosByIdGirador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_GiradorDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", id);

                var products = await connection.QueryAsync<DocumentosGiradorListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }


    }
}