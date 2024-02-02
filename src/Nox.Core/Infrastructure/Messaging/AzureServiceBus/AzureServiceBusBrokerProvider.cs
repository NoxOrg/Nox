using MassTransit;
using Nox.Solution;

namespace Nox.Infrastructure.Messaging.AzureServiceBus;

public class AzureServiceBusBrokerProvider : IMessageBrokerProvider
{
    public MessageBrokerProvider Provider => MessageBrokerProvider.AzureServiceBus;
    private readonly NoxSolution _noxSolution;

    public AzureServiceBusBrokerProvider(NoxSolution noxSolution)
    {
        _noxSolution = noxSolution;
    }

    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, 
        IBusRegistrationConfigurator configuration)
    {
        configuration.UsingAzureServiceBus((context, cfg) =>
        {
            AzureServiceBusConfig config = messagingServerConfig.AzureServiceBusConfig!;
                
            if (string.IsNullOrWhiteSpace(config.SharedAccessKey) || string.IsNullOrWhiteSpace(config.SharedAccessKeyName))
            {
                cfg.Host(new Uri(config.Endpoint));
            }
            else
            {
                var connectionString = $"Endpoint={config.Endpoint};SharedAccessKeyName={config.SharedAccessKeyName};SharedAccessKey={config.SharedAccessKey}";
                cfg.Host(connectionString);
            }

            cfg.ConfigureEndpoints(context);
            cfg.UseRawJsonSerializer();
            cfg.MessageTopology.SetEntityNameFormatter(new CustomEntityNameFormatter(_noxSolution.PlatformId, _noxSolution.Name));
        });

        return configuration;
    }
}
