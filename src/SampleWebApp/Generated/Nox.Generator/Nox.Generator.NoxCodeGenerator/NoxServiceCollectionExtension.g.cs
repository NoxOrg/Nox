// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.DatabaseProvider;
using Nox.DatabaseProvider.Postgres;
using Nox.Types.EntityFramework.Postgres;
using Nox.Types.EntityFramework.vNext;
using SampleWebApp.Infrastructure.Persistence;

public static class NoxServiceCollectionExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        services.AddNoxLib();
        services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, PostgresDatabaseConfigurator>();
        services.AddSingleton<INoxDatabaseProvider, PostgresDatabaseProvider>();
        services.AddDbContext<SampleWebAppDbContext>();
        var tmpProvider = services.BuildServiceProvider();
        var dbContext = tmpProvider.GetRequiredService<SampleWebAppDbContext>();
        dbContext.Database.EnsureCreated();
        return services;
    }
}
