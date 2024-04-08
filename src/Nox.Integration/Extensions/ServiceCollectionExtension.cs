using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Interfaces;
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

    public static IServiceCollection RegisterIntegrationTransform(this IServiceCollection services, Type transformType)
    {
        services.AddTransient(typeof(INoxTransform<INoxTransformDto, INoxTransformDto>), transformType);
        return services;
    }

    private static IServiceCollection RegisterEventPayloads(this IServiceCollection services)
    {
        var payloads = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(IEtlEventDto)));
        foreach (var @payload in payloads)
        {
            services.AddTransient(typeof(IEtlEventDto), payload);
            services.AddTransient(payload);
        }
 
        return services;
    }

    private static IServiceCollection RegisterCreateEvents(this IServiceCollection services)
    {
        var events = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(EtlRecordCreatedEvent<IEtlEventDto>)));
        foreach (var @event in events)
        {
            services.AddTransient(typeof(EtlRecordCreatedEvent<IEtlEventDto>), @event);
        }
 
        return services;
    }
    
    private static IServiceCollection RegisterUpdateEvents(this IServiceCollection services)
    {
        var events = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(EtlRecordUpdatedEvent<IEtlEventDto>)));
        foreach (var @event in events)
        {
            services.AddTransient(typeof(EtlRecordUpdatedEvent<IEtlEventDto>), @event);
        }
 
        return services;
    }
    
    private static IServiceCollection RegisterExecuteCompleteEvents(this IServiceCollection services)
    {
        services.AddTransient<EtlExecuteCompletedDto>();
        services.AddTransient<EtlExecuteCompletedEvent>();
        var events = Assembly
            .GetEntryAssembly()!
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAssignableTo(typeof(EtlExecuteCompletedEvent)));
        foreach (var @event in events)
        {
            services.AddTransient(typeof(EtlExecuteCompletedEvent), @event);
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