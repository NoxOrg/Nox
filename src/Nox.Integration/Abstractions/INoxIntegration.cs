namespace Nox.Integration.Abstractions;

public interface INoxIntegration
{
    public string Name { get; internal set; }
    public string Description { get; internal set; }
    INoxReceiveAdapter ReceiveAdapter { get; internal set; }
    INoxSendAdapter SendAdapter { get; internal set; }

    //todo mapping handler, custom or AutoMapper.
    // If custom, it should create a handler that a user can implement and use to map fields.
}