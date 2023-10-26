namespace Nox.Integration.Abstractions;

public interface INoxSendAdapter
{
    public IntegrationAdapterType AdapterType { get; internal set; }

    public NoxSendAdapterDatabaseOptions? DatabaseOptions { get; internal set; }
    
    //Task<INoxSendAdapterResponse> Execute();
    //todo we must create an EtlBox destination which we can link to the source
    //also add a custom destination that we link in after the destination above, so that we can count the inserts, updates and unchanged
    
}