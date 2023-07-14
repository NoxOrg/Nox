using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.IntegrationSource.File;
using Nox.Solution;

namespace Nox.Integration.Executor;

public static class ServiceExtension
{
    public static IServiceCollection AddIntegration(this IServiceCollection services)
    {
        services.AddSingleton<IIntegrationSourceFactory, IntegrationSourceFactory>();
        services.AddSingleton<IIntegrationExecutor, IntegrationExecutor>();
        return services;
    }
}