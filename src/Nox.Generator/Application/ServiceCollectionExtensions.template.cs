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
{{- if codeGeneratorState.Solution.Domain?.Entities != null }}
using {{ solutionName }}.Infrastructure.Persistence;
{{- end}}
{{- if configPresentation == true }}
using {{ solutionName }}.Presentation.Api.OData;
{{- end }}


internal static class {{className}}
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
            {{- if codeGeneratorState.Solution.Domain?.Entities != null }}
            configurator.WithDatabaseContexts<AppDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<AppDbContext>();
            {{- end }}
            configureNox?.Invoke(configurator);
        });
        {{- if codeGeneratorState.Solution.Domain?.Entities != null }}
        services.AddScoped(typeof(Nox.Domain.IRepository), serviceProvider =>
        {
            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            return new Nox.Domain.Repository(dbContext);
        });
        {{- end }}

        {{- if configPresentation == true }}
        services.AddNoxOdata(configureNoxOdata);
        {{- end }}
        return services;
    }
}