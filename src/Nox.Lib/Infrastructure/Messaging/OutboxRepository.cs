using CloudNative.CloudEvents;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nox.Abstractions;
using Nox.Application;
using Nox.Exceptions;
using Nox.Solution;
using System.Reflection;

namespace Nox.Infrastructure.Messaging
{
    internal class OutboxRepository : IOutboxRepository
    {
        private readonly IPublishEndpoint _bus;
        private readonly ILogger<OutboxRepository> _logger;
        private readonly IUserProvider _userProvider;
        private readonly NoxSolution _noxSolution;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OutboxRepository(
            IPublishEndpoint bus,
            ILogger<OutboxRepository> logger,
            IUserProvider userProvider,
            IWebHostEnvironment webHostEnvironment,
            NoxSolution noxSolution)
        {
            _bus = bus;
            _logger = logger;
            _userProvider = userProvider;
            _noxSolution = noxSolution;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddAsync<T>(T integrationEvent) where T : IIntegrationEvent
        {
            _logger.LogInformation($"Publish message {typeof(T)} to {_bus.GetType()}");

            var prefix = _webHostEnvironment.EnvironmentName == Environments.Production ?
                string.Empty :
                $"{_webHostEnvironment.EnvironmentName.ToLower()}.";

            var cloudEventRecord = new NoxMessageRecord<T>(integrationEvent);
            await _bus.Publish(cloudEventRecord,
                sendContext =>
                {
                    var integrationEventAttribute = integrationEvent.GetType().GetCustomAttribute<IntegrationEventTypeAttribute>();
                    var trait = integrationEventAttribute?.Trait;
                    var eventName = integrationEventAttribute?.EventName;
                    if (string.IsNullOrWhiteSpace(trait))
                    {
                        // TODO: test for null event scenario
                        throw new EventNameIsEmptyException($"Provided {nameof(integrationEventAttribute.Trait)} in {nameof(IntegrationEventTypeAttribute)} for event {integrationEvent.GetType()} can't be null or empty.");
                    }

                    if (string.IsNullOrWhiteSpace(eventName))
                    {
                        // TODO: test for null event scenario
                        throw new EventTraitIsEmptyException($"Provided {nameof(integrationEventAttribute.EventName)} in {nameof(IntegrationEventTypeAttribute)} for event {integrationEvent.GetType()} can't be null or empty.");
                    }

                    var cloudEvent = new CloudEvent(CloudEventsSpecVersion.V1_0)
                    {
                        Id = sendContext.MessageId.ToString(),
                        Source = new Uri($"https://{prefix}{_noxSolution.PlatformId}.com/{_noxSolution.Name}"),
                        Data = integrationEvent,
                        Time = sendContext.SentTime,
                        Type = $"{_noxSolution.PlatformId}.{_noxSolution.Name}.{trait}.v{_noxSolution.Version}.{eventName}",
                        DataSchema = new Uri($"https://{prefix}{_noxSolution.PlatformId}.com/schemas/{_noxSolution.Name}/{trait}/v{_noxSolution.Version}/{eventName}.json"),

                        // OPTIONAL
                        //Subject = "entities:service:entity:6802e075-978b-422f-9d3a-484f43709362",
                    };

                    cloudEvent.Validate();

                    cloudEvent.MapToRecord(sendContext.Message, _userProvider.GetUser().ToString());
                });

            _logger.LogInformation("Publish message {typeName} in PublishEndpoint ", typeof(T));
        }
    }
}