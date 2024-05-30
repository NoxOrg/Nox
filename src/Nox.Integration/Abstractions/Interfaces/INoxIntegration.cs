using Elastic.Apm.Api;
using Nox.Solution;

namespace Nox.Integration.Abstractions.Interfaces;

internal interface INoxIntegration<out TSource, in TTarget> 
    where TSource : class 
    where TTarget : class
{
    string Name { get; }
    string? Description { get; }
    
    internal IntegrationSchedule? Schedule { get; }
    
    internal IntegrationMergeType MergeType { get; }
    
    internal IntegrationTransformType TransformType { get; }
    
    internal Type? DtoType { get; set; }
    
    List<string>? TargetIdColumns { get; }
    List<string>? TargetDateColumns { get; }
    
    List<string>? SourceFilterColumns { get; }
    
    internal Task ExecuteAsync(ITransaction apmTransaction, INoxTransform<TSource, TTarget>? transform);
}