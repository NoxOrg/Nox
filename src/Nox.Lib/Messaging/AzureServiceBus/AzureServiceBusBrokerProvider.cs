using MassTransit;
using Nox.Solution;

namespace Nox.Messaging.AzureServiceBus;

public class AzureServiceBusBrokerProvider: IMessageBrokerProvider
{
    public MessageBrokerProvider Provider => MessageBrokerProvider.AzureServiceBus;

    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, 
        IBusRegistrationConfigurator configuration)
    {
        configuration.UsingAzureServiceBus((context, cfg) =>
        {
            AzureServiceBusConfig config = messagingServerConfig.AzureServiceBusConfig!;

            var connectionString = $"Endpoint={config.Endpoint}/;SharedAccessKeyName={config.SharedAccessKeyName};SharedAccessKey={config.SharedAccessKey}";

            cfg.Host(connectionString);            

            cfg.ConfigureEndpoints(context);
            
            cfg.UseRawJsonSerializer();
                        
            // TODO Define rules for Topics names
            cfg.MessageTopology.SetEntityNameFormatter(new CustomEntityNameFormatter());
        });        
        return configuration;
    }
}