using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions;
using Nox.Integration.Adapters;
using Nox.Solution;

namespace Nox.Integration.Extensions.Receive;

public static class IntegrationContextDatabaseReceiveExtensions
{
    internal static INoxIntegration WithDatabaseReceiveAdapter(this INoxIntegration instance, IntegrationSourceDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.ReceiveAdapter = CreateSqlServerReceiveAdapter(instance.Name, options, dataConnectionDefinition);
                break;
        }
        return instance;
    }

    internal static SqlServerReceiveAdapter CreateSqlServerReceiveAdapter(string integrationName, IntegrationSourceDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerReceiveAdapter(options.Query, options.MinimumExpectedRecords!.Value, csb.ConnectionString);
        return adapter;
    }
}