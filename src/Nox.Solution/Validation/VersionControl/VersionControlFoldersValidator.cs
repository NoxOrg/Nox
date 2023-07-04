using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class VersionControlFoldersValidator: AbstractValidator<VersionControlFolders>
    {
        public VersionControlFoldersValidator()
        {
            RuleFor(f => f.SourceCode)
                .NotEmpty()
                .WithMessage(f => string.Format(ValidationResources.VersionControlSourceFolderEmpty));
            
            RuleFor(f => f.Containers)
                .NotEmpty()
                .WithMessage(f => string.Format(ValidationResources.VersionControlContainersFolderEmpty));
        }
    }
}