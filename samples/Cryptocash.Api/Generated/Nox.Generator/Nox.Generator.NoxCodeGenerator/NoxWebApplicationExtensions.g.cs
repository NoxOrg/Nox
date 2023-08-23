// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Nox;
using Nox.Solution;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Presentation.Api.OData;

public static class NoxWebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddNoxLib(Assembly.GetExecutingAssembly());
        appBuilder.Services.AddNoxOdata();
        appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        appBuilder.Services.AddSingleton<DbContextOptions<CryptocashApiDbContext>>();
        appBuilder.Services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseProvider>();
        appBuilder.Services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        appBuilder.Services.AddDbContext<CryptocashApiDbContext>();
        appBuilder.Services.AddDbContext<DtoDbContext>();
        return appBuilder;
    }
    
}
