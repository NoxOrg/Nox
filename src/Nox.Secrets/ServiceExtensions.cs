using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Providers;
using Nox.Secrets.Resolvers;
using Nox.Solution;

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
        services.TryAddSingleton<ISecretsResolver, SecretsResolver>();
        return services;
    }
}