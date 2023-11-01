namespace Nox.Integration.Abstractions;

public interface INoxReceiveAdapter
{
    public IntegrationAdapterType AdapterType { get; internal set; }
    
    public NoxReceiveAdapterDatabaseOptions? DatabaseOptions { get;  internal set; }
    
    Task<bool> Execute();
    
}