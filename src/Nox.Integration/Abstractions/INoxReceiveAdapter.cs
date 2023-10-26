namespace Nox.Integration.Abstractions;

public interface INoxReceiveAdapter
{
    public IntegrationAdapterType AdapterType { get; internal set; }
    
    public NoxReceiveAdapterDatabaseOptions? DatabaseOptions { get;  internal set; }
    
    //todo create a EtlBox source which we can use in an Etl Network
    
}