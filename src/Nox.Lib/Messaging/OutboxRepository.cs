using CloudNative.CloudEvents;
using MassTransit;
using Microsoft.Extensions.Logging;
using Nox.Application;

namespace Nox.Messaging
{
    internal class OutboxRepository : IOutboxRepository
    {
        private readonly IPublishEndpoint _bus;
        private readonly ILogger<OutboxRepository> _logger;
        private readonly ICloudEventRecordFactory _cloudEventRecordFactory;

        public OutboxRepository(IPublishEndpoint bus, ILogger<OutboxRepository> logger) : this(bus, logger, new DefaultCloudEventRecordFactory())
        {
        }

        public OutboxRepository(IPublishEndpoint bus, ILogger<OutboxRepository> logger, ICloudEventRecordFactory cloudEventRecordFactory)
        {
            _bus = bus;
            _logger = logger;
            _cloudEventRecordFactory = cloudEventRecordFactory;
        }
        public async Task AddAsync<T>(T message) where T : IIntegrationEvent
        {
            _logger.LogInformation($"Publish message {typeof(T)} to {_bus.GetType()}");

            var cloudEventRecord = _cloudEventRecordFactory.CreateRecordForIntegrationEvent<T>(message);
            await _bus.Publish(cloudEventRecord,            
                sendContext =>
                {
                    // TODO define how clients will setup the parameters
                    var cloudEvent = new CloudEvent(CloudEventsSpecVersion.V1_0)
                    {
                        Id = sendContext.MessageId.ToString(),
                        Source = new Uri("https://api.nox.com/lib"),
                        Subject = "entities:service:entity:6802e075-978b-422f-9d3a-484f43709362",
                        Data = message,
                        Time = sendContext.SentTime,
                        Type = "api.nox.entity.v1.action",
                        DataSchema = new Uri("https://api.nox.com/lib/v1/action.json")
                    };

                    cloudEvent.Validate();

                    cloudEvent.MapToRecord(sendContext.Message);

                });
            
            _logger.LogInformation("Publish message {typeName} in PublishEndpoint ", typeof(T));
        }
    }
}