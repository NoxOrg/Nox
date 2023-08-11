using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions.Localization;
using Nox.EntityFramework.SqlServer;
using Nox.Localization.DbContext;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.SqlServer.Extensions;

public static class SqlServerLocalizationOptionsExtension
{
    public static NoxLocalizationOptionsBuilder WithSqlServerStore(this NoxLocalizationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.TryAddSingleton<INoxDatabaseProvider, SqlServerDatabaseProvider>();
        
        optionsBuilder.Services.AddDbContext<NoxLocalizationDbContext>();

        return optionsBuilder;
    }
}