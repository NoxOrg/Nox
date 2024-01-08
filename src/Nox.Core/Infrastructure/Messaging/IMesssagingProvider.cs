
using MassTransit;
using Nox.Solution;

namespace Nox.Infrastructure.Messaging
{
    internal interface IMessageBrokerProvider
    {
        MessageBrokerProvider Provider { get; }

        IBusRegistrationConfigurator ConfigureMassTransit(MessagingServer messagingServerConfig, IBusRegistrationConfigurator configuration);
    }
}
