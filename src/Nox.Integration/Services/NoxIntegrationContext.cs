using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions;
using Nox.Solution;

namespace Nox.Integration.Services;

public class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly ILogger _logger;
    private readonly List<INoxIntegration> _integrations;
    private readonly NoxSolution _solution;
    private readonly IEnumerable<INoxCustomTransformHandler>? _handlers;
    
    public NoxIntegrationContext(ILogger<INoxIntegrationContext> logger, NoxSolution solution, IEnumerable<INoxCustomTransformHandler>? handlers = null)
    {
        _logger = logger;
        _integrations = new List<INoxIntegration>();
        _solution = solution;
        _handlers = handlers;
    }

    public void Initialize()
    {
        foreach (var integrationDefinition in _solution.Application!.Integrations!)
        {
            var instance = new NoxIntegration(_logger, integrationDefinition);
            instance.WithReceiveAdapter(integrationDefinition.Source, _solution.Infrastructure?.Dependencies?.DataConnections);
            instance.WithSendAdapter(integrationDefinition.Target, _solution.Infrastructure?.Dependencies?.DataConnections);
            _integrations.Add(instance);
        }
    }
    
    public async Task<bool> ExecuteIntegrationAsync(string name)
    {
        try
        {
            var integration = _integrations.Single(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            var result = await integration.ExecuteAsync(_handlers);
            return result;
        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException($"Integration {name} does not exist in the Integration Context: {ex.Message}");
        }
    }

    public void AddIntegration(INoxIntegration instance)
    {
        _integrations.Add(instance);
    }
}

