using ETLBox.SqlServer;
using Nox.Integration.Exceptions;

namespace Nox.Integration.Adapters.SqlServer;

public abstract class SqlServerTableTargetAdapterBase
{
    internal readonly SqlConnectionManager BaseConnectionManager;
    
    public string? StoredProcedure { get; }
    public string? TableName { get; }
    public string? SchemaName { get; }
    
    public TargetAdapterMetrics Metrics { get; }
    
    
    public IntegrationTargetAdapterType AdapterType => IntegrationTargetAdapterType.DatabaseTable;
    
    public delegate void InsertEventHandler(object sender, EventArgs args);
    public event InsertEventHandler? OnInsert;
    protected void RaiseOnInsert()
    {
        OnInsert?.Invoke(this, EventArgs.Empty);
        Metrics.Inserts++;
    }
    
    public delegate void UpdateEventHandler(object sender, EventArgs args);
    public event UpdateEventHandler? OnUpdate;
    protected void RaiseOnUpdate()
    {
        OnUpdate?.Invoke(this, EventArgs.Empty);
        Metrics.Updates++;
    }
    
    public delegate void UnchangedEventHandler(object sender, EventArgs args);
    public event UnchangedEventHandler? OnUnchanged;
    protected void RaiseOnUnchanged()
    {
        OnUnchanged?.Invoke(this, EventArgs.Empty);
        Metrics.Unchanged++;
    }

    protected SqlServerTableTargetAdapterBase(string connectionString, string? schemaName, string? storedProcedure, string? tableName)
    {
        if (string.IsNullOrWhiteSpace(storedProcedure) && string.IsNullOrWhiteSpace(tableName))
        {
            throw new NoxIntegrationConfigurationException("a Sql Server Target Adapter must have either a Stored Procedure or Table Name specified!");
        }

        if (!string.IsNullOrWhiteSpace(storedProcedure) && !string.IsNullOrWhiteSpace(tableName))
        {
            throw new NoxIntegrationConfigurationException("a Sql Server Target Adapter cannot have both a Stored Procedure and Table Name specified! Only one option allowed.");
        }

        StoredProcedure = storedProcedure;
        TableName = tableName;
        SchemaName = schemaName ?? "dbo";
        Metrics = new TargetAdapterMetrics();

        BaseConnectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
    }
    
}