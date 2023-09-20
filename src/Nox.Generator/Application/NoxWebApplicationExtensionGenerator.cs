using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application;

internal class NoxWebApplicationExtensionGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.None;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var namePrefix = "Application";

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

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName("NoxWebApplicationExtensions")
            .WithFileNamePrefix(namePrefix)
            .WithObject("namespaces", namespaces)
            .WithObject("dbProvider", dbProvider)
            .WithObject("dbContext", $"{solution.Name}DbContext")
            .GenerateSourceCodeFromResource($"{namePrefix}.NoxWebApplicationBuilderExtension");
    }
}