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
using {{ solutionName }}.Infrastructure.Persistence;
{{- if configPresentation == true }}
using {{ solutionName }}.Presentation.Api.OData;
{{- end }}

namespace {{codeGenConventions.PresentationNameSpace}};

public static class {{className}}
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
        {{- if solution.Domain != null }}
        // Set the Assembly where Entities are generated
        NoxAssemblyConfiguration.DomainAssembly = typeof({{codeGenConventions.DomainNameSpace}}.{{solution.Domain.Entities[0].Name}}).Assembly;
        // Set the Assembly where Application code is generated
        NoxAssemblyConfiguration.ApplicationAssembly = typeof({{codeGenConventions.ApplicationNameSpace}}.Services.RelationshipChainValidator).Assembly;
        // Set the Assembly where Dto's are generated
        NoxAssemblyConfiguration.DtoAssembly = typeof({{codeGenConventions.DtoNameSpace}}.{{solution.Domain.Entities[0].Name}}Dto).Assembly;
        // Set the Assembly where infrastructure is generated
        NoxAssemblyConfiguration.InfrastructureAssembly = typeof({{codeGenConventions.PersistenceNameSpace}}.AppDbContext).Assembly;
        {{- end }}

        services.AddNoxLib(webApplicationBuilder, configurator =>
        {
            configurator.WithRepositories<AppDbContext, DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<AppDbContext>();
            configurator.WithHealthChecks(healthChecksBuilder => healthChecksBuilder.AddDbContextCheck<AppDbContext>());
            configureNox?.Invoke(configurator);
        });

        services.AddScoped<Nox.Application.Services.IRelationshipChainValidator, {{solutionName}}.Application.Services.RelationshipChainValidator>();
       
        {{- if configPresentation == true }}
        services.AddNoxOdata(configureNoxOdata);
        {{- end }}
        return services;
    }
}
