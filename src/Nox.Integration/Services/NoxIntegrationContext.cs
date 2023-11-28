using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions;
using Nox.Solution;

namespace Nox.Integration.Services;

internal sealed class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly ILogger _logger;
    private readonly IDictionary<string, INoxIntegration> _integrations;
    private readonly NoxSolution _solution;
    private readonly IDictionary<string, INoxCustomTransformHandler>? _handlers;
    
    public NoxIntegrationContext(ILogger<INoxIntegrationContext> logger, NoxSolution solution, IEnumerable<INoxCustomTransformHandler>? handlers = null)
    {
        _logger = logger;
        _integrations = new Dictionary<string, INoxIntegration>();
        _solution = solution;
        _handlers = handlers?.ToList().ToDictionary(k => k.IntegrationName, v => v);
        
        foreach (var integrationDefinition in _solution.Application!.Integrations!)
        {
            var instance = new NoxIntegration(_logger, integrationDefinition);
            instance.WithReceiveAdapter(integrationDefinition.Source, _solution.DataConnections);
            instance.WithSendAdapter(integrationDefinition.Target, _solution.DataConnections);
            _integrations[instance.Name] = instance;
        }
    }

    public async Task<bool> ExecuteIntegrationAsync(string name)
    {
        try
        {
            INoxCustomTransformHandler? handler = null;
            if (_handlers != null && _handlers.TryGetValue(name, out var foundHandler))
            {
                handler = foundHandler;
            }
            
            var result = await _integrations[name].ExecuteAsync(handler);
            return result;
        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException($"Failed to execute integration: {name}, {ex.Message}");
        }
    }

    public void AddIntegration(INoxIntegration instance)
    {
        _integrations[instance.Name] = instance;
    }
}

