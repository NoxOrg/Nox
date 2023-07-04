using FluentValidation;

namespace Nox.Solution.Validation;

public class IntegrationSourceHttpOptionsValidator: AbstractValidator<IntegrationSourceWebApiOptions?>
{
    internal IntegrationSourceHttpOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Route)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsRouteEmpty, integrationName));

        RuleFor(opt => opt!.ResponseFormat)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsFormatEmpty, integrationName));
        
        RuleFor(opt => opt!.HttpVerb)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsVerbEmpty, integrationName));


    }
}