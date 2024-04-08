using System.Dynamic;
using ETLBox;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTransform<in TSource, out TTarget>
    where TSource: INoxTransformDto
    where TTarget: INoxTransformDto
{
    string IntegrationName { get; }
    Type SourceType { get; }
    TTarget Invoke(TSource source);
}