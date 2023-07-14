using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Solution;

namespace Nox.Integration;

public class Executor: IExecutor
{
    private readonly ILogger _logger;
    private readonly Solution.Solution _solution;

    public Executor(
        ILogger<Executor> logger,
        Solution.Solution solution)
    {
        _logger = logger;
        _solution = solution;
    }
    
    public Task<bool> ExecuteAsync(string integrationName)
    {
        if (_solution.Application == null || _solution.Application.Integrations == null || !_solution.Application.Integrations.Any()) 
            throw new NoxIntegrationException(ExceptionResources.IntegrationsDefinitionMissing);
        var integration = _solution.Application.Integrations.FirstOrDefault(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
        if (integration == null) throw new NoxIntegrationException(ExceptionResources.IntegrationsDefinitionMissing);
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