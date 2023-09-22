using MassTransit;
using Nox.Solution;

namespace Nox.Messaging.AzureServiceBus;

public class AzureServiceBusBrokerProvider: IMessageBrokerProvider
{
    public MessageBrokerProvider Provider => MessageBrokerProvider.AzureServiceBus;

    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration)
    {
        configuration.UsingAzureServiceBus((context, cfg) =>
        {
            //cfg.Host(messagingServerConfig.ServerUri);
            cfg.Host($"Endpoint=sb://{messagingServerConfig.ServerUri}/;SharedAccessKeyName={messagingServerConfig.User};SharedAccessKey={messagingServerConfig.Password}");            

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