using FluentValidation;

namespace Nox.Solution.Validation;

public class IntegrationTargetHttpOptionsValidator: AbstractValidator<IntegrationTargetWebApiOptions?>
{
    internal IntegrationTargetHttpOptionsValidator
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

        RuleFor(p => p!.RequestAttributes)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.IntegrationTargetHttpRequestAttributesEmpty, integrationName));

        RuleForEach(p => p!.RequestAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Request Attributes of the target for integration '{integrationName}' has an attribute that", "http target request attributes"));
        
        RuleForEach(p => p!.ResponseAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Response Attributes of the target for integration '{integrationName}' has an attribute that", "http target response attributes"));
    }

}