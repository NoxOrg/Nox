using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class MessagingValidator: AbstractValidator<Messaging>
    {
        public MessagingValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.IntegrationEventServer!.ApplyDefaults())
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.IntegrationEventsServerDefaultsFalse));

            RuleFor(p => p.IntegrationEventServer!.AzureServiceBusConfig)
                .NotNull()
                .When(p => p.IntegrationEventServer!.Provider == MessageBrokerProvider.AzureServiceBus)                
                .WithMessage(e => string.Format(ValidationResources.IntegrationEventsServerAzureServiceBusConfigRequired));
        }
    }
}