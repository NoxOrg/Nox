// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.OData.ModelBuilder;
using Nox;
using Nox.Solution;
using Nox.Configuration;
using Nox.Types.EntityFramework.Abstractions;
using {{ solutionName }}.Infrastructure.Persistence;
{{- if configPresentation == true }}
using {{ solutionName }}.Presentation.Api.OData;
{{- end }}

internal static class {{className}}
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
            configurator.WithDatabaseContexts<{{ solutionName }}DbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<{{ solutionName }}DbContext>();
            configureNox?.Invoke(configurator);
        });
        {{- if configPresentation == true }}
        services.AddNoxOdata(configureNoxOdata);
        {{- end }}
        return services;
    }
}
