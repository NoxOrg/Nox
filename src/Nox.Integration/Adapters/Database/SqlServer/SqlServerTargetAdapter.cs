using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Newtonsoft.Json;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerTargetAdapter: SqlServerTargetAdapterBase, INoxDatabaseTargetAdapter
{
    private readonly MergeMode _mergeMode;
    
    public DbMerge<ExpandoObject>? TableTarget =>
        new(BaseConnectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = _mergeMode
        };

    public CustomDestination<ExpandoObject>? StoredProcTarget { get; }

    public CustomDestination<ExpandoObject> MetricsTarget => CreateMetricsTarget();
    
    public SqlServerTargetAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName, MergeMode mergeMode): base(connectionString, schemaName, storedProcedure, tableName)
    {
        _mergeMode = mergeMode;
    }

    private CustomDestination<ExpandoObject> CreateMetricsTarget()
    {
        return new CustomDestination<ExpandoObject>
        {
            WriteAction = WriteAction
        };
    }

    
}

public class SqlServerTargetAdapter<TTarget>: SqlServerTargetAdapterBase, INoxDatabaseTargetAdapter<TTarget>
{
    private readonly MergeMode _mergeMode;
    
    public DbMerge<TTarget> TableTarget =>
        new(BaseConnectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = _mergeMode
        };

    public CustomDestination<TTarget>? StoredProcTarget { get; }

    public CustomDestination<TTarget> MetricsTarget => CreateMetricsTarget();
    
    public SqlServerTargetAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName, MergeMode mergeMode): base(connectionString, schemaName, storedProcedure, tableName)
    {
        _mergeMode = mergeMode;
    }

    private CustomDestination<TTarget> CreateMetricsTarget()
    {
        return new CustomDestination<TTarget>
        {
            WriteAction = WriteAction
        };
    }
}