using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions.Receive;
using Nox.Integration.Extensions.Send;
using Nox.Solution;

namespace Nox.Integration.Extensions;

public static class IntegrationContextExtensions
{
    public static INoxIntegration WithReceiveAdapter(this INoxIntegration instance, IntegrationSource sourceDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        switch (sourceDefinition.SourceAdapterType)
        {
            case IntegrationSourceAdapterType.DatabaseQuery:
                var dataConnection = ProcessDatabaseSourceDefinition(sourceDefinition, dataConnections);
                instance.WithDatabaseReceiveAdapter(sourceDefinition.QueryOptions!, dataConnection);
                break;
        }

        return instance;
    }
    
    private static DataConnection ProcessDatabaseSourceDefinition(IntegrationSource sourceDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        if (sourceDefinition.QueryOptions == null)
        {
            throw new NoxIntegrationConfigurationException(
                "Query options missing. Integrations that receive data from database queries must specify valid query options.");
        }

        DataConnection? dataConnectionDefinition = null;
                
        if (!string.IsNullOrWhiteSpace(sourceDefinition.DataConnectionName))
        {
            if (dataConnections == null || !dataConnections.Any())
            {
                throw new NoxIntegrationConfigurationException("Data Connections missing from solution definition.");
            }

            dataConnectionDefinition = dataConnections.FirstOrDefault(dc => dc.Name == sourceDefinition.DataConnectionName);
        }

        if (dataConnectionDefinition == null)
        {
            throw new NoxIntegrationConfigurationException(
                "Data Connection definition missing. Integrations that receive data from databases must specify a valid data connection definition.");
        }

        return dataConnectionDefinition;
    }

    public static INoxIntegration WithSendAdapter(this INoxIntegration instance, IntegrationTarget targetDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        switch (targetDefinition.TargetAdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                var dataConnection = ProcessDatabaseTargetDefinition(targetDefinition, dataConnections);
                instance.WithDatabaseSendAdapter(targetDefinition.TableOptions!, dataConnection);
                break;
        }
        return instance;
    }

    private static DataConnection ProcessDatabaseTargetDefinition(IntegrationTarget targetDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        if (targetDefinition.TableOptions == null)
        {
            throw new NoxIntegrationConfigurationException(
                "Database options missing. Integrations that send data to databases must specify valid database options.");
        }

        DataConnection? dataConnectionDefinition = null;
                
        if (!string.IsNullOrWhiteSpace(targetDefinition.DataConnectionName))
        {
            if (dataConnections == null || !dataConnections.Any())
            {
                throw new NoxIntegrationConfigurationException("Data Connections missing from solution definition.");
            }

            dataConnectionDefinition = dataConnections.FirstOrDefault(dc => dc.Name == targetDefinition.DataConnectionName);
        }

        if (dataConnectionDefinition == null)
        {
            throw new NoxIntegrationConfigurationException(
                "Data Connection definition missing. Integrations that send data to databases must specify a valid data connection definition.");
        }

        return dataConnectionDefinition;
    }

    public static INoxIntegration WithSchedule(this INoxIntegration instance, IntegrationSchedule schedule)
    {
        //todo add the integration to the hangfire job scheduler.
        return instance;
    }


}