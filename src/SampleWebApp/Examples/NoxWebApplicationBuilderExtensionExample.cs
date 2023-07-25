using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.EntityFramework.SqlServer;
using Nox.Logging.Serilog;
using Nox.Monitoring.ElasticApm;
using Nox.Types.EntityFramework.Abstractions;

namespace SampleWebApp;

public static class NoxWebApplicationBuilderExtensionExample
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        var httpAccessor = appBuilder.Configuration.Get<HttpContextAccessor>();
        appBuilder.Services.AddNoxServices();
        appBuilder.Logging.AddLogging(appBuilder.Configuration, opt  =>
        {
            opt.UseSerilog(serlogOpt =>
            {
                serlogOpt.WithEcsHttpContext(httpAccessor);
            });
        });
        return appBuilder;
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