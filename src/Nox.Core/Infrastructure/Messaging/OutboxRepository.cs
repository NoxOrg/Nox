using CloudNative.CloudEvents;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nox.Abstractions;
using Nox.Application;
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
        private readonly string _messagePrefix;

        public OutboxRepository(
            IPublishEndpoint bus,
            ILogger<OutboxRepository> logger,
            IUserProvider userProvider,
            IHostEnvironment hostEnvironment,
            NoxSolution noxSolution)
        {
            _bus = bus;
            _logger = logger;
            _userProvider = userProvider;
            _noxSolution = noxSolution;
            _messagePrefix = hostEnvironment.EnvironmentName == Environments.Production ? string.Empty : $"{hostEnvironment.EnvironmentName.ToLower()}.";
        }

        public async Task AddAsync<T>(T integrationEvent) where T : IIntegrationEvent
        {
            var integrationEventAttribute = integrationEvent.GetType().GetCustomAttribute<IntegrationEventTypeAttribute>();
            var domainContext = integrationEventAttribute?.DomainContext;
            var eventName = integrationEventAttribute?.EventName;
            if (string.IsNullOrWhiteSpace(domainContext))
            {
                throw new IntegrationEventDomainContextNullException($"Provided {nameof(integrationEventAttribute.DomainContext)} in {nameof(IntegrationEventTypeAttribute)} for event {integrationEvent.GetType()} can't be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(eventName))
            {
                throw new EventNameIsNotFoundException($"Provided {nameof(integrationEventAttribute.EventName)} in {nameof(IntegrationEventTypeAttribute)} for event {integrationEvent.GetType()} can't be null or empty.");
            }

            var message = new CloudEventMessage<T>(integrationEvent) { UserId = _userProvider.GetUser().ToString() };
            var type = $"{_noxSolution.PlatformId}.{_noxSolution.Name}.{domainContext}.v{_noxSolution.Version}.{eventName}";
            var source = new Uri($"https://{_messagePrefix}{_noxSolution.PlatformId}.com/{_noxSolution.Name}");
            var dataSchema = new System.Uri($"https://{_messagePrefix}{_noxSolution.PlatformId}.com/schemas/{_noxSolution.Name}/{domainContext}/v{_noxSolution.Version}/{eventName}.json");
            
            _logger.LogInformation("Publishing integration event '{Type}'. Name: '{EventName}' Source: '{Source}' Type: '{EventType}' DataSchema: '{DataSchema}'",
                typeof(T), eventName, source, type, dataSchema);

            PublishContext<CloudEventMessage<T>>? publishContext = null;

            await _bus.Publish(message, sendContext =>
            {
                var cloudEvent = new CloudEvent();
                cloudEvent.Data = integrationEvent;
                cloudEvent.Id = sendContext.MessageId.ToString();
                cloudEvent.Source = source;
                cloudEvent.Time = sendContext.SentTime;
                cloudEvent.Type = type;
                cloudEvent.DataSchema = dataSchema;
                cloudEvent.DataContentType = "application/json";
                cloudEvent.SetAttributeFromString("xuserid", _userProvider.GetUser().ToString());
                cloudEvent.Validate();

                message.SetCloudEvent(cloudEvent);
                publishContext = sendContext;
            });

            _logger.LogInformation("Published integration event '{Type}' to '{PublishDestination}'. Name: '{EventName}' Source: '{EventSource}' Type: '{EventType}' DataSchema: '{DataSchema}' MessageId: '{MessageId}'",
                typeof(T), publishContext?.DestinationAddress?.AbsolutePath, eventName, source, type, dataSchema, message.Id);
        }
    }
}