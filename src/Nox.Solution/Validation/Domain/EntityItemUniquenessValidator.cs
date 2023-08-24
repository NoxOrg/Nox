using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class EntityItemUniquenessValidator<TElement> : AbstractValidator<TElement>
    {
        public EntityItemUniquenessValidator(
            Entity entity,
            Expression<Func<TElement,string>> valueGetter,
            string excludeItem) : base()
        {
            if (entity == null) return;

            var entityNames = GetPropertyValues(entity.Keys, x => x.Name, nameof(entity.Keys))
                .Concat(GetPropertyValues(entity.Attributes, x => x.Name, nameof(entity.Attributes))
                .Concat(GetPropertyValues(entity.Relationships, x => x.Name, nameof(entity.Relationships)))
                .Concat(GetPropertyValues(entity.OwnedRelationships, x => x.Name, nameof(entity.OwnedRelationships))));

            var itemValueGetter = valueGetter.Compile();
            RuleFor(valueGetter)
                .Must(x => !entityNames.Where(x => x.PropertySource != excludeItem)
                    .Any(t => t.PropertyValue.Equals(x, StringComparison.OrdinalIgnoreCase)))
                .WithMessage(er => string.Format(ValidationResources.DuplicateItemInCollection, excludeItem, itemValueGetter(er)));

        }

        private static IEnumerable<(string PropertySource, string PropertyValue)> GetPropertyValues<TType>(
            IEnumerable<TType>? items,
            Func<TType, string> valueGetter,
            string propertySource)
        {
            if (items == null) return Enumerable.Empty<(string, string)>();

            return items.Select(x => (propertySource, valueGetter(x))).ToArray();
        }

    }

}