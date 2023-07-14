namespace Nox.Integration.Abstractions;

public interface IIntegrationSourceFactory
{
    IIntegrationSource Create(string name);
}