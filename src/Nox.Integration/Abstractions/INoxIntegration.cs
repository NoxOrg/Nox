using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Abstractions;

public interface INoxIntegration
{
    string Name { get; }
    string? Description { get; }
    internal INoxReceiveAdapter? ReceiveAdapter { get; set; }
    internal INoxSendAdapter? SendAdapter { get; set; }
    
    List<string>? IdColumns { get; }
    List<string>? DateColumns { get; }
    
    internal Task<bool> ExecuteAsync();

    //todo mapping handler, custom or AutoMapper.
    // If custom, it should create a handler that a user can implement and use to map fields.
}