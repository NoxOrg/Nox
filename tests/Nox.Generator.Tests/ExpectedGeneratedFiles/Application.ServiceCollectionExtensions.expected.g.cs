// Generated

#nullable enable

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;
using System.Reflection;
using Nox;
using Nox.Solution;
using Nox.Configuration;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Presentation.Api.OData;


internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null, null);
    }

    public static IServiceCollection AddNox(this WebApplicationBuilder webApplicationBuilder, Action<INoxBuilder>? configureNox = null, Action<ODataModelBuilder>? configureNoxOdata = null)
    {
        return webApplicationBuilder.Services.AddNox(configureNox, configureNoxOdata);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, Action<INoxBuilder>? configureNox, Action<ODataModelBuilder>? configureNoxOdata)
    {
        services.AddNoxLib(configurator =>
        {
            configurator.WithDatabaseContexts<TestWebAppDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<TestWebAppDbContext>();
            configureNox?.Invoke(configurator);
        });
        services.AddNoxOdata(configureNoxOdata);
        return services;
    }
}
