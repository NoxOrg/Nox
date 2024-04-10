using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Newtonsoft.Json;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerTableTargetAdapter: SqlServerTableTargetAdapterBase, INoxDatabaseTargetAdapter
{
    public DbMerge<ExpandoObject>? TableTarget =>
        new(BaseConnectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = MergeMode.InsertsAndUpdates
        };

    public CustomDestination<ExpandoObject>? StoredProcTarget { get; }

    public CustomDestination<ExpandoObject> MetricsTarget => CreateMetricsTarget();
    
    public SqlServerTableTargetAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName): base(connectionString, schemaName, storedProcedure, tableName)
    {
        
    }

    private CustomDestination<ExpandoObject> CreateMetricsTarget()
    {
        var result = new CustomDestination<ExpandoObject>();
        result.WriteAction = (dto, i) =>
        {
            var record = (IDictionary<string, object?>)dto;
            var changeActionId = (ChangeAction)record["ChangeAction"]!;
            if (changeActionId == ChangeAction.Insert)
            {
                RaiseOnInsert();
            }
            else if (changeActionId == ChangeAction.Update)
            {
                RaiseOnUpdate();
            }
            else if (changeActionId == ChangeAction.Exists)
            {
                RaiseOnUnchanged();
            }
        };
        return result;
    }
}

public class SqlServerTableTargetAdapter<TTarget>: SqlServerTableTargetAdapterBase, INoxDatabaseTargetAdapter<TTarget>
    where TTarget: INoxTransformDto
{
    public DbMerge<TTarget>? TableTarget =>
        new(BaseConnectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = MergeMode.InsertsAndUpdates
        };

    public CustomDestination<TTarget>? StoredProcTarget { get; }

    public CustomDestination<TTarget> MetricsTarget => CreateMetricsTarget();
    
    public SqlServerTableTargetAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName): base(connectionString, schemaName, storedProcedure, tableName)
    {
        
    }

    private CustomDestination<TTarget> CreateMetricsTarget()
    {
        var result = new CustomDestination<TTarget>();
        result.WriteAction = (dto, i) =>
        {
            var record = (IDictionary<string, object?>)dto;
            var changeActionId = (long)record["ChangeAction"]!;
            if (changeActionId == 1)
            {
                RaiseOnInsert();
            }
            else if (changeActionId == 2)
            {
                RaiseOnUpdate();
            }
            else if (changeActionId == 0)
            {
                RaiseOnUnchanged();
            }
        };
        return result;
    }
}