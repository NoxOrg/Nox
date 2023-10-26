using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration;

public class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly List<INoxIntegration> _integrations;
    
    public NoxIntegrationContext(NoxSolution solution)
    {
        _integrations = new List<INoxIntegration>();
    }

    public void Initialize()
    {
        //todo this must be called from service extension.
        //todo Interrogate the solution definition and build a list of integrations
        //iteratate yaml and build integration instances
        //Add instance to _integrations
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

