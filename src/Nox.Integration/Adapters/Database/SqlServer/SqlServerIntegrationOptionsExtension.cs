using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.SqlServer;

public static class SqlServerIntegrationOptionsExtension
{
    public static NoxIntegrationOptionsBuilder WithSqlServerStore(this NoxIntegrationOptionsBuilder optionsBuilder)
    {
        optionsBuilder.Services.AddSingleton<INoxIntegrationDatabaseProvider, SqlServerIntegrationDatabaseProvider>();
        return optionsBuilder;
    }
}