// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.DatabaseProvider.Postgres;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Infrastructure.Persistence;

public static class NoxServiceCollectionExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        services.AddNoxLib();
        services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        services.AddSingleton<INoxDatabaseConfigurator, PostgresDatabaseProvider>();
        services.AddSingleton<INoxDatabaseProvider, PostgresDatabaseProvider>();
        services.AddDbContext<SampleWebAppDbContext>();
        var tmpProvider = services.BuildServiceProvider();
        var dbContext = tmpProvider.GetRequiredService<SampleWebAppDbContext>();
        dbContext.Database.EnsureCreated();
        return services;
    }
}
