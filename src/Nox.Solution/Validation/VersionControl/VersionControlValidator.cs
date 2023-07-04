using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class VersionControlValidator: AbstractValidator<VersionControl>
    {
        public VersionControlValidator()
        {
            RuleFor(vc => vc.Provider)
                .NotNull()
                .WithMessage(vc => string.Format(ValidationResources.VersionControlProviderEmpty));

            RuleFor(vc => vc.Host)
                .NotEmpty()
                .WithMessage(vc => string.Format(ValidationResources.VersionControlHostEmpty));

            RuleFor(vc => vc.Folders!)
                .SetValidator(vc => new VersionControlFoldersValidator());
        }
    }
}