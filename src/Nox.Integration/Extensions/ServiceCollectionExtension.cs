using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Integration.Abstractions;
using Nox.Integration.Services;

namespace Nox.Integration.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxIntegrations(this IServiceCollection services, Action<NoxIntegrationOptionsBuilder>? integrationOptionsAction = null)
    {
        services.TryAddSingleton<INoxIntegrationContext, NoxIntegrationContext>();
        services.TryAddSingleton<INoxIntegrationDbContextFactory, NoxIntegrationDbContextFactory>();
        services.AddDbContext<NoxIntegrationDbContext>();
        var optionsBuilder = new NoxIntegrationOptionsBuilder(services);
        integrationOptionsAction?.Invoke(optionsBuilder);
        return services;
    }

    public static IServiceCollection RegisterTransformHandler(this IServiceCollection services, Type handlerType)
    {
        services.AddTransient(typeof(INoxCustomTransformHandler), handlerType);
        return services;
    }
    
    public static IServiceCollection RegisterTransformHandler<THandler>(this IServiceCollection services) where THandler: INoxCustomTransformHandler
    {
        services.AddTransient(typeof(INoxCustomTransformHandler), typeof(THandler));
        return services;
    }
}