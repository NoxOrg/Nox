namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTypedFileSourceAdapter<TSource>: INoxTypedSourceAdapter<TSource>
    where TSource: INoxTransformDto
{
    
}