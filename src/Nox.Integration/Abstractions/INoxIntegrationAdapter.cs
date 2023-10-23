namespace Nox.Integration.Abstractions;

public interface INoxIntegrationAdapter
{
    INoxReceiveAdapter Receive { get; }
    INoxSendAdapter Send { get; }
}