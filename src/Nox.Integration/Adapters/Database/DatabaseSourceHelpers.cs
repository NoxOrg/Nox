using Microsoft.Data.SqlClient;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class DatabaseSourceHelpers
{
    internal static object? CreateDatabaseSourceAdapter(Type sourceType, string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                
                return CreateSqlServerSourceAdapter(sourceType, integrationName, options, dataConnectionDefinition);
        }

        throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} source adapter for integration {integrationName} is not implemented.");
    }
    
    private static object? CreateSqlServerSourceAdapter(Type sourceType, string integrationName, IntegrationSourceQueryOptions options, DataConnection dataConnectionDefinition)
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
}