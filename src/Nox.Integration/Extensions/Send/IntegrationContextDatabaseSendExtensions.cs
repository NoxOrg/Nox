using System;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions;
using Nox.Integration.Adapters;
using Nox.Integration.SqlServer;
using Nox.Solution;
namespace Nox.Integration.Extensions.Send;

public static class IntegrationContextDatabaseSendExtensions
{
    internal static INoxIntegration WithDatabaseTableSendAdapter(this INoxIntegration instance, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.SendAdapter = CreateSqlServerTableAdapter(instance.Name, options, dataConnectionDefinition);
                break;
                default:
                    throw new NotImplementedException();
        }

        return instance;
    }
    
    internal static SqlServerTableSendAdapter CreateSqlServerTableAdapter(string integrationName, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerTableSendAdapter(csb.ConnectionString, options.SchemaName, null, options.TableName);
        return adapter;
    }
    
    internal static INoxIntegration WithStoredProcedureSendAdapter(this INoxIntegration instance, IntegrationTargetStoredProcedureOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.SendAdapter = CreateSqlServerProcAdapter(instance.Name, options, dataConnectionDefinition);
                break;
            default:
                throw new NotImplementedException();
        }

        return instance;
    }
    
    internal static SqlServerTableSendAdapter CreateSqlServerProcAdapter(string integrationName, IntegrationTargetStoredProcedureOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerTableSendAdapter(csb.ConnectionString, options.SchemaName, options.StoredProcedure, null);
        return adapter;
    }
}