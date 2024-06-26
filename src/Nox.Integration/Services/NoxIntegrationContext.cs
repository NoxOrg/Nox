using System.Dynamic;
using System.Reflection;
using Elastic.Apm;
using Elastic.Apm.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Adapters;
using Nox.Integration.Exceptions;
using Nox.Solution;

namespace Nox.Integration.Services;

internal sealed class NoxIntegrationContext: INoxIntegrationContext
{
    private readonly ILogger _logger;
    private readonly NoxSolution _solution;
    private readonly IDictionary<string, INoxTransform>? _transforms;
    private readonly IEnumerable<EtlRecordCreatedEvent<IEtlEventDto>>? _createdEvents;
    private readonly IEnumerable<EtlRecordUpdatedEvent<IEtlEventDto>>? _updatedEvents;
    private readonly IEnumerable<EtlExecuteCompletedEvent>? _completedEvents;
    private readonly INoxIntegrationDbContextFactory _dbContextFactory;
    private readonly IPublisher _publisher;
    
    public NoxIntegrationContext(
        ILogger<INoxIntegrationContext> logger, 
        NoxSolution solution, 
        INoxIntegrationDbContextFactory dbContextFactory,
        IPublisher publisher,
        IEnumerable<INoxTransform>? transforms = null,
        IEnumerable<EtlRecordCreatedEvent<IEtlEventDto>>? createdEvents = null,
        IEnumerable<EtlRecordUpdatedEvent<IEtlEventDto>>? updatedEvents = null,
        IEnumerable<EtlExecuteCompletedEvent>? completedEvents = null)
    {
        _logger = logger;
        _solution = solution;
        if (_solution.Application == null || _solution.Application.Integrations == null)
        {
            _logger.LogInformation("Yaml definition does not contain any Integration definitions.");
        }
        
        _transforms = transforms?.AsEnumerable().ToDictionary(k => k.IntegrationName, v => v);
        _createdEvents = createdEvents;
        _updatedEvents = updatedEvents;
        _completedEvents = completedEvents;
        _dbContextFactory = dbContextFactory;
        _publisher = publisher;
    }

    public async Task ExecuteIntegrationAsync(string name)
    {
        try
        {
            var apmTransaction = Agent.Tracer.StartTransaction(name, ApiConstants.ActionExec);
            INoxTransform? transform = null;
            if (_transforms != null && _transforms.TryGetValue(name, out var foundTransform))
            {
                transform = foundTransform;
            }

            var definition = _solution.Application!.Integrations!.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (definition == null)
            {
                throw new NoxIntegrationException($"Integration: {name} not found in yaml definition!");
            }
        
            //Resolve the events
            var createdEvent = _createdEvents?.FirstOrDefault(e => e.IntegrationName == definition.Name);
            var updatedEvent = _updatedEvents?.FirstOrDefault(e => e.IntegrationName == definition.Name);
            var completedEvent = _completedEvents?.FirstOrDefault(e => e.IntegrationName == definition.Name);

            object? sourceAdapter;
            object? targetAdapter;
            Type? instanceType;

            if (transform == null)
            {
                sourceAdapter = AdapterHelpers.CreateSourceAdapter(typeof(ExpandoObject), name, definition.Source, _solution.DataConnections);
                targetAdapter = AdapterHelpers.CreateTargetAdapter(typeof(ExpandoObject), definition, _solution.DataConnections);
                instanceType = typeof(NoxIntegration<,>).MakeGenericType(typeof(ExpandoObject), typeof(ExpandoObject));
            }
            else
            {
                sourceAdapter = AdapterHelpers.CreateSourceAdapter(transform.SourceType, name, definition.Source, _solution.DataConnections);
                targetAdapter = AdapterHelpers.CreateTargetAdapter(transform.TargetType, definition, _solution.DataConnections);
                instanceType = typeof(NoxIntegration<,>).MakeGenericType(transform.SourceType, transform.TargetType);
            }
            
            var instance = Activator.CreateInstance(instanceType, _logger, definition, _dbContextFactory, _publisher, sourceAdapter, targetAdapter,
                createdEvent, updatedEvent, completedEvent);

            var task = (Task)instanceType.InvokeMember("ExecuteAsync", BindingFlags.InvokeMethod, null, instance, new object?[]{apmTransaction, transform})!;
            await task;

        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException($"Failed to execute integration: {name}, {ex.Message}");
        }
    }
    
    public void ExecuteStartupIntegrations()
    {
        if (_solution.Application?.Integrations != null)
        {
            var startupIntegrations = _solution.Application!.Integrations!.Where(i => i.Schedule?.RunOnStartup == true).ToList();
            foreach (var integration in startupIntegrations)
            {
                Task.Run(async () => await ExecuteIntegrationAsync(integration.Name)).ContinueWith((t) =>
                {
                    if (t.IsFaulted) _logger.LogError(t.Exception, "{action} integration: {name} at startup.", "Error executing", integration.Name);
                    if (t.IsCompletedSuccessfully) _logger.LogInformation("{action} integration: {name} at startup.", "Successfully executed", integration.Name);
                });
            }    
        }
    }
}

