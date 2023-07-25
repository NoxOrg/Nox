// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Logging.Serilog;
using Nox.Monitoring.ElasticApm;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp;

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
    }
    
    private static void AddNoxServices(this IServiceCollection services)
    {
        services.AddNoxLib();
        services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseProvider>();
        services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        services.AddDbContext<SampleWebAppDbContext>();
        services.AddDbContext<ODataDbContext>();
        var tmpProvider = services.BuildServiceProvider();
        var dbContext = tmpProvider.GetRequiredService<SampleWebAppDbContext>();
        dbContext.Database.EnsureCreated();
    }
}
