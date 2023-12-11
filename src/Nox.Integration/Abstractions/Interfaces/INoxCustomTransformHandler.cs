namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxCustomTransformHandler
{
    string IntegrationName { get; }
    dynamic Invoke(dynamic sourceRecord);
}