using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class IntegrationMatchValidator: AbstractValidator<IntegrationMatch>
    {
        public IntegrationMatchValidator(string integrationName)
        {
            RuleFor(p => p.Table)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationMatchTableEmpty, integrationName));
            
            RuleFor(p => p.LookupColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationMatchLookupColumnEmpty, integrationName));
            
            RuleFor(p => p.ReturnColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationMatchReturnColumnEmpty, integrationName));
        }
    }
}