using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Solution;

namespace Nox.Integration.Services;

public class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly List<INoxIntegration> _integrations;
    private readonly Solution.Solution _solution;
    
    public NoxIntegrationContext(Solution.Solution solution)
    {
        _integrations = new List<INoxIntegration>();
        _solution = solution;
    }

    public void Initialize()
    {
        foreach (var integration in _solution.Application!.Integrations!)
        {
            var instance = new NoxIntegration(integration.Name, integration.Description);
            instance.WithReceiveAdapter(integration.Source, _solution.Infrastructure?.Dependencies?.DataConnections);
            instance.WithSendAdapter(integration.Target, _solution.Infrastructure?.Dependencies?.DataConnections);
            
            _integrations.Add(instance);
        }
        
        //todo Interrogate the solution definition and build a list of integrations
        //iteratate yaml and build integration instances
    }
    
    public async Task<bool> ExecuteIntegrationAsync(string name)
    {
        var integration = _integrations.Single(i => i.Name == name);
        var result = await integration.ExecuteAsync();
        return result;
    }

    public void AddIntegration(INoxIntegration instance)
    {
        _integrations.Add(instance);
    }
}

