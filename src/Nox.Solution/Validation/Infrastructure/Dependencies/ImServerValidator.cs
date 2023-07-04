using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class ImServerValidator: AbstractValidator<ImServer>
    {
        public ImServerValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("the infrastructure, dependencies, notifications, im server", servers));
            RuleFor(p => p.Provider)
                .NotNull()
                .WithMessage(p => string.Format(ValidationResources.ImServerProviderEmpty, p.Name, ImServerProvider.WhatsApp.ToNameList()));
        }
    }
}