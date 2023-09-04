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

        var code = new CodeBuilder($"Application.NoxWebApplicationExtensions.g.cs", context);

        var usings = new List<string>();
        var dbProvider = "";
        var solution = codeGeneratorState.Solution;
        if (solution.Infrastructure?.Persistence is { DatabaseServer: not null })
        {
            var dbServer = solution.Infrastructure.Persistence.DatabaseServer;
            switch (dbServer.Provider)
            {
                case DatabaseServerProvider.SqlServer:
                    usings.Add("using Nox.EntityFramework.SqlServer;");
                    dbProvider = "SqlServerDatabaseProvider";
                    break;

                case DatabaseServerProvider.Postgres:
                    usings.Add("using Nox.EntityFramework.Postgres;");
                    dbProvider = "PostgresDatabaseProvider";
                    break;
                case DatabaseServerProvider.SqLite:
                    usings.Add("using Nox.EntityFramework.Sqlite;");
                    dbProvider = "SqliteDatabaseProvider";
                    break;
            }
        }

        code.AppendLine("using Microsoft.EntityFrameworkCore;");
        code.AppendLine("using System.Reflection;");
        code.AppendLine("using Nox;");
        code.AppendLine("using Nox.Solution;");
        code.AppendLines(usings.ToArray());
        code.AppendLine("using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine($"using {solution.Name}.Infrastructure.Persistence;");
        if (config.Presentation)
            code.AppendLine($"using {solution.Name}.Presentation.Api.OData;");
        code.AppendLine();

        code.AppendLine("public static class NoxWebApplicationBuilderExtension");
        code.StartBlock();
        code.AppendLine("public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)");
        code.StartBlock();
        code.AppendLine($"appBuilder.Services.AddNoxLib(Assembly.GetExecutingAssembly());");
        code.AppendLine("appBuilder.Services.AddNoxOdata();");
        var dbContextName = $"{solution.Name}DbContext";

        code.AppendLine($"appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));");
        code.AppendLine($"appBuilder.Services.AddSingleton<DbContextOptions<{dbContextName}>>();");
        code.AppendLine($"appBuilder.Services.AddSingleton<INoxDatabaseConfigurator, {dbProvider}>();");
        code.AppendLine($"appBuilder.Services.AddSingleton<INoxDatabaseProvider, {dbProvider}>();");
        code.AppendLine($"appBuilder.Services.AddDbContext<{dbContextName}>();");
        code.AppendLine($"appBuilder.Services.AddDbContext<DtoDbContext>();");
        code.AppendLine("return appBuilder;");
        code.EndBlock();
        code.AppendLine();

        code.EndBlock();

        code.GenerateSourceCode();
    }
}