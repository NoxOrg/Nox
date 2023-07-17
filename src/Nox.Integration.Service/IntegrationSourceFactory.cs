using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.IntegrationSource.File;
using Nox.Solution;

namespace Nox.Integration.Service;

public class IntegrationSourceFactory: IIntegrationSourceFactory
{
    private readonly NoxSolution _solution;

    public IntegrationSourceFactory(NoxSolution solution)
    {
        _solution = solution;
    }

    public IIntegrationSource Create (string sourceName)
    {
        var integrationName = "";
        try
        {
            var integrationDef = _solution.Application!.Integrations!.FirstOrDefault(i => i.Source!.Name.Equals(sourceName, StringComparison.OrdinalIgnoreCase));
            if (integrationDef == null) throw new NoxIntegrationException(string.Format((string)ExceptionResources.SourceMissing, sourceName));
            integrationName = integrationDef.Name;
            var sourceDef = integrationDef.Source;
            if (sourceDef == null) throw new NoxIntegrationException(string.Format((string)ExceptionResources.SourceMissing, sourceName));
            var dataConnectionDef = _solution.Infrastructure!.Dependencies!.DataConnections!.FirstOrDefault(dc => dc.Name.Equals(sourceDef.DataConnectionName, StringComparison.OrdinalIgnoreCase));
            if (dataConnectionDef == null) throw new NoxIntegrationException(string.Format((string)ExceptionResources.DataConnectionMissing, sourceDef.DataConnectionName, sourceName, integrationDef.Name));
            switch (dataConnectionDef.Provider)
            {
                case DataConnectionProvider.CsvFile:
                    var csvSource = new CsvIntegrationSource(sourceDef, dataConnectionDef);
                    return csvSource;
            }
        }
        catch (Exception ex)
        {
            throw new NoxIntegrationException(string.Format((string)ExceptionResources.SourceContructionFailure, sourceName, integrationName), ex);    
        }
        throw new NoxIntegrationException(string.Format((string)ExceptionResources.SourceContructionFailure, sourceName, integrationName));    
    }
}