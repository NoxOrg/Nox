using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Abstractions;

public interface INoxIntegration
{
    string Name { get; }
    string? Description { get; }
    
    internal IntegrationMergeType MergeType { get; }
    
    internal IntegrationTransformType TransformType { get; }
    
    internal INoxReceiveAdapter? ReceiveAdapter { get; set; }
    internal INoxSendAdapter? SendAdapter { get; set; }
    
    List<string>? IdColumns { get; }
    List<string>? DateColumns { get; }
    
    internal Task<bool> ExecuteAsync(IEnumerable<INoxCustomTransformHandler>? handlers = null);

    //todo mapping handler, custom or AutoMapper.
    // If custom, it should create a handler that a user can implement and use to map fields.
}