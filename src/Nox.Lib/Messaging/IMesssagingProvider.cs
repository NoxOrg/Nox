
using MassTransit;
using Nox.Solution;

namespace Nox.Messaging
{
    public interface IMessageBrokerProvider
    {
        MessageBrokerProvider Provider { get; }

        IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration);
    }
}
