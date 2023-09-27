using MassTransit;
using Nox.Solution;

namespace Nox.Messaging.InMemoryBus;

public class InMemoryBrokerProvider: IMessageBrokerProvider
{
    public MessageBrokerProvider Provider => MessageBrokerProvider.InMemory;

    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration)
    {        
        configuration.UsingInMemory((context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);
            
            cfg.UseRawJsonSerializer(RawSerializerOptions.AddTransportHeaders | RawSerializerOptions.CopyHeaders | RawSerializerOptions.AnyMessageType);            
        });        
        return configuration;
    }
}