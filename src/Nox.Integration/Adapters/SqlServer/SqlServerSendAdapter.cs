using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Adapters;
using Nox.Integration.Exceptions;

namespace Nox.Integration.Adapters;

public class SqlServerSendAdapter: INoxDatabaseSendAdapter
{
    public IntegrationTargetAdapterType AdapterType => IntegrationTargetAdapterType.DatabaseTable;
    public string? StoredProcedure { get; }
    public string? TableName { get; }
    public DbMerge<ExpandoObject>? TableTarget { get; }
    
    public CustomDestination<ExpandoObject>? StoredProcTarget { get; }

    public string? SchemaName { get; }

    public SqlServerSendAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName)
    {
        if (string.IsNullOrWhiteSpace(storedProcedure) && string.IsNullOrWhiteSpace(tableName))
        {
            throw new NoxIntegrationConfigurationException("a Sql Server Send Adapter must have either a Stored Procedure or Table Name specified!");
        }

        if (!string.IsNullOrWhiteSpace(storedProcedure) && !string.IsNullOrWhiteSpace(tableName))
        {
            throw new NoxIntegrationConfigurationException("a Sql Server Send Adapter cannot have both a Stored Procedure and Table Name specified! Only one option allowed.");
        }
        
        
        StoredProcedure = storedProcedure;
        TableName = tableName;
        SchemaName = schemaName ?? "dbo";
        
        var connectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
        switch (AdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                TableTarget = new DbMerge(connectionManager, TableName)
                {
                    CacheMode = CacheMode.Partial,
                    MergeMode = MergeMode.InsertsAndUpdates
                };
                break;
            case IntegrationTargetAdapterType.StoredProcedure:
                //todo create a store procedure target
                StoredProcTarget = new CustomDestination();
                break;
            default:
                throw new NotImplementedException($"Adapter type {Enum.GetName(IntegrationTargetAdapterType.DatabaseTable)}, is not implemented in SqlServerSendAdapter");
        }
        
    }
    
}