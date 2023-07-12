using Microsoft.Extensions.Logging;
using Nox.Etl.Abstractions;
using Nox.Etl.Abstractions.Exceptions;

namespace Nox.Etl;

public class EtlExecutor: IEtlExecutor
{
    private readonly ILogger _logger;
    private readonly Solution.Solution _solution;

    public EtlExecutor(
        ILogger<EtlExecutor> logger,
        Solution.Solution solution)
    {
        _logger = logger;
        _solution = solution;
    }
    
    public async Task<bool> ExecuteAsync(string integrationName)
    {
        if (_solution.Application == null) throw new NoxIntegrationException(IntegrationExceptionResources.IntegrationsDefinitionMissing);
        
        var integration = _solution.Application.Integrations.FirstOrDefault(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
        
        return false;
    }
}