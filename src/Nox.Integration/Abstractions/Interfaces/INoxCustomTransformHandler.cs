namespace Nox.Integration.Abstractions;

public interface INoxCustomTransformHandler
{
    string IntegrationName { get; }
    dynamic Invoke(dynamic sourceRecord);
}