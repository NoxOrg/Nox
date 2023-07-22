using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Store;
using Nox.Solution;

namespace Nox.Integration.Service;

public static class ServiceExtension
{
    public static IServiceCollection AddIntegration(this IServiceCollection services, IntegrationDatabaseServer serverConfiguration, Action<StoreOptionsBuilder> optionsAction)
    {
        services
            .AddSingleton<IIntegrationSourceFactory, IntegrationSourceFactory>()
            .AddSingleton<IIntegrationTargetFactory, IntegrationTargetFactory>()
            .AddSingleton<IIntegrationExecutor, IntegrationExecutor>()
            .AddSingleton<IStoreService, StoreService>();
        var optionsBuilder = new StoreOptionsBuilder(services, serverConfiguration);
        optionsAction?.Invoke(optionsBuilder); 
        return services;
    }
}