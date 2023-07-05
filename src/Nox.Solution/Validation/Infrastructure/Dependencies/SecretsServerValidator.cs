using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class SecretsServerValidator: AbstractValidator<SecretsServer>
    {
        public SecretsServerValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("the infrastructure, dependencies, security, secrets, secrets server", servers));
            RuleFor(p => p.Provider)
                .NotNull()
                .WithMessage(p => string.Format(ValidationResources.SecretsServerProviderEmpty, p.Name, SecretsServerProvider.AzureKeyVault.ToNameList()));
        }
    }
}