using CloudNative.CloudEvents;
using MassTransit;
using Microsoft.Extensions.Logging;
using Nox.Abstractions;
using Nox.Application;

namespace Nox.Messaging
{
    internal class OutboxRepository : IOutboxRepository
    {
        private readonly IPublishEndpoint _bus;
        private readonly ILogger<OutboxRepository> _logger;
        private readonly IUserProvider _userProvider;

        public OutboxRepository(IPublishEndpoint bus, ILogger<OutboxRepository> logger, IUserProvider userProvider)
        {
            _bus = bus;
            _logger = logger;
            _userProvider = userProvider;
        }
        public async Task AddAsync<T>(T integrationEvent) where T : IIntegrationEvent
        {
            _logger.LogInformation($"Publish message {typeof(T)} to {_bus.GetType()}");

            var cloudEventRecord =  new CloudEventRecord<T>(integrationEvent);
            await _bus.Publish(cloudEventRecord,            
                sendContext =>
                {
                    // TODO define how clients will setup the parameters
                    var cloudEvent = new CloudEvent(CloudEventsSpecVersion.V1_0)
                    {
                        Id = sendContext.MessageId.ToString(),
                        Source = new Uri("https://api.nox.com/lib"),
                        Subject = "entities:service:entity:6802e075-978b-422f-9d3a-484f43709362",
                        Data = integrationEvent,
                        Time = sendContext.SentTime,
                        Type = "api.nox.entity.v1.action",
                        //Optional
                        //DataSchema = new Uri("https://api.nox.com/lib/v1/action.json"),
                    };

                    cloudEvent.Validate();

                    cloudEvent.MapToRecord(sendContext.Message, _userProvider.GetUser().ToString());
                });
            
            _logger.LogInformation("Publish message {typeName} in PublishEndpoint ", typeof(T));
        }
    }
}