// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Types.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.vNext;
using SampleWebApp.Infrastructure.Persistence;

public static class NoxServiceCollectionExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        services.AddNoxLib();
        services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, SqlServerDatabaseConfigurator>();
        services.AddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        services.AddDbContext<SampleWebAppDbContext>();
        var tmpProvider = services.BuildServiceProvider();
        var dbContext = tmpProvider.GetRequiredService<SampleWebAppDbContext>();
        dbContext.Database.EnsureCreated();
        return services;
    }
}
