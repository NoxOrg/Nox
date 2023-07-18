using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class SecretsValidator: AbstractValidator<Secrets>
    {
        public SecretsValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.OrganizationSecretsServer!)
                .SetValidator(v => new SecretsServerValidator(servers, v.OrganizationSecretsServer!.Name));

            RuleFor(p => p.SolutionSecretsServer!)
                .SetValidator(v => new SecretsServerValidator(servers, v.SolutionSecretsServer!.Name));
        }
    }
}