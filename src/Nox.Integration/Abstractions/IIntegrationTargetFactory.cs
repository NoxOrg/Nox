namespace Nox.Integration.Abstractions;

public interface IIntegrationTargetFactory
{
    IIntegrationTarget Create(string name);
}