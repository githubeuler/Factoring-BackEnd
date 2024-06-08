using Dapper;
using Factoring.Application.DTOs.EvaluacionOperaciones;
//using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
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

    public async Task<Response<int>> AddAsync(EvaluacionOperacionesInsertDto entity)
    {
        try
        {
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


        //EvaluacionOperacionesCalculoInsertDto

    }
}