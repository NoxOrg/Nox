using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator.Common;

internal class NoxWebApplicationExtensionGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.None;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new CodeBuilder($"NoxWebApplicationExtensions.g.cs", context);

        var usings = new List<string>();
        
        var entityStoreDbProvider = "";
        
        var solution = codeGeneratorState.Solution;

        DatabaseServer? entityStoreServer = null;
        
        if (solution.Infrastructure?.Persistence is { DatabaseServer: not null })
        {
            entityStoreServer = solution.Infrastructure.Persistence.DatabaseServer;
            switch (entityStoreServer.Provider)
            {
                case DatabaseServerProvider.SqlServer:
                    usings.Add("using Nox.EntityFramework.SqlServer;");
                    entityStoreDbProvider = "SqlServerDatabaseProvider";
                    break;

                case DatabaseServerProvider.Postgres:
                    usings.Add("using Nox.EntityFramework.Postgres;");
                    entityStoreDbProvider = "PostgresDatabaseProvider";
                    break;
            }
        }

        if (solution.Application is { Localization: not null })
        {
            usings.Add("using Nox.Localization;");
        }

        code.AppendLine("using Microsoft.EntityFrameworkCore;");
        code.AppendLine("using System.Reflection;");
        code.AppendLine("using Nox.Abstractions;");
        code.AppendLine("using Nox;");
        code.AppendLine("using Nox.Solution;");
        code.AppendLines(usings.ToArray());
        code.AppendLine("using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine("using Nox.Types.EntityFramework.Enums;");
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
        code.AppendLine($"appBuilder.Services.AddSingleton<INoxDatabaseConfigurator>(provider => new {entityStoreDbProvider}(");
        code.Indent();
        code.AppendLine("NoxDataStoreType.EntityStore,");
        code.AppendLine("provider.GetServices<INoxTypeDatabaseConfigurator>())");
        code.UnIndent();
        code.AppendLine(");");
       
        code.AppendLine($"appBuilder.Services.AddSingleton<INoxDatabaseProvider>(provider => new {entityStoreDbProvider}(");
        code.Indent();
        code.AppendLine("NoxDataStoreType.EntityStore,");
        code.AppendLine("provider.GetServices<INoxTypeDatabaseConfigurator>())");
        code.UnIndent();
        code.AppendLine(");");
        
        code.AppendLine($"appBuilder.Services.AddDbContext<{dbContextName}>();");
        if (config.Presentation)
            code.AppendLine($"appBuilder.Services.AddDbContext<ODataDbContext>();");

        if (solution.Application is { Localization: not null })
        {
            code.AppendLine("appBuilder.Services.AddNoxLocalization();");
        }
        
        code.AppendLine("return appBuilder;");
        code.EndBlock();
        code.AppendLine();

        code.EndBlock();

        code.GenerateSourceCode();
    }
}