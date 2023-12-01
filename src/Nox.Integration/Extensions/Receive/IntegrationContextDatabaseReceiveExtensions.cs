using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions;
using Nox.Integration.Adapters;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Extensions.Receive;

public static class IntegrationContextDatabaseReceiveExtensions
{
    internal static INoxIntegration WithDatabaseReceiveAdapter(this INoxIntegration instance, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.ReceiveAdapter = CreateSqlServerReceiveAdapter(instance.Name, options, dataConnectionDefinition);
                break;
        }
        return instance;
    }

    internal static SqlServerQueryReceiveAdapter CreateSqlServerReceiveAdapter(string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerQueryReceiveAdapter(options.Query, options.MinimumExpectedRecords!.Value, csb.ConnectionString);
        return adapter;
    }
}