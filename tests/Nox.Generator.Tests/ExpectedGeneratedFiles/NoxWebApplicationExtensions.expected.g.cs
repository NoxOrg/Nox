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
        appBuilder.Services.AddNoxLib();
        appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        appBuilder.Services.AddSingleton<DbContextOptions<TestWebAppDbContext>>();
        appBuilder.Services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseProvider>();
        appBuilder.Services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        appBuilder.Services.AddDbContext<TestWebAppDbContext>();
        appBuilder.Services.AddDbContext<ODataDbContext>();
        return appBuilder;
    }
    
}
