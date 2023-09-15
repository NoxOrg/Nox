using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Common;
using Nox.Solution;
using Scriban;

namespace Nox.Generator.Application;

internal class NoxWebApplicationExtensionGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.None;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var scribanTemplate = Template.Parse(
            @"// Generated

#nullable enable
{{~ for namespace in namespaces}}
using {{ namespace ~}};
{{- end }}

public static class NoxWebApplicationBuilderExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, Action<ODataModelBuilder>? configureOData)
    {
        services.AddNoxLib(Assembly.GetExecutingAssembly());
        services.AddNoxOdata(configureOData);
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        services.AddSingleton<DbContextOptions<{{ dbContext }}>>();
        services.AddSingleton<INoxDatabaseConfigurator, {{ dbProvider }}>();
        services.AddSingleton<INoxDatabaseProvider, {{ dbProvider }}>();
        services.AddDbContext<{{ dbContext }}>();
        services.AddDbContext<DtoDbContext>();
        return services;
    }
}
"
        );

        var solution = codeGeneratorState.Solution;

        List<string> namespaces = new()
        {
            "Microsoft.EntityFrameworkCore",
            "System.Reflection",
            "Microsoft.OData.ModelBuilder",
            "Nox",
            "Nox.Solution",
            "Nox.Types.EntityFramework.Abstractions",
            $"{solution.Name}.Infrastructure.Persistence",
        };

        if (config.Presentation)
            namespaces.Add($"{solution.Name}.Presentation.Api.OData");

        var dbProvider = "";
        if (solution.Infrastructure?.Persistence is { DatabaseServer: not null })
        {
            switch (solution.Infrastructure.Persistence.DatabaseServer.Provider)
            {
                case DatabaseServerProvider.SqlServer:
                    namespaces.Add("Nox.EntityFramework.SqlServer");
                    dbProvider = "SqlServerDatabaseProvider";
                    break;

                case DatabaseServerProvider.Postgres:
                    namespaces.Add("Nox.EntityFramework.Postgres");
                    dbProvider = "PostgresDatabaseProvider";
                    break;
                case DatabaseServerProvider.SqLite:
                    namespaces.Add("Nox.EntityFramework.Sqlite");
                    dbProvider = "SqliteDatabaseProvider";
                    break;
            }
        }

        namespaces.Sort();

        object model = new
        {
            namespaces,
            dbProvider,
            dbContext = $"{solution.Name}DbContext"
        };

        context.AddSource("Application.NoxWebApplicationExtensions.g.cs",
            SourceText.From(scribanTemplate.Render(model, member => member.Name), Encoding.UTF8));
    }
}