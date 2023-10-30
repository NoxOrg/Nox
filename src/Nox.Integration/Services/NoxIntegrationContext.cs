using Nox.Integration.Abstractions;
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
            
            _integrations.Add(instance);
        }
        
        //todo Interrogate the solution definition and build a list of integrations
        //iteratate yaml and build integration instances
    }
    
    public Task<bool> ExecuteIntegrationAsync(string name)
    {
        //todo this must execute an integration from _integrations;
        //Execute the Receive Adapter - this loads records from the adapter source
        //Do Transformation/mapping
        //Execute the Send Adapter - this sends the records to the target
        //Handle Send Adapter response
        
        //this must return flag to indicate success or failure
        return Task.FromResult(true);
    }

}

