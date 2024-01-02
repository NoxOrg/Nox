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


internal static class ServiceCollectionExtensions
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
        services.AddNoxLib(webApplicationBuilder, configurator =>
        {
            configurator.WithDatabaseContexts<AppDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<AppDbContext>();
            configurator.WithRepository<Nox.Domain.Repository>();
            configurator.WithHealthChecks(healthChecksBuilder => healthChecksBuilder.AddDbContextCheck<AppDbContext>());
            configureNox?.Invoke(configurator);
        });

        services.AddScoped<Nox.Application.Queries.IValidateEntityChainQueryHandler, CryptocashIntegration.Application.Queries.ValidateEntityChainQueryHandler>();
        services.AddNoxOdata(configureNoxOdata);
        return services;
    }
}
