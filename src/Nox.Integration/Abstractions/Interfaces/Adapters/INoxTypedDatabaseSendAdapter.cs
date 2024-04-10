using ETLBox.DataFlow;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTypedDatabaseTargetAdapter<TTarget>: INoxTargetAdapter
    where TTarget: INoxTransformDto
{
    string? StoredProcedure { get; }
    string? TableName { get; }
    DbMerge<TTarget>? TableTarget { get; }
    CustomDestination<TTarget>? StoredProcTarget { get; } 
    string? SchemaName { get; }
}