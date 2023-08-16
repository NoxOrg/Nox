using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.EntityFramework.Sqlite;
using Nox.Localization.DbContext;
using Nox.Solution;
using Nox.Types.EntityFramework;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization.Sqlite.Extensions;

public static class SqliteLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqliteStore(this NoxLocalizationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.TryAddSingleton<INoxDatabaseProvider>(provider => new SqliteDatabaseProvider(
            NoxDataStoreType.LocalizationStore, 
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        return optionsBuilder;
    }
}