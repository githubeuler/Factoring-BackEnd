using Dapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class OperacionesFacturaRepositoryAsync : IOperacionesFacturaRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        public OperacionesFacturaRepositoryAsync(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }

        public async Task<int> AddAsync(OperacionesFacturaInsertDto entity)
        {
            //  <OAV - 07/02/2023>  SE AGREGA TRY-CATCH
            var parameters = new DynamicParameters();
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Inserta_OperacionesFacturas";

                    parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                    parameters.Add("@p_cNroDocumento", entity.NroDocumento);
                    parameters.Add("@p_nMonto", entity.Monto);
                    parameters.Add("@p_dFechaEmision", entity.FechaEmision);
                    parameters.Add("@p_dFechaVencimiento", entity.FechaVencimiento);
                    parameters.Add("@p_cNombreDocumentoXML", entity.NombreDocumentoXML);
                    parameters.Add("@p_cRutaDocumentoXML", entity.RutaDocumentoXML);
                    parameters.Add("@p_cNombreDocumentoPDF", entity.NombreDocumentoPDF);
                    parameters.Add("@p_cRutaDocumentoPDF", entity.RutaDocumentoPDF);
                    parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                    parameters.Add("@p_dFechaPagoNegociado", entity.FechaPagoNegociado);
                    parameters.Add("@p_nIdOperacionesFacturas", DbType.String, direction: ParameterDirection.Output);
                    await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return parameters.Get<int>("p_nIdOperacionesFacturas");
        }

        public async Task DeleteAsync(OperacionesFacturaDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_OperacionesFacturas";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperacionesFacturas", entity.IdOperacionesFacturas);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task EditAsync(OperacionesFacturaEditDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Editar_OperacionesFacturas";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperacionesFacturas", entity.IdOperacionesFacturas);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                parameters.Add("@p_dFechaPagoNegociado", entity.FechaPagoNegociado);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task EditMontoAsync(OperacionesFacturaEditMontoDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Update_OperacionesFacturas";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperaciones", entity.nIdOperaciones);
                parameters.Add("@p_nIdOperacionesFactura", entity.nIdOperacionesFacturas);
                parameters.Add("@p_nMonto", entity.nMonto);
                parameters.Add("@p_cUsuarioActualizacion", entity.cUsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<OperacionesFacturaListDto> FindByNumberAsync(int IdGirador, int IdAdquiriente, string NroFactura)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FacturasByNumero";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdGirador", IdGirador);
                parameters.Add("@p_nIdAdquiriente", IdAdquiriente);
                parameters.Add("@p_cNroDocumento", NroFactura);
                var factura = await connection.QueryFirstOrDefaultAsync<OperacionesFacturaListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return factura;
            }
        }

        public async Task<IReadOnlyList<OperacionesFacturaListDto>> GetAllFacturasByOperaciones(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_OperacionesFacturas";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperaciones", id);

                var products = await connection.QueryAsync<OperacionesFacturaListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
        public async Task<IReadOnlyList<OperacionesFacturaListDto>> GetAllFacturasByOperacionesFacturas(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_OperacionesFacturasxId";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperacionFactura", id);

                var products = await connection.QueryAsync<OperacionesFacturaListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }

        public async Task<IReadOnlyList<OperacionesFacturaResponseDataTable>> GetListFacturasBandeja(OperacionesFacturaRequestDataTableDto model)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_OperacionesFactura_Reestructurado";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@nEstado", model.nEstado);
                parameters.Add("@filter_nNroOperacion", model.FilterNroOperacion);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);
                parameters.Add("@FechaCreacion", model.FechaCreacion);
                var operacionesList = await connection.QueryAsync<OperacionesFacturaResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
            }

        }
        public async Task<Response<int>> ValidateEstadoOperacionesFacturasAsync(int IdOperacionFactura, int tipoOperacion)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Validate_EstadoOperacionesFacturas";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdOperacionFactura", IdOperacionFactura);
                    parameters.Add("@p_nTipoOperacion", tipoOperacion);
                    parameters.Add("@p_nDescMensaje", null, DbType.String, direction: ParameterDirection.Output, size: 250);
                    parameters.Add("@p_nIdEstado", DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    int IdOperaciones = parameters.Get<int>("@p_nIdEstado");
                    if (parameters.Get<int>("p_nIdEstado") == 0) return new Response<int>(parameters.Get<string>("p_nDescMensaje"));
                    else return new Response<int>(parameters.Get<int>("p_nIdEstado"), parameters.Get<string>("p_nDescMensaje"));
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new Response<int>(message);
            }
        }

        public async Task<IReadOnlyList<FondeadorGetPermisos>> GetValidateFondeadoresAsync(string facturas)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Iversionistas";
                var parameters = new DynamicParameters();
                parameters.Add("@filter_nNrofactura", facturas);
                var operacionesList = await connection.QueryAsync<FondeadorGetPermisos>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
            }

        }

        public async Task<IReadOnlyList<FondeadorGetPermisos>> GetListadoFondeadoresAsync(string facturas)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Validar_Reglas_Iversionistas";
                var parameters = new DynamicParameters();
                parameters.Add("@filter_nNrofactura", facturas);
                var operacionesList = await connection.QueryAsync<FondeadorGetPermisos>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
            }
        }
        public async Task<OperacionesFacturaListDto> GetFacturaById(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FacturasById";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperacionesFactura", id);
                var invoice = await connection.QueryFirstOrDefaultAsync<OperacionesFacturaListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return invoice;
            }
        }
        public async Task<int> AddInvoicesLogCavaliAsync(OperacionesFacturaInsertCavaliDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_CavaliOperacionesPorFactura";
                var parameters = new DynamicParameters();
                parameters.Add("@p_ConjuntoFacturasJson", entity.ConjuntoFacturasJson);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_TramaEnvio4012", entity.TramaEnvio4012);
                parameters.Add("@p_TramaRespuesta4012", entity.TramaRespuesta4012);
                parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                parameters.Add("@p_nIdOperacionesFactura", entity.IdOperacionesFactura);
                parameters.Add("@p_nParticipantCode", entity.cParticipantCode);
                parameters.Add("@p_nIdCavaliOperacionesFactura", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_nIdCavaliOperacionesFactura");
            }
        }


        public async Task<IReadOnlyList<FacturasGetRegistro>> GetListaFacturasRegistradasAsync(string facturas,int nTipo)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Lista_Facturas_AnotacionRegistro";
                var parameters = new DynamicParameters();
                parameters.Add("@filter_nNrofactura", facturas);
                parameters.Add("@nTipo", nTipo);
                var operacionesList = await connection.QueryAsync<FacturasGetRegistro>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
            }
        }

        public async Task<int> AddDocumentoSolicitudOperacionesAsync(DocumentosSolicitudperacionesInsertDto entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Inserta_DocumentosSolicitudEvaluacionOperaciones";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdSolEvalOperaciones", entity.nIdSolEvalOperaciones);
                    parameters.Add("@p_nTipoDocumento", entity.nTipoDocumento);
                    parameters.Add("@p_cNombreDocumento", entity.cNombreDocumento);
                    parameters.Add("@_cRutaDocumento", entity.cRutaDocumento);
                    parameters.Add("@_cUsuarioCreador", entity.cUsuarioCreador);
                    parameters.Add("@p_nIdDocumentoSolEvalOperaciones", DbType.String, direction: ParameterDirection.Output);
                    await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return parameters.Get<int>("p_nIdDocumentoSolEvalOperaciones");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return 0;
            }
        }

        public async Task<IReadOnlyList<DocumentoSolicitudOperacionListDto>> GetDocumentoBySolicitud(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consultar_DocumentosSolicitudEvaluacionOperaciones";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperacion", id);
                var products = await connection.QueryAsync<DocumentoSolicitudOperacionListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
        public async Task<IReadOnlyList<DocumentoSolicitudOperacionListIdDto>> GetAllDocumentoSolicitudByOperaciones(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_DocumentosSolicitudEvaluacionOperacionesxId";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdSolEvalOperaciones", id);

                var products = await connection.QueryAsync<DocumentoSolicitudOperacionListIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
        public async Task DeleteDocumentoAsync(OperacionesSolicitudDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_DocumentosSolicitudEvaluacionOperaciones";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdDocumentoSolEvalOperaciones", entity.nIdDocumentoSolEvalOperaciones);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<OperacionesFacturaListDto> GetEstadoOperacion(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultaEstado_Operacion";
                var parameters = new DynamicParameters();
                parameters.Add("@pnIdOperacionFactura", id);
                var invoice = await connection.QueryFirstOrDefaultAsync<OperacionesFacturaListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return invoice;
            }
        }
    }
}
