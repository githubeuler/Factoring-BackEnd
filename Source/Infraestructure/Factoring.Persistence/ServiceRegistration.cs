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
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            #endregion Repositories
        }
    }
}
