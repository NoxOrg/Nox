using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.Application.Behaviors;
using Nox.Application.Providers;
using Nox.Factories;
using Nox.Messaging;
using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

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
            .AddNoxMediatR(entryAssembly, noxAssemblies)
            .AddNoxTypesDatabaseConfigurator(noxAssemblies)
            .AddNoxFactories(noxAssemblies)
            .AddAutoMapper(entryAssembly)
            .AddNoxProviders()
            .AddNoxDtos()
            .AddMessaging();
        

    }
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddSingleton<IMessageOutbox, MessageOutbox>();

        /*Move to Generated WebServiceCollection to use Solution to define the Type of Bud*/
        services.AddMassTransit(x =>
        {        
            x.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
        

        return services;
    }
    private static IServiceCollection AddNoxMediatR(
        this IServiceCollection services,
        Assembly entryAssembly,
        Assembly[] noxAssemblies)
    {
        // Register all Behaviors - Filtering for example
        services.Scan(scan =>
          scan.FromAssemblies(entryAssembly)
          .AddClasses(classes => classes
                .AssignableTo(typeof(IPipelineBehavior<,>))
                .Where(c => !c.ContainsGenericParameters) // Skip Open Generics
           )
          .AsImplementedInterfaces()
          .WithSingletonLifetime());

        // Register Command Validators, 
        services.Scan(scan =>
          scan.FromAssemblies(entryAssembly)
          .AddClasses(classes => classes
                .AssignableTo(typeof(IValidator<>))
                .Where(c => !c.ContainsGenericParameters) // Skip Open Generics
           )
          .AsImplementedInterfaces(i=> i.IsAssignableTo(typeof(IValidator)) && i.GenericTypeArguments.Any())
          .WithSingletonLifetime());

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
           .AddClasses(classes => classes.AssignableTo(typeof(IEntityFactory<,>)))
           .AsImplementedInterfaces()
           .WithSingletonLifetime());

        services.Scan(scan =>
          scan.FromAssemblies(noxAssemblies)
          .AddClasses(classes => classes.AssignableTo(typeof(IEntityMapper<>)))
          .AsImplementedInterfaces()
          .WithSingletonLifetime());

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

    private static IServiceCollection AddNoxProviders(
        this IServiceCollection services)
    {
        services.AddScoped<IUserProvider, DefaultUserProvider>();
        services.AddScoped<ISystemProvider, DefaultSystemProvider>();

        return services;
    }

    private static IServiceCollection AddNoxDtos(
       this IServiceCollection services)
    {
        // For now we do not need a specific database provider
        services.AddSingleton<INoxDtoDatabaseConfigurator, NoxDtoDatabaseConfigurator>();

        return services;
    }
}