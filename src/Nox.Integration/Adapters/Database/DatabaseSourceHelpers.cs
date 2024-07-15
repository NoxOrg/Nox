using Microsoft.Data.SqlClient;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class DatabaseSourceHelpers
{
    internal static object? CreateDatabaseQuerySourceAdapter(Type sourceType, string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                return CreateSqlServerQuerySourceAdapter(sourceType, integrationName, options, dataConnectionDefinition);
        }

        throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} source adapter for integration {integrationName} is not implemented.");
    }

    internal static object? CreateDatabaseProcedureSourceAdapter(Type sourceType, string integrationName, IntegrationSourceProcedureOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                return CreateSqlServerProcedureSourceAdapter(sourceType, integrationName, options, dataConnectionDefinition);
        }
        throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} source adapter for integration {integrationName} is not implemented.");
    }
    
    private static object? CreateSqlServerQuerySourceAdapter(Type sourceType, string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapterType = typeof(SqlServerQuerySourceAdapter<>).MakeGenericType(sourceType);
        return Activator.CreateInstance(adapterType, options.Query, options.MinimumExpectedRecords!.Value, csb.ConnectionString);
    }
    
    private static object? CreateSqlServerProcedureSourceAdapter(Type sourceType, string integrationName, IntegrationSourceProcedureOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapterType = typeof(SqlServerProcedureSourceAdapter<>).MakeGenericType(sourceType);
        return Activator.CreateInstance(adapterType, options.StoredProcedure, options.Parameters, csb.ConnectionString);
    }
}
