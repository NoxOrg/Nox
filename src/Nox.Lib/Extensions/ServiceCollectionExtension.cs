using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.Application.Providers;
using Nox.Factories;
using Nox.Messaging;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Nox.Messaging.AzureServiceBus;
using Nox.Configuration;
using FluentValidation;
using MediatR;
using Nox.Application.Behaviors;

namespace Nox;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxLib(this IServiceCollection services, Action<INoxBuilderConfigurator>? configure = null)
    {
        NoxBuilderConfigurator configurator = new();
        // Default service/entry assembly is the one calling this method
        configurator.SetClientAssembly(Assembly.GetCallingAssembly());
        configure?.Invoke(configurator);
        configurator.Configure(services);

        return services;
    }

    internal static IServiceCollection AddNoxFactories(this IServiceCollection services, Assembly[] noxAssemblies)
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
    internal static IServiceCollection AddNoxMediatR(this IServiceCollection services,Assembly serviceAssembly)
    {
        // Register all Behaviors - Filtering for example
        services.Scan(scan =>
          scan.FromAssemblies(serviceAssembly)
          .AddClasses(classes => classes
                .AssignableTo(typeof(IPipelineBehavior<,>))
                .Where(c => !c.ContainsGenericParameters) // Skip Open Generics
           )
          .AsImplementedInterfaces()
          .WithSingletonLifetime());

        // Register Command Validators, 
        services.Scan(scan =>
          scan.FromAssemblies(serviceAssembly)
          .AddClasses(classes => classes
                .AssignableTo(typeof(IValidator<>))
                .Where(c => !c.ContainsGenericParameters) // Skip Open Generics
           )
          .AsImplementedInterfaces(i => i.IsAssignableTo(typeof(IValidator)) && i.GenericTypeArguments.Any())
          .WithSingletonLifetime());

        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(serviceAssembly);
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>)); //Validation Extensibility
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
    }

    internal static IServiceCollection AddNoxProviders(this IServiceCollection services)
    {
        services.AddScoped<IUserProvider, DefaultUserProvider>();
        services.AddScoped<ISystemProvider, DefaultSystemProvider>();

        return services;
    }

    internal static IServiceCollection AddNoxDtos(this IServiceCollection services)
    {
        // For now we do not need a specific database provider
        services.AddSingleton<INoxDtoDatabaseConfigurator, NoxDtoDatabaseConfigurator>();

        return services;
    }
}