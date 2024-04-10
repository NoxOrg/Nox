using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class IntegrationContextDatabaseTargetExtensions
{
    internal static INoxIntegration WithDatabaseTableTargetAdapter(this INoxIntegration instance, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.TargetAdapter = CreateSqlServerTableAdapter(instance.Name, options, dataConnectionDefinition);
                break;
                default:
                    throw new NotImplementedException();
        }

        return instance;
    }
    
    internal static SqlServerTableTargetAdapter CreateSqlServerTableAdapter(string integrationName, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerTableTargetAdapter(csb.ConnectionString, options.SchemaName, null, options.TableName);
        return adapter;
    }
    
    internal static INoxIntegration WithStoredProcedureTargetAdapter(this INoxIntegration instance, IntegrationTargetStoredProcedureOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.TargetAdapter = CreateSqlServerProcAdapter(instance.Name, options, dataConnectionDefinition);
                break;
            default:
                throw new NotImplementedException();
        }

        return instance;
    }

    internal static SqlServerTableTargetAdapter CreateSqlServerProcAdapter(string integrationName, IntegrationTargetStoredProcedureOptions options, DataConnection dataConnectionDefinition)

    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerTableTargetAdapter(csb.ConnectionString, options.SchemaName, options.StoredProcedure, null);
        return adapter;
    }
}