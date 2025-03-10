﻿using Dapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Fondeador.ControlFileFondeador;
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
    public class FondeadorRepositoryAsync : IFondeadorRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public FondeadorRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IReadOnlyList<FondeadorResponseDataTable>> GetListFondeador(FondeadorRequestDataTable model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Fondeador_v2";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@filter_cDoi", model.FilterDoi);
                parameters.Add("@filter_cRazon", model.FilterRazon);
                parameters.Add("@filter_FecCrea", model.FilterFecCrea);
                parameters.Add("@usuario", model.Usuario);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);
                parameters.Add("@IdEstado", model.IdEstado);

                var fondeadorList = await connection.QueryAsync<FondeadorResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return fondeadorList.AsList();
            }
        }
        public async Task<int> AddAsync(FondeadorInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_Fondeador";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iTipoDocumento", entity.IdDocumento);
                parameters.Add("@p_cNroDocumento", entity.NroDocumento);
                parameters.Add("@p_cNombreFondeador", entity.NombreFondeador);
                //parameters.Add("@p_iTipoNegocio", entity.IdTipoNegocio);
                //parameters.Add("@p_iPais", entity.IdPais);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_iIdFondeador", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_iIdFondeador");
            }
        }
        public async Task DeleteAsync(FondeadorDeleteDto entity)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_Elimina_Fondeador";
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_nIdFondeador", entity.IdFondeador);
                    parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                    await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateAsync(FondeadorUpdateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Actualiza_Fondeador";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeador", entity.IdFondeador);
                parameters.Add("@p_iIdPais", entity.IdPais);
                parameters.Add("@p_iTipoDocumento", entity.TipoDocumento);
                parameters.Add("@p_cNroDocumento", entity.NroDocumento);
                parameters.Add("@p_cNombreFondeador", entity.NombreFondeador);
                parameters.Add("@p_iIdTipoNegocio", entity.IdTipoNegocio);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                parameters.Add("@p_iIdProducto", entity.IdProducto);
                parameters.Add("@p_iIdInteresCalculado", entity.IdInteresCalculado);
                parameters.Add("@p_iIdTipoFondeo", entity.IdTipoFondeo);
                parameters.Add("@p_cDistribucionFondeador", entity.DistribucionFondeador);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<FondeadorGetByIdDto> GetByIdAsync(int id)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Fondeador_Edicion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdFondeador", id);
                var girador = await connection.QueryFirstOrDefaultAsync<FondeadorGetByIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return girador;
            }

        }


        public async Task<IReadOnlyList<FondeadorGetAllDto>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultaFondeadores";
                var fondeador = await connection.QueryAsync<FondeadorGetAllDto>(query, param: null, commandType: CommandType.StoredProcedure);
                return fondeador.AsList();
            }
        }
        public async Task<IReadOnlyList<FileExportFondeadorResponseDto>> GetListFileExport(FileExportFondeadorRequestDto request)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FondeadorExportar";
                var parameters = new DynamicParameters();
                parameters.Add("@filter_cDoi", request.Doi);
                parameters.Add("@filter_cRazon", request.Razon);
                parameters.Add("@filter_FecCrea", request.FechaCreacion);

                var list = await connection.QueryAsync<FileExportFondeadorResponseDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return list.AsList();
            }
        }

        public async Task<IReadOnlyList<FondeadorGetByIdDto>> GetByTipoFondeoAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FondeadorByTipoFondeo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_TipoFondeo", id);
                var girador = await connection.QueryAsync<FondeadorGetByIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return girador.AsList();
            }
        }
    }
}
