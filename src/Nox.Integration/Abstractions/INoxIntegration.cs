namespace Nox.Integration.Abstractions;

public interface INoxIntegration
{
    public string Name { get; internal set; }
    public string Description { get; internal set; }
    INoxReceiveAdapter ReceiveAdapter { get; internal set; }
    INoxSendAdapter SendAdapter { get; internal set; }
    
    //todo handlers?
    
    //todo mapping?
}