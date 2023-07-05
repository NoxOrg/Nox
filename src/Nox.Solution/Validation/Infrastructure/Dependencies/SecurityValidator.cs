using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class SecurityValidator: AbstractValidator<Security>
    {
        public SecurityValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.Secrets!)
                .SetValidator(new SecretsValidator(servers));
        }
    }
}