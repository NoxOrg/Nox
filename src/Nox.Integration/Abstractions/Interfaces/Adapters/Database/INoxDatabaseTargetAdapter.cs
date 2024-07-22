using System.Dynamic;
using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxDatabaseTargetAdapter: INoxTargetAdapter
{
    string? StoredProcedure { get; }
    string? TableName { get; }
    DbMerge<ExpandoObject>? TableTarget { get; }
    
    CustomDestination<ExpandoObject>? StoredProcTarget { get; } 
    
    event InsertEventHandler? OnInsert;
    event UpdateEventHandler? OnUpdate;

    string? SchemaName { get; }
}

public interface INoxDatabaseTargetAdapter<TTarget>: INoxTargetAdapter<TTarget>
{
    string? StoredProcedure { get; }
    string? TableName { get; }
    DbMerge<TTarget>? TableTarget { get; }
    CustomDestination<TTarget>? StoredProcTarget { get; } 
    
    event InsertEventHandler? OnInsert;
    event UpdateEventHandler? OnUpdate;
    
    string? SchemaName { get; }
}