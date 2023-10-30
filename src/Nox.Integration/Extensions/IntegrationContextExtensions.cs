using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Adapters;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions.Receive;
using Nox.Integration.Extensions.Send;
using Nox.Solution;

namespace Nox.Integration.Extensions;

public static class IntegrationContextExtensions
{
    public static INoxIntegration WithReceiveAdapter(this INoxIntegration instance, IntegrationSource sourceDefinition, DataConnection? dataConnectionDefinition)
    {
        switch (sourceDefinition.SourceAdapterType)
        {
            case IntegrationAdapterType.Database:
                if (sourceDefinition.DatabaseOptions == null)
                {
                    throw new NoxIntegrationConfigurationException(
                        "Database options missing. Integrations that receive data from databases must specify valid database options.");
                }

                if (dataConnectionDefinition == null)
                {
                    throw new NoxIntegrationConfigurationException(
                        "Data Connection definition missing. Integrations that receive data from databases must specify a valid data connection definition.");
                }
                instance.WithDatabaseReceiveAdapter(sourceDefinition.DatabaseOptions, dataConnectionDefinition);
                break;
        }

        return instance;
    }

    public static INoxIntegration WidthSendAdapter(this INoxIntegration instance, IntegrationTarget targetDefinition, DataConnection? dataConnectionDefinition)
    {
        switch (targetDefinition.TargetAdapterType)
        {
            case IntegrationAdapterType.Database:
                if (targetDefinition.DatabaseOptions == null)
                {
                    throw new NoxIntegrationConfigurationException("Database options missing. Integrations that send data to databases must specify valid database options.");
                }
                if (dataConnectionDefinition == null)
                {
                    throw new NoxIntegrationConfigurationException(
                        "Data Connection definition missing. Integrations that send data to databases must specify a valid data connection definition.");
                }

                instance.WithDatabaseSendAdapter(targetDefinition.DatabaseOptions, dataConnectionDefinition);
                break;
        }
        return instance;
    }

    
}