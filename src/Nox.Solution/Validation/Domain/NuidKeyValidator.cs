using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Types;

namespace Nox.Solution.Validation
{
    internal class NuidKeyValidator : SimpleTypeValidator
    {
        public NuidKeyValidator(Entity entity) : base(entity.Name, "nuid key")
        {
            RuleFor(x => x.NuidTypeOptions)
                .Must(opts =>
                {
                    var propertyNames = entity.Keys!
                        .Where(x => x.Type == NoxType.Nuid && x.NuidTypeOptions != null)
                        .SelectMany(x => x.NuidTypeOptions!.PropertyNames)
                        .Distinct()
                        .ToList();

                    return ValidateNuidReferences(entity, propertyNames);
                })
              .WithMessage(m => string.Format(ValidationResources.NuidKeyMissingProperty, m.Name, entity.Name));
        }

        private static bool ValidateNuidReferences(Entity entity, IEnumerable<string> propertyNames)
        {
            var entityProperties = entity
                .Attributes!
                .Select(x => x.Name.ToLower())
                .ToList();

            foreach (var propertyName in propertyNames)
            {
                var isDefined = entityProperties.Contains(propertyName.ToLower());
                if (!isDefined)
                {
                    return false;
                }
            }

            return true;
        }
    }
}