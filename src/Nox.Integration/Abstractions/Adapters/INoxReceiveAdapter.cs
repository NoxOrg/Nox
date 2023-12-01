using System.Dynamic;
using ETLBox;

namespace Nox.Integration.Abstractions.Adapters;

public interface INoxReceiveAdapter
{
    IntegrationSourceAdapterType AdapterType { get; }
    IDataFlowExecutableSource<ExpandoObject> DataFlowSource { get; }
    void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates);
}