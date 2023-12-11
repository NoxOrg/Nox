using Elastic.Apm.Api;
using Nox.Solution;

namespace Nox.Integration.Abstractions.Interfaces;

internal interface INoxIntegration
{
    string Name { get; }
    string? Description { get; }
    
    internal IntegrationSchedule? Schedule { get; }
    
    internal IntegrationMergeType MergeType { get; }
    
    internal IntegrationTransformType TransformType { get; }
    
    internal INoxReceiveAdapter? ReceiveAdapter { get; set; }
    internal INoxSendAdapter? SendAdapter { get; set; }

    internal Type? DtoType { get; set; }
    
    List<string>? TargetIdColumns { get; }
    List<string>? TargetDateColumns { get; }
    
    List<string>? SourceFilterColumns { get; }
    
    internal Task ExecuteAsync(ITransaction apmTransaction, INoxCustomTransformHandler? handler = null);

    //todo mapping handler, custom or AutoMapper.
    // If custom, it should create a handler that a user can implement and use to map fields.
}