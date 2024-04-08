namespace Nox.Integration.Abstractions.Events;

public class NoxTransformEventArgs<TSource, TTarget> : EventArgs 
    where TSource : new() 
    where TTarget : new()
{
    public TSource Source { get; }
    public TTarget Target { get; } = new();

    public NoxTransformEventArgs(TSource source)
    {
        Source = source;
    }
}