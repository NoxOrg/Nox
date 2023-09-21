using Nox.Application;

namespace Nox.Messaging;

public interface IMessageOutbox
{
    Task SendAsync(IIntegrationEvent message);
}