using System;
using System.Collections.Immutable;
using System.Linq;
using Nox.Yaml.Attributes;

namespace Nox.Types.Abstractions
{
    public static class CultureCode
    {
        public const string RegularExpression = @"^[a-z]{2}(?:-[A-Z]{2})?(?:-[A-Z][a-z]{3})?$";
        
        public static readonly ImmutableSortedDictionary<string,Culture> CultureCodeDisplayNames = Enum.GetValues(typeof(Culture))
            .Cast<Culture>()
            .ToImmutableSortedDictionary(x =>
                {
                    var field = x.GetType().GetField(x.ToString())!;
                    var attribute = field.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
                    return attribute?.DisplayName ?? x.ToString();
                }, 
                x => x);
    }
}
