using System.Dynamic;
using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Adapters;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTargetAdapter
{
    CustomDestination<ExpandoObject> MetricsTarget { get; }
    
    TargetAdapterMetrics Metrics { get; }
}

public interface INoxTargetAdapter<TTarget>
{
    IntegrationTargetAdapterType AdapterType { get; }
    CustomDestination<TTarget> MetricsTarget { get; }
    TargetAdapterMetrics Metrics { get; }
}