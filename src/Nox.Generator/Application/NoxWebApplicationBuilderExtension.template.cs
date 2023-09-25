// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
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

internal static class NoxWebApplicationBuilderExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null, null);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, Action<INoxBuilderConfigurator>? configureNox, Action<ODataModelBuilder>? configureNoxOdata)
    {
        services.AddNoxLib(configurator =>
        {
            configurator.WithDatabaseContexts<{{ solutionName }}DbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<{{ solutionName }}DbContext>();
            configureNox?.Invoke(configurator);
        });
        services.AddNoxOdata(configureNoxOdata);
        return services;
    }
}
