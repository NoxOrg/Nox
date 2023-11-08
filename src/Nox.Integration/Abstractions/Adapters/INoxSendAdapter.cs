using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;

namespace Nox.Integration.Abstractions.Adapters;

public interface INoxSendAdapter
{
    public IntegrationTargetAdapterType AdapterType { get; }
   
}