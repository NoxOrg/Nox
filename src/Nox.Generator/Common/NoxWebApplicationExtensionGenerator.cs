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
        code.AppendLine("using Nox;");
        code.AppendLine("using Nox.Solution;");
        code.AppendLine("using Nox.Logging.Serilog;");
        code.AppendLine("using Nox.Monitoring.ElasticApm;");
        code.AppendLines(usings.ToArray());
        code.AppendLine("using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine($"using {solution.Name}.Infrastructure.Persistence;");
        if(generatePresentation)
            code.AppendLine($"using {solution.Name}.Presentation.Api.OData;");
        code.AppendLine();
        code.AppendLine($"namespace {solution.Name};");
        code.AppendLine();

        code.AppendLine("public static class NoxWebApplicationBuilderExtension");
        code.StartBlock();
        code.AppendLine("public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)");
        code.StartBlock();
        code.AppendLine("var httpAccessor = appBuilder.Configuration.Get<HttpContextAccessor>();");
        code.AppendLine("appBuilder.Services.AddNoxServices();");
        code.AppendLine("appBuilder.Logging.AddLogging(appBuilder.Configuration, opt  =>");
        code.StartBlock();
        code.AppendLine("opt.UseSerilog(serilogOpt =>");
        code.StartBlock();
        code.AppendLine("serilogOpt.WithEcsHttpContext(httpAccessor);");
        code.EndBlockWithBracket();
        code.EndBlockWithBracket();
        code.AppendLine("return appBuilder;");
        code.EndBlock();
        code.AppendLine();
        
        code.AppendLine("public static void UseNox(this IApplicationBuilder builder)");
        code.StartBlock();
        code.AppendLine("var solution = builder.ApplicationServices.GetRequiredService<NoxSolution>();");
        if (solution.Infrastructure is { Dependencies.Monitoring: not null })
        {
            switch (solution.Infrastructure.Dependencies.Monitoring.Provider)
            {
                case MonitoringProvider.ElasticApm:
                    code.AppendLine("builder.UseElasticMonitoring(solution.Infrastructure!.Dependencies!.Monitoring);");
                    break;
            }
        }
        
        code.EndBlock();
        code.AppendLine();
        
        code.AppendLine("private static void AddNoxServices(this IServiceCollection services)");
        code.StartBlock();
        code.AppendLine("services.AddNoxLib();");
        if (solution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            var dbContextName = $"{solution.Name}DbContext";
            code.AppendLine($"services.AddSingleton<DbContextOptions<{dbContextName}>>();");
            code.AppendLine($"services.AddSingleton<INoxDatabaseConfigurator, {dbProvider}>();");
            code.AppendLine($"services.AddSingleton<INoxDatabaseProvider, {dbProvider}>();");
            code.AppendLine($"services.AddDbContext<{dbContextName}>();");
            if(generatePresentation)
                code.AppendLine($"services.AddDbContext<ODataDbContext>();");
            code.AppendLine("var tmpProvider = services.BuildServiceProvider();");
            code.AppendLine($"var dbContext = tmpProvider.GetRequiredService<{dbContextName}>();");
            code.AppendLine("dbContext.Database.EnsureCreated();");            
        }
        code.EndBlock();
        code.EndBlock();

        code.GenerateSourceCode();

    }
}