using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

internal class SearchServerValidator: AbstractValidator<SearchServer>
{
    public SearchServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, persistence, search server", servers));
        RuleFor(p => p.Provider)
            .NotNull()
            .WithMessage(p => string.Format(ValidationResources.SearchServerProviderEmpty, p.Name, SearchServerProvider.ElasticSearch.ToNameList()));
    }
}