using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation;

internal class UniquePropertyValidator<TType> : AbstractValidator<TType>
{
    public UniquePropertyValidator(IEnumerable<TType>? items,Func<TType,string> propertyGetter, string objectType) : base()
    {
        if (items == null) return;

        RuleFor(x => propertyGetter(x))
            .Must((TType item, string propValue) => !items.Any(x => !x!.Equals(item) && propertyGetter(x).Equals(propValue, StringComparison.OrdinalIgnoreCase)))
            .WithMessage(er => string.Format(ValidationResources.DuplicateItemInCollection, objectType, propertyGetter(er)));
    }
}