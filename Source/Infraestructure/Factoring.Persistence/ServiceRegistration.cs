using Factoring.Application.Interfaces.Repositories;
using Factoring.Persistence.Data;
using Factoring.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Factoring.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient<IUsuarioRepositoryAsync, UsuarioRepositoryAsync>();
            services.AddTransient<ICatalogoRepositoryAsync, CatalogoRepositoryAsync>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IOperacionesRepositoryAsync, OperacionesRepositoryAsync>();
            services.AddTransient<IAdquirienteRepositoryAsync, AdquirienteRepositoryAsync>();
            services.AddTransient<IGiradorRepositoryAsync, GiradorRepositoryAsync>();
            services.AddTransient<IGiradorCategoriaRepositoryAsync, GiradorCategoriaRepositoryAsync>();
            services.AddTransient<IOperacionesFacturaRepositoryAsync, OperacionesFacturaRepositoryAsync>();
            services.AddTransient<IOperacionesRepositoryAsync, OperacionesRepositoryAsync>();
            services.AddTransient<IAdquirienteDireccionRepositoryAsync, AdquirienteDireccionRepositoryAsync>();
            services.AddTransient<IGiradorDireccionRepositoryAsync, GiradorDireccionRepositoryAsync>();
            #endregion Repositories
        }
    }
}
