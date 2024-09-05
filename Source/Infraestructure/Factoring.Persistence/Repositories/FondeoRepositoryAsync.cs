using Dapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class FondeoRepositoryAsync : IFondeoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public FondeoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyList<FondeoGetAllDto>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultaFondeo";
                var fondeo = await connection.QueryAsync<FondeoGetAllDto>(query, param: null, commandType: CommandType.StoredProcedure);
                return fondeo.AsList();
            }
        }

        public async Task<IReadOnlyList<FondeoResponseDataTable>> GetListFondeo(FondeoRequestDataTable model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Fondeo";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);

                parameters.Add("@filter_cNroOperacion", model.FilterNroOperacion);
                parameters.Add("@filter_cFondeadorAsignado", model.FilterFondeadorAsignado);
                parameters.Add("@filter_cGirador", model.FilterGirador);
                parameters.Add("@filter_dFechaRegistro", model.FilterFechaRegistro);
                parameters.Add("@filter_cEstadoFondeo", model.FilterEstadoFondeo == "0" ? null : model.FilterEstadoFondeo);

                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);
                parameters.Add("@IdEstado", model.IdEstado);

                var fondeadorList = await connection.QueryAsync<FondeoResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return fondeadorList.AsList();
            }
        }

        public async Task<bool> InsertAsync(FondeoInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_Fondeo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdFondeadorFactura", entity.IdFondeadorFactura);
                parameters.Add("@p_cUsuarioCreacion", entity.UsuarioCreacion);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<bool> UpdateAsync(FondeoUpdateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Actualiza_Fondeo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdFondeadorFactura", entity.IdFondeadorFactura);
                parameters.Add("@p_nIdOperacion", entity.IdOperacion);
                parameters.Add("@p_nIdFondeador", entity.IdFondeador);
                parameters.Add("@p_nIdTipoProducto", entity.IdTipoProducto);
                parameters.Add("@p_nCapitalFinanciado", entity.PorCapitalFinanciado);
                parameters.Add("@p_nTasaAnualFondeo", entity.PorTasaAnualFondeo);
                parameters.Add("@p_nTasaMoraFondeo", entity.PorTasaMoraFondeo);
                parameters.Add("@p_nTasaMensual", entity.PorTasaMensual);
                parameters.Add("@p_nComisionFactura", entity.PorComisionFactura);
                parameters.Add("@p_nSpread", entity.PorSpread);
                parameters.Add("@p_dFechaDesembolso", entity.FechaDesembolso);
                parameters.Add("@p_dFechaCobranza", entity.FechaCobranza);
                parameters.Add("@p_cUsuarioModificacion", entity.UsuarioModificacion);
                parameters.Add("@p_nIgv", entity.Igv);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<bool> UpdateStateAsync(FondeoUpdateStateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Actualiza_Estado_Fondeo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdFondeadorFactura", entity.IdFondeadorFactura);
                parameters.Add("@p_nIdEstadoFondeo", entity.IdEstadoFondeo);
                parameters.Add("@p_cComentario", entity.Comentario);
                parameters.Add("@p_cUsuarioModificacion", entity.UsuarioModificacion);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
        public async Task<IReadOnlyList<ReporteFondeoDTO>> GetListFondeoDonwload(FondeoRequestDataTable model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Fondeo_Exportar";
                var parameters = new DynamicParameters();

                parameters.Add("@filter_cNroOperacion", model.FilterNroOperacion);
                parameters.Add("@filter_cFondeadorAsignado", model.FilterFondeadorAsignado);
                parameters.Add("@filter_cGirador", model.FilterGirador);
                parameters.Add("@filter_dFechaRegistro", model.FilterFechaRegistro);
                parameters.Add("@filter_cEstadoFondeo", model.FilterEstadoFondeo);

                var fondeoList = await connection.QueryAsync<ReporteFondeoDTO>(query, parameters, commandType: CommandType.StoredProcedure);
                return fondeoList.AsList();
            }
        }
    }
}
