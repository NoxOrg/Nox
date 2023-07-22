using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Store;
using Nox.Solution;

namespace Nox.Integration.Service;

public static class ServiceExtension
{
    public static IServiceCollection AddIntegration(this IServiceCollection services, Action<StoreOptionsBuilder>? optionsAction = null)
    {
        services
            .AddSingleton<IIntegrationSourceFactory, IntegrationSourceFactory>()
            .AddSingleton<IIntegrationTargetFactory, IntegrationTargetFactory>()
            .AddSingleton<IIntegrationExecutor, IntegrationExecutor>()
            .AddSingleton<IStoreService, StoreService>();
        optionsAction?.Invoke(new StoreOptionsBuilder());
        return services;
    }
}