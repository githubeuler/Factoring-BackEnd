using Dapper;
using Factoring.Application.DTOs.Aceptante;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Persistence.Repositories
{
    public class AceptanteRepositoryAsync : IAceptanteRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public AceptanteRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<AceptanteGetByIdDto> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Consulta_Adquiriente_Edicion";
            var parameters = new DynamicParameters();
            parameters.Add("@p_nIdAdquiriente", id);
            var adquiriente = await connection.QueryFirstOrDefaultAsync<AceptanteGetByIdDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return adquiriente;

        }
        public async Task DeleteAsync(AdquirienteDeleteDto entity)
        {
            try
            {
                using var connection = _connectionFactory.GetConnection;
                var query = "pe_Elimina_Adquiriente";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdAdquiriente", entity.IdAdquiriente);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<int>> UpdateAsync(AdquirienteUpdateDto entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Actualiza_Aceptante";
            var parameters = new DynamicParameters();
            parameters.Add("@p_nIdAdquiriente", entity.IdAdquiriente);
            parameters.Add("@p_nIdPais", entity.IdPais);
            parameters.Add("@p_cRegUnicoEmpresa", entity.RegUnicoEmpresa);
            parameters.Add("@p_cRazonSocial", entity.RazonSocial);
            parameters.Add("@p_nIdSector", entity.IdSector);
            parameters.Add("@p_nIdGrupoEconomico", entity.IdGrupoEconomico);
            parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
            parameters.Add("@p_nDescMensaje", null, DbType.String, direction: ParameterDirection.Output, size: 250);
            parameters.Add("@p_nIdAdquiriente", DbType.Int32, direction: ParameterDirection.ReturnValue);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            int IdGirador = parameters.Get<int>("p_nIdAdquiriente");
            if (parameters.Get<int>("p_nIdAdquiriente") == 0) return new Response<int>(parameters.Get<string>("p_nDescMensaje"));
            else return new Response<int>(parameters.Get<int>("p_nIdAdquiriente"), parameters.Get<string>("p_nDescMensaje"));
        }
    }
}
