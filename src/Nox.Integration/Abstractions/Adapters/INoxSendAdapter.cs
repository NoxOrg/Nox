using ETLBox;

namespace Nox.Integration.Abstractions.Adapters;

public interface INoxSendAdapter
{
    public IntegrationSourceAdapterType SourceAdapterType { get; }
    public IDataFlowDestination DataFlowTarget { get; }
   
}