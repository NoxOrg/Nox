using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization.SqlServer.Extensions;

public static class SqlServerLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqlServerStore(this NoxLocalizationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.TryAddSingleton<INoxDatabaseProvider>(provider => new SqlServerDatabaseProvider(
            NoxDataStoreType.LocalizationStore, 
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        return optionsBuilder;
    }
}