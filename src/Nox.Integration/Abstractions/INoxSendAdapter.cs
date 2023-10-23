namespace Nox.Integration.Abstractions;

public interface INoxSendAdapter
{
    Task<INoxSendAdapterResponse> Execute();
}