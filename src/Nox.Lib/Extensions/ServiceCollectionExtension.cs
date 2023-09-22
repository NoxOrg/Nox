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
using Azure;

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
            .AddNoxDtos();           
    }
    
    public static IServiceCollection AddNoxMessaging<T>(this IServiceCollection services, DatabaseServerProvider databaseServerProvider) where T: DbContext
    {
        services.AddScoped<IOutboxRepository, OutboxRepository>();
        services.AddMassTransit(x =>
        {            
            x.AddEntityFrameworkOutbox<T>(o =>
            {
                switch (databaseServerProvider)
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

            // TODO Configure according to NoSolution
            x.UsingAzureServiceBus((context, cfg) =>
            {
                // TODO Get Server config from Nox.Solution
                //cfg.Host("...");

                cfg.ConfigureEndpoints(context);

                // TODO Cloud Events Raw message?
                cfg.UseRawJsonSerializer(RawSerializerOptions.AddTransportHeaders | RawSerializerOptions.CopyHeaders | RawSerializerOptions.AnyMessageType);
                
                // TODO Define rules for Topics names
                cfg.Message<CloudEventRecord<Application.IIntegrationEvent>>(x =>
                {
                    x.SetEntityName("test-integration-event");
                });                
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