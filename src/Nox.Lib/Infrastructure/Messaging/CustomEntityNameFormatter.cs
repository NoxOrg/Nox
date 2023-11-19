using MassTransit;
using Nox.Application;
using System.Reflection;

namespace Nox.Infrastructure.Messaging
{
    internal class CustomEntityNameFormatter : IEntityNameFormatter
    {
        public readonly string _platformId;
        public readonly string _name;

        public CustomEntityNameFormatter(string platformId, string name)
        {
            _platformId = platformId;
            _name = name;
        }
        
        public string FormatEntityName<T>()
        {
            var messageType = typeof(T);

            if (!messageType.IsGenericType || messageType.GetGenericTypeDefinition() != typeof(CloudEventMessage<>))
            {
                throw new UnknownMessageTypeException($"Unknown message type '{typeof(T)}' received.");
            }
            var integrationEventAttribute = messageType.GenericTypeArguments[0].GetCustomAttribute<IntegrationEventTypeAttribute>();
          
            if (integrationEventAttribute == null ||
                string.IsNullOrWhiteSpace(integrationEventAttribute.DomainContext))
            {
                throw new IntegrationEventDomainContextNullException($"Integration event {messageType.Name} should have {nameof(IntegrationEventTypeAttribute)} with non-empty {nameof(integrationEventAttribute.DomainContext)} specified.");
            }

            return $"{_platformId}.{_name}.{integrationEventAttribute.DomainContext}";
        }
    }
}