namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxIntegrationContext
{
    Task ExecuteIntegrationAsync(string name);

    void ExecuteStartupIntegrations();
}