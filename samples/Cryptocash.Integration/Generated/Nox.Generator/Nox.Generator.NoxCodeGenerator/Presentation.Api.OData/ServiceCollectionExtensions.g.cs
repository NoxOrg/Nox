// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;
using System.Reflection;
using Nox;
using Nox.Solution;
using Nox.Configuration;
using Nox.Types.EntityFramework.Abstractions;
using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Presentation.Api.OData;

namespace CryptocashIntegration.Presentation;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Use for testing without a WebApplicationBuilder
    /// Do not use directly on production code
    /// </summary>
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null, null, null);
    }

    public static IServiceCollection AddNox(this WebApplicationBuilder webApplicationBuilder, Action<INoxOptions>? configureNox = null, Action<ODataModelBuilder>? configureNoxOdata = null)
    {
        return webApplicationBuilder.Services.AddNox(webApplicationBuilder, configureNox, configureNoxOdata);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, WebApplicationBuilder? webApplicationBuilder, Action<INoxOptions>? configureNox, Action<ODataModelBuilder>? configureNoxOdata)
    {
        // Set the Assembly where Entities are generated
        NoxAssemblyConfiguration.DomainAssembly = typeof(CryptocashIntegration.Domain.CountryQueryToTable).Assembly;
        // Set the Assembly where Application code is generated
        NoxAssemblyConfiguration.ApplicationAssembly = typeof(CryptocashIntegration.Application.Services.RelationshipChainValidator).Assembly;
        // Set the Assembly where Dto's are generated
        NoxAssemblyConfiguration.DtoAssembly = typeof(CryptocashIntegration.Application.Dto.CountryQueryToTableDto).Assembly;

        services.AddNoxLib(webApplicationBuilder, configurator =>
        {
            configurator.WithRepositories<AppDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<AppDbContext>();
            configurator.WithHealthChecks(healthChecksBuilder => healthChecksBuilder.AddDbContextCheck<AppDbContext>());
            configureNox?.Invoke(configurator);
        });

        services.AddScoped<Nox.Application.Services.IRelationshipChainValidator, CryptocashIntegration.Application.Services.RelationshipChainValidator>();
        services.AddNoxOdata(configureNoxOdata);
        return services;
    }
}
