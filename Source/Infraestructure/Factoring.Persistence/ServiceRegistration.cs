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
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IOperacionesRepositoryAsync, OperacionesRepositoryAsync>();
            services.AddTransient<IAdquirienteRepositoryAsync, AdquirienteRepositoryAsync>();
            services.AddTransient<IGiradorRepositoryAsync, GiradorRepositoryAsync>();
            services.AddTransient<IOperacionesFacturaRepositoryAsync, OperacionesFacturaRepositoryAsync>();
            #endregion Repositories
        }
    }
}
