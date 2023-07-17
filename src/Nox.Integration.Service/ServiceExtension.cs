using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Executor;
using Nox.Integration.Store;

namespace Nox.Integration.Service;

public static class ServiceExtension
{
    public static IServiceCollection AddIntegration(this IServiceCollection services)
    {
        services
            .AddDbContext<IntegrationContext>(opt =>
            {
                
            })
            .AddSingleton<IIntegrationSourceFactory, IntegrationSourceFactory>()
            .AddSingleton<IIntegrationTargetFactory, IntegrationTargetFactory>()
            .AddSingleton<IIntegrationExecutor, IntegrationExecutor>();
        return services;
    }
}