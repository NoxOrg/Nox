using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Store;
using Nox.Integration.Store.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Service;

public static class ServiceExtension
{
    public static IServiceCollection AddIntegration(this IServiceCollection services, IntegrationDatabaseServer dbServer)
    {
        services
            .AddSingleton<IIntegrationSourceFactory, IntegrationSourceFactory>()
            .AddSingleton<IIntegrationTargetFactory, IntegrationTargetFactory>()
            .AddSingleton<IIntegrationExecutor, IntegrationExecutor>()
            .AddSingleton<IStoreService, StoreService>();

        switch (dbServer.Provider)
        {
            case DatabaseServerProvider.SqlServer:
                services.AddSqlServerIntegrationStore(dbServer);
                break;
            default:
                throw new NotImplementedException();
        }

        return services;
    }
}