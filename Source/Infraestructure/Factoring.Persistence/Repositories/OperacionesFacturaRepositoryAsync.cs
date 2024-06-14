using Dapper;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
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
    }
}
