using ETLBox;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTypedSourceAdapter<TSource>
    where TSource: INoxTransformDto
{
    IntegrationSourceAdapterType AdapterType { get; }
    IDataFlowExecutableSource<TSource> DataFlowSource { get; }
    void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates);
}