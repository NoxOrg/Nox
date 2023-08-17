using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization.SqlServer;

public static class SqlServerLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqlServerStore(this NoxLocalizationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.AddSingleton<INoxDatabaseProvider>(provider => new SqlServerDatabaseProvider(
            NoxDataStoreType.LocalizationStore, 
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        return optionsBuilder;
    }
}