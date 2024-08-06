using Dapper;
using Factoring.Application.DTOs.Fondeador.DocumentoFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class FondeadorDocumentoRepositoryAsync : IFondeadorDocumentoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public FondeadorDocumentoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(DocumentosFondeadorCreateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_FondeadorDocumentos";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cRutaDocumento", entity.RutaDocumento);
                parameters.Add("@p_cNombreDocumento", entity.NombreDocumento);
                parameters.Add("@p_iTipoDocumento", entity.IdTipoDocumento);
                parameters.Add("@p_cUsuario", entity.UsuarioCreador);
                parameters.Add("@p_iIdFondeador", entity.IdFondeador);
                parameters.Add("@p_iIdFondeadorDocumentos", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_iIdFondeadorDocumentos");
            }
        }

        public async Task DeleteAsync(DocumentosFondeadorDeleteDto entity)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_FondeadorDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeadorDocumento", entity.IdFondeadorDocumento);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }

        }


        public async Task<IReadOnlyList<DocumentosFondeadorResponseListDto>> GetAllDocumentosByIdGirador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FondeadorDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeador", id);

                var products = await connection.QueryAsync<DocumentosFondeadorResponseListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }


    }
}
