namespace Nox.Integration.Abstractions;

public interface INoxCustomTransformHandler
{
    string IntegrationName { get; }
    IDictionary<string, string> Invoke();
}