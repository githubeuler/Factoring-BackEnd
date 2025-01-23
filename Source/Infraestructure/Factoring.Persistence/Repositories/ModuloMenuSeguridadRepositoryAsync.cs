using Dapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Interfaces.Repositories;
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
    public class ModuloMenuSeguridadRepositoryAsync: IModuloMenuSeguridadRepositoryAsync
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
                parameters.Add("@Pageno", nRol);
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
    }
}
