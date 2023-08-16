using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Application.Behaviors;
using Nox.Factories;
using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxLib(this IServiceCollection services, Assembly entryAssembly)
    {
        var allAssemblies =
            entryAssembly!.GetReferencedAssemblies();

        // Nox + Entry Assembly
        var noxAssemblies = allAssemblies
            .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
            .Select(Assembly.Load)
            .Union(new[] { entryAssembly! }).ToArray();

        return services
            .AddSingleton(typeof(NoxSolution), CreateSolution)
            .AddSecretsResolver()
            .AddNoxMediatR(entryAssembly)
            .AddNoxTypesDatabaseConfigurator(noxAssemblies)
            .AddNoxFactories(noxAssemblies)
            .AddAutoMapper(entryAssembly);
    }

    private static IServiceCollection AddNoxMediatR(
        this IServiceCollection services,
        Assembly entryAssembly)
    {
        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(entryAssembly);
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>)); //Validation Extensibility
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
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

    private static IServiceCollection AddNoxFactories(
        this IServiceCollection services,
        Assembly[] noxAssemblies)
    {
        services.Scan(scan =>
          scan.FromAssemblies(noxAssemblies)
          .AddClasses(classes => classes.AssignableTo(typeof(IEntityMapper<>)))
          .AsImplementedInterfaces()
          .WithSingletonLifetime());

        services.Scan(scan =>
         scan.FromAssemblies(noxAssemblies)
         .AddClasses(classes => classes.AssignableTo(typeof(IEntityFactory<,>)))
         .AsImplementedInterfaces()
         .WithSingletonLifetime());

        // Register as open generic
        services.AddSingleton(typeof(IEntityFactory<,>), typeof(EntityFactory<,>));



        services.Scan(scan =>
          scan.FromAssemblies(noxAssemblies)
          .AddClasses(classes => classes.AssignableTo(typeof(INoxTypeFactory<>)))
          .AsImplementedInterfaces()
          .WithSingletonLifetime());

        return services;
    }

    private static IServiceCollection AddNoxTypesDatabaseConfigurator(
        this IServiceCollection services,
        Assembly[] noxAssemblies)
    {
        services.Scan(scan => scan
            .FromAssemblies(noxAssemblies)
            .AddClasses(classes => classes.AssignableTo<INoxTypeDatabaseConfigurator>())
            .As<INoxTypeDatabaseConfigurator>()
            .WithSingletonLifetime());

        return services;
    }
}