using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxLib(this IServiceCollection services)
    {
        
        return services
            .AddSingleton(typeof(NoxSolution),CreateSolution)
            .AddSecretsResolver()
            .AddNoxTypesDatabaseConfigurator();
    }

    private static NoxSolution CreateSolution(IServiceProvider serviceProvider)
    {
        return new NoxSolutionBuilder()
            .OnResolveSecrets((_, args) =>
            {
                var yaml = args.Yaml;
                var secretsConfig = args.SecretsConfiguration;
                var secretKeys = SecretExtractor.Extract(yaml);
                var resolver = serviceProvider.GetRequiredService<INoxSecretsResolver>();
                resolver.Configure(secretsConfig!, Assembly.GetEntryAssembly());
                args.Secrets = resolver.Resolve(secretKeys!);
            })
            .Build();
    }

    internal static IServiceCollection AddSecretsResolver(this IServiceCollection services)
    {
        services.AddPersistedSecretStore();
        services.TryAddSingleton<INoxSecretsResolver, NoxSecretsResolver>();
        return services;
    }
 
    internal static IServiceCollection AddPersistedSecretStore(this IServiceCollection services)
    {
        services.AddDataProtection();
        services.AddSingleton<IPersistedSecretStore, PersistedSecretStore>();
        return services;
    }

    internal static IServiceCollection AddNoxTypesDatabaseConfigurator(this IServiceCollection services)
    {
       // TODO Scan and register Configurators
        return services;
    }
}