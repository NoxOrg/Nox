// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Nox;
using Nox.Solution;
using Nox.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Abstractions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Presentation.Api.OData;

public static class NoxWebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddNoxLib(Assembly.GetExecutingAssembly());
        appBuilder.Services.AddNoxOdata();
        appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        appBuilder.Services.AddSingleton<DbContextOptions<ClientApiDbContext>>();
        appBuilder.Services.AddSingleton<INoxDatabaseConfigurator, SqliteDatabaseProvider>();
        appBuilder.Services.AddSingleton<INoxDatabaseProvider, SqliteDatabaseProvider>();
        appBuilder.Services.AddDbContext<ClientApiDbContext>();
        appBuilder.Services.AddDbContext<ODataDbContext>();
        return appBuilder;
    }
    
}
