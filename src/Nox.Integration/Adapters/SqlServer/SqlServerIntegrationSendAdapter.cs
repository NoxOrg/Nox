using Nox.Integration.Abstractions;

namespace Nox.Integration.Adapters;

public class SqlServerIntegrationSendAdapter: INoxSendAdapter
{
    public IntegrationAdapterType AdapterType { get; set; }
    public NoxSendAdapterDatabaseOptions? DatabaseOptions { get; set; }
    public Task<INoxSendAdapterResponse> Execute()
    {
        //todo this must return an actual response
        return Task.FromResult((INoxSendAdapterResponse)new NoxSendAdapterResponse());
    }
}