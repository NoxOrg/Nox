using FluentValidation;

namespace Nox.Solution.Validation;

public class IntegrationSourceHttpOptionsValidator: AbstractValidator<IntegrationSourceWebApiOptions?>
{
    internal IntegrationSourceHttpOptionsValidator
        (string integrationName)
    {
        RuleFor(opt => opt!.Route)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsRouteEmpty, integrationName));

        RuleFor(opt => opt!.ExchangeFormat)
            .IsInEnum()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsFormatEmpty, integrationName));
        
        RuleFor(opt => opt!.HttpVerb)
            .IsInEnum()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsVerbEmpty, integrationName));

        RuleFor(p => p!.ResponseAttributes)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.IntegrationSourceHttpResponseAttributesEmpty, integrationName));

        RuleForEach(p => p!.ResponseAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Response Attributes of the source for integration '{integrationName}' has an attribute that", "http source response attributes"));
        
    }

}