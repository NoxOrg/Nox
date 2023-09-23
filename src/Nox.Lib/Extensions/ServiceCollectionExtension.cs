using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Microsoft.CodeAnalysis;
using Nox.Messaging.AzureServiceBus;

namespace Nox;

public static class ServiceCollectionExtension
{
    public static NoxSolution AddNoxLib(this IServiceCollection services, Assembly entryAssembly)
    {
        var allAssemblies =
            entryAssembly!.GetReferencedAssemblies();

        // Nox + Entry Assembly
        var noxAssemblies = allAssemblies
            .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
            .Select(Assembly.Load)
            .Union(new[] { entryAssembly! }).ToArray();

        var noxSolution = CreateSolution(services.BuildServiceProvider());
        services
            .AddSingleton(typeof(NoxSolution), noxSolution)
            .AddSecretsResolver()
            .AddNoxMediatR(entryAssembly, noxAssemblies)
            .AddNoxTypesDatabaseConfigurator(noxAssemblies)
            .AddNoxFactories(noxAssemblies)
            .AddAutoMapper(entryAssembly)
            .AddNoxProviders()
            .AddNoxDtos();

        // Opted by returning Solution to avoid resolving it by the container in the registration phase
        return noxSolution;
    }

    public static IServiceCollection TryAddNoxMessaging<T>(this IServiceCollection services, NoxSolution noxSolution) where T : DbContext
    {
        if (noxSolution.Infrastructure?.Messaging?.IntegrationEventServer is null)
        {
            return services;
        }

        MessagingServer messagingConfig = noxSolution.Infrastructure.Messaging.IntegrationEventServer;

        services.AddScoped<IOutboxRepository, OutboxRepository>();
        services.AddMassTransit(x =>
        {
            if (noxSolution.Infrastructure?.Persistence is { DatabaseServer: not null })
            {
                x.AddEntityFrameworkOutbox<T>(o =>
                {                    
                    switch (noxSolution.Infrastructure.Persistence.DatabaseServer.Provider)
                    {
                        case DatabaseServerProvider.MySql:
                            o.UseMySql();
                            break;
                        case DatabaseServerProvider.SqlServer:
                            o.UseSqlServer();
                            break;
                        case DatabaseServerProvider.Postgres:
                            o.UsePostgres();
                            break;
                        case DatabaseServerProvider.SqLite:
                            o.UseSqlite();
                            break;
                        default:
                            throw new NotImplementedException();
                    };

                    //We do not need to clean up the inbox, not being used
                    o.DisableInboxCleanupService();

                    //Disable message delivery
                    //o.UseBusOutbox(c=>c.DisableDeliveryService());
                    // enable the bus outbox
                    o.UseBusOutbox();
                });
            }

            IMessageBrokerProvider messageBrokerProvider = messagingConfig.Provider switch
            {
                MessageBrokerProvider.AzureServiceBus => new AzureServiceBusBrokerProvider(),
                MessageBrokerProvider.InMemory => new InMemoryBrokerProvider(),
                //MessageBrokerProvider.RabbitMq => throw new NotImplementedException(),
                //MessageBrokerProvider.AmazonSqs => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };           
            messageBrokerProvider.ConfigureMassTransit(messagingConfig, x);
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
          .AsImplementedInterfaces(i => i.IsAssignableTo(typeof(IValidator)) && i.GenericTypeArguments.Any())
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
           .AddClasses(classes => classes.AssignableTo(typeof(IEntityFactory<,,>)))
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