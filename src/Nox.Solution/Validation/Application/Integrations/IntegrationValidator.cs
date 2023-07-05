using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class IntegrationValidator : AbstractValidator<Integration>
    {
        private readonly IEnumerable<Integration>? _integrations;

        public IntegrationValidator(IEnumerable<Integration>? integrations, IEnumerable<DataConnection>? dataConnections)
        {
            if (integrations == null) return;
            _integrations = integrations;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationNameEmpty));

            RuleFor(p => p.Name).Must(HaveUniqueName)
                .WithMessage(m => string.Format(ValidationResources.IntegrationNameDuplicate, m.Name));

            RuleFor(p => p.Source)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.IntegrationSourceMissing, m.Name))
                .SetValidator(v => new IntegrationSourceValidator(v.Name, dataConnections, v.Source!.DataConnectionName));

            RuleFor(p => p.Transform!)
                .SetValidator(v => new IntegrationTransformValidator(v.Name));

            RuleFor(p => p.Target)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.IntegrationTargetMissing, m.Name));

            RuleFor(p => p.Target!)
                .SetValidator(v => new IntegrationTargetValidator(v.Name, dataConnections));
        }

        private bool HaveUniqueName(Integration toEvaluate, string name)
        {
            return _integrations!.All(dto => dto.Equals(toEvaluate) || dto.Name != name);
        }
    }
}