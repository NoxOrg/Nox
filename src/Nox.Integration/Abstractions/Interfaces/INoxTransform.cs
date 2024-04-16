namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTransform
{
    string IntegrationName { get; } 
    Type SourceType { get; }
    Type TargetType { get; }
}

public interface INoxTransform<in TSource, out TTarget>: INoxTransform
{
    
    TTarget Invoke(TSource source);
}