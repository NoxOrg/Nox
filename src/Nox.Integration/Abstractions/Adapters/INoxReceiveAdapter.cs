using System.Dynamic;
using ETLBox;

namespace Nox.Integration.Abstractions.Adapters;

public interface INoxReceiveAdapter
{
    IntegrationSourceAdapterType SourceAdapterType { get; }
    IDataFlowExecutableSource<ExpandoObject> DataFlowSource { get; }
}