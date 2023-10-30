using Nox.Application;

namespace Nox.Infrastructure.Messaging
{
    internal record class CloudEventMessage(IIntegrationEvent IntegrationEvent, string user, string MessagePrefix);
}
