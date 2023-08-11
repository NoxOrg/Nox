using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions.Localization;
using Nox.EntityFramework.Sqlite;
using Nox.Localization.DbContext;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.Sqlite.Extensions;

public static class SqliteLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqliteStore(this NoxLocalizationOptionsBuilder optionsBuilder, DatabaseServer serverConfig)
    {
        optionsBuilder.Services.TryAddSingleton<INoxDatabaseProvider, SqliteDatabaseProvider>();
        
        optionsBuilder.Services.AddDbContext<NoxLocalizationDbContext>();
        
        // optionsBuilder.Services.AddDbContext<NoxLocalizationDbContext>( options =>
        // {
        //     options.UseSqlite(serverConfig.ServerUri, dbOptions =>
        //     {
        //         dbOptions.MigrationsAssembly("Nox.Localization.Sqlite");
        //     });
        // });
        return optionsBuilder;
    }
}