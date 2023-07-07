using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Providers;
using Nox.Secrets.Resolvers;
using Nox.Solution;

namespace Nox.Secrets;

public static class ServiceExtensions
{
    public static IServiceCollection AddPersistedSecretStore(this IServiceCollection services)
    {
        services.AddDataProtection();
        services.AddSingleton<IPersistedSecretStore, PersistedSecretStore>();
        return services;
    }

    public static IServiceCollection AddAzureSecretResolver(this IServiceCollection services, SecretsServer serverConfig)
    {
        var provider = new AzureSecretsProvider(serverConfig.ServerUri);
        services.AddSingleton<ISecretsProvider>(provider);
        services.AddSingleton(serviceProvider =>
        {
            var store = serviceProvider.GetRequiredService<IPersistedSecretStore>();
            return new AzureSecretsResolver(store, serverConfig);
        });
        return services;
    }

    public static UserSecretsProvider AddUserSecretResolver(this IServiceCollection services, Assembly executingAssembly)
    {
        var resolver = new UserSecretsProvider(executingAssembly);
        services.AddSingleton<ISecretsProvider>(resolver);
        return resolver;
    }
}