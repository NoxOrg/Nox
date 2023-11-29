using CloudNative.CloudEvents;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
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
            IWebHostEnvironment webHostEnvironment,
            NoxSolution noxSolution)
        {
            _bus = bus;
            _logger = logger;
            _userProvider = userProvider;
            _noxSolution = noxSolution;
            _messagePrefix = webHostEnvironment.EnvironmentName == Environments.Production ? string.Empty : $"{webHostEnvironment.EnvironmentName.ToLower()}.";
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
            var source = new Uri($"https://{_messagePrefix}{_noxSolution.PlatformId}.com/{_noxSolution.Name}");

            _logger.LogInformation($"Publishing integration event '{typeof(T)}'. Name: '{eventName}' Source: '{source}'");
            PublishContext<CloudEventMessage<T>>? publishContext = null;

            await _bus.Publish(message, sendContext =>
            {
                var cloudEvent = new CloudEvent();
                cloudEvent.Data = integrationEvent;
                cloudEvent.Id = sendContext.MessageId.ToString();
                cloudEvent.Source = source;
                cloudEvent.Time = sendContext.SentTime;
                cloudEvent.Type = $"{_noxSolution.PlatformId}.{_noxSolution.Name}.{domainContext}.v{_noxSolution.Version}.{eventName}";
                cloudEvent.DataSchema = new System.Uri($"https://{_messagePrefix}{_noxSolution.PlatformId}.com/schemas/{_noxSolution.Name}/{domainContext}/v{_noxSolution.Version}/{eventName}.json");
                cloudEvent.DataContentType = "application/json";
                cloudEvent.SetAttributeFromString("xuserid", _userProvider.GetUser().ToString());
                cloudEvent.Validate();

                message.SetCloudEvent(cloudEvent);
                publishContext = sendContext;
            });

            _logger.LogInformation($"Published integration event '{typeof(T)}' to '{publishContext?.DestinationAddress?.AbsolutePath}'. Name: '{eventName}' Source: '{source}' MessageId: '{message.Id}'");
        }
    }
}