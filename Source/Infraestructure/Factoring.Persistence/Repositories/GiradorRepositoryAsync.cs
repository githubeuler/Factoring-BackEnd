using Dapper;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.Features.Girador.Queries;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class GiradorRepositoryAsync : IGiradorRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public GiradorRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Response<int>> AddAsync(GiradorInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_Girador";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdPais", entity.IdPais);
                parameters.Add("@p_cRegUnicoEmpresa", entity.RegUnicoEmpresa);
                parameters.Add("@p_cRazonSocial", entity.RazonSocial);
                parameters.Add("@p_nIdSector", entity.IdSector);
                parameters.Add("@p_nVenta", entity.Venta);
                parameters.Add("@p_nCompra", entity.Compra);
                parameters.Add("@p_nIdGrupoEconomico", entity.IdGrupoEconomico);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_nDescMensaje", null, DbType.String, direction: ParameterDirection.Output, size: 250);
                parameters.Add("@p_nIdGirador", DbType.Int32, direction: ParameterDirection.ReturnValue);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                int IdGirador = parameters.Get<int>("p_nIdGirador");
                if (parameters.Get<int>("p_nIdGirador") == 0) return new Response<int>(parameters.Get<string>("p_nDescMensaje"));
                else return new Response<int>(parameters.Get<int>("p_nIdGirador"), parameters.Get<string>("p_nDescMensaje"));

            }
        }

        public async Task<IReadOnlyList<GiradorResponseDataTable>> GetListGirador(GiradorRequestDataTable model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Girador";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@filter_cRuc", model.FilterRuc);
                parameters.Add("@filter_cRazon", model.FilterRazon);
                parameters.Add("@filter_IdPais", model.FilterIdPais == 0 ? null : model.FilterIdPais);
                parameters.Add("@filter_FecCrea", model.FilterFecCrea);
                parameters.Add("@filter_IdSector", model.FilterIdSector == 0 ? null : model.FilterIdSector);
                parameters.Add("@filter_IdGrupoEconomico", model.FilterIdGrupoEconomico == 0 ? null : model.FilterIdGrupoEconomico);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);

                var giradorList = await connection.QueryAsync<GiradorResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return giradorList.AsList();
            }
        }
        public async Task<IReadOnlyList<GiradorResponseList>> GetListaGirador()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Girador_Combo";
                var giradorList = await connection.QueryAsync<GiradorResponseList>(query, null, commandType: CommandType.StoredProcedure);
                return giradorList.AsList();
            }
        }

        public async Task<GiradorGetByIdDto> GetByIdAsync(int id)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Girador_Edicion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", id);
                var girador = await connection.QueryFirstOrDefaultAsync<GiradorGetByIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return girador;
            }

        }

        public async Task<bool> UpdateAsync(GiradorUpdateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Actualiza_Girador";
                var parameters = new DynamicParameters();


                parameters.Add("@p_nIdGirador", entity.IdGirador);
               
                parameters.Add("@p_cRegUnicoEmpresa", entity.RegUnicoEmpresa);
                parameters.Add("@p_cRazonSocial", entity.RazonSocial);
                parameters.Add("@p_dFechaInicioActividad", entity.FechaInicioActividad);
                parameters.Add("@p_nIdActividadEconomica", entity.IdActividadEconomica);
                parameters.Add("@p_dFechaFirmaContrato", entity.FechaFirmaContrato);
                parameters.Add("@p_cAntecedente", entity.Antecedente);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<GetGiradorDocumentosFileName> GetDocumentosFileName(int IdDocumento, int IdTipo)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Documentos_Girador_Tipo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdDocumento", IdDocumento);
                parameters.Add("@p_nIdTipo", IdTipo);
                var girador = await connection.QueryFirstOrDefaultAsync<GetGiradorDocumentosFileName>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return girador;
            }

        }
    }
}
