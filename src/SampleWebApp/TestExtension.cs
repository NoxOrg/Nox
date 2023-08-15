using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp;


public static class TestExtension
{
    public static WebApplicationBuilder AddNoxTest(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddNoxLib(Assembly.GetExecutingAssembly());
        appBuilder.Services.AddNoxOdata();
        appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        appBuilder.Services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        appBuilder.Services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseProvider>();
        appBuilder.Services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        appBuilder.Services.AddDbContext<SampleWebAppDbContext>();
        appBuilder.Services.AddDbContext<ODataDbContext>();

        appBuilder.AddNoxLocalization();
        
        return appBuilder;
    }
    
}