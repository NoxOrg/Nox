namespace Nox.Integration.Abstractions;

public interface INoxIntegrationContext
{
    Task ExecuteIntegrationAsync(string name);

    void ExecuteStartupIntegrations();
}