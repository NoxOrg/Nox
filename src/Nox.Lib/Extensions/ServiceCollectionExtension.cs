using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.Application.Behaviors;
using Nox.Application.Factories;
using Nox.Application.Providers;
using Nox.Configuration;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using System.Reflection;

namespace Nox;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// Use for testing without a WebApplicationBuilder
    /// Do not use directly on production code
    /// </summary>
    public static IServiceCollection AddNoxLib(this IServiceCollection services, Action<INoxOptions>? configure = null)
    {
        AddNoxLib(services, null, configure);
        return services;
    }

    public static IServiceCollection AddNoxLib(this IServiceCollection services, WebApplicationBuilder? webApplicationBuilder, Action<INoxOptions>? configure = null)
    {
        NoxOptions configurator = new();
        // Default service/entry assembly is the one calling this method
        configurator.WithClientAssembly(Assembly.GetCallingAssembly());
        configure?.Invoke(configurator);
        configurator.Configure(services, webApplicationBuilder);

        return services;
    }

    internal static IServiceCollection AddNoxFactories(this IServiceCollection services, Assembly[] noxAssemblies)
    {
        services.Scan(scan =>
           scan.FromAssemblies(noxAssemblies)
           .AddClasses(classes => classes.AssignableTo(typeof(IEntityFactory<,,>)))
           .AsImplementedInterfaces()
           .WithTransientLifetime());

        return services;
    }
    internal static IServiceCollection AddNoxMediatR(this IServiceCollection services, Assembly serviceAssembly)
    {
        // Register all Behaviors - Filtering for example
        services.Scan(scan =>
          scan.FromAssemblies(serviceAssembly)
          .AddClasses(classes => classes
                .AssignableTo(typeof(IPipelineBehavior<,>))
                .Where(c => !c.ContainsGenericParameters) // Skip Open Generics
           )
          .AsImplementedInterfaces()
          .WithTransientLifetime());

        // Register Command Validators, 
        services.Scan(scan =>
          scan.FromAssemblies(serviceAssembly)
          .AddClasses(classes => classes
                .AssignableTo(typeof(IValidator<>))
                .Where(c => !c.ContainsGenericParameters) // Skip Open Generics
           )
          .AsImplementedInterfaces(i => i.IsAssignableTo(typeof(IValidator)) && i.GenericTypeArguments.Any())
          .WithTransientLifetime());

        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(serviceAssembly);
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>)); //Validation Extensibility
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
    }
    
    internal static IServiceCollection AddNoxHttpDefaults(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
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
        services.AddTransient<INoxDtoDatabaseConfigurator, NoxDtoDatabaseConfigurator>();

        return services;
    }
}