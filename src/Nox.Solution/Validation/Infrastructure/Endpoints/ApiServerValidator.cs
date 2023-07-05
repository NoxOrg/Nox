using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

internal class ApiServerValidator: AbstractValidator<ApiServer>
{
    public ApiServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, endpoints, API server", servers));
        RuleFor(p => p.Provider)
            .NotNull()
            .WithMessage(p => string.Format(ValidationResources.ApiServerProviderEmpty, p.Name, ApiServerProvider.OData.ToNameList()));
    }
}