using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Lib;
using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxLib(this IServiceCollection services, Assembly entryAssembly)
    {
        return services
            .AddSingleton(typeof(NoxSolution), CreateSolution)
            .AddSecretsResolver()
            .AddNoxMediatR(entryAssembly)
            .AddNoxTypesDatabaseConfigurator(entryAssembly)
            .AddAutoMapper(entryAssembly);
    }

    private static IServiceCollection AddNoxMediatR(this IServiceCollection services, Assembly entryAssembly)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(entryAssembly));
    }

    private static NoxSolution CreateSolution(IServiceProvider serviceProvider)
    {
        return new NoxSolutionBuilder()
            .OnResolveSecrets((_, args) =>
            {
                var secretsConfig = args.SecretsConfig;
                var secretKeys = args.Variables;
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

    private static IServiceCollection AddNoxTypesDatabaseConfigurator(this IServiceCollection services,
        Assembly entryAssembly)
    {
        var allAssemblies =
            entryAssembly!.GetReferencedAssemblies();

        // Nox + Entry Assembly
        var noxAssemblies = allAssemblies
            .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
            .Select(Assembly.Load)
            .Union(new[] { Assembly.GetEntryAssembly()! });

        services.Scan(scan => scan
            .FromAssemblies(noxAssemblies)
            .AddClasses(classes => classes.AssignableTo<INoxTypeDatabaseConfigurator>())
            .As<INoxTypeDatabaseConfigurator>()
            .WithSingletonLifetime());
        return services;
    }
}