using System.Dynamic;
using System.Net.Http.Json;
using ETLBox;
using ETLBox.SqlServer;
using Newtonsoft.Json;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Exceptions;

namespace Nox.Integration.Adapters.SqlServer;

public abstract class SqlServerTargetAdapterBase
{
    internal readonly SqlConnectionManager BaseConnectionManager;
    
    public string? StoredProcedure { get; }
    public string? TableName { get; }
    public string? SchemaName { get; }
    
    public TargetAdapterMetrics Metrics { get; }
    
    
    public IntegrationTargetAdapterType AdapterType => IntegrationTargetAdapterType.DatabaseTable;
    
    public event InsertEventHandler? OnInsert;
    protected void RaiseOnInsert(dynamic dataRecord)
    {
        OnInsert?.Invoke(this, new MetricsEventArgs(dataRecord));
        Metrics.Inserts++;
    }
    
    public event UpdateEventHandler? OnUpdate;
    protected void RaiseOnUpdate(dynamic dataRecord)
    {
        OnUpdate?.Invoke(this, new MetricsEventArgs(dataRecord));
        Metrics.Updates++;
    }
    
    protected void RaiseOnUnchanged()
    {
        Metrics.Unchanged++;
    }

    protected SqlServerTargetAdapterBase(string connectionString, string? schemaName, string? storedProcedure, string? tableName)
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
    
    protected void WriteAction(ExpandoObject dto, int index)
    {
        var record = (IDictionary<string, object?>)dto;
        var changeActionId = (ChangeAction)record["ChangeAction"]!;
        if (changeActionId == ChangeAction.Insert)
        {
            RaiseOnInsert(dto);
        }
        else if (changeActionId == ChangeAction.Update)
        {
            RaiseOnUpdate(dto);
        }
        else if (changeActionId == ChangeAction.Exists)
        {
            RaiseOnUnchanged();
        }
    }
    
    protected void WriteAction<TTarget>(TTarget dto, int index)
    {
        var changeActionProperty = dto!.GetType().GetProperty("ChangeAction");
        if (changeActionProperty != null)
        {
            var changeAction = (ChangeAction)changeActionProperty.GetValue(dto)!;
            if (changeAction == ChangeAction.Insert)
            {
                RaiseOnInsert(dto);
            }
            else if (changeAction == ChangeAction.Update)
            {
                RaiseOnUpdate(dto);
            }
            else if (changeAction == ChangeAction.Exists)
            {
                RaiseOnUnchanged();
            }
        }
    }
    
}