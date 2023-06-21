namespace Nox.Core.Interfaces.Messaging;

public interface INoxMessenger
{
    Task SendMessage(IEnumerable<IMessageTarget> messageTargets, object message);

    Task SendMessageAsync<T>(IEnumerable<string> messageProviders, T message) where T : notnull;

    Task SendHeartbeat(IHeartbeatMessage message, CancellationToken stoppingToken);
}

public interface IMessageTarget
{
    string MessagingProvider { get; set; }
}

public interface IHeartbeatMessage
{
    string Value { get; set; }
}
