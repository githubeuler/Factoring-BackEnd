using Dapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class AdquirienteRepositoryAsync : IAdquirienteRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public AdquirienteRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Response<int>> AddAsync(AdquirienteInsertDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_Adquiriente";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdPais", entity.IdPais);
                parameters.Add("@p_cRegUnicoEmpresa", entity.RegUnicoEmpresa);
                parameters.Add("@p_cRazonSocial", entity.RazonSocial);
                parameters.Add("@p_nIdSector", entity.IdSector);
                parameters.Add("@p_nIdGrupoEconomico", entity.IdGrupoEconomico);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                //parameters.Add("@p_nIdAdquiriente", DbType.String, direction: ParameterDirection.Output);
                parameters.Add("@p_nDescMensaje", null, DbType.String, direction: ParameterDirection.Output, size: 250);
                parameters.Add("@p_nIdAdquiriente", DbType.Int32, direction: ParameterDirection.ReturnValue);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                //return parameters.Get<int>("p_nIdAdquiriente");
                int IdGirador = parameters.Get<int>("p_nIdAdquiriente");
                if (parameters.Get<int>("p_nIdAdquiriente") == 0) return new Response<int>(parameters.Get<string>("p_nDescMensaje"));
                else return new Response<int>(parameters.Get<int>("p_nIdAdquiriente"), parameters.Get<string>("p_nDescMensaje"));
            }
        }

        public async Task<IReadOnlyList<AdquirienteResponseDataTable>> GetListAdquiriente(AdquirienteRequestDataTable model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Adquiriente";
                var parameters = new DynamicParameters();
                parameters.Add("@Pageno", model.Pageno);
                parameters.Add("@filter_cRuc", model.FilterRuc);
                parameters.Add("@filter_cRazon", model.FilterRazon);
                parameters.Add("@filter_IdPais", model.FilterIdPais == 0 ? null : model.FilterIdPais);
                parameters.Add("@filter_FecCrea", model.FilterFecCrea);
                parameters.Add("@filter_IdSector", model.FilterIdSector == 0 ? null : model.FilterIdSector);
                parameters.Add("@filter_IdGrupoEconomico", model.FilterIdGrupoEconomico == 0 ? null : model.FilterIdGrupoEconomico);
                parameters.Add("@pagesize", model.PageSize);
                parameters.Add("@Sorting", model.Sorting);
                parameters.Add("@SortOrder", model.SortOrder);

                var adquirienteList = await connection.QueryAsync<AdquirienteResponseDataTable>(query, parameters, commandType: CommandType.StoredProcedure);
                return adquirienteList.AsList();
            }
        }

        public async Task<IReadOnlyList<AdquirienteResponseLista>> GetListaAdquiriente()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_Adquiriente_Combo";

                var adList = await connection.QueryAsync<AdquirienteResponseLista>(query, null, commandType: CommandType.StoredProcedure);
                return adList.AsList();
            }
        }
    }
}
