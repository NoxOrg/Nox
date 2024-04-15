using System.Dynamic;
using ETLBox;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxSourceAdapter
{
    static IntegrationSourceAdapterType AdapterType { get; }
    IDataFlowExecutableSource<ExpandoObject> DataFlowSource { get; }

    void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates);
}

public interface INoxSourceAdapter<TSource>
{
    static IntegrationSourceAdapterType AdapterType { get; }
    IDataFlowExecutableSource<TSource> DataFlowSource { get; }
    void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates);
}