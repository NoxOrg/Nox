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

            // TODO Cloud Events Raw message?
            //cfg.UseRawJsonSerializer(RawSerializerOptions.AddTransportHeaders | RawSerializerOptions.CopyHeaders | RawSerializerOptions.AnyMessageType);

            // TODO Define rules for Topics names
            cfg.Message<CloudEventRecord<Application.IIntegrationEvent>>(x =>
            {
                x.SetEntityName("test-integration-event");
            });
        });        
        return configuration;
    }
}