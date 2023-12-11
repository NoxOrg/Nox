using System.Dynamic;
using ETLBox;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxReceiveAdapter
{
    IntegrationSourceAdapterType AdapterType { get; }
    IDataFlowExecutableSource<ExpandoObject> DataFlowSource { get; }
    void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates);
}