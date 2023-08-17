using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization.Sqlite;

public static class SqliteLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqliteStore(this NoxLocalizationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.AddSingleton<INoxDatabaseProvider>(provider => new SqliteDatabaseProvider(
            NoxDataStoreType.LocalizationStore, 
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        return optionsBuilder;
    }
}