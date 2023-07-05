using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class MessagingValidator: AbstractValidator<Messaging>
    {
        public MessagingValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.IntegrationEventServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, messaging, integration event server", servers));
            
            RuleFor(p => p.IntegrationEventServer!.ApplyDefaults())
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.IntegrationEventsServerDefaultsFalse));
        }
    }
}