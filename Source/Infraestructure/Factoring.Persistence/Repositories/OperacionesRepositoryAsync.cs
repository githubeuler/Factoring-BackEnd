﻿using Dapper;
using Factoring.Application.DTOs.Externo;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class OperacionesRepositoryAsync : IOperacionesRepositoryAsync
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        public OperacionesRepositoryAsync(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }

        public async Task<Response<int>> AddAsync(OperacionesInsertDto entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Inserta_Operaciones";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdGirador", entity.IdGirador);
                    parameters.Add("@p_nIdAdquiriente", entity.IdAdquiriente);
                    //parameters.Add("@p_nIdInversionista", entity.IdInversionista);
                    parameters.Add("@p_nIdTipoMoneda", entity.IdTipoMoneda);
                    parameters.Add("@p_nIdGiradorDireccion", entity.IdGiradorDireccion);
                    parameters.Add("@p_nIdAdquirienteDireccion", entity.IdAdquirienteDireccion);
                    parameters.Add("@p_nTEM", entity.TEM);
                    parameters.Add("@p_nPorcentajeFinanciamiento", entity.PorcentajeFinanciamiento);
                    parameters.Add("@p_nMontoOperacion", entity.MontoOperacion);
                    parameters.Add("@p_nDescContrato", entity.DescContrato);
                    parameters.Add("@p_nDescFactura", entity.DescFactura);
                    parameters.Add("@p_nDescCobranza", entity.DescCobranza);
                    parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                    parameters.Add("@p_nPorcentajeRetencion", entity.PorcentajeRetencion);
                    parameters.Add("@p_nInteresMoratorio", entity.InteresMoratorio);

                    //*************Ini-09-01-2023-RCARRILLO******//
                    parameters.Add("@p_iCategoria", entity.IdCategoria);
                    parameters.Add("@p_cMotivoTransaccion", entity.MotivoTransaccion);
                    parameters.Add("@p_cSustentoComercial", entity.SustentoComercial);
                    parameters.Add("@p_nPlazo", entity.Plazo);
                    parameters.Add("@p_nCantidadFactura", entity.CantidadFactura);
                    //*************Fin-09-01-2023-RCARRILLO******//

                    parameters.Add("@p_nDescMensaje", null, DbType.String, direction: ParameterDirection.Output, size: 250);
                    parameters.Add("@p_nInteresMoratorioOut", null, DbType.Decimal, direction: ParameterDirection.Output);
                    parameters.Add("@p_nIdOperaciones", DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                    int IdOperaciones = parameters.Get<int>("p_nIdOperaciones");
                    if (parameters.Get<int>("p_nIdOperaciones") == 0) return new Response<int>(parameters.Get<string>("p_nDescMensaje"));
                    else return new Response<int>(parameters.Get<int>("p_nIdOperaciones"), parameters.Get<string>("p_nDescMensaje"));

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new Response<int>(message);
            }
        }

        public async Task<OperacionesGetByIdDto> GetByIdAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Operaciones_Edicion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperaciones", id);
                var product = await connection.QueryFirstOrDefaultAsync<OperacionesGetByIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return product;
            }
        }

        public async Task<IReadOnlyList<OperacionesResponseDataTable>> GetListOperaciones(OperacionesRequestDataTableDto model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Operaciones";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@filter_nNroOperacion", model.FilterNroOperacion);
                parameters.Add("@filter_cRazonGirador", model.FilterRazonGirador);
                parameters.Add("@filter_cRazonAdquiriente", model.FilterRazonAdquiriente);
                parameters.Add("@filter_FecCrea", model.FilterFecCrea);
                parameters.Add("@filter_nEstado", model.Estado);
                parameters.Add("@nUsuario", model.Usuario);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);

                var operacionesList = await connection.QueryAsync<OperacionesResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
            }
        }
        public async Task<IReadOnlyList<ReportesGiradorOperacionesDTO>> GetListOperacionesDonwload(OperacionesRequestDataTableDto model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Operaciones_Exportar";
                var parameters = new DynamicParameters();

                parameters.Add("@filter_nNroOperacion", model.FilterNroOperacion);
                parameters.Add("@filter_cRazonGirador", model.FilterRazonGirador);
                parameters.Add("@filter_cRazonAdquiriente", model.FilterRazonAdquiriente);
                parameters.Add("@filter_FecCrea", model.FilterFecCrea);
                parameters.Add("@filter_nEstado", model.Estado);

                var operacionesList = await connection.QueryAsync<ReportesGiradorOperacionesDTO>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
            }
        }

        public async Task<Response<int>> UpdateAsync(OperacionesUpdateDto entity)
        {
            var parameters = new DynamicParameters();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Actualiza_Operaciones";
                parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                parameters.Add("@p_nIdGirador", entity.IdGirador);
                parameters.Add("@p_nIdAdquiriente", entity.IdAdquiriente);
                parameters.Add("@p_nIdTipoMoneda", entity.IdTipoMoneda);
                parameters.Add("@p_nIdGiradorDireccion", entity.IdGiradorDireccion);
                parameters.Add("@p_nIdAdquirienteDireccion", entity.IdAdquirienteDireccion);
                parameters.Add("@p_nTEM", entity.TEM);
                parameters.Add("@p_nPorcentajeFinanciamiento", entity.PorcentajeFinanciamiento);
                parameters.Add("@p_nMontoOperacion", entity.MontoOperacion);
                parameters.Add("@p_nDescContrato", entity.DescContrato);
                parameters.Add("@p_nDescFactura", entity.DescFactura);
                parameters.Add("@p_nDescCobranza", entity.DescCobranza);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                parameters.Add("@p_nPorcentajeRetencion", entity.PorcentajeRetencion);
                parameters.Add("@p_nInteresMoratorio", entity.InteresMoratorio);
                parameters.Add("@p_iCategoria", entity.IdCategoria);
                parameters.Add("@p_cMotivoTransaccion", entity.MotivoTransaccion);
                parameters.Add("@p_cSustentoComercial", entity.SustentoComercial);
                parameters.Add("@p_nPlazo", entity.Plazo);

                parameters.Add("@p_nDescMensaje", null, DbType.String, direction: ParameterDirection.Output, size: 250);
                parameters.Add("@p_nIdOperacionesOut", DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                int IdOperaciones = parameters.Get<int>("p_nIdOperacionesOut");
                if (parameters.Get<int>("p_nIdOperacionesOut") == 0) return new Response<int>(parameters.Get<string>("p_nDescMensaje"));
                else return new Response<int>(parameters.Get<int>("p_nIdOperacionesOut"), parameters.Get<string>("p_nDescMensaje"));
            }
        }
        public async Task DeleteAsync(OperacionesDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_Operaciones";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<DivisoGetFondeador> GetObtenerIversionista(int IdFactura)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Obtener_Iversionista";
                var parameters = new DynamicParameters();
                parameters.Add("@IdFactura", IdFactura);
                var inversionista = await connection.QueryFirstOrDefaultAsync<DivisoGetFondeador>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return inversionista;
            }
        }


        public async Task<DivisoGetFondeador> GetObtenerIversionistaEnvio(int nCategoria,int nFondeador,int nNroEnvio,int nAsignacion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Obtener_Iversionista_Envio";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nCategoria", nCategoria);
                parameters.Add("@p_nFondeador", nFondeador);
                parameters.Add("@p_nNroEnvio", nNroEnvio);
                parameters.Add("@nAsignacion", nAsignacion);
                var inversionista = await connection.QueryFirstOrDefaultAsync<DivisoGetFondeador>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return inversionista;
            }
        }

        public async Task<int> GetprocessNumberFacturas()
        {
            try
            {
                using var connection = _connectionFactory.GetConnection;
                var query = "pe_Consulta_Operaciones_factura_Correlativo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nNumeroFactura", null, DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return Convert.ToInt32(parameters.Get<int>("p_nNumeroFactura"));
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<DivisoGetFondeador> GetObtenerIversionistaFSeleccionado(int iIdFondeador)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ObtenerFondeadorCavali";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdFondeador", iIdFondeador);
                var inversionista = await connection.QueryFirstOrDefaultAsync<DivisoGetFondeador>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return inversionista;
            }

        }

        public async Task<string> GetFileBase64(string filename)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_configuration["UrlBaseApiFiles"].ToString());
                    client.MaxResponseContentBufferSize = 9999999;
                    var result = await client.PostAsync($"Upload/download-file?fileName={System.Net.WebUtility.UrlEncode(filename)}", null);
                    byte[] fileBytes = await result.Content.ReadAsByteArrayAsync();
                    return Convert.ToBase64String(fileBytes);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
