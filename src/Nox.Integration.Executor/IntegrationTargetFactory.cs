using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.IntegrationSource.File;
using Nox.Solution;

namespace Nox.Integration.Executor;

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
                    
                    break;
            }
            
            
            // var dataConnectionDef = _solution.Infrastructure!.Dependencies!.DataConnections!.FirstOrDefault(dc => dc.Name.Equals(targetDef.DataConnectionName, StringComparison.OrdinalIgnoreCase));
            // if (dataConnectionDef == null) throw new NoxIntegrationException(string.Format((string)ExceptionResources.DataConnectionMissing, targetDef.DataConnectionName, targetName, integrationDef.Name));
            // switch (dataConnectionDef.Provider)
            // {
            //     case DataConnectionProvider.CsvFile:
            //         var csvTarget = new CsvIntegrationSource(targetDef, dataConnectionDef);
            //         return csvTarget;
            // }
        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException(string.Format((string)ExceptionResources.TargetContructionFailure, targetName, integrationName), ex);    
        }
        throw new NoxIntegrationException(string.Format((string)ExceptionResources.TargetContructionFailure, targetName, integrationName));    
    }
}