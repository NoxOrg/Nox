using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class DatabaseTargetHelpers
{
    internal static object? CreateDatabaseTargetAdapter(Type targetType, string integrationName, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition, MergeMode mergeMode)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                return CreateSqlServerTableAdapter(targetType, integrationName, options, dataConnectionDefinition, mergeMode);
            default:
                throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} target adapter for integration {integrationName} has not been implemented");
        }
    }
    
    private static object? CreateSqlServerTableAdapter(Type targetType, string integrationName, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition, MergeMode mergeMode)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapterType = typeof(SqlServerTargetAdapter<>).MakeGenericType(targetType);
        return Activator.CreateInstance(adapterType, csb.ConnectionString, options.SchemaName, null, options.TableName, mergeMode);
    }
}