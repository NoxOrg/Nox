using System.Dynamic;
using ETLBox.DataFlow;
using Nox.Integration.Adapters;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTargetAdapter
{
    public IntegrationTargetAdapterType AdapterType { get; }
    public CustomDestination<ExpandoObject> MetricsTarget { get; }
    
    public TargetAdapterMetrics Metrics { get; }
}

public interface INoxTargetAdapter<TTarget>
where TTarget: INoxTransformDto
{
    public IntegrationTargetAdapterType AdapterType { get; }
    public CustomDestination<TTarget> MetricsTarget { get; }
    public TargetAdapterMetrics Metrics { get; }
}