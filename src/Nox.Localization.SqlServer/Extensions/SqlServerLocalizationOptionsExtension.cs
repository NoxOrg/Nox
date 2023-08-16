using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.SqlServer.Extensions;

public static class SqlServerLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqlServerStore(this NoxLocalizationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.TryAddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        return optionsBuilder;
    }
}