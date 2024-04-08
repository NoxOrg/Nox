using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Exceptions;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerTableSendAdapter: INoxDatabaseSendAdapter
{
    public IntegrationTargetAdapterType AdapterType => IntegrationTargetAdapterType.DatabaseTable;
    
    private readonly SqlConnectionManager _connectionManager;
    
    public string? StoredProcedure { get; }
    public string? TableName { get; }

    public DbMerge<ExpandoObject>? TableTarget =>
        new(_connectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = MergeMode.InsertsAndUpdates
        };

    public CustomDestination<ExpandoObject>? StoredProcTarget { get; }
    
    

    public string? SchemaName { get; }

    public SqlServerTableSendAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName)
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

        _connectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
    }
    
}