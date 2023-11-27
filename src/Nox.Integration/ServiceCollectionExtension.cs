using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Integration.Abstractions;
using Nox.Integration.Services;
using Microsoft.Extensions.Logging;
using Nox.Solution;

namespace Nox.Integration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxIntegrations(this IServiceCollection services, NoxSolution solution)
    {
        services.TryAddSingleton<INoxIntegrationContext, NoxIntegrationContext>();
        
        return services;
    }

    public static IServiceCollection RegisterTransformHandler(this IServiceCollection services, Type handlerType)
    {
        services.AddTransient(typeof(INoxCustomTransformHandler), handlerType);
        return services;
    }
}