using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

internal class CacheServerValidator: AbstractValidator<CacheServer>
{
    public CacheServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, persistence, cache server", servers));
        RuleFor(p => p.Provider)
            .NotNull()
            .WithMessage(p => string.Format(ValidationResources.CacheServerProviderEmpty, p.Name, CacheServerProvider.Memcached.ToNameList()));
    }
}