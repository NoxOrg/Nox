using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator.Common;

internal static class NoxWebApplicationExtensionGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolution solution, bool generatePresentation)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new CodeBuilder($"NoxWebApplicationExtensions.g.cs", context);

        var usings = new List<string>();
        var dbProvider = "";
        
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
            }
        }
        
        code.AppendLine("using Microsoft.EntityFrameworkCore;");
        code.AppendLine("using System.Reflection;");
        code.AppendLine("using Nox;");
        code.AppendLine("using Nox.Solution;");
        code.AppendLines(usings.ToArray());
        code.AppendLine("using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine($"using {solution.Name}.Infrastructure.Persistence;");
        if(generatePresentation)
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
        if(generatePresentation)
            code.AppendLine($"appBuilder.Services.AddDbContext<ODataDbContext>();");
        code.AppendLine("var tmpProvider = appBuilder.Services.BuildServiceProvider();");
        code.AppendLine($"var dbContext = tmpProvider.GetRequiredService<{dbContextName}>();");
        code.AppendLine("return appBuilder;");
        code.EndBlock();
        code.AppendLine();
        
        code.EndBlock();

        code.GenerateSourceCode();

    }
}