using Dapper;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Domain.Entities;
using Factoring.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class ModuloMenuSeguridadRepositoryAsync : IModuloMenuSeguridadRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;
        public ModuloMenuSeguridadRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyList<MenuAccionesResponseDto>> GetListNenuModulo(int nRol)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultarModuloMenu";
                var parameters = new DynamicParameters();
                parameters.Add("@nIdRol", nRol);
                var fondeadorList = await connection.QueryAsync<MenuAccionesResponseDto>(query, parameters, commandType: CommandType.StoredProcedure);
                return fondeadorList.AsList();
            }
        }

        public async Task<IReadOnlyList<PerfilResponseDto>> GetListRol(PerfilRequestDto model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultaRol";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);
                parameters.Add("@cNombrePerfil", model.cNombrePerfil);
                var fondeadorList = await connection.QueryAsync<PerfilResponseDto>(query, parameters, commandType: CommandType.StoredProcedure);
                return fondeadorList.AsList();
            }
        }
        public async Task<int> AddAsync(ModuloDTO entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_RegistrarRolesMenu";
            var parameters = new DynamicParameters();
            parameters.Add("@nIdRol", entity.nIdRol);
            parameters.Add("@cRol", entity.cRol);
            //parameters.Add("@nIdMenu", entity.nIdMenu);
            //parameters.Add("@filter_Acciones", entity.filter_Acciones);
            parameters.Add("@p_nIdRolOutput", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("p_nIdRolOutput");
        }

        public async Task<PerfilResponseEditDto> GetListRolEdit(int nIdRol)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_ConsultaRoles";
                var parameters = new DynamicParameters();
                parameters.Add("@nIdRol", nIdRol);
                var fondeadorList = await connection.QueryFirstAsync<PerfilResponseEditDto>(query, parameters, commandType: CommandType.StoredProcedure);
                return fondeadorList;
            }
        }
        public async Task<int> UpdateAsync(int nIdRol)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_UpdateRolMenu";
            var parameters = new DynamicParameters();
            parameters.Add("@nIdRol", nIdRol);
            parameters.Add("@p_nIdRolOutput", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("p_nIdRolOutput");
        }

        public async Task<IReadOnlyList<AccionesResponseDto>> GetListAcciones(AccionesRequestDto model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "pe_ConsultaRolMenuAccion";
                    var parameters = new DynamicParameters();
                    parameters.Add("@nIdRol", model.nIdRol);
                    parameters.Add("@nIdMenu", model.nIdMenu);
                    var fondeadorList = await connection.QueryAsync<AccionesResponseDto>(query, parameters, commandType: CommandType.StoredProcedure);
                    return fondeadorList.AsList();
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
            }
            return null;
        }


        public async Task<int> AddAccionesAsync(ModuloNewDTO entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_RegistrarAccionesMenu";
            var parameters = new DynamicParameters();
            parameters.Add("@nIdMenu", entity.nIdMenu);
            parameters.Add("@nIdRol", entity.nIdRol);           
            parameters.Add("@filter_Acciones", entity.filter_Acciones);
            parameters.Add("@p_nIdRolOutput", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("p_nIdRolOutput");
        }
    }
}