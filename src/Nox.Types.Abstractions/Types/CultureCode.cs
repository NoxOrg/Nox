using System;
using System.Collections.Immutable;
using System.Linq;
using Nox.Types.Abstractions.Extensions;

namespace Nox.Types.Abstractions
{
    public static class CultureCode
    {
        public const string RegularExpression = @"^[a-z]{2}(?:-[A-Z]{2})?(?:-[A-Z][a-z]{3})?$";
        
        public static readonly ImmutableSortedDictionary<string,Culture> DisplayNames = Enum.GetValues(typeof(Culture))
            .Cast<Culture>()
            .ToImmutableSortedDictionary(culture => culture.ToDisplayName(), culture => culture);
    }
}
