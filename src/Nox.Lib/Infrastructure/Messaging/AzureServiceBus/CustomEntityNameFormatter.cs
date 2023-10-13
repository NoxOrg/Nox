using MassTransit;
using Nox.Solution;
using System.Reflection;

namespace Nox.Infrastructure.Messaging.AzureServiceBus
{
    internal class CustomEntityNameFormatter : IEntityNameFormatter
    {
        public readonly NoxSolution _noxSolution;

        public CustomEntityNameFormatter(NoxSolution noxSolution)
        {
            _noxSolution = noxSolution;
        }

        public string FormatEntityName<T>()
        {
            var integrationEventAttribute = typeof(T).GetCustomAttribute<IntegrationEventTypeAttribute>();

            if (integrationEventAttribute == null ||
                string.IsNullOrWhiteSpace(integrationEventAttribute.Trait))
            {
                throw new Exception($"Integration event {typeof(T).Name} should have {nameof(IntegrationEventTypeAttribute)} with non-empty {nameof(integrationEventAttribute.Trait)} specified.");
            }

            return $"{_noxSolution.PlatformId}.{_noxSolution.Name}.{integrationEventAttribute.Trait}";
        }
    }
}