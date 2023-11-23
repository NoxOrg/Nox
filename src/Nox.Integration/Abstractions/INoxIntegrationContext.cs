namespace Nox.Integration.Abstractions;

internal interface INoxIntegrationContext
{
    Task<bool> ExecuteIntegrationAsync(string name);
    void AddIntegration(INoxIntegration instance);
}