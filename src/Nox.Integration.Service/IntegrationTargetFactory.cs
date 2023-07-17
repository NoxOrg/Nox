using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.IntegrationTarget.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Service;

public class IntegrationTargetFactory: IIntegrationTargetFactory
{
    private readonly NoxSolution _solution;

    public IntegrationTargetFactory(NoxSolution solution)
    {
        _solution = solution;
    }

    public IIntegrationTarget Create (string targetName)
    {
        var integrationName = "";
        try
        {
            var integrationDef = _solution.Application!.Integrations!.FirstOrDefault(i => i.Target!.Name.Equals(targetName, StringComparison.OrdinalIgnoreCase));
            if (integrationDef == null) throw new NoxIntegrationException(string.Format((string)ExceptionResources.TargetMissing, targetName));
            integrationName = integrationDef.Name;
            var targetDef = integrationDef.Target;
            if (targetDef == null) throw new NoxIntegrationException(string.Format((string)ExceptionResources.TargetMissing, targetName));
            
            switch (targetDef.TargetType)
            {
                case IntegrationTargetType.Entity:
                    var entityStoreDef = _solution.Infrastructure!.Persistence.DatabaseServer;
                    return CreateEntityStoreTarget(integrationDef.Name, targetDef, entityStoreDef);
                default:
                    var dataConnectionDef = _solution.Infrastructure!.Dependencies!.DataConnections!.First(dc => dc.Name.Equals(targetDef.DataConnectionName, StringComparison.OrdinalIgnoreCase));
                    return CreateTarget(integrationDef.Name, targetDef, dataConnectionDef);
            }
        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException(string.Format((string)ExceptionResources.TargetContructionFailure, targetName, integrationName), ex);    
        }
    }

    private IIntegrationTarget CreateTarget(string integrationName, Solution.IntegrationTarget targetDef, DataConnection dataConnectionDef)
    {
        switch (dataConnectionDef.Provider)
        {
            case DataConnectionProvider.SqlServer:
                return new SqlServerIntegrationTarget(targetDef.Name, dataConnectionDef, integrationName);
            default:
                throw new NotImplementedException($"Target provider Type {dataConnectionDef.Provider} has not been implemented yet.");
        }
    }
    
    private IIntegrationTarget CreateEntityStoreTarget(string integrationName, Solution.IntegrationTarget targetDef, DatabaseServer entityStoreDef)
    {
        switch (entityStoreDef.Provider)
        {
            case DatabaseServerProvider.SqlServer:
                return new SqlServerIntegrationTarget(targetDef.Name, entityStoreDef, integrationName);
            default:
                throw new NotImplementedException($"Target provider Type {entityStoreDef.Provider} has not been implemented yet.");
        }
    }
}