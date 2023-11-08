using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Solution;

namespace Nox.Integration.Services;

public class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<NoxIntegrationContext> _logger;
    private readonly List<INoxIntegration> _integrations;
    private readonly Solution.Solution _solution;
    
    public NoxIntegrationContext(ILoggerFactory loggerFactory, Solution.Solution solution)
    {
        _loggerFactory = loggerFactory;
        _logger = loggerFactory.CreateLogger<NoxIntegrationContext>();
        _integrations = new List<INoxIntegration>();
        _solution = solution;
    }

    public void Initialize()
    {
        foreach (var integrationDefinition in _solution.Application!.Integrations!)
        {
            var instance = new NoxIntegration(_loggerFactory, integrationDefinition);
            instance.WithReceiveAdapter(integrationDefinition.Source, _solution.Infrastructure?.Dependencies?.DataConnections);
            instance.WithSendAdapter(integrationDefinition.Target, _solution.Infrastructure?.Dependencies?.DataConnections);
            
            _integrations.Add(instance);
        }
        
        //todo Interrogate the solution definition and build a list of integrations
        //iterate yaml and build integration instances
    }
    
    public async Task<bool> ExecuteIntegrationAsync(string name)
    {
        var integration = _integrations.Single(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        var result = await integration.ExecuteAsync();
        return result;
    }

    public void AddIntegration(INoxIntegration instance)
    {
        _integrations.Add(instance);
    }
}

