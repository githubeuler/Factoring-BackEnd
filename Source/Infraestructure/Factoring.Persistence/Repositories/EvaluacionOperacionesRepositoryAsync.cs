using Dapper;
using Factoring.Application.DTOs.EvaluacionOperaciones;
//using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Util;
using Factoring.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class EvaluacionOperacionesRepositoryAsync : IEvaluacionOperacionesRepositoryAsync

    {
        private readonly IConnectionFactory _connectionFactory;

        public EvaluacionOperacionesRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Response<int>> AddAsync(EvaluacionOperacionesInsertDto entity, string guid = "")
        {
            try
            {
                LogUtil.GetLogger().Info($"{guid} - Inicio AddAsync - entity : {entity.ToJson()}");
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Inserta_EstadosOperacion";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                    parameters.Add("@p_nIdCatalogoEstado", entity.IdCatalogoEstado);
                    parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                    parameters.Add("@p_Comentario", entity.Comentario);
                    parameters.Add("@p_nIdEstadosOperaciones", DbType.String, direction: ParameterDirection.Output);
                    await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    int respuesta = parameters.Get<int>("p_nIdEstadosOperaciones");
                    LogUtil.GetLogger().Info($"{guid} - AddAsync - respuesta : {respuesta}");
                    if (respuesta == 0) return new Response<int>("Existen facturas que no estan anotadas en cavally.");
                    else return new Response<int>(respuesta, "Actualizado Correctamente");
                }
            }
            catch (Exception ex)
            {
                LogUtil.GetLogger().Error($"{guid} - Error AddAsync - ex : {ex.ToJson()}");
                var message = ex.Message;
                return new Response<int>(message);
            }
        }
        public async Task<Response<int>> AddFacturaAsync(EvaluacionOperacionesInsertDto entity)
        {
            try
            {

                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Inserta_EstadoFactura";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                    parameters.Add("@p_nIdOperacionesFactura", entity.IdOperacionesFactura);
                    parameters.Add("@p_nIdCatalogoEstado", entity.IdCatalogoEstado);
                    parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                    parameters.Add("@p_cComentario", entity.Comentario);
                    parameters.Add("@p_TipoProceso", 0);
                    parameters.Add("@p_bRegistro", entity.bRegistro);
                    parameters.Add("@p_nIdEstadoFactura", DbType.String, direction: ParameterDirection.Output);
                    await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    int respuesta = parameters.Get<int>("p_nIdEstadoFactura");
                    if (respuesta == 0) return new Response<int>("Existen facturas que no estan anotadas en cavally.");
                    else return new Response<int>(respuesta, "Actualizado Correctamente");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new Response<int>(message);
            }

        }

        public async Task<int> AddFacturaEvaluacionAsync(EvaluacionOperacionesInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_EvaluacionOperacionesFacturas";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                parameters.Add("@p_nIdOperacionesFactura", entity.IdOperacionesFactura);
                parameters.Add("@p_nIdCatalogoEstado", entity.IdCatalogoEstado);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_cComentario", entity.Comentario);
                parameters.Add("@p_TipoProceso", 0); //TIPO DE PROCESO DESDE PATFACTORING               
                parameters.Add("@p_nIdEvaluacionOperaciones", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_nIdEvaluacionOperaciones");

            }
        }

        public async Task<Response<int>> UpdateFacturaAsync(EvaluacionOperacionesCalculoInsertDto entity)
        {
            try
            {

                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Update_Calculos_Factura";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                    parameters.Add("@p_nIdOperacionesFactura", entity.IdOperacionesFactura);
                    parameters.Add("@p_nIdCatalogoEstado", entity.IdCatalogoEstado);
                    parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                    //parameters.Add("@p_dFecha", entity.cFecha);            
                    parameters.Add("@p_nIdEstadoFactura", DbType.String, direction: ParameterDirection.Output);
                    await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    int respuesta = parameters.Get<int>("p_nIdEstadoFactura");
                    if (respuesta == 0) return new Response<int>("Existen facturas que no estan anotadas en cavally.");
                    else return new Response<int>(respuesta, "Actualizado Correctamente");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new Response<int>(message);
            }

        }
        public async Task<Response<int>> GenerateCalculoFacturaAsync(EvaluacionOperacionesCalculoInsertDto entity)
        {
            try
            {

                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Generar_Calculo_Factura";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdOperaciones", entity.IdOperaciones);
                    parameters.Add("@p_nIdOperacionesFactura", entity.IdOperacionesFactura);
                    parameters.Add("@p_nIdCatalogoEstado", entity.IdCatalogoEstado);
                    parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                    parameters.Add("@p_dFecha", entity.cFecha);            
                    parameters.Add("@p_nIdEstadoFactura", DbType.String, direction: ParameterDirection.Output);
                    await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    int respuesta = parameters.Get<int>("p_nIdEstadoFactura");
                    if (respuesta == 0) return new Response<int>("Existen facturas que no estan anotadas en cavally.");
                    else return new Response<int>(respuesta, "Calculado Correctamente");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new Response<int>(message);
            }

        }

        //EvaluacionOperacionesCalculoInsertDto

    }
}