using Dapper;
using Factoring.Application.DTOs.DocumentosAceptante;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class AceptanteDocumentoRepositoryAsync : IAceptanteDocumentoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public AceptanteDocumentoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(DocumentosAceptanteInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_AceptanteDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdTipoDocumento", entity.IdTipoDocumento);
                parameters.Add("@p_cRuta", entity.Ruta);
                parameters.Add("@p_cNombreDocumento", entity.NombreDocumento);
                parameters.Add("@p_nIdAceptante", entity.IdAceptante);
                parameters.Add("@p_nIdAceptanteDocumento", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_nIdAceptanteDocumento");
            }
        }

        public async Task DeleteAsync(DocumentosAceptanteDeleteDto entity)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_AceptanteDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdAceptanteDocumento", entity.IdAceptanteDocumento);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }

        }


        public async Task<IReadOnlyList<DocumentosAceptanteListDto>> GetAllDocumentosByIdAceptante(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_AceptanteDocumento";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdAceptante", id);
                var products = await connection.QueryAsync<DocumentosAceptanteListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }


    }
}
