using Dapper;
using Factoring.Application.DTOs.ContactoAceptante;
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
    public class AceptanteContactoRepositoryAsync : IAceptanteContactoRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;
        public AceptanteContactoRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddAsync(ContactoAdquirienteCreateDto entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Inserta_AceptanteContacto";
            var parameters = new DynamicParameters();
            parameters.Add("@p_cNombre", entity.Nombre);
            parameters.Add("@p_cApellidoPaterno", entity.ApellidoPaterno);
            parameters.Add("@p_cApellidoMaterno", entity.ApellidoMaterno);
            parameters.Add("@p_cCelular", entity.Celular);
            parameters.Add("@p_cEmail", entity.Email);
            parameters.Add("@p_nIdAdquiriente", entity.IdAdquiriente);
            parameters.Add("@p_nIdTipoContacto", entity.IdTipoContacto);
            parameters.Add("@p_nIdAdquirienteContacto", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("p_nIdAdquirienteContacto");
        }
        public async Task DeleteAsync(ContactoAdquirienteDeleteDto entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Elimina_AceptanteContacto";
            var parameters = new DynamicParameters();
            parameters.Add("@p_nIdAdquirienteContacto", entity.IdAdquirienteContacto);
            parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
            await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IReadOnlyList<ContactoAdquirienteResponseListDto>> GetAllContactoByIdAdquiriente(int id)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "pe_Consulta_AceptanteContacto";
            var parameters = new DynamicParameters();
            parameters.Add("@p_nIdAdquiriente", id);
            var products = await connection.QueryAsync<ContactoAdquirienteResponseListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return products.AsList();
        }
    }
}