using MassTransit;
using Nox.Solution;

namespace Nox.Messaging.AzureServiceBus;

public class InMemoryBrokerProvider: IMessageBrokerProvider
{
    public MessageBrokerProvider Provider => MessageBrokerProvider.InMemory;

    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration)
    {
        // TODO Configure according to NoSolution
        configuration.UsingInMemory((context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);

            // TODO Cloud Events Raw message?
            //cfg.UseRawJsonSerializer(RawSerializerOptions.AddTransportHeaders | RawSerializerOptions.CopyHeaders | RawSerializerOptions.AnyMessageType);            
        });        
        return configuration;
    }
}