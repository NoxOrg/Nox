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

    
    
    

    public static UserSecretsProvider AddUserSecretResolver(this IServiceCollection services, Assembly executingAssembly)
    {
        var resolver = new UserSecretsProvider(executingAssembly);
        services.AddSingleton<ISecretsProvider>(resolver);
        return resolver;
    }
}