using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class EndpointsValidator: AbstractValidator<Endpoints>
    {
        public EndpointsValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.ApiServer!)
                .SetValidator(v => new ApiServerValidator(servers));
            
            RuleFor(p => p.BffServer!)
                .SetValidator(v => new BffServerValidator(servers));
        }
    }
}