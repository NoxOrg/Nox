using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.Secrets.Abstractions;

namespace Nox.Secrets;

public static class ServiceExtensions
{
    internal static IServiceCollection AddPersistedSecretStore(this IServiceCollection services)
    {
        services.AddDataProtection();
        services.AddSingleton<IPersistedSecretStore, PersistedSecretStore>();
        return services;
    }

    public static IServiceCollection AddSecretsResolver(this IServiceCollection services)
    {
        services.AddPersistedSecretStore();
        services.TryAddSingleton<INoxSecretsResolver, NoxSecretsResolver>();
        return services;
    }
}