// Generated

#nullable enable

using ClientApi.Infrastructure.Persistence;
using ClientApi.Presentation.Api.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Nox;
using Nox.EntityFramework.Sqlite;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using System.Reflection;

public static class NoxWebApplicationBuilderExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, Action<ODataModelBuilder>? configureOData)
    {
        services.AddNoxLib(Assembly.GetExecutingAssembly());
        services.AddNoxOdata(configureOData);
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        services.AddSingleton<DbContextOptions<ClientApiDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, SqliteDatabaseProvider>();
        services.AddSingleton<INoxDatabaseProvider, SqliteDatabaseProvider>();
        services.AddDbContext<ClientApiDbContext>();
        services.AddDbContext<DtoDbContext>();
        return services;
    }
}
