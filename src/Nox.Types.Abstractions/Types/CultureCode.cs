using System.Collections.Immutable;
using System.Linq;
using Nox.Yaml.Attributes;
using Nox.Yaml.Enums.CultureCode;

namespace Nox.Types.Abstractions
{
    public class CultureCode
    {
        public const string RegularExpression = @"^[a-z]{2}(?:-[A-Z]{2})?(?:-[A-Z][a-z]{3})?$";
    }
}
