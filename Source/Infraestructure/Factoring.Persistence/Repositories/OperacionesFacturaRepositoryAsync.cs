using Dapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
//using Factoring.Application.DTOs.Equifax;
//using Factoring.Application.DTOs.Operaciones.OperacionesLote;
//using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;

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

       

    }
}