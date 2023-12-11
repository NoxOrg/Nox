using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Services;

namespace Nox.Integration.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNoxIntegrations(this IServiceCollection services, Action<NoxIntegrationOptionsBuilder>? integrationOptionsAction = null)
    {
        services.TryAddSingleton<INoxIntegrationContext, NoxIntegrationContext>();
        services.TryAddSingleton<INoxIntegrationDbContextFactory, NoxIntegrationDbContextFactory>();
        services
            .AddDbContext<NoxIntegrationDbContext>()
            .RegisterEventPayloads()
            .RegisterCreateEvents()
            .RegisterUpdateEvents()
            .RegisterExecuteCompleteEvents();
        var optionsBuilder = new NoxIntegrationOptionsBuilder(services);
        integrationOptionsAction?.Invoke(optionsBuilder);
        return services;
    }

    public static IServiceCollection RegisterTransformHandler(this IServiceCollection services, Type handlerType)
    {
        services.AddTransient(typeof(INoxCustomTransformHandler), handlerType);
        return services;
    }
    
    public static IServiceCollection RegisterTransformHandler<THandler>(this IServiceCollection services) where THandler: INoxCustomTransformHandler
    {
        services.AddTransient(typeof(INoxCustomTransformHandler), typeof(THandler));
        return services;
    }

    private static IServiceCollection RegisterEventPayloads(this IServiceCollection services)
    {
        var payloads = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(INoxEtlEventPayload)));
        foreach (var @payload in payloads)
        {
            services.AddTransient(typeof(INoxEtlEventPayload), payload);
            services.AddTransient(payload);
        }
 
        return services;
    }

    public static IServiceCollection RegisterCreateEvents(this IServiceCollection services)
    {
        var events = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(NoxEtlRecordCreatedEvent<INoxEtlEventPayload>)));
        foreach (var @event in events)
        {
            services.AddTransient(typeof(NoxEtlRecordCreatedEvent<INoxEtlEventPayload>), @event);
        }
 
        return services;
    }
    
    public static IServiceCollection RegisterUpdateEvents(this IServiceCollection services)
    {
        var events = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>)));
        foreach (var @event in events)
        {
            services.AddTransient(typeof(NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>), @event);
        }
 
        return services;
    }
    
    public static IServiceCollection RegisterExecuteCompleteEvents(this IServiceCollection services)
    {
        services.AddTransient<NoxEtlExecuteCompletedPayload>();
        services.AddTransient<NoxEtlExecuteCompletedEvent>();
        var events = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(NoxEtlExecuteCompletedEvent)));
        foreach (var @event in events)
        {
            services.AddTransient(typeof(NoxEtlExecuteCompletedEvent), @event);
        }
 
        return services;
    }
    
    private static bool IsSubclassOfRawGeneric(Type generic, Type? toCheck)
    {
        while (toCheck != typeof(object))
        {
            var cur = toCheck is { IsGenericType: true } ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur) {
                return true;
            }
            toCheck = toCheck?.BaseType;
        }

        return false;
    }
    
}