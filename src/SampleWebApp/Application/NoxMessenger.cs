using Nox.Abstractions;

namespace SampleWebApp.Application
{
    public class NoxMessenger : INoxMessenger
    {
        public Task SendHeartbeat(IHeartbeatMessage message, CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public Task SendMessage(IEnumerable<IMessageTarget> messageTargets, object message)
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync<T>(IEnumerable<string> messageProviders, T message) where T : notnull
        {
            throw new NotImplementedException();
        }
    }
}
