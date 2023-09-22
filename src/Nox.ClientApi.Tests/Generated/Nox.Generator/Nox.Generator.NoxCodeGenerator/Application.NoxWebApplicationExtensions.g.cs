// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OData.ModelBuilder;
using Nox;
using Nox.Solution;
using Nox.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Abstractions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Presentation.Api.OData;

public static class NoxWebApplicationBuilderExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
                        {
                            return services.AddNox(null);
                        }
                        
    public static IServiceCollection AddNox(this IServiceCollection services, Action<ODataModelBuilder>? configureOData)
    {
        var noxSolution = services.AddNoxLib(Assembly.GetExecutingAssembly());
        services.TryAddNoxMessaging<ClientApiDbContext>(noxSolution);
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
