namespace Nox.Integration.Abstractions;

public interface INoxIntegrationExecutor
{
    Task<bool> ExecuteAsync(string name);
}