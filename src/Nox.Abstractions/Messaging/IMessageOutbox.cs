using Nox.Application;

namespace Nox.Messaging;

public interface IMessageOutbox
{
    Task Send(IApplicationEvent message);
}