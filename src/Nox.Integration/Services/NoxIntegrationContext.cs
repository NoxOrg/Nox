using Elastic.Apm;
using Elastic.Apm.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
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
    
    public NoxIntegrationContext(
        ILogger<INoxIntegrationContext> logger, 
        NoxSolution solution, 
        INoxIntegrationDbContextFactory dbContextFactory,
        IPublisher publisher,
        IEnumerable<INoxCustomTransformHandler>? handlers = null,
        IEnumerable<EtlRecordCreatedEvent<IEtlEventDto>>? createdEvents = null,
        IEnumerable<EtlRecordUpdatedEvent<IEtlEventDto>>? updatedEvents = null,
        IEnumerable<EtlExecuteCompletedEvent>? completedEvents = null)
    {
        _logger = logger;
        _integrations = new Dictionary<string, INoxIntegration>();
        _solution = solution;
        _handlers = handlers?.ToList().ToDictionary(k => k.IntegrationName, v => v);

        if (_solution.Application == null || _solution.Application.Integrations == null)
        {
            _logger.LogInformation("Yaml definition does not contain any Integration definitions.");
        }
        else
        {
            foreach (var integrationDefinition in _solution.Application!.Integrations!)
            {
                //Resolve the events
                var createdEvent = createdEvents?.FirstOrDefault(e => e.IntegrationName == integrationDefinition.Name);
                var updatedEvent = updatedEvents?.FirstOrDefault(e => e.IntegrationName == integrationDefinition.Name);
                var completedEvent = completedEvents?.FirstOrDefault(e => e.IntegrationName == integrationDefinition.Name);
                
                var instance = new NoxIntegration(_logger, integrationDefinition, dbContextFactory, publisher, createdEvent, updatedEvent, completedEvent)
                    .WithReceiveAdapter(integrationDefinition.Source, _solution.DataConnections)
                    .WithSendAdapter(integrationDefinition.Target, _solution.DataConnections)
                    .WithTargetDto(integrationDefinition.Target, _solution.Domain);
                _integrations[instance.Name] = instance;
            }    
        }
        
    }

    public async Task ExecuteIntegrationAsync(string name)
    {
        try
        {
            var apmTransaction = Agent.Tracer.StartTransaction(name, ApiConstants.ActionExec);
            INoxCustomTransformHandler? handler = null;
            if (_handlers != null && _handlers.TryGetValue(name, out var foundHandler))
            {
                handler = foundHandler;
            }
            
            await _integrations[name].ExecuteAsync(apmTransaction, handler);
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
    
    public void ExecuteStartupIntegrations()
    {
        var startupIntegrations = _integrations.Where(i => i.Value.Schedule is { RunOnStartup: true });
        foreach (var integration in startupIntegrations)
        {
            Task.Run(async () => await ExecuteIntegrationAsync(integration.Key)).ContinueWith((t) =>
            {
                if (t.IsFaulted) _logger.LogError(t.Exception, $"Error executing {integration.Key} integration at startup.");
                if (t.IsCompletedSuccessfully) _logger.LogInformation($"Successfully executed {integration.Key} integration at startup.");
            });
        }
    }
    
}

