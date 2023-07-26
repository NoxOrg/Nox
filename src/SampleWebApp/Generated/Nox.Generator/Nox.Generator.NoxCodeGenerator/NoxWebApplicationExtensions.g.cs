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
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp;

public static class NoxWebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddNoxLib();
        appBuilder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        appBuilder.Services.AddNoxTypesDatabaseConfigurator(Assembly.GetExecutingAssembly());
        appBuilder.Services.AddNoxOdata();
        appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        appBuilder.Services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        appBuilder.Services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseProvider>();
        appBuilder.Services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        appBuilder.Services.AddDbContext<SampleWebAppDbContext>();
        appBuilder.Services.AddDbContext<ODataDbContext>();
        var tmpProvider = appBuilder.Services.BuildServiceProvider();
        var dbContext = tmpProvider.GetRequiredService<SampleWebAppDbContext>();
        return appBuilder;
    }
    
}
