using ETLBox.DataFlow;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxEtlMessageTargetAdapter<TTarget> : INoxTargetAdapter<TTarget>
{
    CustomDestination<TTarget>? Target { get; }

    
    
    event InsertEventHandler? OnInsert;
    event UpdateEventHandler? OnUpdate;
}