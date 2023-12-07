using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.Integration.Abstractions;

namespace Nox.Integration.SqlServer;

public static class SqlServerIntegrationOptionsExtension
{
    public static NoxIntegrationOptionsBuilder WithSqlServerStore(this NoxIntegrationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.AddSingleton<INoxIntegrationDatabaseProvider, SqlServerIntegrationDatabaseProvider>();
        return optionsBuilder;
    }
}