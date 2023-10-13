using FluentValidation;
using Nox.Types;
using System.Linq;

namespace Nox.Solution.Validation
{
    // TODO: should be removed once this feature is implemented in future versions.
    internal class EntityLocalizationValidator : AbstractValidator<Entity>
    {
        public EntityLocalizationValidator(string errorMessage)
        {
            RuleFor(e => e.Attributes.Where(IsLocalizedTextField))
                .Empty()
                .WithMessage(e => string.Format(errorMessage, e.Name));
        }

        private bool IsLocalizedTextField(NoxSimpleTypeDefinition noxSimpleTypeDefinition)
        {
            return
                noxSimpleTypeDefinition.Type == NoxType.Text &&
                noxSimpleTypeDefinition.TextTypeOptions != null &&
                noxSimpleTypeDefinition.TextTypeOptions.IsLocalized;
        }
    }
}
