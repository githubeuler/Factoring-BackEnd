using Dapper;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class OperacionesRepositoryAsync: IOperacionesRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        public OperacionesRepositoryAsync(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
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
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);

                var operacionesList = await connection.QueryAsync<OperacionesResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return operacionesList.AsList();
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
    }
}
