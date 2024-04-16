using ETLBox;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class IntegrationContextDatabaseTargetExtensions
{
    internal static SqlServerTargetAdapter<TTarget> CreateSqlServerProcAdapter<TTarget>(string integrationName, IntegrationTargetStoredProcedureOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerTargetAdapter<TTarget>(csb.ConnectionString, options.SchemaName, options.StoredProcedure, null, MergeMode.Full);
        return adapter;
    }
}