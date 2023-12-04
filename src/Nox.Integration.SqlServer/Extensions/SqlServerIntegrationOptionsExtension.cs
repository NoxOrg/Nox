using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nox.Abstractions;
using Nox.EntityFramework.SqlServer;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Integration.SqlServer;

public static class SqlServerIntegrationOptionsExtension
{
    public static NoxIntegrationOptionsBuilder WithSqlServerStore(this NoxIntegrationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.TryAddSingleton<INoxDatabaseProvider>(provider => new SqlServerDatabaseProvider(
            NoxDataStoreType.IntegrationStore,
            provider.GetServices<INoxTypeDatabaseConfigurator>(),
            provider.GetRequiredService<NoxCodeGenConventions>(),
            provider.GetRequiredService<INoxClientAssemblyProvider>())
        );
        return optionsBuilder;
    }
}