using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class DomainCommandValidator: AbstractValidator<DomainCommand>
    {
        private readonly IEnumerable<DomainCommand>? _commands;

        public DomainCommandValidator(IEnumerable<DomainCommand>? commands, string entityName)
        {
            if (_commands == null) return;
            _commands = commands;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DomainCommandNameEmpty, entityName));
            
            RuleFor(c => c.Name).Must(HaveUniqueName)
                .WithMessage(m => string.Format(ValidationResources.DomainCommandNameDuplicate, m.Name, entityName));

            RuleFor(c => c.Type)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DomainCommandTypeEmpty, m.Name, entityName));

            RuleFor(c => c.ObjectTypeOptions!)
                .SetValidator(v => new ObjectTypeOptionsValidator($"domain command '{v.Name}' in entity '{entityName}'", "Domain commands"));
        }
        
        private bool HaveUniqueName(DomainCommand toEvaluate, string name)
        {
            return _commands!.All(q => q.Equals(toEvaluate) || q.Name != name);
        }
    }
}