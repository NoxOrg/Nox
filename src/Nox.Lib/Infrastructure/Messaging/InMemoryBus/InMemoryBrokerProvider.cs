using MassTransit;
using Nox.Solution;

namespace Nox.Infrastructure.Messaging.InMemoryBus;

public class InMemoryBrokerProvider : IMessageBrokerProvider
{
    public MessageBrokerProvider Provider => MessageBrokerProvider.InMemory;

    private readonly NoxSolution _noxSolution;

    public InMemoryBrokerProvider(NoxSolution noxSolution)
    {
        _noxSolution = noxSolution;
    }
    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration)
    {
        configuration.UsingInMemory((context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);

            cfg.UseRawJsonSerializer();

            cfg.AddSerializer(new CloudEventSerializorFactory(_noxSolution.PlatformId, _noxSolution.Name, _noxSolution.Version));

            cfg.MessageTopology.SetEntityNameFormatter(new CustomEntityNameFormatter(_noxSolution.PlatformId, _noxSolution.Name));
        });
        return configuration;
    }
}