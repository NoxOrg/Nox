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
        code.AppendLine("using Microsoft.OData.ModelBuilder;");
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
        code.AppendLine(@"public static IServiceCollection AddNox(this IServiceCollection services)
                        {
                            return services.AddNox(null);
                        }
                        ");
        code.AppendLine("public static IServiceCollection AddNox(this IServiceCollection services, Action<ODataModelBuilder>? configureOData)");
        code.StartBlock();
        code.AppendLine($"services.AddNoxLib(Assembly.GetExecutingAssembly());");
        if(codeGeneratorState.Solution.Infrastructure?.Messaging is not null)
            
        code.AppendLine($"services.AddNoxMessaging<{solution.Name}DbContext>(Nox.DatabaseServerProvider.{codeGeneratorState.Solution.Infrastructure.Persistence.DatabaseServer.Provider});");
       
        code.AppendLine("services.AddNoxOdata(configureOData);");
        var dbContextName = $"{solution.Name}DbContext";

        code.AppendLine($"services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));");
        code.AppendLine($"services.AddSingleton<DbContextOptions<{dbContextName}>>();");
        code.AppendLine($"services.AddSingleton<INoxDatabaseConfigurator, {dbProvider}>();");
        code.AppendLine($"services.AddSingleton<INoxDatabaseProvider, {dbProvider}>();");
        code.AppendLine($"services.AddDbContext<{dbContextName}>();");
        code.AppendLine($"services.AddDbContext<DtoDbContext>();");
        code.AppendLine("return services;");
        code.EndBlock();
        code.AppendLine();

        code.EndBlock();

        code.GenerateSourceCode();
    }
}