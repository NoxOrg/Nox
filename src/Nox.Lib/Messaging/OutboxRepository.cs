using CloudNative.CloudEvents;
using CloudNative.CloudEvents.SystemTextJson;
using MassTransit;
using Microsoft.Extensions.Logging;
using Nox.Application;
using System.Text.Json;

namespace Nox.Messaging
{
    internal class OutboxRepository : IOutboxRepository
    {
        private readonly IPublishEndpoint _bus;
        private readonly ILogger<OutboxRepository> _logger;

        public OutboxRepository(IPublishEndpoint bus, ILogger<OutboxRepository> logger)
        {
            _bus = bus;
            _logger = logger;
        }
        public async Task AddAsync<T>(T message) where T : IIntegrationEvent
        {
            _logger.LogInformation("Adding message to Outbox {typeName}", typeof(T));

            var cloudEventRecord = new CloudEventRecord<IIntegrationEvent>(message);

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

                    cloudEvent.ToRecord(sendContext.Message);
                    
                    // Customize Mass Transit Envelope
                    sendContext.SourceAddress = cloudEvent.Source;
                });
            
            _logger.LogInformation("Publish message {typeName} in PublishEndpoint ", typeof(T));
        }

        public static CloudEventFormatter New(JsonSerializerOptions options) =>
            new JsonEventFormatter(options, new JsonDocumentOptions());

    }
}