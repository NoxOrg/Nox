using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class IntegrationScheduleValidator: AbstractValidator<IntegrationSchedule>
    {
        public IntegrationScheduleValidator(string sourceName, string integrationName)
        {
            RuleFor(p => p.Start)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.IntegrationScheduleStartEmpty, sourceName, integrationName));
        }
    }
}