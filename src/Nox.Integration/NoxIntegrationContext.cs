using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration;

public class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly List<INoxIntegration> _integrations;
    
    public NoxIntegrationContext(NoxSolution solution)
    {
        //todo this must be created and configured from solution.
        _integrations = new List<INoxIntegration>();
        
        
        
    }
    
    public Task<bool> ExecuteIntegrationAsync(string name)
    {
        //todo this must execute an integration from _integrations;
        //Execute the Receive Adapter - this loads records from the adapter source
        //Do Transformation
        //Execute the Send Adapter - this sends the records to the target
        //Handle Send Adapter response
        
        return Task.FromResult(true);
    }
}