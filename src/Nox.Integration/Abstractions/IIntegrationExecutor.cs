namespace Nox.Integration.Abstractions;

public interface IIntegrationExecutor
{
    Task ExecuteAsync(string integrationName);
}