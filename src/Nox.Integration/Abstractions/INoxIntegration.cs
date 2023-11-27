using Nox.Integration.Abstractions.Adapters;
using Nox.Solution;

namespace Nox.Integration.Abstractions;

internal interface INoxIntegration
{
    string Name { get; }
    string? Description { get; }
    
    internal IntegrationSchedule? Schedule { get; }
    
    internal IntegrationMergeType MergeType { get; }
    
    internal IntegrationTransformType TransformType { get; }
    
    internal INoxReceiveAdapter? ReceiveAdapter { get; set; }
    internal INoxSendAdapter? SendAdapter { get; set; }
    
    List<string>? IdColumns { get; }
    List<string>? DateColumns { get; }
    
    internal Task<bool> ExecuteAsync(INoxCustomTransformHandler? handler = null);

    //todo mapping handler, custom or AutoMapper.
    // If custom, it should create a handler that a user can implement and use to map fields.
}