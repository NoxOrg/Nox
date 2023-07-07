using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Resolvers;

namespace Nox.Secrets;

public static class ServiceExtensions
{
    public static IServiceCollection AddPersistedSecretStore(this IServiceCollection services)
    {
        services.AddDataProtection();
        services.AddSingleton<IPersistedSecretStore, PersistedSecretStore>();
        return services;
    }

    public static IServiceCollection AddAzureSecretResolver(this IServiceCollection services, string vaultUrl)
    {
        var resolver = new AzureSecretResolver(vaultUrl);
        services.AddSingleton<ISecretResolver>(resolver);
        return services;
    }

    public static UserSecretResolver AddUserSecretResolver(this IServiceCollection services, Assembly executingAssembly)
    {
        var resolver = new UserSecretResolver(executingAssembly);
        services.AddSingleton<ISecretResolver>(resolver);
        return resolver;
    }
}