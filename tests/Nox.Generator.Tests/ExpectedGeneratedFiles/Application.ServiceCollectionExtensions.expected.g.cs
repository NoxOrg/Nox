// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.OData.ModelBuilder;
using Nox;
using Nox.Solution;
using Nox.Configuration;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Presentation.Api.OData;

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
            configurator.WithDatabaseContexts<TestWebAppDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<TestWebAppDbContext>();
            configureNox?.Invoke(configurator);
        });
        services.AddNoxOdata(configureNoxOdata);
        return services;
    }
}
