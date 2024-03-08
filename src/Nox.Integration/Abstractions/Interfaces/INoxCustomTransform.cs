namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxCustomTransform
{
    string IntegrationName { get; }
    dynamic Invoke(dynamic sourceRecord);
}