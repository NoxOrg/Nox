﻿// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.OData.ModelBuilder;
using Nox;
using Nox.Solution;
using Nox.Configuration;
using Nox.Types.EntityFramework.Abstractions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Presentation.Api.OData;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null, null);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, Action<INoxBuilderConfigurator>? configureNox, Action<ODataModelBuilder>? configureNoxOdata)
    {
        services.AddNoxLib(configurator =>
        {
            configurator.WithDatabaseContexts<CryptocashDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<CryptocashDbContext>();
            configureNox?.Invoke(configurator);
        });
        services.AddNoxOdata(configureNoxOdata);
        return services;
    }
}