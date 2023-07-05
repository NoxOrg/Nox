using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator.Common;

public class ServiceCollectionExtensionGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new CodeBuilder($"NoxServiceCollectionExtension.g.cs", context);

        var usings = new List<string>();
        var dbConfigurator = "";
        var dbProvider = "";
        
        if (solution.Infrastructure?.Persistence is { DatabaseServer: not null })
        {
            var dbServer = solution.Infrastructure.Persistence.DatabaseServer;
            switch (dbServer.Provider)
            {
                case DatabaseServerProvider.SqlServer:
                    usings.Add("using Nox.DatabaseProvider.SqlServer;");
                    usings.Add("using Nox.Types.EntityFramework.SqlServer;");
                    dbConfigurator = "SqlServerDatabaseConfigurator";
                    dbProvider = "SqlServerDatabaseProvider";
                    break;
                case DatabaseServerProvider.Postgres:
                    usings.Add("using Nox.DatabaseProvider.Postgres;");
                    usings.Add("using Nox.Types.EntityFramework.Postgres;");
                    dbConfigurator = "PostgresDatabaseConfigurator";
                    dbProvider = "PostgresDatabaseProvider";
                    break;
            }
        }
        
        code.AppendLine("using Microsoft.EntityFrameworkCore;");
        code.AppendLine("using Nox;");
        code.AppendLine("using Nox.DatabaseProvider;");
        code.AppendLines(usings.ToArray());
        code.AppendLine("using Nox.Types.EntityFramework.vNext;");
        code.AppendLine("using SampleWebApp.Infrastructure.Persistence;");
        code.AppendLine();

        code.AppendLine("public static class NoxServiceCollectionExtension");
        code.StartBlock();
        code.AppendLine("public static IServiceCollection AddNox(this IServiceCollection services)");
        code.StartBlock();
        code.AppendLine("services.AddNoxLib();");
        if (solution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            var dbContextName = $"{solution.Name}DbContext";
            code.AppendLine($"services.AddSingleton<DbContextOptions<{dbContextName}>>();");
            code.AppendLine($"services.AddSingleton<INoxDatabaseConfigurator, {dbConfigurator}>();");
            code.AppendLine($"services.AddSingleton<INoxDatabaseProvider, {dbProvider}>();");
            code.AppendLine($"services.AddDbContext<{dbContextName}>();");
            code.AppendLine("var tmpProvider = services.BuildServiceProvider();");
            code.AppendLine($"var dbContext = tmpProvider.GetRequiredService<{dbContextName}>();");
            code.AppendLine("dbContext.Database.EnsureCreated();");
        }
        
        code.AppendLine("return services;");
        code.EndBlock();
        code.EndBlock();

        code.GenerateSourceCode();

    }
}