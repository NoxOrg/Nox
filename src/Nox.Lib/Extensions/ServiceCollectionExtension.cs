using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Helpers;
using Nox.Secrets.Providers;
using Nox.Solution;

namespace Nox;

public static class ServiceCollectionExtension
{
    private static NoxSolution? _solution;
    private static IServiceCollection? _interimServices;

    public static NoxSolution Solution
    {
        get
        {
            if (_solution == null) CreateSolution();
            return _solution!;
        }
    }
    
    public static IServiceCollection AddNoxLib(this IServiceCollection services)
    {
        services.AddSecretsResolver();
        _interimServices = services;
        services.AddSingleton(Solution);
        return services;
    }

    private static void CreateSolution()
    {
        _solution = new NoxSolutionBuilder()
            .OnResolveSecrets((_, args) =>
            {
                var yaml = args.Yaml;
                var secretsConfig = args.SecretsConfiguration;
                var secretKeys = SecretExtractor.Extract(yaml);
                var interimServiceProvider = _interimServices!.BuildServiceProvider();
                var resolver = interimServiceProvider.GetRequiredService<ISecretsResolver>();
                resolver.Configure(secretsConfig!, Assembly.GetEntryAssembly());
                args.Secrets = resolver.Resolve(secretKeys!);
            })
            .Build();
    }

}