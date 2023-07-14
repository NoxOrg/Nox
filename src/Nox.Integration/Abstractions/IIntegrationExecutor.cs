namespace Nox.Integration.Abstractions;

public interface IIntegrationExecutor
{
    Task<bool> ExecuteAsync(string integrationName);
}