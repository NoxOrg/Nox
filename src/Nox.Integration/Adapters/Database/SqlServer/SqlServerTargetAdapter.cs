using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Newtonsoft.Json;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerTargetAdapter: SqlServerTargetAdapterBase, INoxDatabaseTargetAdapter
{
    public DbMerge<ExpandoObject>? TableTarget =>
        new(BaseConnectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = MergeMode.InsertsAndUpdates
        };

    public CustomDestination<ExpandoObject>? StoredProcTarget { get; }

    public CustomDestination<ExpandoObject> MetricsTarget => CreateMetricsTarget();
    
    public SqlServerTargetAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName): base(connectionString, schemaName, storedProcedure, tableName)
    {
        
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
    public DbMerge<TTarget>? TableTarget =>
        new(BaseConnectionManager, TableName)
        {
            CacheMode = CacheMode.Partial,
            MergeMode = MergeMode.InsertsAndUpdates
        };

    public CustomDestination<TTarget>? StoredProcTarget { get; }

    public CustomDestination<TTarget> MetricsTarget => CreateMetricsTarget();
    
    public SqlServerTargetAdapter(string connectionString, string? schemaName, string? storedProcedure, string? tableName): base(connectionString, schemaName, storedProcedure, tableName)
    {
        
    }

    private CustomDestination<TTarget> CreateMetricsTarget()
    {
        return new CustomDestination<TTarget>
        {
            WriteAction = WriteAction
        };
    }
}