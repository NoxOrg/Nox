using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Solution;

namespace Nox.Integration.Executor;

public class IntegrationExecutor: IIntegrationExecutor
{
    private readonly ILogger _logger;
    private readonly IIntegrationSourceFactory _sourceFactory;
    private readonly NoxSolution _solution;

    public IntegrationExecutor(
        ILogger<IIntegrationExecutor> logger,
        IIntegrationSourceFactory sourceFactory,
        NoxSolution solution)
    {
        _logger = logger;
        _sourceFactory = sourceFactory;
        _solution = solution;
    }
    
    public Task<bool> ExecuteAsync(string integrationName)
    {
        if (_solution.Application?.Integrations == null || !_solution.Application.Integrations.Any()) 
            throw new NoxIntegrationException(ExceptionResources.IntegrationsDefinitionMissing);
        var integration = _solution.Application.Integrations.FirstOrDefault(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
        if (integration == null) throw new NoxIntegrationException(ExceptionResources.IntegrationsDefinitionMissing);
        var source = _sourceFactory.Create(integration.Source!.Name);
        var target = integration.Target!;
        if (target.TargetType == IntegrationTargetType.Entity)
        {
            var entity = _solution.Domain!.Entities.First(e => e.Name == target.Name);
            
        }
        return Task.FromResult(false);
    }

    private Task Execute(Solution.Integration integration, Entity entity)
    {
        //var sourceProvider = integration.Source
        return Task.CompletedTask;
    }
}