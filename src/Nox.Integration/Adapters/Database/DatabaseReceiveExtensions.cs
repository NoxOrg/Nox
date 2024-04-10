using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class DatabaseSourceExtensions
{
    internal static INoxIntegration WithDatabaseSourceAdapter(this INoxIntegration instance, string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.SourceAdapter = CreateSqlServerSourceAdapter(integrationName, options, dataConnectionDefinition);
                break;
        }

        return instance;
    }
    
    private static SqlServerQuerySourceAdapter CreateSqlServerSourceAdapter(string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerQuerySourceAdapter(options.Query, options.MinimumExpectedRecords!.Value, csb.ConnectionString);
        return adapter;
    }
}