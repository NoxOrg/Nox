using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Providers;

namespace Nox.Secrets;

public static class ServiceExtensions
{
    public static IServiceCollection AddPersistedSecretStore(this IServiceCollection services)
    {
        services.AddDataProtection();
        services.AddSingleton<IPersistedSecretStore, PersistedSecretStore>();
        return services;
    }

    public static IServiceCollection AddAzureSecretProvider(this IServiceCollection services, string vaultUrl)
    {
        var provider = new AzureSecretProvider(vaultUrl);
        services.AddSingleton<ISecretProvider>(provider);
        return services;
    }

    public static IServiceCollection AddUserSecretProvider(this IServiceCollection services, Assembly executingAssembly)
    {
        var provider = new UserSecretProvider(executingAssembly);
        services.AddSingleton<ISecretProvider>(provider);
        return services;
    }
}