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
    public IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration, string environmentName)
    {
        configuration.UsingInMemory((context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);

            cfg.UseRawJsonSerializer();

            cfg.MessageTopology.SetEntityNameFormatter(new CustomEntityNameFormatter(_noxSolution.PlatformId, _noxSolution.Name, environmentName));
        });
        return configuration;
    }
}