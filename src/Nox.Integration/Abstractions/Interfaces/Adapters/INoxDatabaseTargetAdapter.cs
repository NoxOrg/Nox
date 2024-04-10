using System.Dynamic;
using ETLBox.DataFlow;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxDatabaseTargetAdapter: INoxTargetAdapter
{
    string? StoredProcedure { get; }
    string? TableName { get; }
    DbMerge<ExpandoObject>? TableTarget { get; }
    CustomDestination<ExpandoObject>? StoredProcTarget { get; } 
    string? SchemaName { get; }
}

public interface INoxDatabaseTargetAdapter<TTarget>: INoxTargetAdapter<TTarget>
    where TTarget: INoxTransformDto
{
    string? StoredProcedure { get; }
    string? TableName { get; }
    DbMerge<TTarget>? TableTarget { get; }
    CustomDestination<TTarget>? StoredProcTarget { get; } 
    string? SchemaName { get; }
}