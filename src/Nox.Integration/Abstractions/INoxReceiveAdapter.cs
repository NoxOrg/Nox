namespace Nox.Integration.Abstractions;

public interface INoxReceiveAdapter
{
    Task<bool> Execute();
}