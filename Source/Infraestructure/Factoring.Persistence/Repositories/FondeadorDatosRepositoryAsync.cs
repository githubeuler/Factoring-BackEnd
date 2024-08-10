using Dapper;
using Factoring.Application.Features.Fondeador.DatosFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using System.Data;

namespace Factoring.Persistence.Repositories
{
    public class FondeadorDatosRepositoryAsync : IFondeadorDatosRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;

        public FondeadorDatosRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(DatosFondeadorCreateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_FondeadorDatos";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdProducto", entity.IdProducto);
                parameters.Add("@p_nTasaFondeo", entity.TasaFondeo);
                parameters.Add("@p_nTasaMora", entity.TasaMora);
                parameters.Add("@p_iMoneda", entity.iMoneda);
                parameters.Add("@p_nCapitalFinanciado", entity.CapitalFinanciado);
                parameters.Add("@p_iMetodoCalculo", entity.IdMetodoCalculo);
                parameters.Add("@p_iDiaPago", entity.DiaPago);
                parameters.Add("@p_iModalidad", entity.IdModalidad);
                parameters.Add("@p_iRetencionInicialFondeador", entity.iRetencionInicialFondeador);
                parameters.Add("@p_cUsuarioCreador", entity.UsuarioCreador);
                parameters.Add("@p_iIdFondeador", entity.IdFondeador);
                parameters.Add("@p_iTipodeNegocio", entity.ITipodeNegocio);
                parameters.Add("@p_iCalculoInteres", entity.iCalculoInteres);
                parameters.Add("@p_iIdFondeadorDatos", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_iIdFondeadorDatos");
            }
        }
        public async Task<IReadOnlyList<DatosFondeadorResponseListDto>> GetAllDatosByIdFondeador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FondeadorDatos";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeador", id);

                var products = await connection.QueryAsync<DatosFondeadorResponseListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }
        public async Task DeleteAsync(DatosFondeadorDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_FondeadorDatos";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeadorDatos", entity.IdFondeadorDatos);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddPrestamoAsync(DatosFondeadorPrestamoCreateDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_FondeadorPrestamo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeador", entity.IdFondeadorCabecera);
                parameters.Add("@p_iIdProducto", entity.IdProductoPrestamo);
                parameters.Add("@p_iMoneda", entity.IdMonedaPrestamo);
                parameters.Add("@p_iModalidad", entity.IdModalidadPrestamo);
                parameters.Add("@p_nPorcentajeCapital", entity.nCapitalPrestamo);
                parameters.Add("@p_nPorcentajeInteres", entity.nInteresPrestamo);
                parameters.Add("@p_nPorcentajeInteresPG", entity.nInteresPeriodoGraciaPrestamo);
                parameters.Add("@p_bAplicaPorcentajeCapital", entity.bAplicanCapitalPrestamo);
                parameters.Add("@p_bAplicaPorcentajeInteres", entity.bAplicanInteresPrestamo);
                parameters.Add("@p_bAplicaPorcentajeInteresPG", entity.bAplicaInteresPeriodoGraciaPrestamo);
                parameters.Add("@p_cUsuario", entity.UsuarioCreador);
                parameters.Add("@p_iIdFondeadorPrestamo", DbType.String, direction: ParameterDirection.Output);
                await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("p_iIdFondeadorPrestamo");
            }
        }

        public async Task<IReadOnlyList<FondeadorPrestamoResponseListDto>> GetAllPrestamoByIdFondeador(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Consulta_FondeadorPrestamo_Edicion";
                var parameters = new DynamicParameters();
                parameters.Add("@p_nIdFondeador", id);

                var products = await connection.QueryAsync<FondeadorPrestamoResponseListDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return products.AsList();
            }
        }

        public async Task DeletePrestamoAsync(FondeadorPrestamoDeleteDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Elimina_FondeadorPrestamo";
                var parameters = new DynamicParameters();
                parameters.Add("@p_iIdFondeadorPrestamo", entity.iIdFondeadorPrestamo);
                parameters.Add("@p_cUsuarioActualizacion", entity.UsuarioActualizacion);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
