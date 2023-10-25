namespace Nox.Integration.Abstractions;

public interface INoxSendAdapter
{
    public IntegrationAdapterType AdapterType { get; internal set; }

    public NoxSendAdapterDatabaseOptions? DatabaseOptions { get; internal set; }
    Task<INoxSendAdapterResponse> Execute();
}