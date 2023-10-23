using MassTransit;
using Nox.Application;
using System.Reflection;

namespace Nox.Infrastructure.Messaging.AzureServiceBus
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
            var integrationEventAttribute = typeof(T).GenericTypeArguments[0].GetCustomAttribute<IntegrationEventTypeAttribute>();

            if (typeof(T).GetGenericTypeDefinition() != typeof(NoxMessageRecord<>))
            {
                throw new UnknownMessageTypeException($"Unknown message type '{typeof(T)}' received.");
            }

            if (integrationEventAttribute == null ||
                string.IsNullOrWhiteSpace(integrationEventAttribute.Trait))
            {
                throw new EventTraitIsNotFoundException($"Integration event {typeof(T).Name} should have {nameof(IntegrationEventTypeAttribute)} with non-empty {nameof(integrationEventAttribute.Trait)} specified.");
            }

            return $"{_platformId}.{_name}.{integrationEventAttribute.Trait}";
        }
    }
}