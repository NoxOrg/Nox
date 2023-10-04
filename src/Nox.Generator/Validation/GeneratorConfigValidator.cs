using FluentValidation;
using Nox.Generator.Common;

namespace Nox.Generator.Validation;

internal class GeneratorConfigValidator : AbstractValidator<GeneratorConfig>
{
    public GeneratorConfigValidator()
    {
        When(config => config.Ui, () =>
        {
            RuleFor(config => config.Domain)
                .Equal(false)
                .WithMessage("Domain should be false if UI is not None.");

            RuleFor(config => config.Application)
                .Equal(false)
                .WithMessage("Application should be false if UI is not None.");

            RuleFor(config => config.Infrastructure)
                .Equal(false)
                .WithMessage("Infrastructure should be false if UI is not None.");

            RuleFor(config => config.Presentation)
                .Equal(false)
                .WithMessage("Presentation should be false if UI is not None.");
        });
    }
}