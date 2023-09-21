using MassTransit;
using Microsoft.Extensions.Logging;
using Nox.Application;

namespace Nox.Messaging
{
    internal class MessageOutbox : IMessageOutbox
    {
        private readonly IBus _bus;
        private readonly ILogger<MessageOutbox> _logger;

        public MessageOutbox(IBus bus, ILogger<MessageOutbox> logger)
        {
            _bus = bus;
            _logger = logger;
        }
        public async Task SendAsync(IIntegrationEvent message)
        {
            _logger.LogInformation("Adding message to Outbox {typeName}", message.GetType());
            
            // TODO Add Message to OutBox

            // TODO Cloud Events Envelop / customize mass transit
                        
            await _bus.Publish(message);

            _logger.LogInformation("Publish message {typeName} in Bus ", message.GetType());
        }
    }
}
