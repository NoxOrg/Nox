namespace Nox.Integration.Abstractions;

public interface INoxIntegrationContext
{
    Task<bool> ExecuteIntegrationAsync(string name);
}