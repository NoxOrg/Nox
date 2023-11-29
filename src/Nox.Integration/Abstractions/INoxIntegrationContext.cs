namespace Nox.Integration.Abstractions;

internal interface INoxIntegrationContext
{
    Task ExecuteIntegrationAsync(string name);
    void AddIntegration(INoxIntegration instance);

    void ExecuteStartupIntegrations();
}