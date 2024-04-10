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
    
    internal INoxSourceAdapter? SourceAdapter { get; set; }
    internal INoxTargetAdapter? TargetAdapter { get; set; }

    internal Type? DtoType { get; set; }
    
    List<string>? TargetIdColumns { get; }
    List<string>? TargetDateColumns { get; }
    
    List<string>? SourceFilterColumns { get; }
    
    internal Task ExecuteAsync(ITransaction apmTransaction, INoxTransform<INoxTransformDto, INoxTransformDto>? transform = null);

    //todo mapping handler, custom or AutoMapper.
    // If custom, it should create a handler that a user can implement and use to map fields.
}