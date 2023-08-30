using ClientApi.Presentation.Api.OData;
using ClientApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Abstractions;
using Nox;
using System.Reflection;

public static class NoxApplicationExtensions
{
    public static void AddNox(this IServiceCollection services)
    {
        services.AddNoxLib(Assembly.GetExecutingAssembly());
        services.AddNoxOdata();
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        services.AddSingleton<DbContextOptions<ClientApiDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, SqliteDatabaseProvider>();
        services.AddSingleton<INoxDatabaseProvider, SqliteDatabaseProvider>();
        services.AddDbContext<ClientApiDbContext>();
        services.AddDbContext<DtoDbContext>();
    }
}
