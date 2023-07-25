// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Nox;
using Nox.Solution;
using Nox.Logging.Serilog;
using Nox.Monitoring.ElasticApm;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Presentation.Api.OData;

namespace TestWebApp;

public static class NoxWebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        var httpAccessor = appBuilder.Configuration.Get<HttpContextAccessor>();
        appBuilder.Services.AddNoxServices();
        appBuilder.Logging.AddLogging(appBuilder.Configuration, opt  =>
        {
            opt.UseSerilog(serilogOpt =>
            {
                serilogOpt.WithEcsHttpContext(httpAccessor);
            });
        });
        return appBuilder;
    }
    
    public static void UseNox(this IApplicationBuilder builder)
    {
        var solution = builder.ApplicationServices.GetRequiredService<NoxSolution>();
        builder.UseElasticMonitoring(solution.Infrastructure!.Dependencies!.Monitoring);
    }
    
    private static void AddNoxServices(this IServiceCollection services)
    {
        services.AddNoxLib();
        services.AddNoxTypesDatabaseConfigurator(Assembly.GetExecutingAssembly());
        services.AddNoxOdata();
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        services.AddSingleton<DbContextOptions<TestWebAppDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseProvider>();
        services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        services.AddDbContext<TestWebAppDbContext>();
        services.AddDbContext<ODataDbContext>();
        var tmpProvider = services.BuildServiceProvider();
        var dbContext = tmpProvider.GetRequiredService<TestWebAppDbContext>();
    }
}
