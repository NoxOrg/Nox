using System.Threading.Tasks;

namespace Nox.Integration.Abstractions;

internal interface INoxIntegrationContext
{
    Task<bool> ExecuteIntegrationAsync(string name);
    void AddIntegration(INoxIntegration instance);

    void ExecuteStartupIntegrations();
}