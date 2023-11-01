using Nox.Application;

namespace Nox.Infrastructure.Messaging
{
    internal record class CloudEventMessage<T>(T IntegrationEvent, string User, string MessagePrefix) where T :IIntegrationEvent;
}
