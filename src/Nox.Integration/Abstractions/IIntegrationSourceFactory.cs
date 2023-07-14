namespace Nox.Integration.Abstractions;

public interface IIntegrationSourceFactory
{
    ISource Create(string name);
}