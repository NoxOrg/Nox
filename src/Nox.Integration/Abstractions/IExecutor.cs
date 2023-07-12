namespace Nox.Integration.Abstractions;

public interface IExecutor
{
    Task<bool> ExecuteAsync(string integrationName);
}