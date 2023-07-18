using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Integration.Store;
using Nox.Solution;

namespace Nox.Integration.Service;

public class IntegrationExecutor: IIntegrationExecutor
{
    private readonly ILogger _logger;
    private readonly IStoreService _storeService;
    private readonly IIntegrationSourceFactory _sourceFactory;
    private readonly IIntegrationTargetFactory _targetFactory;
    private readonly NoxSolution _solution;
    private readonly IntegrationDbContext _dbContext;

    public IntegrationExecutor(
        ILogger<IIntegrationExecutor> logger,
        IStoreService storeService,
        IIntegrationSourceFactory sourceFactory,
        IIntegrationTargetFactory targetFactory,
        NoxSolution solution,
        IntegrationDbContext dbContext)
    {
        _logger = logger;
        _storeService = storeService;
        _dbContext = dbContext;
        _sourceFactory = sourceFactory;
        _targetFactory = targetFactory;
        _solution = solution;
    }
    
    public async Task ExecuteAsync(string integrationName)
    {
        try
        {
            if (_solution.Application?.Integrations == null || !_solution.Application.Integrations.Any())
                throw new NoxIntegrationException(ExceptionResources.IntegrationsDefinitionMissing);
            var integration = _solution.Application.Integrations.FirstOrDefault(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
            if (integration == null) throw new NoxIntegrationException(ExceptionResources.IntegrationsDefinitionMissing);
            var source = _sourceFactory.Create(integration.Source!.Name);
            var target = _targetFactory.Create(integration.Target!.Name);
            if (integration.Target.TargetType == IntegrationTargetType.Entity)
            {
                var entity = _solution.Domain!.Entities.First(e => e.Name == target.Name);
                await new EntityExecutor(_logger, integration, _storeService, source, target, entity)
                    .ExecuteAsync();
            }
        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException($"Unable to execute integration {integrationName}", ex);
        }

    }

    
}